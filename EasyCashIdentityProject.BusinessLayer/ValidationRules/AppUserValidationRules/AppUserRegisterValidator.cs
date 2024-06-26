﻿using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçlilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçlilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçlilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçlilemez!");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("En fazla 30 karakter");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolarınız eşeleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("lütfen geçerli bir Email adresi giriniz");




        }

    }
}
