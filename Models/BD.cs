using Microsoft.Data.SqlClient;
using Dapper;
using TP06.Models;
using System.Collections.Generic;

public static class BD
{
    private static string _connectionString = @"Server=localhost; 
    DataBase = TP06-prog; Integrated Security=True; TrustServerCertificate=True;";

    public static Integrantes devolverIntegrante(string Nombre, string Contraseña)
    {
        Integrantes integrante = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
             string query = "SELECT * FROM Integrantes WHERE Nombre = @nombre AND Contraseña = @contraseña";
             integrante = connection.QueryFirstOrDefault<Integrantes>(query, new {nombre = Nombre, contraseña = Contraseña});
        }
       return integrante;
    }
    public static List<Integrantes> devolverGrupo(Integrantes integrante)
    {
        string Equipo = integrante.equipo;
        List<Integrantes> integrantes = new List<Integrantes>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
             string query = "SELECT * FROM Integrantes WHERE Equipo = @equipo";
             integrantes = connection.Query<Integrantes>(query, new {equipo = Equipo}).ToList();
        }
       return integrantes;
    }
    
}
