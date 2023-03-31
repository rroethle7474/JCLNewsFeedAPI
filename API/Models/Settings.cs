using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class APIs
    {
        public YouTube YouTube{ get; set; } 
        public Yahoo Yahoo { get; set; }   
        public Google Google {get; set;} 
    }

    public class YouTube
    {
        public string ApiKey { get; set; }
        public string ApplicationName { get; set; }
    }

    public class Yahoo 
    {
        public string Url {get; set;}
        public string ApiKey { get; set; }
        public string ApplicationHost { get; set; }
    }

    public class Google
    {
        public string ApiKey {get; set;}
        public string SearchEngineId {get; set;}
    }

}