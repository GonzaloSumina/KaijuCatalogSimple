
using KaijuCatalogWeb.Domain;
using KaijuCatalogWeb.Repositories;
using KaijuCatalogWeb.Services;
using Moq;

namespace KaijuCatalog.Tests;

public class KaijuServiceTests
{
    private readonly Mock<IKaijuRepository> _repositoryMock;
    private readonly KaijuService _service;

    public KaijuServiceTests()
    {
        _repositoryMock = new Mock<IKaijuRepository>();
        _service = new KaijuService(_repositoryMock.Object);
    }

    [Fact]
    public void Register_KaijuNuevo_LoGuarda()
    {
        // Arrange
        var kaiju = new Kaiju(1, "Godzilla", 120, 90000, "Alto");

        _repositoryMock
            .Setup(r => r.GetById(1))
            .Returns((Kaiju?)null);

        // Act
        _service.Register(kaiju);

        // Assert
        _repositoryMock.Verify(
            r => r.Add(kaiju),
            Times.Once);
    }

    [Fact]
    public void Register_IdExistente_LanzaExcepcion()
    {
        // Arrange
        var kaiju = new Kaiju(1, "Godzilla", 120, 90000, "Alto");

        _repositoryMock
            .Setup(r => r.GetById(1))
            .Returns(kaiju);

        // Act y Assert
        Assert.Throws<InvalidOperationException>(
            () => _service.Register(kaiju));

        _repositoryMock.Verify(
            r => r.Add(It.IsAny<Kaiju>()),
            Times.Never);
    }

    [Fact]
    public void FindById_IdValido_DevuelveKaiju()
    {
        // Arrange
        var esperado = new Kaiju(1, "Godzilla", 120, 90000, "Alto");

        _repositoryMock
            .Setup(r => r.GetById(1))
            .Returns(esperado);

        // Act
        var resultado = _service.FindById(1);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void FindById_IdNoPositivo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(
            () => _service.FindById(0));

        _repositoryMock.Verify(
            r => r.GetById(It.IsAny<int>()),
            Times.Never);
    }

    [Fact]
    public void GetAll_DevuelveKaijusDelRepositorio()
    {
        // Arrange
        var kaijus = new List<Kaiju>
        {
            new(1, "Godzilla", 120, 90000, "Alto"),
            new(2, "Mothra", 25, 15000, "Medio")
        };

        _repositoryMock
            .Setup(r => r.GetAll())
            .Returns(kaijus);

        // Act
        var resultado = _service.GetAll();

        // Assert
        Assert.Equal(2, resultado.Count());
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }
}
