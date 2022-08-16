using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p=>p.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Bırakamazsınız!");
            RuleFor(p => p.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklama Alanını Boş Bırakamazsınız!");
            RuleFor(p=>p.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter olmalı!");
            RuleFor(p => p.CategoryName).MaximumLength(20).WithMessage("Kategori Alanı En Fazla 20 Karakter Olmalı!");
        }
    }
}
