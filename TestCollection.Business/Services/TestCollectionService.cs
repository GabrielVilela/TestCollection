using System;
using System.Collections.Generic;
using System.Text;
using TestCollection.Business.Services.Interfaces;
using TestCollection.Util.Interfaces;

namespace TestCollection.Business.Services
{
    public class TestCollectionService : ITestCollectionService
    {
        public static ITestCollection testCollection;
        public bool Add(string key, int subIndex, string value)
        {
            return testCollection.Add(key, subIndex, value);
        }
        public long IndexOf(string key, string value)
        {
            return testCollection.IndexOf(key, value);
        }
    }
}
