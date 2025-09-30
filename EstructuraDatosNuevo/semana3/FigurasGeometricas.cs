public class Cuadrado
{
    private double lado;

    public Cuadrado(double l) => lado = l;

    public double CalcularArea() => lado * lado;
    public double CalcularPerimetro() => 4 * lado;
}

public class Circulo
{
    private double radio;

    public Circulo(double r) => radio = r;

    public double CalcularArea() => System.Math.PI * radio * radio;
    public double CalcularPerimetro() => 2 * System.Math.PI * radio;
}