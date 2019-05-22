using Microsoft.AspNetCore.Mvc;
using TestCollection.Application.Services.Interfaces;
using TestCollection.Application.ViewModels;

namespace TestCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCollectionController : ControllerBase
    {
        public readonly ITestCollectionAppService _testCollectionAppService;
        public TestCollectionController(ITestCollectionAppService testCollectionAppService)
        {
            _testCollectionAppService = testCollectionAppService;
        }
        [HttpPost("add")]
        public IActionResult Post([FromBody]TestItemViewModel item)
        {
            try
            {
                return Ok(_testCollectionAppService.Add(item));
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
                return Ok(_testCollectionAppService.IndexOf(key, value));
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
                return Ok(_testCollectionAppService.Get(key, start, end));
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
                return Ok(_testCollectionAppService.Remove(key));
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
                return Ok(_testCollectionAppService.RemoveValuesFromSubIndex(key, subIndex));
            }
            catch
            {
                return Forbid();
            }
        }
    }
}