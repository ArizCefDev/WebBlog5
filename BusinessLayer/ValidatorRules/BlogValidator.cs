using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatorRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Açıqlama boş ola bilməz");
            //RuleFor(x => x.Image).NotEmpty().WithMessage("Şəkil boş ola bilməz");
            RuleFor(x => x.Content).MinimumLength(200).WithMessage("Minumum uzunluq 200 simvol olmalıdır");
        }
    }
}
