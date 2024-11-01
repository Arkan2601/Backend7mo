using System;
namespace marcatel_api.Models
{
    public class GetExistenciasModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
         public int IdAlmacen { get; set; }
        public decimal Cantidad { get; set; }
         public string Fecha { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }

    }

    public class InsertExistenciasModel
    {
        public string Insumo { get; set; }
         public int IdAlmacen { get; set; } 
          public decimal Cantidad { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateExistenciasModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public int IdAlmacen { get; set; } 
       public decimal Cantidad { get; set; }
        public int UsuarioActualiza {get; set;}

    }

    public class DeleteExistenciasModel
    {
        public int Id { get; set; }
    }

}