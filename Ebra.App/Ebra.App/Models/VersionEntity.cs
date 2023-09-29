using System;

namespace Ebra.App.Models
{
    public class VersionEntity : EntityBase 
    { 
        public string version { get; set; }
        public Type type { get; set; }
    }
}
