using CaseProject.Entities.Concrete;
using FluentValidation;

namespace CaseProject.Business.ValidationRules.FluentValidation
{
    public class HistoryValidator:AbstractValidator<History>
    {
        public HistoryValidator()
        {
            RuleFor(x => x.EventDescription).NotEmpty().WithMessage("Olay açıklaması boş bırakılamaz");
            RuleFor(x => x.EventDescription).Length(5,250).WithMessage("Olayı açıklaması 5 ile 250 karakter arasında olmalıdır");
        }
    }
}
