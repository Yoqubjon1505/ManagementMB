using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface ISaleService
    {
        public Sale GetById(Guid id);
        public IQueryable<Sale> GetAll();
        public IQueryable<Sale> GetByDateTime(DateTime dateTime);
        public bool Create(Guid id, SaleProductDTO item);
        public bool UpdateSale(Guid id, SaleProductDTO item);
        public bool DeleteSale(Guid id);
    }
}
