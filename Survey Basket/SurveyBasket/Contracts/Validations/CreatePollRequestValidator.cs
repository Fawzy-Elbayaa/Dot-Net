

namespace SurveyBasket.Contracts.Validations
{
    public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(x => x.Tittle)
                .NotEmpty()
                .WithMessage("Please Add a {PropertyName}")
                .Length(3, 100)
                .WithMessage("Title Field Should be at least {MinLength} and maximum {MaxLength} , you entered [{TotalLength}]");


            RuleFor(x => x.Summary)
                .NotEmpty()
                .WithMessage("Please Add a {PropertyName}")
                .Length(3, 1000)
                .WithMessage("Description Field Should be at least [{MinLength}] and maximum [{MaxLength}] , you entered [{TotalLength}]");

        }
    }
}
