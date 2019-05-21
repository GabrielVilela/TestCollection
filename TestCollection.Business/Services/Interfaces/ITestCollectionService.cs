using System;
using System.Collections.Generic;
using System.Text;

namespace TestCollection.Business.Services.Interfaces
{
    public interface ITestCollectionService
    {
        bool Add(string key, int subIndex, string value);
        long IndexOf(string key, string value);
    }
}
