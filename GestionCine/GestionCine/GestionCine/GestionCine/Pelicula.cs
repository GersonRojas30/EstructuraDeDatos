public class Pelicula
{
    public string Nombre { get; set; }
    public string Horario { get; set; }
    public decimal Precio { get; set; }

    public Pelicula(string nombre, string horario, decimal precio)
    {
        Nombre = nombre;
        Horario = horario;
        Precio = precio;
    }
}
