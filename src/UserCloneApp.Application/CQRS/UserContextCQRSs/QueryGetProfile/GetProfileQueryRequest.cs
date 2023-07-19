using MediatR;

namespace UserCloneApp.Application.CQRS.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryRequest : IRequest<GetProfileQueryResponse>
    {
    }
}
