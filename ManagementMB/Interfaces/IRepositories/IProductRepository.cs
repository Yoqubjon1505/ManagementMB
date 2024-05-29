using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetAll();
        public Product GetById(Guid id);
        public bool Create(Product item);
        public bool Update(Guid id, ProductDTO item);
        public void UpdateForSale(Product product);
        public bool Delete(Guid id);
    }
}
