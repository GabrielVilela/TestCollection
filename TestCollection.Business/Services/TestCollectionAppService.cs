using AutoMapper;
using System.Collections.Generic;
using TestCollection.Application.Services.Interfaces;
using TestCollection.Application.ViewModels;
using TestCollection.Domain.Entities;
using TestCollection.Domain.Interfaces;
using TestCollection.Util.Interfaces;

namespace TestCollection.Application.Services
{
    public class TestCollectionAppService : ITestCollectionAppService
    {
        public readonly ITestCollectionService _testCollectionService;
        protected readonly IMapper _mapper;
        public TestCollectionAppService(ITestCollectionService testCollectionService, IMapper mapper)
        {
            _testCollectionService = testCollectionService;
            _mapper = mapper;
        }
        public bool Add(TestItemViewModel item)
        {
            return _testCollectionService.Add(_mapper.Map<TestItem>(item));
        }
        public long IndexOf(string key, string value)
        {
            return _testCollectionService.IndexOf(key, value);
        }

        public IList<string> Get(string key, int start, int end)
        {
            return _testCollectionService.Get(key, start, end);
        }
        public bool RemoveValuesFromSubIndex(string key, int subIndex)
        {
            return _testCollectionService.RemoveValuesFromSubIndex(key, subIndex);
        }
        public bool Remove(string key)
        {
            return _testCollectionService.Remove(key);
        }
    }
}
