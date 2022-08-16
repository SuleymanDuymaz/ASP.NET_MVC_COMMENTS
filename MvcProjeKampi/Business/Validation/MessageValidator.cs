    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Entity.Concrete;

namespace Business.Validation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(p=>p.MessageContent).NotEmpty().WithMessage("Mesaj boş bırakılamaz");
            RuleFor(p => p.RecieverMail).NotEmpty().WithMessage("Alıcı alanı boş bırakılamaz");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz");

        }


    }
}
