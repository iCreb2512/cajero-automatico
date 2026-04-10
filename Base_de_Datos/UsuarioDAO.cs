// Datos/UsuarioDAO.cs

using System;
using Microsoft.Data.Sqlite;
using CajeroAutomatico.Modelos;

namespace CajeroAutomatico.Datos
{
    public class UsuarioDAO
    {
        // Busca un usuario por número de tarjeta y PIN (para login)
        public Usuario? BuscarUsuario(string numeroTarjeta, string pin)
        {
            const string sql = @"
                SELECT Id, Nombre, NumeroTarjeta, PIN, Saldo
                FROM Usuarios
                WHERE NumeroTarjeta = @tarjeta AND PIN = @pin
                LIMIT 1;";

            using var con = ConexionDB.ObtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@tarjeta", numeroTarjeta);
            cmd.Parameters.AddWithValue("@pin",     pin);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new Usuario
            {
                Id            = reader.GetInt32(0),
                Nombre        = reader.GetString(1),
                NumeroTarjeta = reader.GetString(2),
                PIN           = reader.GetString(3),
                Saldo         = reader.GetDouble(4)
            };
        }

        // Devuelve el saldo actual del usuario
        public double ObtenerSaldo(int idUsuario)
        {
            const string sql = "SELECT Saldo FROM Usuarios WHERE Id = @id;";

            using var con = ConexionDB.ObtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", idUsuario);

            var resultado = cmd.ExecuteScalar();
            return resultado != null ? Convert.ToDouble(resultado) : 0.0;
        }

        // Actualiza el saldo del usuario (para depósitos y retiros)
        public bool ActualizarSaldo(int idUsuario, double nuevoSaldo)
        {
            const string sql = "UPDATE Usuarios SET Saldo = @saldo WHERE Id = @id;";

            using var con = ConexionDB.ObtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@saldo", nuevoSaldo);
            cmd.Parameters.AddWithValue("@id",    idUsuario);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}