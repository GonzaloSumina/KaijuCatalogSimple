
using KaijuCatalogWeb.Domain;

namespace KaijuCatalogWeb.Repositories;

public class InMemoryKaijuRepository : IKaijuRepository
{
    private readonly List<Kaiju> _kaijus = new();

    public void Add(Kaiju kaiju)
    {
        _kaijus.Add(kaiju);
    }

    public Kaiju? GetById(int id)
    {
        return _kaijus.FirstOrDefault(k => k.Id == id);
    }

    public IEnumerable<Kaiju> GetAll()
    {
        return _kaijus;
    }
}
