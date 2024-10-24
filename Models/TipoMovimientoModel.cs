using System;
namespace marcatel_api.Models


{
     public class InsertTipoMovimientoModel
    {
        public string Descripcion { get; set; }
        public int UsuarioActualiza { get; set; }
        

    }





    public class GetTipoMovimientoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }
       public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }

        //public string Mensaje { get; set; }

    }

    

    public class UpdateTipoMovimientoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    


    public class DeleteTipoMovimientoModel
    {
        public int Id { get; set; }
    }

}