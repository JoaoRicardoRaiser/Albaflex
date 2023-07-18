using Albaflex.CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albaflex.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductInputModel model);
    }
}
