using Microsoft.Data.SqlClient;
using Dapper;

static class BD
{

    public List<Integrantes> devolverEquipo(string Email, string Contraseña)
    {
        Integrantes integrante = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
             string query = "SELECT FROM Integrantes WHERE Email = @email AND Contraseña = @contraseña";
             integrante = connection.Query<Integrantes>(query, new {email = Email, contraseña = Contraseña});
        }
       return integrante;
    }
}
