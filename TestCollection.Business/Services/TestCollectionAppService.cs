using AutoMapper;
using System;
using System.Collections.Generic;
using TestCollection.Application.Services.Interfaces;
using TestCollection.Application.ViewModels;
using TestCollection.Domain.Entities;
using TestCollection.Domain.Interfaces;

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
            try
            {
                return _testCollectionService.Add(_mapper.Map<TestItem>(item));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public long IndexOf(string key, string value)
        {
            try
            {
                return _testCollectionService.IndexOf(key, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<string> Get(string key, int start, int end)
        {
            try
            {
                return _testCollectionService.Get(key, start, end);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RemoveValuesFromSubIndex(string key, int subIndex)
        {
            try
            {
                return _testCollectionService.RemoveValuesFromSubIndex(key, subIndex);
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
                return _testCollectionService.Remove(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
