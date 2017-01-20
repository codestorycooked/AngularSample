using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularBackendAPI.Controllers
{

    public class ValuesController : ApiController
    {
        List<DataViewModel> _data;
        public ValuesController()
        {
            _data = new List<DataViewModel>();

        }

        //Creating DataModel Class - Thsi is non persistant data
        public class DataViewModel
        {
            public string FirstName { get; set; }
            public string Age { get; set; }
        }

        [HttpGet]
        // GET api/values
        public List<DataViewModel> Get()
        {
            var dataStored = JsonConvert.DeserializeObject<List<DataViewModel>>(System.IO.File.ReadAllText(@"C:\data\data.json"));
            return dataStored;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post(DataViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid Request");
            }
            for (int i = 0; i < 10; i++)
            {
                _data.Add(model);
            }


            string json = JsonConvert.SerializeObject(_data.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"C:\data\data.json", json);
            return Ok();

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
