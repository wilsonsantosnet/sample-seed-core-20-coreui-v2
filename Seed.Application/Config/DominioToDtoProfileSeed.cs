using Seed.Domain.Entitys;
using Seed.Dto;

namespace Seed.Application.Config
{
    public class DominioToDtoProfileSeed : AutoMapper.Profile
    {

        public DominioToDtoProfileSeed()
        {
            CreateMap(typeof(SampleStandart), typeof(SampleStandartDto)).ReverseMap();
            CreateMap(typeof(SampleStandart), typeof(SampleStandartDtoSpecialized));
            CreateMap(typeof(SampleStandart), typeof(SampleStandartDtoSpecializedResult));
            CreateMap(typeof(SampleStandart), typeof(SampleStandartDtoSpecializedReport));
            CreateMap(typeof(SampleStandart), typeof(SampleStandartDtoSpecializedDetails));
            CreateMap(typeof(Sample), typeof(SampleDto)).ReverseMap();
            CreateMap(typeof(Sample), typeof(SampleDtoSpecialized));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedResult));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedReport));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedDetails));
            CreateMap(typeof(SampleDetail), typeof(SampleDetailDto)).ReverseMap();
            CreateMap(typeof(SampleDetail), typeof(SampleDetailDtoSpecialized));
            CreateMap(typeof(SampleDetail), typeof(SampleDetailDtoSpecializedResult));
            CreateMap(typeof(SampleDetail), typeof(SampleDetailDtoSpecializedReport));
            CreateMap(typeof(SampleDetail), typeof(SampleDetailDtoSpecializedDetails));
            CreateMap(typeof(SampleType), typeof(SampleTypeDto)).ReverseMap();
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecialized));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedResult));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedReport));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedDetails));
            CreateMap(typeof(Product), typeof(ProductDto)).ReverseMap();
            CreateMap(typeof(Product), typeof(ProductDtoSpecialized));
            CreateMap(typeof(Product), typeof(ProductDtoSpecializedResult));
            CreateMap(typeof(Product), typeof(ProductDtoSpecializedReport));
            CreateMap(typeof(Product), typeof(ProductDtoSpecializedDetails));
            CreateMap(typeof(SampleProduct), typeof(SampleProductDto)).ReverseMap();
            CreateMap(typeof(SampleProduct), typeof(SampleProductDtoSpecialized));
            CreateMap(typeof(SampleProduct), typeof(SampleProductDtoSpecializedResult));
            CreateMap(typeof(SampleProduct), typeof(SampleProductDtoSpecializedReport));
            CreateMap(typeof(SampleProduct), typeof(SampleProductDtoSpecializedDetails));

        }

    }
}
