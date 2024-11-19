using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

        public class ResponsePersonas
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyPersonas Response { get; set; }
    }

    public class ResponseBodyPersonas
    {
        public List<GetPersonasModel> data { get; set; }
    }
    public class GetPersonasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string FechaAct { get; set; }
        public string FechaReg { get; set; }
        public string Mensaje { get; set; }


    }
    public class InsertPersonasModel
    {
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public int Usuario { get; set; }
        public string Pass { get; set; }
    }
    public class UpdatePersonasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public int Usuario { get; set; }

        public int Sucursal {get; set;}
    }
    public class DeletePersonasModel
    {
        public int Id { get; set; }
    }
}
