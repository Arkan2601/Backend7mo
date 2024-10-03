using System;
namespace marcatel_api.Models
{
    public class GetProveedoresModel
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public int IdBanco {get; set;}
       public int PlazoPago {get; set;}
       public string Correo {get; set;}
       public string RFC {get; set;}
        public string RazonSocial {get; set;}
        public string CLABE {get; set;}
        public DateTime FechaRegistro {get; set;}
        public DateTime FechaActualiza {get; set;}
        public string UsuarioActualiza {get; set;}

    }
    public class InsertProveedoresModel
    {
       public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public int IdBanco {get; set;}
        public int PlazoPago {get; set;}
        public string Correo {get; set;}
        public string RFC {get; set;}
        public string RazonSocial {get; set;}
        public string CLABE {get; set;}
        public int UsuarioActualiza {get; set;}

  
    } 
    public class UpdateProveedoresModel
    {
       public int Id {get; set;}
       public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public int IdBanco {get; set;}
        public int PlazoPago {get; set;}
        public string Correo {get; set;}
        public string RFC {get; set;}
        public string RazonSocial {get; set;}
        public string CLABE {get; set;}
        public int UsuarioActualiza {get; set;}

    }
    public class DeleteProveedoresModel
    {
        public int Id {get; set;}
    }
}