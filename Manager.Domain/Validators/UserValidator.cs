using FluentValidation;
using Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
               .NotEmpty()
               .WithMessage("The entity can not be empty.")

               .NotNull()
               .WithMessage("The entity can not be null.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("The name can not be null.")

                .NotEmpty()
                .WithMessage("The name can not be empty.")

                .MinimumLength(3)
                .WithMessage("The name must have a miminum of three characters.")

                .MaximumLength(80)
                .WithMessage("The name must have a maximum of eigthy characters.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("The password can not be null")

                .NotEmpty()
                .WithMessage("The password can not be empty")

                .MinimumLength(6)
                .WithMessage("The password must have a minimum of six characters")

                .MaximumLength(30)
                .WithMessage("The password must have a maximum of thirty characters");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("The email can not be null")

                .NotEmpty()
                .WithMessage("The email can not be empty")

                .MinimumLength(10)
                .WithMessage("The email must have a minimum of ten characters.")

                .MaximumLength(180)
                .WithMessage("The email must have a maximum of one hundred eigthy characters.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("The email is invalid");

        }
    }
}
