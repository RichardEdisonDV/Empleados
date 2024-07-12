using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Industrias.Queries.GetIndustrias
{
    public class GetIndustriasQuery:IRequest<BaseWrapperResponse<List<IndustriaDto>>>
    {
    }
}
