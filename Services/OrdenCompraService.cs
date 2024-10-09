using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class OrdenCompraService
    {
        private string connection;
        public OrdenCompraService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<GetOrdenCompraModel> InsertOrdenCompra(InsertarOrdenCompraModel orden)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetOrdenCompraModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdProveedor", SqlDbType = SqlDbType.Int, Value = orden.IdProveedor });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaLlegada", SqlDbType = SqlDbType.Date, Value = orden.FechaLlegada });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.Int, Value = orden.IdSurcursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdComprador", SqlDbType = SqlDbType.Int, Value = orden.IdComprador });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = orden.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertOrdenCompra", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetOrdenCompraModel
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

        public List<GetOrdenCompraModel> getOrdenCompras()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetOrdenCompraModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetOrdenCompra", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetOrdenCompraModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdProveedor = row["Proveedor"].ToString(),
                            FechaLlegada = row["FechaLlegada"].ToString(),
                            IdSurcursal = row["Sucursal"].ToString(),
                            IdComprador = row["Comprador"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            Total = decimal.Parse(row["Total"].ToString()),
                            UsuarioActualiza = row["Usuario"].ToString()
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

        public string UpdateOrdenCompra(UpdateOrdenCompraModel orden)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdOrdenCompra", SqlDbType = SqlDbType.Int, Value = orden.IdOrden });
                parametros.Add(new SqlParameter { ParameterName = "@pIdProveedor", SqlDbType = SqlDbType.Int, Value = orden.IdProveedor });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaLlegada", SqlDbType = SqlDbType.Date, Value = orden.FechaLlegada });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.Int, Value = orden.IdSurcursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdComprador", SqlDbType = SqlDbType.Int, Value = orden.IdComprador });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = orden.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateOrdenCompra", parametros);
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

        public string DeleteEntradas(DeleteEntradasModel entradas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = entradas.Id });
                DataSet ds = dac.Fill("sp_DeleteEntradas", parametros);
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