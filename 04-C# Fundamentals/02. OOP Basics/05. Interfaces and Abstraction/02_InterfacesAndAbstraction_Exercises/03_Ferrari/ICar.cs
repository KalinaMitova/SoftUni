public interface ICar
{
    string Model { get; }
    string DriverName { get; set; }
    string Gas();
    string Brakes();
}