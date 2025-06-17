using Demo_Design_Pattern_MediaTor.Application.Commands;
using FluentValidation;

namespace Demo_Design_Pattern_MediaTor.Application.Validators
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Tên khách hàng không được để trống")
                .MaximumLength(100).WithMessage("Tên không quá 100 ký tự");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Tổng tiền phải lớn hơn 0");
        }
    }
}
