using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaeAPIDotNetCore.Models;

namespace WaeAPIDotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            Casa casa = new Casa
            {
                Janela = "Aluminio",
                Porta = "Madeira",
                Luz = "Solar"
            };

            return Json(casa);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Casa casa = new Casa
            {
                Janela = $"Janela com ID: {id}",
                Porta = $"Madeira com ID: {id}",
                Luz = $"Solar com ID: {id}"
            };
            return Json(casa);
        }

        
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Call call)
        {
            call.CallId = $"{call.CallId} - RECEBIDO";

            return Json(call);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IEnumerable<string> Put(int id, [FromBody]string value)
        //public void Put(int id, [FromBody]string value)
        {
            return new string[] {$"id: {id}", $"value: {value}" };
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
