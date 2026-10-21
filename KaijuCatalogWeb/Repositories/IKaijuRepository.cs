using KaijuCatalogWeb.Domain;

namespace KaijuCatalogWeb.Repositories;

public interface IKaijuRepository
{
    void Add(Kaiju kaiju);
    Kaiju? GetById(int id);
    IEnumerable<Kaiju> GetAll();
}