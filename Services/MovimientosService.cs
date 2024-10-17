using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class MovimientosService
    {
        private string connection;
        public MovimientosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


    public string InsertMovimientos(InsertMovimientosModel movimientos)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = movimientos.IdAlmacen });
        parametros.Add(new SqlParameter { ParameterName = "@pTipoMovimiento", SqlDbType = SqlDbType.Int, Value = movimientos.TipoMovimiento });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioRegistra });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAutoriza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioAutoriza });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioActualiza });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertMovimientos", parametros);

        // Comprobar si el procedimiento retornó alguna fila
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Capturando el valor del Id desde el resultado del procedimiento
            int nuevoId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
            return $"Registro insertado con éxito. Id: {nuevoId}";
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

        public List<GetMovimientosModel> GetMovimientos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovimientosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetMovimientos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovimientosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreAlmacen= row["NombreAlmacen"].ToString(),
                            TipoMovimiento= int.Parse(row["TipoMovimiento"].ToString()),
                            FechaCreacion= row["FechaCreacion"].ToString(),
                            FechaAutorizacion = row["FechaAutorizacion"].ToString(),
                            UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                            UsuarioAutoriza = row["UsuarioAutoriza"].ToString(),
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

        public string UpdateMovimientos(UpdateMovimientosModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = movimientos.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = movimientos.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pTipoMovimiento", SqlDbType = SqlDbType.Int, Value = movimientos.TipoMovimiento });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioRegistra });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAutoriza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioAutoriza });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateMovimientos", parametros);
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




           public string UpdateMovimientosAutoriza(UpdateMovimientosAutorizaModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateMovimientosAutorizaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = movimientos.Id });
           


                DataSet ds = dac.Fill("sp_UpdateFechaAutorizacion", parametros);
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



        public string DeleteMovimientos(DeleteMovimientosModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = movimientos.Id });
                DataSet ds = dac.Fill("sp_DeleteMovimientos", parametros);
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