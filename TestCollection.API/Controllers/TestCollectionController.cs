using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCollection.Business.Services.Interfaces;

namespace TestCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCollectionController : ControllerBase
    {
        public readonly ITestCollectionService _testCollectionService;
        public TestCollectionController(ITestCollectionService testCollectionService)
        {
            _testCollectionService = testCollectionService;
        }
        [HttpPost("add")]
        public IActionResult Post(string key, int subIndex, string value)
        {
            try
            {
                return Ok(_testCollectionService.Add(key,subIndex, value));
            }
            catch
            {
                return Forbid();
            }
        }
        [HttpGet("indexOf")]
        public IActionResult IndexOf(string key, string value)
        {
            try
            {
                return Ok(_testCollectionService.IndexOf(key, value));
            }
            catch
            {
                return Forbid();
            }
        }
        [HttpGet("get")]
        public IActionResult Get(string key, int start, int end)
        {
            try
            {
                return Ok(_testCollectionService.Get(key, start, end));
            }
            catch
            {
                return Forbid();
            }
        }
        [HttpDelete("remove")]
        public IActionResult Remove(string key)
        {
            try
            {
                return Ok(_testCollectionService.Remove(key));
            }
            catch
            {
                return Forbid();
            }
        }
        [HttpDelete("removeValuesFromSubIndex")]
        public IActionResult RemoveValuesFromSubIndex(string key, int subIndex)
        {
            try
            {
                return Ok(_testCollectionService.RemoveValuesFromSubIndex(key, subIndex));
            }
            catch
            {
                return Forbid();
            }
        }
    }
}