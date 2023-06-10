using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Username alanını boş geçemezsiniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Password alanını boş geçemezsiniz");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Role alanını boş geçemezsiniz");
        }
    }
}
