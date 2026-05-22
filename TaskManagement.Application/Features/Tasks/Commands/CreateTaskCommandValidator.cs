using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.Commands
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(150).WithMessage("Task title cannot exceed 150 characters.");

            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("ProjectId is required.");

            RuleFor(x => x.DueDate)
                .Must(date => !date.HasValue || date.Value > DateTime.UtcNow)
                .WithMessage("Due date must be a future date.");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Invalid priority value.");
        }
    }
}
