using System.Collections.Generic;

namespace TestCollection.Business.Services.Interfaces
{
    public interface ITestCollectionService
    {
        bool Add(string key, int subIndex, string value);
        long IndexOf(string key, string value);
        IList<string> Get(string key, int start, int end);
        bool RemoveValuesFromSubIndex(string key, int subIndex);
        bool Remove(string key);

    }
}
