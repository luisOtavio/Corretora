using FluentValidation;

namespace Corretora.Application.Sbp.Events
{
    public class NewSbpEventCommandValidator : AbstractValidator<NewSbpEventCommand>
    {
        public NewSbpEventCommandValidator()
        {
            //RuleFor(c => c.Amount)
            //    .Must((decimal amount) => amount > 0)
            //    .WithMessage("Ammout must be greater than zero");

            RuleFor(c => c.Target)
                .Must((TargetDto target) => target != null)
                .WithMessage("Target not found");

            RuleFor(c => c.Origin)
                .Must((OriginDto origin) => origin != null)
                .WithMessage("Origin not found");

            RuleFor(c => c.Event)
                .Must((string _event) => string.IsNullOrEmpty(_event) == false)
                .WithMessage("Event not found");
        }
    }
}
