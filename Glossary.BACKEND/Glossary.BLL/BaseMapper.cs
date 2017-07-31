using AutoMapper;

namespace Glossary.BLL.Mapper
{
    /// <summary>
    /// Provide mapping facility to and from with MODEL and DTO Objects
    /// </summary>
    /// <typeparam name="MODEL">Entities</typeparam>
    /// <typeparam name="DTO">DTO</typeparam>
    public partial class BaseMapper<MODEL, DTO>
        where MODEL : class
        where DTO : class
    {
        // Provide mapping configuration for Model
        private MapperConfiguration modelMapperConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MODEL, DTO>();
                });
            }
        }

        // Provide mapping configuration for DTO
        private MapperConfiguration dtoMapperConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DTO, MODEL>();
                });
            }
        }

        // Maps the data from Model source to DTO
        protected DTO GetMappedToDTO(object source)
        {
            return modelMapperConfig.CreateMapper().Map<DTO>(source);
        }

        // Maps the data from DTO source to Model 
        protected MODEL GetMappedToModel(object source)
        {
            return dtoMapperConfig.CreateMapper().Map<MODEL>(source);
        }
    }

    public partial class BaseMapper
    {
        // Generic method to be used for inline mapping
        public TO GetMapped<TO, FROM>(object source)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FROM, TO>();
            });
            return mapper.CreateMapper().Map<TO>(source);
        }
    }
}
