using System;
namespace marcatel_api.Models
{
    public class GetDetalleMovimientosModel
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }

    }

    public class InsertDetalleMovimientosModel
    {
         public int IdMovimiento { get; set; } 
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateDetalleMovimientosModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public int UsuarioActualiza {get; set;}
        public int Estatus { get; set; }

    }

    public class DeleteDetalleMovimientosModel
    {
        public int Id { get; set; }
    }

}