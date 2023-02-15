using System.Net;
using Albaflex.CrossCutting.Models;
using Albaflex.Data.Interfaces;
using Albaflex.Services.Interfaces;
using Albaflex.Services.Validators;
using Albaflex.CrossCutting.Notification;
using Albaflex.Data.Entities;
using Albaflex.Data;

namespace Albaflex.Services.Services
{
    public class TissueService : ITissueService
    {
        private readonly NotificationContext _notificationContext;
        private readonly ITissueRepository _tissueRepository;
        private readonly TissueValidator _tissueValidator;
        private readonly IUnitOfWork _unitOfWork;

        public TissueService(NotificationContext notificationContext, ITissueRepository tissueRepository, TissueValidator tissueValidator, IUnitOfWork unitOfWork)
        {
            _notificationContext = notificationContext;
            _tissueRepository = tissueRepository;
            _tissueValidator = tissueValidator;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateTissueInputModel model)
        {
            try
            {
                if (!_tissueValidator.Validate(model).IsValid)
                    return;

                await _tissueRepository.CreateAsync(new Tissue(model.Code, model.Name, model.Value));

                await _unitOfWork.CommitAsync();

                _notificationContext.AddNotification(HttpStatusCode.OK, "Tissue created with sucess!");
            }
            catch(Exception ex) 
            {
                _notificationContext.AddNotification(HttpStatusCode.BadRequest, $"had a problem to create a tissue. Exception: {ex.Message}");
            }
        }
    }
}
