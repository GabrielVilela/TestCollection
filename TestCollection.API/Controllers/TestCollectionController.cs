using Microsoft.AspNetCore.Mvc;
using System;
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
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("indexOf")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 30)]
        public IActionResult IndexOf(string key, string value)
        {
            try
            {
                return Ok(_testCollectionAppService.IndexOf(key, value));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("get")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 30)]
        public IActionResult Get(string key, int start, int end)
        {
            try
            {
                return Ok(_testCollectionAppService.Get(key, start, end));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("remove")]
        public IActionResult Remove(string key)
        {
            try
            {
                return Ok(_testCollectionAppService.Remove(key));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("removeValuesFromSubIndex")]
        public IActionResult RemoveValuesFromSubIndex(string key, int subIndex)
        {
            try
            {
                return Ok(_testCollectionAppService.RemoveValuesFromSubIndex(key, subIndex));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}