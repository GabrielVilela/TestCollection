using System.Collections.Generic;
using TestCollection.Application.ViewModels;

namespace TestCollection.Application.Services.Interfaces
{
    public interface ITestCollectionAppService
    {
        bool Add(TestItemViewModel testItem);
        long IndexOf(string key, string value);
        IList<string> Get(string key, int start, int end);
        bool RemoveValuesFromSubIndex(string key, int subIndex);
        bool Remove(string key);

    }
}
