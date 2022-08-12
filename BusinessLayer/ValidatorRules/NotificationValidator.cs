using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatorRules
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Tipi boş ola bilməz");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Açıqlama boş ola bilməz");
        }
    }
}
