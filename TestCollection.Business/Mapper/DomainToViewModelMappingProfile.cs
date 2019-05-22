using AutoMapper;
using TestCollection.Application.ViewModels;
using TestCollection.Domain.Entities;

namespace TestCollection.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TestItem, TestItemViewModel>();
        }
    }
}
