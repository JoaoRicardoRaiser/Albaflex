using Albaflex.CrossCutting.Models;
using Albaflex.CrossCutting.Notification;
using Albaflex.Data.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace Albaflex.Services.Validators
{
    public class TissueValidator: AbstractValidator<CreateTissueInputModel>
    {
        private readonly NotificationContext _notificationContext;

        public TissueValidator(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
            RuleFor(t => t.Value).NotEqual(0).WithMessage($"The value of {nameof(Tissue)} couldn't be 0");
            RuleFor(t => t.Name).NotNull().WithMessage($"The name of {nameof(Tissue)} couldn't be null");
            RuleFor(t => t.Name).NotEmpty().WithMessage($"The name of {nameof(Tissue)} couldn't be empty");
        }

        public override ValidationResult Validate(ValidationContext<CreateTissueInputModel> context)
        {
            var resultado = base.Validate(context);

            if (!resultado.IsValid)
            {
                foreach (var error in resultado.Errors)
                {
                    _notificationContext.AddNotification(HttpStatusCode.BadRequest, error.ErrorMessage);
                }
            }

            return resultado;
        }
    }
}
