
namespace KaijuCatalogWeb.Domain;

public class Kaiju
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double Height { get; private set; }
    public double Weight { get; private set; }
    public string ThreatLevel { get; private set; }

    public Kaiju(
        int id,
        string name,
        double height,
        double weight,
        string threatLevel)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre es obligatorio.");

        if (height <= 0)
            throw new ArgumentException("La altura debe ser positiva.");

        if (weight <= 0)
            throw new ArgumentException("El peso debe ser positivo.");

        if (string.IsNullOrWhiteSpace(threatLevel))
            throw new ArgumentException("El nivel de amenaza es obligatorio.");

        Id = id;
        Name = name;
        Height = height;
        Weight = weight;
        ThreatLevel = threatLevel;
    }
}
