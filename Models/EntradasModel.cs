using System;
namespace marcatel_api.Models
{
    public class GetEntradasModel
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }

        public string Factura { get; set; }
        public string Surcursal { get; set; }
        public string FechaEntrega { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int Estatus { get; set; }
        public string Mensaje { get; set; }

    }

    public class InsertEntradasModel
    {
        public int IdProveedor { get; set; }
        public string Factura { get; set; }
        public int IdSurcursal { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateEntradasModel
    {
        public int Id { get; set; }
        public string IdProveedor { get; set; }
         public string Factura {get; set;}
        public int IdSurcursal{get; set;}
        public DateTime FechaEntrega{get; set;}
        public int UsuarioActualiza {get; set;}
        public DateTime FechaActualiza { get; set; }

    }

    public class DeleteEntradasModel
    {
        public int Id { get; set; }
    }

}