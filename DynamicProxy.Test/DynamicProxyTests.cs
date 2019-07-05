using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DynamicProxy.Test
{
    [TestClass]
    public class DynamicProxyTests
    {
        Proxy dynamicProxy = new Proxy();

        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://www.dneonline.com/calculator.asmx?WSDL";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("intA", 2);
            parameters.Add("intB", 5);

            var response = dynamicProxy.InvokeService(url, "Subtract", "Calculator", parameters);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string url = "http://secure.smartbearsoftware.com/samples/testcomplete10/webservices/Service.asmx?WSDL";
            string sampleMessage = @"<SampleTestClass><X>20</X><Y>20</Y><Name>John</Name><IntArray><int>5</int></IntArray></SampleTestClass>";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("obj", sampleMessage);
            
            var response = dynamicProxy.InvokeService(url, "SetSampleObject", "SampleWebService", parameters);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string url = "http://www.webservicex.com/globalweather.asmx?WSDL";
            string CountryName = "Brazil";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(nameof(CountryName), CountryName);

            var response = dynamicProxy.InvokeService(url, "GetCitiesByCountry", "GlobalWeather", parameters);

            Assert.IsNotNull(response);
        }
    }
}
