
using KaijuCatalogWeb.Domain;
using KaijuCatalogWeb.Repositories;

namespace KaijuCatalogWeb.Services;

public class KaijuService
{
    private readonly IKaijuRepository _repository;

    public KaijuService(IKaijuRepository repository)
    {
        _repository = repository;
    }

    public void Register(Kaiju kaiju)
    {
        if (_repository.GetById(kaiju.Id) is not null)
            throw new InvalidOperationException(
                "Ya existe un Kaiju con ese identificador.");

        _repository.Add(kaiju);
    }

    public Kaiju? FindById(int id)
    {
        if (id <= 0)
            throw new ArgumentException(
                "El identificador debe ser positivo.");

        return _repository.GetById(id);
    }

    public IEnumerable<Kaiju> GetAll()
    {
        return _repository.GetAll();
    }
}
