using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ReportKardexMovService
    {
        private string connection;
        public ReportKardexMovService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }
        public List<GetReportKardexMovModel> GetReportKardexMov(GetReportKardexMovModel drk)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    var lista = new List<GetReportKardexMovModel>();

    if (string.IsNullOrEmpty(drk.FechaInicio))
    {
        drk.FechaInicio = DateTime.MinValue.ToString("yyyy-MM-dd");
    }
    if (string.IsNullOrEmpty(drk.FechaFinal))
    {
        drk.FechaFinal = DateTime.MaxValue.ToString("yyyy-MM-dd");
    }

    parametros.Add(new SqlParameter { ParameterName = "@pFechaInicio", SqlDbType = SqlDbType.Date, Value = drk.FechaInicio });
    parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.Date, Value = drk.FechaFinal });

    try
    {
        DataSet ds = dac.Fill("sp_ReportKardexMov", parametros);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(new GetReportKardexMovModel
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Movimiento_Ligado = int.Parse(row["Movimiento_Ligado"].ToString()),
                    TipoMovimiento = row["TipoMovimiento"].ToString(),
                    Sucursal = row["Sucursal"].ToString(),
                    Insumo = row["Insumo"].ToString(),
                    Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                    FechaRegistro = row["FechaRegistro"].ToString(),
                    FechaActualiza = row["FechaActualiza"].ToString(),
                    UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                    Estatus = row["Estatus"].ToString()
                });
            }
        }
        return lista;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw;
    }
}


        }

        


        

    }
