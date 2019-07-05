using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedLibrary
{
    public class WriteToFile : ICommand
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Message { get; set; }
    }
}