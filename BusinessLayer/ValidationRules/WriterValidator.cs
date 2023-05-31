using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı adı 50 karakterden fazla olamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Title kısmını boş geçemezsiniz");
        }
    }
}
