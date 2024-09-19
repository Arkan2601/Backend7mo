using System;
namespace marcatel_api.Models
{
    public class GetEntradasModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }

        public string Factura {get; set;}
        public int IdSurcursal{get; set;}
        public DateTime FechaEntrega {get; set;}
        public DateTime FechaRegistro {get; set;}
        public DateTime FechaActualiza {get; set;}
        public int UsuarioActualiza {get; set;}
        public int Estatus{get; set;}
        
    }

    public class InsertEntradasModel
    {
        public int IdProveedor {get; set;}
        public string Factura {get; set;}
        public int IdSurcursal{get; set;}
        public int UsuarioActualiza {get; set;}
        
    }

    public class UpdateEntradasModel
    {
        public int Id { get; set; }
        public string IdProveedor { get; set; }
         public string Factura {get; set;}
        public int IdSurcursal{get; set;}
        public DateTime FechaEntrega{get; set;}
        public DateTime FechaActualiza {get; set;}
        public int UsuarioActualiza {get; set;}
    }

    public class DeleteEntradasModel
    {
        public int Id {get; set;}
    }

}