using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatorRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minumum uzunluq 2 simvol olmalıdır");
        }
    }
}
