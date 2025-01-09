﻿using RombiBack.Abstraction;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.Accesorios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RombiBack.Entities.ROM.ENTEL_RETAIL.Models.PlanificacionHorarios;

namespace RombiBack.Repository.ROM.ENTEL_TPF.MGM_MantenimientoTPF.MGM_AccesorioTPF
{
    public class AccesorioTPFRepository : IAccesorioTPFRepository
    {
        private readonly DataAcces _dbConnection;

        public AccesorioTPFRepository(DataAcces dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<Accesorio>> GetAccesorioRomWebTPF(int idemppaisnegcue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection.GetConnectionROMBI()))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("USP_GETACCESORIO", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@idemppaisnegcue", SqlDbType.Int).Value = idemppaisnegcue;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                List<Accesorio> response = new List<Accesorio>();

                                while (await reader.ReadAsync())
                                {
                                    Accesorio accesorioresponse = new Accesorio();

                                    accesorioresponse.idtipoaccesorio = reader.IsDBNull(reader.GetOrdinal("idtipoaccesorio"))
                                                                    ? null
                                                                    : reader.GetInt32(reader.GetOrdinal("idtipoaccesorio"));
                                    accesorioresponse.nombretipoaccesorio = reader.IsDBNull(reader.GetOrdinal("nombretipoaccesorio"))
                                                                    ? null
                                                                    : reader.GetString(reader.GetOrdinal("nombretipoaccesorio"));
                                    accesorioresponse.subtipoaccesorio = reader.IsDBNull(reader.GetOrdinal("subtipoaccesorio"))
                                                                    ? null
                                                                    : reader.GetString(reader.GetOrdinal("subtipoaccesorio"));
                                    accesorioresponse.categoriaaccesorio = reader.IsDBNull(reader.GetOrdinal("categoriaaccesorio"))
                                                                    ? null
                                                                    : reader.GetString(reader.GetOrdinal("categoriaaccesorio"));
                                    accesorioresponse.idemppaisnegcue = reader.IsDBNull(reader.GetOrdinal("idemppaisnegcue"))
                                                               ? null
                                                               : reader.GetInt32(reader.GetOrdinal("idemppaisnegcue"));
                                    accesorioresponse.estado = reader.IsDBNull(reader.GetOrdinal("estado"))
                                                               ? null
                                                               : reader.GetInt32(reader.GetOrdinal("estado"));
                                    accesorioresponse.usuariocreacion = reader.IsDBNull(reader.GetOrdinal("usuariocreacion"))
                                                                   ? null
                                                                   : reader.GetString(reader.GetOrdinal("usuariocreacion"));
                                    accesorioresponse.fechacreacion = (reader.IsDBNull(reader.GetOrdinal("fechacreacion"))
                                                                    ? (DateTime?)null
                                                                    : reader.GetDateTime(reader.GetOrdinal("fechacreacion")));
                                    accesorioresponse.usuariomodificacion = reader.IsDBNull(reader.GetOrdinal("usuariomodificacion"))
                                                                   ? null
                                                                   : reader.GetString(reader.GetOrdinal("usuariomodificacion"));
                                    accesorioresponse.fechamodificacion = (reader.IsDBNull(reader.GetOrdinal("fechamodificacion"))
                                                                    ? (DateTime?)null
                                                                    : reader.GetDateTime(reader.GetOrdinal("fechamodificacion")));

                                    response.Add(accesorioresponse);
                                }


                                return response;
                            }
                            else
                            {
                                // No se encontraron resultados
                                return new List<Accesorio>(); // Devuelve una lista vacía en lugar de null
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                // Por ejemplo, podrías registrar el error y devolver un mensaje de error adecuado
                Console.WriteLine("Error: " + ex.Message);
                throw; // O devuelve algún tipo de indicación de error adecuada
            }
        }

        public async Task<Respuesta> PostAccesesorioRomWebTPF(Accesorio accesorio)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection.GetConnectionROMBI()))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("USP_POSTACCESORIO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idtipoaccesorio", SqlDbType.Int).Value = accesorio.idtipoaccesorio;
                        cmd.Parameters.Add("@nombretipoaccesorio", SqlDbType.VarChar).Value = accesorio.nombretipoaccesorio;
                        cmd.Parameters.Add("@subtipoaccesorio", SqlDbType.VarChar).Value = accesorio.subtipoaccesorio;
                        cmd.Parameters.Add("@categoriaaccesorio", SqlDbType.VarChar).Value = accesorio.categoriaaccesorio;
                        cmd.Parameters.Add("@idemppaisnegcue", SqlDbType.Int).Value = accesorio.idemppaisnegcue;
                        cmd.Parameters.Add("@usuariocreacion", SqlDbType.VarChar).Value = accesorio.usuariocreacion;

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            Respuesta respuesta = new Respuesta();

                            while (await rdr.ReadAsync())
                            {
                                respuesta.Mensaje = rdr.GetString(rdr.GetOrdinal("Mensaje"));

                                // Manejar múltiples filas si es necesario
                                // Por ejemplo, almacenar cada resultado en una lista
                            }

                            return respuesta;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Código 2627 y 2601: Violación de restricción de clave única
                    throw new InvalidOperationException("Ya existe un accesorio con la misma descripción.");
                }
                else
                {
                    // Otros errores de base de datos
                    throw new InvalidOperationException("Ocurrió un error al insertar el accesorio.");
                }
            }
        }

        public async Task<Respuesta> DeleteAccesesorioRomWebTPF(Accesorio accesorio)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection.GetConnectionROMBI()))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("USP_DELETEACCESORIO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idtipoaccesorio", SqlDbType.VarChar).Value = accesorio.idtipoaccesorio;
                        cmd.Parameters.Add("@nombretipoaccesorio", SqlDbType.VarChar).Value = accesorio.nombretipoaccesorio;
                        cmd.Parameters.Add("@idemppaisnegcue", SqlDbType.Int).Value = accesorio.idemppaisnegcue;
                        cmd.Parameters.Add("@usuariomodificacion", SqlDbType.VarChar).Value = accesorio.usuariomodificacion;

                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            Respuesta respuesta = new Respuesta();

                            while (await rdr.ReadAsync())
                            {
                                respuesta.Mensaje = rdr.GetString(rdr.GetOrdinal("Mensaje"));

                                // Manejar múltiples filas si es necesario
                                // Por ejemplo, almacenar cada resultado en una lista
                            }

                            return respuesta;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Código 2627 y 2601: Violación de restricción de clave única
                    throw new InvalidOperationException("ERROR");
                }
                else
                {
                    // Otros errores de base de datos
                    throw new InvalidOperationException("Ocurrió un error ");
                }
            }
        }
    }
}
