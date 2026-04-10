// Datos/ConexionDB.cs

using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace CajeroAutomatico.Datos
{
    public static class ConexionDB
    {
        private static readonly string _rutaBD = "cajero.db";

        public static string CadenaConexion => $"Data Source={_rutaBD};";

        // Devuelve una conexión abierta lista para usar
        public static SqliteConnection ObtenerConexion()
        {
            var conexion = new SqliteConnection(CadenaConexion);
            conexion.Open();
            return conexion;
        }

        // Crea las tablas leyendo el archivo init.sql
        // Se llama una sola vez desde Program.cs
        public static void InicializarBD()
        {
            string rutaScript = Path.Combine("Scripts", "init.sql");

            if (!File.Exists(rutaScript))
                throw new FileNotFoundException($"No se encontró: {rutaScript}");

            string sql = File.ReadAllText(rutaScript);

            using var conexion = ObtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}