using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;
using System.IO;
using ClosedXML.Excel;

namespace marcatel_api.Services
{
    public class DetalleTraspasoService
    {
        private string connection;
        public DetalleTraspasoService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        // public byte[] ExportarTraspasosAExcel()
        // {
        //     var listaTraspasos = GetDetalleTraspaso();


        //     using (var workbook = new XLWorkbook())
        //     {
        //         var worksheet = workbook.Worksheets.Add("Movimientos");


        //         worksheet.Cell(1, 1).Value = "Id";
        //         worksheet.Cell(1, 2).Value = "Traspaso Ligado";
        //         worksheet.Cell(1, 3).Value = "Insumo";
        //         worksheet.Cell(1, 4).Value = "Almacen de Origen";
        //         worksheet.Cell(1, 5).Value = "Almacen de Destino";
        //         worksheet.Cell(1, 6).Value = "Enviado";
        //         worksheet.Cell(1, 7).Value = "Recibido";
        //         worksheet.Cell(1, 8).Value = "Usuario que Envia";
        //         worksheet.Cell(1, 9).Value = "Usuario que Recibe";
        //         worksheet.Cell(1, 10).Value = "Fecha Registro";


        //         for (int i = 0; i < listaTraspasos.Count; i++)
        //         {
        //             var movimiento = listaTraspasos[i];
        //             worksheet.Cell(i + 2, 1).Value = movimiento.Id;
        //             worksheet.Cell(i + 2, 2).Value = movimiento.IdTraspaso;
        //             worksheet.Cell(i + 2, 3).Value = movimiento.Insumo;
        //             worksheet.Cell(i + 2, 4).Value = movimiento.AlmacenOrigen;
        //             worksheet.Cell(i + 2, 5).Value = movimiento.AlmacenDestino;
        //             worksheet.Cell(i + 2, 6).Value = movimiento.CantidadEnviada;
        //             worksheet.Cell(i + 2, 7).Value = movimiento.CatidadRecibida;
        //             worksheet.Cell(i + 2, 8).Value = movimiento.UsuarioEnvía;
        //             worksheet.Cell(i + 2, 9).Value = movimiento.UsuarioRecibe;
        //             worksheet.Cell(i + 2, 9).Value = movimiento.FechaRegistro;
        //         }

        //         worksheet.Columns().AdjustToContents();

        //         using (var stream = new MemoryStream())
        //         {
        //             workbook.SaveAs(stream);
        //             return stream.ToArray();
        //         }
        //     }
        // }

        public List<GetDetalleTraspasoModel> GetDetalleTraspaso(GetDetalleTraspasoModel traspaso)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTraspasoModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTraspaso", SqlDbType = SqlDbType.Int, Value = traspaso.IdTraspaso });
                // Si el procedimiento almacenado no necesita parámetros, no agregues ninguno
                DataSet ds = dac.Fill("sp_GetDetalleTraspaso", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleTraspasoModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdTraspaso = int.Parse(row["IdTraspaso"].ToString()),
                            Insumo = row["Insumo"].ToString(),
                            CantidadEnviada = decimal.Parse(row["CantidadEnviada"].ToString()),
                            CatidadRecibida = decimal.Parse(row["CantidadRecibida"].ToString()),
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


        public string InsertDetalleTraspaso(InsertDetalleTraspasoModel traspaso)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTraspasoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTraspaso", SqlDbType = SqlDbType.Int, Value = traspaso.IdTraspaso });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = traspaso.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidadEnviada", SqlDbType = SqlDbType.Decimal, Value = traspaso.CantidadEnviada });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = traspaso.UsuarioActualiza });



                DataSet ds = dac.Fill("sp_InsertDetalleTraspaso", parametros);

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

        public string UpdateDetalleTrasapaso(UpdateDetalleTraspasoModel traspaso)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTraspasoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = traspaso.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.Int, Value = traspaso.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidadEnviada", SqlDbType = SqlDbType.Decimal, Value = traspaso.CantidadEnviada });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidadRecibida", SqlDbType = SqlDbType.Decimal, Value = traspaso.CantidadRecibida });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = traspaso.UsuarioActualiza });
                DataSet ds = dac.Fill("sp_UpdateDetalleTraspaso", parametros);
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

        public string DeleteDetalleTraspaso(DeleteDetalleTraspasoModel traspaso)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTraspasoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = traspaso.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleTraspaso", parametros);
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