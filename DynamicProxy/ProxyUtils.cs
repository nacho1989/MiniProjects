using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    public class ServiceInfo
    {
        private string _serviceName;
        private string _serviceType;
        private List<MethodInfo> _operations = new List<MethodInfo>();

        public string ServiceName { get => _serviceName; set => _serviceName = value; }
        public List<MethodInfo> Operations { get => _operations; set => _operations = value; }
    }
}
