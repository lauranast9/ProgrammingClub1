using FluentValidation;
using ProgrammingClub.CQRS.DTOs;

namespace ProgrammingClub.Models.Validators
{
    public class MembershipTypeValidator : AbstractValidator<MembershipTypeDTO>

    {

        public MembershipTypeValidator()

        {

            RuleFor(mt => mt.Name)

                .NotEmpty().WithMessage("Name is required.")

                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(mt => mt.Description)

                .NotEmpty().WithMessage("Description is required.")

                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(mt => mt.SubscriptionLengthInMonths)

                .GreaterThan(0).WithMessage("Subscription length must be greater than zero.")

                .LessThanOrEqualTo(12).WithMessage("Subscription length cannot exceed 12 months.");

        }

    }

}
 

