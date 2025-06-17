using Demo_Design_Pattern_MediaTor.Common;
using MediatR;

namespace Demo_Design_Pattern_MediaTor.Application.Commands
{
    public class DeleteOrderCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
