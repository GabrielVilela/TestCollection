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
        [HttpPost]
        public IActionResult Post(string key, int subindex, string value)
        {
            try
            {
                return Ok(_testCollectionService.Add(key,subindex, value));
            }
            catch
            {
                return Forbid();
            }
        }
    }
}