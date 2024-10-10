using System;
namespace marcatel_api.Models
{
    public class GetBancosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }

    }

    public class InsertBancosModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateBancosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
         public string Direccion {get; set;}
         public int UsuarioActualiza {get; set;}

    }

    public class DeleteBancosModel
    {
        public int Id { get; set; }
    }

}