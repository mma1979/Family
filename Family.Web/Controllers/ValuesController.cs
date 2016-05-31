using Family.Core.Entities;
using Family.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Family.Web.Controllers
{
    public class ValuesController : ApiController
    {
        IRepository _repo;
        public ValuesController(IRepository repo)
        {
            _repo = repo;
        }
        // GET api/values
        public IEnumerable<object> Get()
        {
            return _repo.All<Man>().Select(m => new {
                m.ManId,
                m.ManName,
                m.ManAge,
                m.IsAlive,
                Wifes = m.Wifes.Select(w => new
                {
                    w.WomanId,
                    w.WomanName,
                    w.WomanAge,
                    w.IsAlive,
                    w.HasbundId
                }),
                Children = m.Children.Select(c => new
                {
                    c.ChildId,
                    c.ChildName,
                    c.ChildAge,
                    c.IsAlive,
                    c.FatherId,
                    c.MotherId
                })
            });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
