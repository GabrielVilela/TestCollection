using System;
using System.Collections.Generic;
using System.Text;
using TestCollection.Business.Services.Interfaces;
using TestCollection.Util.Interfaces;

namespace TestCollection.Business.Services
{
    public class TestCollectionService : ITestCollectionService
    {
        public static ITestCollection testCollection = new TestCollection.Util.TestCollection();
        public bool Add(string key, int subIndex, string value)
        {
            return testCollection.Add(key, subIndex, value);
        }
        public long IndexOf(string key, string value)
        {
            return testCollection.IndexOf(key, value);
        }

        public IList<string> Get(string key, int start, int end)
        {
            return testCollection.Get(key, start, end);
        }
        public bool RemoveValuesFromSubIndex(string key, int subIndex)
        {
            return testCollection.RemoveValuesFromSubIndex(key, subIndex);
        }
        public bool Remove(string key)
        {
            return testCollection.Remove(key);
        }
    }
}
