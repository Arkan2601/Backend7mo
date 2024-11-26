using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class RolService
    {
        private string connection;
        public RolService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<GetRolModel> InsertRol(InsertRolModel rol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRolModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pRol", SqlDbType = SqlDbType.VarChar, Value = rol.Rol });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = rol.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertRol", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                   foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRolModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Mensaje = row["Mensaje"].ToString()
                        });
                    }
                }
                
                return lista;
            }
            catch (Exception ex)
            {
              throw ex;
            }
        }

        public List<GetRolModel> GetRol()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRolModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetRol", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRolModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Rol = row["Rol"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(), 
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString()

                           
                        });
                    }
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string UpdateRol(UpdateRolModel rol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = rol.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pRol", SqlDbType = SqlDbType.VarChar, Value = rol.Rol });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = rol.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateRol", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public string DeleteRol(DeleteRolModel rol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = rol.Id });
                DataSet ds = dac.Fill("sp_DeleteRol", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }


    }
}