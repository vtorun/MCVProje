using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Alanını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı 3 Karakterden Az Olamaz");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanıcı Adı 50 Karakterden Çok Olamaz");
            RuleFor(x => x.UserMail).MinimumLength(3).WithMessage("Mail 3 Karakterden Az Olamaz");
            RuleFor(x => x.UserMail).MaximumLength(50).WithMessage("Mail 50 Karakterden Çok Olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Adını 3 Karakterden Az Olamaz");
            RuleFor(x => x.Subject).MaximumLength(25).WithMessage("Konu Adını 25 Karakterden Çok Olamaz");
        }
    }
}
