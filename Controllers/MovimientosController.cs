using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;


namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly MovimientosService _movimientosService;

        public MovimientosController(MovimientosService movimientosService)
        {
            _movimientosService = movimientosService;
        }





        [HttpPost("Insert")]
public JsonResult InsertMovimientos([FromBody] InsertMovimientosModel movimientos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _movimientosService.InsertMovimientos(movimientos);

        // Suponemos que el mensaje de éxito contiene el ID del registro insertado
        if (catClienteResponse.Contains("Registro insertado con éxito", StringComparison.OrdinalIgnoreCase))
        {
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Éxito.";

            // Extraer el ID de la respuesta
            // Suponiendo que CatClienteResponse es algo como "Registro insertado con éxito. ID: 123"
            int id = ExtractIdFromResponse(catClienteResponse);
            objectResponse.response = new
            {
                id = id // Agregamos el ID del registro insertado
            };
        }
        else
        {
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false; // Cambiado a false para indicar un error
            objectResponse.message = "Error: " + catClienteResponse; // Incluye el mensaje de error de la SP

            objectResponse.response = new
            {
                data = catClienteResponse
            };
        }
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError; // Cambia a 500 en caso de excepción
        objectResponse.success = false;
        objectResponse.message = "Error interno del servidor: " + ex.Message;
    }

    return new JsonResult(objectResponse);
}

// Método auxiliar para extraer el ID del mensaje de respuesta
private int ExtractIdFromResponse(string response)
{
    // Suponiendo que la respuesta tiene el formato: "Registro insertado con éxito. ID: 123"
    var parts = response.Split(new[] { "Id: " }, StringSplitOptions.None);
    if (parts.Length > 1 && int.TryParse(parts[1], out int id))
    {
        return id; // Devuelve el ID extraído
    }
    return 0; // Devuelve 0 si no se puede extraer el ID
}



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetMovimientos() 
        {
            var movimientos = _movimientosService.GetMovimientos();
            return Ok(movimientos);
        }


        [HttpPut("Update")]
        public JsonResult UpdateMovimientos([FromBody] UpdateMovimientosModel movimientos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _movimientosService.UpdateMovimientos(movimientos);

                string msgDefault = "Registro actualizado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }



    [HttpPut("UpdateFechaAutoriza")]
        public JsonResult UpdateMovimientosAutoriza([FromBody] UpdateMovimientosAutorizaModel movimientos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _movimientosService.UpdateMovimientosAutoriza(movimientos);

                string msgDefault = "Registro actualizado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }



        [HttpPut("Delete")]
public JsonResult DeleteMovimientos([FromBody] DeleteMovimientosModel movimientos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _movimientosService.DeleteMovimientos(movimientos);

        // Suponemos que el mensaje de éxito contiene la frase "Registro eliminado con éxito"
        if (catClienteResponse.Contains("Registro eliminado con éxito", StringComparison.OrdinalIgnoreCase))
        {
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Éxito.";

            objectResponse.response = new
            {
                data = catClienteResponse
            };
        }
        else
        {
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false; // Cambiado a false para indicar un error
            objectResponse.message = "Error: " + catClienteResponse; // Incluye el mensaje de error de la SP

            objectResponse.response = new
            {
                data = catClienteResponse
            };
        }
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError; // Cambia a 500 en caso de excepción
        objectResponse.success = false;
        objectResponse.message = "Error interno del servidor: " + ex.Message;
    }

    return new JsonResult(objectResponse);
}

} 
}