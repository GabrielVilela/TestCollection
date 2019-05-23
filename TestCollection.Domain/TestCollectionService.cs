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
            try
            {
                return testCollection.IndexOf(key, value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IList<string> Get(string key, int start, int end)
        {
            try
            {
               return testCollection.Get(key, start, end);
            }
            catch(Exception ex)
            {
                throw ex;
            }           
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
