using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaeAPIDotNetCore.Models
{
    public class Call
    {
        public String UCID { get; set; }
        public String CallId { get; set; }
        public List<CallTracked> CallsTracked { get; set; }
    }
}
