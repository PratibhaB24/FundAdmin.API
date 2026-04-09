using FluentValidation;
using FundAdmin.API.DTOs.Investor;

namespace FundAdmin.API.Validators
{
    public class UpdateInvestorValidator : AbstractValidator<UpdateInvestorDto>
    {
        public UpdateInvestorValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
