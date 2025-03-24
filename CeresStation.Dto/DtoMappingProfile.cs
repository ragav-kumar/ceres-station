using AutoMapper;
using CeresStation.Model;

namespace CeresStation.Dto;

public class DtoMappingProfile : Profile
{
	public DtoMappingProfile()
	{
		CreateMap<Extractor, ExtractorDto>();
		CreateMap<Column, ColumnDto>();
		CreateMap<Resource, ResourceDto>();
		CreateMap<Reagent, ReagentDto>();
		CreateMap<Processor, ProcessorDto>();
		CreateMap<EntityBase, EntityDto>();
		CreateMap<Transport, TransportDto>();
		CreateMap<Consumer, ConsumerDto>();
	}
}
