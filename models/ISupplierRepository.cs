namespace InventorySystem.models;
using InventorySystem.models;

public interface ISupplierRepository
{
    void CreateSupplier(Supplier supplier);
    void AddSupplier(Supplier supplier);
    List<Supplier> GetAllSuppliers();
    Product GetProduct(int id);
    void UpdateProduct(Product product);
    void DeleteProduct(Supplier product);
    void ExistSupplier(int id);
}