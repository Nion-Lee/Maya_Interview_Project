using Infrastructure.Dtos;
using Infrastructure.Repositories;

namespace ApplicationService.DtoMapper
{
    public class DtoMapperService
    {
        public FeeNoDto ModelToDto(FeeNoRepo items)
        {
            if (items is null)
                return null;

            return new FeeNoDto
            {

            };
        }

        public FeeNoRepo DtoToModel(FeeNoDto dto)
        {
            if (dto is null)
                return null;

            return new FeeNoRepo
            {

            };
        }
    }
}
