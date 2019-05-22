using System;
using System.Collections.Generic;
using System.Text;
using TestCollection.Domain.Entities;

namespace TestCollection.Domain.Interfaces
{
    public interface ITestCollectionService
    {
        bool Add(TestItem testItem);
        long IndexOf(string key, string value);
        IList<string> Get(string key, int start, int end);
        bool RemoveValuesFromSubIndex(string key, int subIndex);
        bool Remove(string key);
    }
}
