using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

    public class ResponseDTraspaso
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDT Response { get; set; }
    }

    public class ResponseBodyDT
    {
        public DataResponseDT data { get; set; }
    }

    public class DataResponseDT
    {
        public bool Status { get; set; }
        public string Mensaje { get; set; }
        // Cambia esto a una lista en lugar de un solo objeto
        public List<GetDetalleTraspasoModel> DetalleTraspaso { get; set; }
    }
    public class GetDetalleTraspasoModel
    {
        public int Id { get; set; }
        public int IdTraspaso { get; set; }
        public string Insumo { get; set; }
        public string AlmacenOrigen { get; set; }
        public string AlmacenDestino { get; set; }
        public decimal CantidadEnviada { get; set; }
        public decimal CatidadRecibida { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string UsuarioEnvía { get; set; }
        public string UsuarioRecibe { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }


    }

    public class InsertDetalleTraspasoModel
    {
        public int IdTraspaso { get; set; }
        public string Insumo { get; set; }
        public decimal CantidadEnviada { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateDetalleTraspasoModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public decimal CantidadEnviada { get; set; }
        public decimal CantidadRecibida { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class DeleteDetalleTraspasoModel
    {
        public int Id { get; set; }
    }


}
