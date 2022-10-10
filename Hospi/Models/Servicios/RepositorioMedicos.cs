using Dapper;
using System.Data.SqlClient;

namespace HospiEnCasa.Models.Servicios
{

    public interface IRepositorioMedicos
    {
        Task Crear(Medico medico);
        Task<bool> Existe(string code);
        Task<IEnumerable<Medico>> Obtener();
        Task Actualizar(Medico medico);
        Task<Medico> ObtenerporId(int id);
        Task<IEnumerable<Medico>> FiltroMedico(string nombre);
    }
    public class RepositorioMedicos : IRepositorioMedicos
    {
        private readonly string connectionString;

        public RepositorioMedicos(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task Crear(Medico medico)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO Medico (Nombre,Apellido, Codigo,Rethus,NumeroTelefono)
                                                 Values(@Nombre,@Apellido, @Codigo, @Rethus, @NumeroTelefono);
                                                 SELECT SCOPE_IDENTITY();", medico);
            medico.Id = id;
        }

        public async Task<bool> Existe(string code)
            {
            using var connection = new SqlConnection(connectionString);
             var  existe = await connection.QueryFirstOrDefaultAsync<int>(
                                                               @"select 1 from Medico where Codigo = @Codigo", new { codigo = code} 
                                                                );
            if (existe == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<Medico>> Obtener()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Medico>(@"SELECT Id,Nombre, Apellido, Codigo, Rethus 
                                                                FROM Medico");

        }

        public async Task Actualizar(Medico medico)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE Medico
                                           SET Nombre = @Nombre,Apellido = @Apellido,
                                           Rethus = @Rethus,
                                           NumeroTelefono = @NumeroTelefono 
                                           WHERE Id = @Id",
                                           medico);
        }
        public async Task<Medico> ObtenerporId (int id)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Medico>(@"SELECT Id,Nombre, Apellido,NumeroTelefono, Rethus
                                                                FROM Medico
                                                                WHERE Id = @Id ", new { id}
                                                                 );

        }
        public async Task<IEnumerable<Medico>> FiltroMedico (string nombre)
        {
            using var connection = new SqlConnection(connectionString); 
            return await connection.QueryAsync<Medico>(@"SELECT Id,Nombre, Apellido, Codigo, Rethus 
                                                                FROM Medico
                                                                 WHERE Nombre = @Nombre",new {nombre });
        }

    }
}
