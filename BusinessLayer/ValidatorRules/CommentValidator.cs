using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatorRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Gmail addresi boş ola bilməz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Açıqlama boş ola bilməz");
        }
    }
}
