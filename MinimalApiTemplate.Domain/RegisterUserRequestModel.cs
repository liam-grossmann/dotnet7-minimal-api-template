using FluentValidation;

namespace MinimalApiTemplate.Domain;

public class RegisterUserRequestModel
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? EmailAddress { get; set; }

    public class Validator : AbstractValidator<RegisterUserRequestModel>
    {
        public Validator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.EmailAddress).NotEmpty();
        }
    }
}