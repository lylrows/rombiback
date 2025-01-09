using Microsoft.Extensions.Configuration;
using RombiBack.Abstraction;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Bundles;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Ventas;
using RombiBack.Security.Model.UserAuth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RombiBack.Repository.ROM.ENTEL_RETAIL.MGM_Mantenimiento.MGM_Bundles
{
    public class BundleRepository : IBundleRepository
    {
        private readonly DataAcces _dbConnection;
        private readonly string _AWSMessageCA;

        public BundleRepository(DataAcces dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            var awsOptions = configuration.GetSection("AWSCredentials");
            _AWSMessageCA = awsOptions["AWSMessageCA"];
        }
        public async Task<List<Bundle>> GetBundles(int idcodigo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection.GetConnectionENTEL_RETAIL()))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("select Id,Descripcion,Status from bundles where CadenaId=0", connection))
                    {
                        command.CommandType = CommandType.Text;
                        //command.Parameters.Add("@idcodigo", SqlDbType.Int).Value = idcodigo;


                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            List<Bundle> response = new List<Bundle>();

                            while (await reader.ReadAsync())
                            {
                                Bundle bundles = new Bundle();


                                //idbundle = reader["idbundle"] != DBNull.Value ? Convert.ToInt32(reader["idbundle"]) : 0,
                                //codigobundle = reader["codigobundle"]?.ToString() ?? "",
                                //nombrebundle = reader["nombrebundle"]?.ToString() ?? "",
                                //flagauthmessage = reader["flagauthmessage"] != DBNull.Value ? Convert.ToInt32(reader["flagauthmessage"]) : 0,
                                //estado = reader["estado"] != DBNull.Value ? Convert.ToInt32(reader["estado"]) : 0,

                                bundles.Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                                //codigobundle = reader["codigobundle"]?.ToString() ?? "",
                                bundles.Descripcion = reader["Descripcion"]?.ToString() ?? "";
                                //flagauthmessage = reader["flagauthmessage"] != DBNull.Value ? Convert.ToInt32(reader["flagauthmessage"]) : 0,
                                bundles.Status = reader["Status"]?.ToString() ?? "";





                                response.Add(bundles);
                            }
                            return response;

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public async Task UpdateBundle(int idcodigo, string estado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection.GetConnectionENTEL_RETAIL()))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("UPDATE bundles SET Status = @estado WHERE Id = @idcodigo ", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                        command.Parameters.Add("@idcodigo", SqlDbType.Int).Value = idcodigo;

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        // Puedes manejar el resultado aquí si lo necesitas
                        if (rowsAffected == 0)
                        {
                            // No se encontró el registro o el estado no era 'I'
                            throw new Exception("No se pudo actualizar el estado. Puede que el ID no exista o el estado no sea 'I'.");
                        }
                        if (rowsAffected > 0)
                        {
                            // No se encontró el registro o el estado no era 'I'
                            Console.Write("Correcto");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

    }
}
