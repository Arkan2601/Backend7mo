using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
        public class ResponseTipoMovimiento
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyTipoMovimiento Response { get; set; }
    }

    public class ResponseBodyTipoMovimiento
    {
        public List<GetTipoMovimientoModel> data { get; set; }
    }

     public class InsertTipoMovimientoModel
    {
        public string Descripcion { get; set; }
        public int EntradaSalida {get; set;} //1 para entrada, 2 para salida
        public int UsuarioActualiza { get; set; }
        

    }





    public class GetTipoMovimientoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }
       public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public int EntradaSalida {get; set;}
        public string EntradaSalidaStr {get;set;}

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