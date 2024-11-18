// File: MenuGor.Application/Validators/CompanyValidator.cs

using FluentValidation;
using MenuGor.Core.Entities;

namespace MenuGor.Application.Validators
{
    /// <summary>
    /// Firma entity'si için validator
    /// </summary>
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            // Firma adı boş olmamalı ve en fazla 100 karakter olmalı
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

            // Email adresi boş olmamalı ve geçerli bir email formatında olmalı
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            // Telefon numarası boş olmamalı ve belirtilen formatta olmalı
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+?[1-9]\d{1,14}$");

            // Diğer kurallar buraya eklenebilir
            // Örnek:
            // RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
            // RuleFor(x => x.ConnectionString).NotEmpty();
            // RuleFor(x => x.DealerId).GreaterThan(0);
        }
    }
}