// Modelos/Usuario.cs

namespace CajeroAutomatico.Modelos
{
    public class Usuario
    {
        public int    Id            { get; set; }
        public string Nombre        { get; set; } = string.Empty;
        public string NumeroTarjeta { get; set; } = string.Empty;
        public string PIN           { get; set; } = string.Empty;
        public double Saldo         { get; set; }
    }
}