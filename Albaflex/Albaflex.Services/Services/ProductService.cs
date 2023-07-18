using System.Net;
using Albaflex.CrossCutting.Models;
using Albaflex.Services.Interfaces;
using Albaflex.Services.Validators;
using Albaflex.CrossCutting.Notification;
using Albaflex.Data.Interfaces;
using Albaflex.Data.Entities;
using Albaflex.Data;

namespace Albaflex.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly NotificationContext _notificationContext;
        private readonly IProductRepository _productRepository;
        private readonly ProductValidator _productValidator;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            NotificationContext notificationContext, 
            IProductRepository productRepository,
            ProductValidator productValidator,
            IUnitOfWork unitOfWork)
        {
            _notificationContext = notificationContext;
            _productRepository = productRepository;
            _productValidator = productValidator;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateProductInputModel model)
        {
            try
            {
                if (!_productValidator.Validate(model).IsValid)
                    return;

                if (await _productRepository.Exists(x => x.Code == model.Code))
                {
                    _notificationContext.AddNotification(HttpStatusCode.BadRequest, $"Product with code: {model.Code} already exists");
                    return;
                }

                await _productRepository.CreateAsync(Product.FromCreateProductInputModel(model));

                await _unitOfWork.CommitAsync();

                _notificationContext.AddNotification(HttpStatusCode.OK, "Product created with sucess!");
            }
            catch(Exception ex) 
            {
                _notificationContext.AddNotification(HttpStatusCode.BadRequest, $"had a problem to create a product. Exception: {ex.Message}");
            }
        }

        public async Task CreateAsyncMediator(CreateProductInputModel model)
        {
            try
            {
                if (!_productValidator.Validate(model).IsValid)
                    return;

                await _productRepository.CreateAsync(Product.FromCreateProductInputModel(model));

                await _unitOfWork.CommitAsync();

                _notificationContext.AddNotification(HttpStatusCode.OK, "Tissue created with sucess!");
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification(HttpStatusCode.BadRequest, $"had a problem to create a tissue. Exception: {ex.Message}");
            }
        }
    }
}
