using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        Product Create(ProductDTO entity);
        bool Update(Guid id, ProductDTO product);
        bool Delete(Guid id);
        public void UpdateForPurchase(Guid id, ProductDTO entity);
        //public void UpdateForSale(Product product);

    }
}
