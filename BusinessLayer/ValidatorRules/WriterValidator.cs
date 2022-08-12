using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatorRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı boş ola bilməz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Gmail boş ola bilməz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə boş ola bilməz");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Minumum uzunluq 8 simvol olmalıdır");
            //RuleFor(x => x.About).NotEmpty().WithMessage("Yazar haqqında boş ola bilməz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minumum uzunluq 2 simvol olmalıdır");
        }
    }
}
