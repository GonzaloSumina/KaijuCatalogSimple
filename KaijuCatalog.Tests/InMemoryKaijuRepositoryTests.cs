
using KaijuCatalogWeb.Domain;
using KaijuCatalogWeb.Repositories;

namespace KaijuCatalog.Tests;

public class InMemoryKaijuRepositoryTests
{
    [Fact]
    public void Add_KaijuValido_PuedeEncontrarsePorId()
    {
        // Arrange
        var repository = new InMemoryKaijuRepository();
        var kaiju = new Kaiju(1, "Godzilla", 120, 90000, "Alto");

        // Act
        repository.Add(kaiju);
        var resultado = repository.GetById(1);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Godzilla", resultado.Name);
    }

    [Fact]
    public void GetById_IdInexistente_RetornaNull()
    {
        // Arrange
        var repository = new InMemoryKaijuRepository();

        // Act
        var resultado = repository.GetById(99);

        // Assert
        Assert.Null(resultado);
    }

    [Fact]
    public void GetAll_ConVariosKaijus_RetornaTodos()
    {
        // Arrange
        var repository = new InMemoryKaijuRepository();
        var kaiju1 = new Kaiju(1, "Godzilla", 120, 90000, "Alto");
        var kaiju2 = new Kaiju(2, "Mothra", 50, 20000, "Medio");

        // Act
        repository.Add(kaiju1);
        repository.Add(kaiju2);
        var resultado = repository.GetAll().ToList();

        // Assert
        Assert.Equal(2, resultado.Count);
        Assert.Contains(resultado, k => k.Id == 1);
        Assert.Contains(resultado, k => k.Id == 2);
    }

    [Fact]
    public void GetAll_SinKaijus_RetornaColeccionVacia()
    {
        // Arrange
        var repository = new InMemoryKaijuRepository();

        // Act
        var resultado = repository.GetAll();

        // Assert
        Assert.Empty(resultado);
    }
}
