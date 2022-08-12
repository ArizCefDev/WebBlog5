using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatorRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Details1).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Details2).MinimumLength(100).WithMessage("Minumum uzunluq 100 simvol olmalıdır");
        }
    }
}
