using System;
namespace marcatel_api.Models
{
    public class GetDetalleOrdenCompraModel
    {
        public int Id { get; set; }
        public int IdOrdenCompra { get; set; }

        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadRecibida {get; set;}
        public decimal Costo {get; set;}
        public decimal CostoRenglon {get; set;}
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }

    }

    public class InsertDetalleOrdenCompraModel
    {
        public int IdOrdenCompra {get; set;}
        public string Insumo {get; set;}
        public decimal Cantidad {get; set;}

        public int UsuarioActualiza { get; set; }

    }

    public class UpdateDetalleOrdenCompraModel
    {
        public int Id { get; set; }
        public int IdOrdenCompra {get; set;}

        public decimal CantidadRecibida {get; set;}
        public int Estatus {get; set;}
        
        public int UsuarioActualiza { get; set; }
    }

    public class DeleteDetalleOrdenCompraModel
    {
        public int Id { get; set; }
    }

}