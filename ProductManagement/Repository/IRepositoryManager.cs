using Repository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }

        void Save();
    }
}
