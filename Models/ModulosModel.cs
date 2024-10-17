using System;
namespace marcatel_api.Models
{
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
