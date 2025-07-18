using InventorySystem.models;
namespace InventorySystem.Service;

public class SupplierService
{
    private readonly ISupplierRepository _supplierRepo;

    public SupplierService(ISupplierRepository supplierRepo)
    {
        _supplierRepo = supplierRepo;
    }

    public void AddSupplier(String name, String phone, String address, String email)
    {
        Supplier supplier = new Supplier(name, phone, address, email);
        _supplierRepo.AddSupplier(supplier);
    }
}