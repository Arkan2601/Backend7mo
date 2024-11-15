using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

 public class ResponseModulos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyModulos Response { get; set; }
    }

    public class ResponseBodyModulos
    {
        public List<GetModulosModel> data { get; set; }
    }

    public class GetModulosModel
    {
        public int Id {get; set;}
        public string Modulo {get; set;}
        public string CategoriaModulo {get; set;}
        public string Usuario {get; set;}
        public string FechaAct {get; set;}
        public string FechaReg {get; set;}

    }
    public class InsertModulosModel
    {
        public string NombreModulo {get; set;}
        public int CategoriaModulo {get; set;}
        public int Usuario {get; set;}
  
    } 
    public class UpdateModulosModel
    {
        public int Id {get; set;}
        public string NombreModulo {get; set;}
        public int CategoriaModulo {get; set;}
        public int Usuario {get; set;}
    }
    public class DeleteModulosModel
    {
        public int Id {get; set;}
    }
}
