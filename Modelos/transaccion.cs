// Datos/TransaccionDAO.cs

using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CajeroAutomatico.Modelos;

namespace CajeroAutomatico.Datos
{
    public class TransaccionDAO
    {
        // Inserta una nueva transacción en el historial
        public bool InsertarTransaccion(int usuarioId, string tipo, double monto)
        {
            const string sql = @"
                INSERT INTO Transacciones (UsuarioId, Tipo, Monto)
                VALUES (@usuarioId, @tipo, @monto);";

            using var con = ConexionDB.ObtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
            cmd.Parameters.AddWithValue("@tipo",      tipo);
            cmd.Parameters.AddWithValue("@monto",     monto);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Devuelve todas las transacciones de un usuario
        public List<Transaccion> ObtenerHistorial(int usuarioId)
        {
            var lista = new List<Transaccion>();

            const string sql = @"
                SELECT Id, UsuarioId, Tipo, Monto, Fecha
                FROM Transacciones
                WHERE UsuarioId = @usuarioId
                ORDER BY Fecha DESC;";

            using var con = ConexionDB.ObtenerConexion();
            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Transaccion
                {
                    Id        = reader.GetInt32(0),
                    UsuarioId = reader.GetInt32(1),
                    Tipo      = reader.GetString(2),
                    Monto     = reader.GetDouble(3),
                    Fecha     = reader.GetString(4)
                });
            }

            return lista;
        }
    }
}