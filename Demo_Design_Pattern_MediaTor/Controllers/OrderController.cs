using Demo_Design_Pattern_MediaTor.Application.Commands;
using Demo_Design_Pattern_MediaTor.Application.Queries;
using Demo_Design_Pattern_MediaTor.Common;
using Demo_Design_Pattern_MediaTor.Domain.Dtos.OrderDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Design_Pattern_MediaTor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = await _mediator.Send(command, cancellationToken);

            var response = new BaseResponse<Guid>
            {
                Success = true,
                Data = orderId,
                Message = "Tạo đơn hàng thành công"
            };

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery(), cancellationToken);
            return Ok(new BaseResponse<List<OrderDto>>
            {
                Success = true,
                Data = orders,
                Message = "Lấy danh sách đơn hàng thành công"
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
            return order != null
                ? Ok(new BaseResponse<OrderDto> { Success = true, Data = order, Message = "Lấy đơn hàng thành công" })
                : NotFound(new BaseResponse<OrderDto> { Success = false, Message = "Không tìm thấy đơn hàng" });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest(new BaseResponse<bool>
                {
                    Success = false,
                    Message = "ID không khớp giữa URL và body",
                    Errors = new List<string> { "ID mismatch" }
                });
            }

            var result = await _mediator.Send(command, cancellationToken);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);
            return result.Success ? Ok(result) : NotFound(result);
        }

    }
}
