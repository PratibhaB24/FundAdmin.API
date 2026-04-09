using FluentValidation;
using FundAdmin.API.DTOs.Investor;

namespace FundAdmin.API.Validators
{
    public class CreateInvestorValidator : AbstractValidator<CreateInvestorDto>
    {
        public CreateInvestorValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.FundId)
                .NotEmpty();
        }
    }
}
