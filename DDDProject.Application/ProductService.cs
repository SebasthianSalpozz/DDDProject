using DDDProject.Domain;

namespace DDDProject.Application;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Product?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

    public async Task AddAsync(string name, decimal price)
    {
        var product = new Product(name, price);
        await _repository.AddAsync(product);
    }

    public async Task UpdateAsync(Guid id, string name, decimal price)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product != null)
        {
            product.Update(name, price);
            await _repository.UpdateAsync(product);
        }
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
