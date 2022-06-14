using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaeAPIDotNetCore.Models
{
    public class CallTracked
    {
        public string UcId { get; set; }
        public string CallId { get; set; }
        public DateTime dateCall { get; set; }
        public String TypeCall { get; set; }
    }
}
