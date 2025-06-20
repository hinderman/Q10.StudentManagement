using FluentValidation;

namespace Q10.StudentManagement.Subject.Application.Commands.Validations
{
    public class UpdateSubjectValidation : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectValidation()
        {
            RuleFor(RuleFor => RuleFor.pName)
                .NotEmpty().WithName("Nombre de la asignatura").WithMessage("El {PropertyName} el requerido.")
                .MaximumLength(100).WithName("Nombre de la asignatura").WithMessage("El {PropertyName} debe tener a lo mucho 100 caracteres.");

            RuleFor(RuleFor => RuleFor.pCode)
                .NotEmpty().WithName("Codigo de la asignatura").WithMessage("El {PropertyName} es requerido.")
                .MaximumLength(20).WithName("Codigo de la asignatura").WithMessage("El {PropertyName} debe tener a lo mucho 20 caracteres.");

            RuleFor(RuleFor => RuleFor.pCredits)
                .GreaterThan(0).WithName("Creditos de la asignatura").WithMessage("El {PropertyName} debe ser mayor a 0.")
                .LessThanOrEqualTo(10).WithName("Creditos de la asignatura").WithMessage("El {PropertyName} debe ser menor o igual a 10.");
        }
    }
}
