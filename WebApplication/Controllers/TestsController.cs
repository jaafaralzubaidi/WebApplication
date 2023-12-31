﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TestsController : ApiController
    {
        TestsDBContext testDBContext = new TestsDBContext();

        // GET: api/Tests
        [HttpGet]
        public IHttpActionResult LoadAllTests()
        {
            return Ok(testDBContext.Test);
        }

        // GET: api/Tests?sort=asc or api/Tests?sort=desc
        [HttpGet]
        public IHttpActionResult LoadAllTestsWithSorting(string sort)
        {
            IQueryable<Test> tests;
            switch (sort) {
                case "desc":
                    tests = testDBContext.Test.OrderByDescending(i => i.CreatedAt);
                    break;
                case "asc":
                    tests = testDBContext.Test.OrderBy(i => i.CreatedAt);
                    break;
                default:
                    tests = testDBContext.Test;
                    break;
            }
            return Ok(tests);
        }

        // GET: api/Test/5   
        // api/Tests?
        [HttpGet]
        public IHttpActionResult LoadATest(int id)
        {
            var found = testDBContext.Test.FirstOrDefault(x => x.Id == id);
            if (found == null)
                return BadRequest($"Can't find a record with this ID:{id}");

            return Ok(found);
        }

        // GET: api/Test/PagingTest?pageNumber=1&pageSize=5 or api/Test/PagingTest with default values
        [HttpGet]
        [Route("api/Test/PagingTest/{pageNumber=1}/{pageSize=5}")]
        public IHttpActionResult PagingTest(int pageNumber, int pageSize)
        {
            // need to use OrderBy before using skip in LINQ 
            var tests = testDBContext.Test.OrderBy(t => t.Id);

            //paging algorithm
            return Ok(tests.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        //GET: api/Tests/SearchTests?type=action
        [HttpGet]
        [Route("api/Tests/SearchTests/{type=}")]
        public IHttpActionResult SearchingTest(string type)
        {
            var test = testDBContext.Test.Where(t => t.Type.StartsWith(type));
            return Ok(test);
        }
        // POST: api/Tests
        public IHttpActionResult Post([FromBody]Test test)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            testDBContext.Test.Add(test);
            testDBContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Tests/5
        public IHttpActionResult Put(int id, [FromBody]Test test)
        {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var found = testDBContext.Test.FirstOrDefault(x => x.Id == id);
            if (found == null)
                return BadRequest($"Can't find a record with this ID:{id}");

            found.Author = test.Author;
            found.Title = test.Title;
            found.Description = test.Description;
            found.Type = test.Type;
            testDBContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Tests/5
        public IHttpActionResult Delete(int id)
        {
            var found = testDBContext.Test.FirstOrDefault(x => x.Id == id);
            if (found == null)
                return BadRequest($"Can't find a record with this ID:{id}");

            testDBContext.Test.Remove(found);
            testDBContext.SaveChanges();
            return Ok();
        }
    }
}
