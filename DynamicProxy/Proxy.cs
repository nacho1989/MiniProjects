using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Serialization;

namespace DynamicProxy
{
    public class Proxy
    {
        private ServiceInfo _serviceInfo;

        private Dictionary<string, object> paramInfo;

        public object InvokeService(String serviceUrl, string operationName, string serviceName, Dictionary<string, object> args)
        {
            paramInfo = args;
            _serviceInfo = new ServiceInfo();

            Assembly serviceAssembly = BuildAssemblyFromUrl(serviceUrl);
            GetServiceMethods(serviceName, serviceAssembly);

            return InvokeService(serviceAssembly, serviceName, operationName, args);
        }
        

        private object InvokeServiceMethod(object proxy, string methodName)
        {
            MethodInfo mi = proxy.GetType().GetMethod(methodName);

            object[] args = BuildParameters(mi);

            return  mi.Invoke(proxy, args);
        }

        private object InvokeService(Assembly proxyAssembly, String serviceName, string MethodName, params object[] args)
        {
            object wsvcClass = proxyAssembly.CreateInstance(serviceName);
            if(wsvcClass == null)
                return null;
            return InvokeServiceMethod(wsvcClass, MethodName);
        }


        private void GetServiceMethods(string serviceName, Assembly proxyAssembly)
        {
            object proxyClass = proxyAssembly.CreateInstance(serviceName);

            if (proxyClass == null)
            {
                throw new Exception($"Invalid Service: Could not find Class with name {serviceName}");
            }
            
            MethodInfo[] methods = proxyClass.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);

            _serviceInfo.ServiceName = serviceName;

            foreach (var info in methods)
            { 
                if (Attribute.GetCustomAttribute(info, typeof(System.Web.Services.Protocols.SoapDocumentMethodAttribute)) != null)
                {
                    _serviceInfo.Operations.Add(info);
                }
            }
        }

        private object[] BuildParameters(MethodInfo method)
        {
            Dictionary<object, Type> unmatchedTypes = new Dictionary<object, Type>();

            if (!_serviceInfo.Operations.Contains(method)){ }
                
            
            int paramCount = paramInfo.Count;

            object[] args = new object[paramCount];

            if (paramCount != method.GetParameters().Length) { }

            int counter = 0;

            foreach(KeyValuePair<string, object> kvp in paramInfo)
            {
                string paramName = kvp.Key;
                object param = kvp.Value;

                if (paramName == method.GetParameters()[counter].Name
                    && param.GetType() != method.GetParameters()[counter].ParameterType)
                {
                    unmatchedTypes.Add(param, method.GetParameters()[counter].ParameterType);
                }
                else
                {
                    args[counter] = param;
                    counter++;
                }
            }

            if(unmatchedTypes.Count > 0)
            {
                foreach(KeyValuePair<object, Type> kvp in unmatchedTypes)
                {
                    object key = kvp.Key;
                    Type value = kvp.Value;

                    MethodInfo deserializer = this.GetType().GetMethod("DeSerialize", BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo genericDeserializer = deserializer.MakeGenericMethod(value);

                    var obj = genericDeserializer.Invoke(this, new object[] { key as string });
                    args[counter] = obj;

                    counter++;
                }
            }

            unmatchedTypes.Clear();
            
            return args;
        }

        private Assembly BuildAssemblyFromUrl(string serviceUrl)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            ServiceDescriptionImporter importer = BuildServiceDescriptionImporter(client, serviceUrl);
            return CompileProxyCode(importer);
        }

        private ServiceDescriptionImporter BuildServiceDescriptionImporter(System.Net.WebClient client, string serviceUrl)
        {
            ServiceDescription description = ServiceDescription.Read(client.OpenRead(serviceUrl));

            ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
            importer.ProtocolName = "Soap12";
            importer.AddServiceDescription(description, null, null);

            importer.Style = ServiceDescriptionImportStyle.Client;

            importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
            return importer;
        }

        private Assembly CompileProxyCode(ServiceDescriptionImporter descriptionImporter)
        {

            CodeNamespace nmspace = new CodeNamespace();
            CodeCompileUnit unit = new CodeCompileUnit();

            unit.Namespaces.Add(nmspace);

            ServiceDescriptionImportWarnings warning = descriptionImporter.Import(nmspace, unit);

            if (warning == 0)
            {
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

                string[] assemblyReferences = new string[5]{
                    "System.dll",
                    "System.Web.Services.dll",
                    "System.Web.dll",
                    "System.Xml.dll",
                    "System.Data.dll"
                };

                CompilerParameters parms = new CompilerParameters(assemblyReferences);

                CompilerResults results = provider.CompileAssemblyFromDom(parms, unit);

                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError oops in results.Errors)
                    {
                        //TODO : change this to log statement
                        System.Diagnostics.Debug.WriteLine("========Compiler error============");
                        System.Diagnostics.Debug.WriteLine(oops.ErrorText);
                    }
                    throw new System.Exception("Compile Error Occured calling webservice. Check Debug ouput window.");
                }

                return results.CompiledAssembly;
            }
            else
            {
                throw new Exception("Invalid WSDL");
            }
        }


        private T DeSerialize<T>(string xml)
        {
            XmlTypeMapping myTypeMapping =
            new SoapReflectionImporter().ImportTypeMapping(typeof(T));

            XmlSerializer serializer = new XmlSerializer(myTypeMapping);
            T serialized;

            using (var stringreader = new StringReader(xml))
            {
                serialized = (T)serializer.Deserialize(stringreader);
            }
            return serialized;
        }

        private String Serialize<T>(T request)
        {
            XmlTypeMapping myTypeMapping =
           new SoapReflectionImporter().ImportTypeMapping(typeof(T));

            XmlSerializer serializer = new XmlSerializer((myTypeMapping));
            string xml;
            var encoding = new UTF8Encoding();

            var stream = new MemoryStream();
            using (var writer = new XmlTextWriter(stream, encoding))
            {
                serializer.Serialize(writer, request);
                stream = (MemoryStream)writer.BaseStream;

                xml = encoding.GetString(stream.ToArray());
            }

            return xml;
        }

    }
}
