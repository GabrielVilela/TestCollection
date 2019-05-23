using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using TestCollection.Domain.Entities;
using TestCollection.Domain.Interfaces;
using TestCollection.Util.Interfaces;

namespace TestCollection.Domain
{
    public class TestCollectionService : ITestCollectionService
    {
        public static ITestCollection testCollection = new Util.TestCollection();
        private IMemoryCache _cache;
        public TestCollectionService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public bool Add(TestItem item)
        {
            try
            {
                return testCollection.Add(item.Key, item.SubIndex, item.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long IndexOf(string key, string value)
        {
            var cacheKey = key + "_index_of_" + value;
            long result = 0;
            try
            {
                if (!_cache.TryGetValue(cacheKey, out result))
                {
                    var opcoesDoCache = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1)
                    };
                    result = testCollection.IndexOf(key, value);
                    _cache.Set(cacheKey, result, opcoesDoCache);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IList<string> Get(string key, int start, int end)
        {
            var cacheKey = key + "_get_" + start+"_"+end;
            IList<string> result;
            try
            {
                if (!_cache.TryGetValue(cacheKey, out result))
                {
                    var opcoesDoCache = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1)
                    };
                    result = testCollection.Get(key, start, end);
                    _cache.Set(cacheKey, result, opcoesDoCache);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public bool RemoveValuesFromSubIndex(string key, int subIndex)
        {
                try
                {
                    return testCollection.RemoveValuesFromSubIndex(key, subIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Remove(string key)
        {
            try
            {
                return testCollection.Remove(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
