using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{
      public class ResponseSucursales
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodySucursales Response { get; set; }
    }

    public class ResponseBodySucursales
    {
        public List<GetSucursalesModel> data { get; set; }
    }
    public class GetSucursalesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string FechaAct { get; set; }
        public string FechaReg { get; set; }


    }
    public class InsertSucursalesModel
    {

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }

    }
    public class UpdateSucursalesModel
    {   
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }
    }
    public class DeleteSucursalesModel
    {
        public int Id { get; set; }
    }
}
