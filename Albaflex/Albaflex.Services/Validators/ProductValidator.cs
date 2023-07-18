using Albaflex.CrossCutting.Models;
using Albaflex.CrossCutting.Notification;
using Albaflex.Data.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace Albaflex.Services.Validators
{
    public class ProductValidator: AbstractValidator<CreateProductInputModel>
    {
        private readonly NotificationContext _notificationContext;

        public ProductValidator(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
            RuleFor(t => t.Price).NotEqual(0).WithMessage($"The value of {nameof(Product)} couldn't be 0");
            RuleFor(t => t.Description).NotNull().WithMessage($"The name of {nameof(Product)} couldn't be null");
            RuleFor(t => t.Description).NotEmpty().WithMessage($"The name of {nameof(Product)} couldn't be empty");
        }

        public override ValidationResult Validate(ValidationContext<CreateProductInputModel> context)
        {
            var resultado = base.Validate(context);

            if (!resultado.IsValid)
                foreach (var error in resultado.Errors)
                    _notificationContext.AddNotification(HttpStatusCode.BadRequest, error.ErrorMessage);

            return resultado;
        }
    }
}
