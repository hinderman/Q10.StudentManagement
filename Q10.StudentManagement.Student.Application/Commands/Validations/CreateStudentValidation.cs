using FluentValidation;

namespace Q10.StudentManagement.Student.Application.Commands.Validations
{
    public class CreateStudentValidation : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidation()
        {
            RuleFor(RuleFor => RuleFor.pName)
                .NotEmpty().WithName("Nombre de estudiante").WithMessage("El {PropertyName} el requerido.")
                .MaximumLength(100).WithName("Nombre de estudiante").WithMessage("El {PropertyName} debe tener a lo mucho 100 caracteres.");

            RuleFor(RuleFor => RuleFor.pEmail)
                .NotEmpty().WithName("E-mail").WithMessage("El {PropertyName} es requerido.")
                .EmailAddress().WithName("E-mail").WithMessage("El {PropertyName} no posee el formato requerido.")
                .MaximumLength(30).WithName("E-mail").WithMessage("El {PropertyName} debe tener a lo mucho 30 caracteres.");

            RuleFor(RuleFor => RuleFor.pDocument)
                .NotEmpty().WithName("Numero de documento").WithMessage("El {PropertyName} es requerido.")
                .MaximumLength(20).WithName("Numero de documento").WithMessage("El {PropertyName} debe tener a lo mucho 20 caracteres.");
        }
    }
}
