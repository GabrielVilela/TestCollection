using AutoMapper;
using TestCollection.Application.ViewModels;
using TestCollection.Domain.Entities;

namespace TestCollection.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TestItemViewModel, TestItem>();
        }
    }
}
