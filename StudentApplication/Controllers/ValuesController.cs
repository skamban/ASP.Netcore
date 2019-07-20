using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        //GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[HttpGet("{id?}")]
        //[HttpGet("{id=489}")]
        //[HttpGet("{id:int}")]
        //[HttpGet("{id}")]
        //public string Get(int id, [FromQuery]string text)
        //{
        //    return $"value {id} theText {text}";
        //}

            //Action results
        [HttpGet("{id}")]
        //[Produces("application/json")]
        [Produces("application/sruthi+json")] //custom json
        public IActionResult Get(int id, string text)
        {
            return Ok(( new ValueText { id = id, textValue = text } )) ;
        }

        //Route templates ex
        // POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]ValueText value)
        //{
        //    //validation
        //    if (!ModelState.IsValid)
        //    {
        //        throw new InvalidOperationException("Text Length invalid");
        //    }
        //}

        //Action result ex
        [HttpPost]
        public IActionResult Post([FromBody]ValueText value)
        {
            //validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                return CreatedAtAction("Get", new { id = value.id } ,value);
            }
        }

        // PUT api/<controller>/5

     //   Route templates
        [HttpPut("{id}")]
            public void Put(int id, [FromBody]string value) 
        {
        }



        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ValueText
    {
        public int id { get; set; } 
        [MinLength(3)]
        public string textValue { get; set; }   
    }
}
