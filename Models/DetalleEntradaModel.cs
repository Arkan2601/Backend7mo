using System;
namespace marcatel_api.Models
{
    public class GetDetalleEntradaModel
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal CantidadSinCargo { get; set; }
        public decimal Total { get; set; }
        public string FechaReg { get; set; }
        public string FechaAct { get; set; }
        public string UsuarioAct { get; set; }
        public string Mensaje { get; set; }

    }

     public class GetReportEntradasModel
    {
        public int Id { get; set; }
        public int Entrada_Ligada { get; set; }
        public string Codigo { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreSucursal { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal CantidadSinCargo { get; set; }
        public decimal Total { get; set; }
        public string Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
    }

    public class InsertDetalleEntradaModel
    {
        public int IdEntrada { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Descuento { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class UpdateDetalleEntradaModel
    {
        public int Id { get; set; }
        public int UsuarioActualiza { get; set; }
        public int Estatus { get; set; }

    }

    public class DeleteDetalleEntradaModel
    {
        public int Id { get; set; }
    }

    public class UpdateCantSinCargoModel
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
    }
}