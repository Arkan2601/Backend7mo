using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;


namespace marcatel_api.Services
{
    public class DetalleEntradaService
    {
        private string connection;
        public DetalleEntradaService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetDetalleEntradaModel> GetDetalleEntrada(GetDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdEntrada", SqlDbType = SqlDbType.Int, Value = de.IdEntrada });

                DataSet ds = dac.Fill("sp_GetDetalleEntrada", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleEntradaModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdEntrada = int.Parse(row["IdEntrada"].ToString()),
                            Codigo = row["Codigo"].ToString(),
                            Articulo = row["Articulo"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            Costo = decimal.Parse(row["Cantidad"].ToString()),
                            Descuento = decimal.Parse(row["Cantidad"].ToString()),
                            MontoDescuento = decimal.Parse(row["Cantidad"].ToString()),
                            CantidadSinCargo = decimal.Parse(row["Cantidad"].ToString()),
                            Total = decimal.Parse(row["Cantidad"].ToString()),
                            FechaAct = DateTime.Parse(row["FechaActualiza"].ToString()),
                            FechaReg = DateTime.Parse(row["FechaRegistra"].ToString()),
                            UsuarioAct = row["UsuarioActualiza"].ToString()

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

        public string InsertDetalleEntrada(InsertDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdEntrada", SqlDbType = SqlDbType.Int, Value = de.IdEntrada });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = de.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = de.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pCosto", SqlDbType = SqlDbType.Decimal, Value = de.Costo });
                parametros.Add(new SqlParameter { ParameterName = "@pDescuento", SqlDbType = SqlDbType.Decimal, Value = de.Descuento });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidadSinCargo", SqlDbType = SqlDbType.Decimal, Value = de.CantidadSinCargo });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = de.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertDetalleEntrada", parametros);

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

        public string UpdateDetalleEntrada(UpdateDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = de.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = de.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = de.Estatus });
                DataSet ds = dac.Fill("sp_UpdateDetalleEntrada", parametros);
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

        public string DeleteDetalleEntrada(DeleteDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = de.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleEntrada", parametros);
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
