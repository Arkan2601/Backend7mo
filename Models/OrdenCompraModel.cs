using System;
namespace marcatel_api.Models
{
    public class GetOrdenCompraModel
    {
        public int Id { get; set; }
        public string IdProveedor { get; set; }
        public string FechaLlegada { get; set; }
        public string IdSurcursal { get; set; }
        public string IdComprador { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioActualiza { get; set; }
        public decimal Total {get; set;}
        public string Mensaje { get; set; }

    }

    public class InsertarOrdenCompraModel
    {
        public int IdProveedor { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int IdSucursal { get; set; }
        public int IdComprador { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateOrdenCompraModel
    {
        public int IdOrden { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int IdSurcursal{get; set;}
        public int IdComprador{get; set;}
        public int UsuarioActualiza {get; set;}
    }

    public class DeleteOrdenCompraModel
    {
        public int Id { get; set; }
    }

}