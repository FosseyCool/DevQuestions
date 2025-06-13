using DevQuestions.Contacts;
using FluentValidation;

namespace DevQuestions.Application.Questions.Validation;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(500).WithMessage("Заголовок невалидный.");
        RuleFor(x => x.Body).NotEmpty().MaximumLength(500).WithMessage("Заголовок невалидный.");
        RuleFor(x => x.UserId).NotEmpty();
    }
}