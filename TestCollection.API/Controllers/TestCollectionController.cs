using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using TestCollection.Application.Services.Interfaces;
using TestCollection.Application.ViewModels;

namespace TestCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCollectionController : ControllerBase
    {
        public readonly ITestCollectionAppService _testCollectionAppService;
        private IMemoryCache _cache;
        public TestCollectionController(ITestCollectionAppService testCollectionAppService, IMemoryCache cache)
        {
            _cache = cache;
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
            var cacheKey = key + "_indexOf_" + value;
            long result = 0;
            try
            {
                if (!_cache.TryGetValue(cacheKey, out result))
                {
                    var opcoesDoCache = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                    };
                    result = _testCollectionAppService.IndexOf(key, value);
                    _cache.Set(cacheKey, result, opcoesDoCache);
                }
                return Ok(result);
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
            var cacheKey = key + "_get_" + start + "_" + end;
            IList<string> result;
            try
            {
                if (!_cache.TryGetValue(cacheKey, out result))
                {
                    var opcoesDoCache = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                    };
                    result = _testCollectionAppService.Get(key, start, end);
                    _cache.Set(cacheKey, result, opcoesDoCache);
                }
                return Ok(result);
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