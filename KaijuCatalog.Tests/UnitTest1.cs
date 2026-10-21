
using KaijuCatalogWeb.Domain;

namespace KaijuCatalog.Tests;

public class KaijuTests
{
    [Fact]
    public void Constructor_DatosValidos_CreaKaiju()
    {
        // Arrange
        int id = 1;
        string name = "Godzilla";
        double height = 120;
        double weight = 90000;
        string threatLevel = "Alto";

        // Act
        var kaiju = new Kaiju(id, name, height, weight, threatLevel);

        // Assert
        Assert.Equal(id, kaiju.Id);
        Assert.Equal(name, kaiju.Name);
        Assert.Equal(height, kaiju.Height);
        Assert.Equal(weight, kaiju.Weight);
        Assert.Equal(threatLevel, kaiju.ThreatLevel);
    }

    [Fact]
    public void Constructor_NombreVacio_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "", 120, 90000, "Alto"));
    }

    [Fact]
    public void Constructor_AlturaCero_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "Godzilla", 0, 90000, "Alto"));
    }

    [Fact]
    public void Constructor_AlturaNegativa_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "Godzilla", -1, 90000, "Alto"));
    }

    [Fact]
    public void Constructor_PesoCero_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "Godzilla", 120, 0, "Alto"));
    }

    [Fact]
    public void Constructor_PesoNegativo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "Godzilla", 120, -1, "Alto"));
    }

    [Fact]
    public void Constructor_NivelAmenazaVacio_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "Godzilla", 120, 90000, ""));
    }

    [Fact]
    public void Constructor_NombreNulo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, null!, 120, 90000, "Alto"));
    }

    [Fact]
    public void Constructor_NivelAmenazaNulo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Kaiju(1, "Godzilla", 120, 90000, null!));
    }
}
