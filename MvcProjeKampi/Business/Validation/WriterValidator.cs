using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Validation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(p=>p.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(P => P.WriterName).MinimumLength(2).WithMessage("Yazar Adı En Az 3 Karakter Uzunluğunda Olmalı");
            RuleFor(p => p.WriterName).MaximumLength(50).WithMessage("Yazarın Adı En Fazla 50 Karakter Uzunluğunda Olmalı");
            RuleFor(p=>p.WriterSurname).NotEmpty().WithMessage("Yazarın Soyadı boş geçilemez");
            RuleFor(p=>p.WriterSurname).MinimumLength(2).WithMessage("Yazar Soyadı En Az 2 Karakter Uzunluğunda Olmalı");
            RuleFor(p=>p.WriterSurname).MaximumLength(100).WithMessage("Yazar Soyadı En Fazla 100 Karakter Uzunluğunda Olmalı");
            RuleFor(p=>p.WriterMail).NotEmpty().WithMessage("Mail Boş bırakılamaz");
            RuleFor(p=>p.WriterPassword).NotEmpty().WithMessage("Şifre Boş Bırakılamaz");


          
        }
    }
}
