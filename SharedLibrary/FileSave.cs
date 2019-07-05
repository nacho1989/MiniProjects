using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class FileSave : ICommand
    {
        public Guid Id { get; set; }
        public string Message = "A file just got saved";
    }

    public class FileSaved : IEvent
    {
        public Guid Id { get; set; }
        public string Message = "We know file has been saved";
    }
}
