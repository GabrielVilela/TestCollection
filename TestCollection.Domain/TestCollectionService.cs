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
            return testCollection.Add(item.Key, item.SubIndex, item.Value);
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
