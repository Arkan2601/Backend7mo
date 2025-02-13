using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Collections.Generic;
using System.Linq;


namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class CfgColaboradoresController : ControllerBase
    {
        private readonly CfgColaboradoresService _CfgColaboradoresService;

        public CfgColaboradoresController(CfgColaboradoresService cfgColaboradores)
        {
            _CfgColaboradoresService = cfgColaboradores;
        }





        [HttpPost("Insert")]
public JsonResult InsertCfgColaboradores([FromBody] InsertCfgColaboradoresModel cfgColaboradores)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _CfgColaboradoresService.InsertCfgColaboradores(cfgColaboradores);

        // Suponemos que el mensaje de éxito contiene el ID del registro insertado
        if (catClienteResponse.Contains("Registro insertado con éxito", StringComparison.OrdinalIgnoreCase))
        {
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Registro insertado con éxito.";

            // Extraer el ID de la respuesta
            // Suponiendo que CatClienteResponse es algo como "Registro insertado con éxito. ID: 123"
           // int id = ExtractIdFromResponse(catClienteResponse);
            //objectResponse.response = new
            //{
              //  id = id // Agregamos el ID del registro insertado
            //};
        }
        else
        {
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false; // Cambiado a false para indicar un error
            objectResponse.message = "Error."; //+ catClienteResponse; // Incluye el mensaje de error de la SP

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
//private int ExtractIdFromResponse(string response)
//{
    // Suponiendo que la respuesta tiene el formato: "Registro insertado con éxito. ID: 123"
  //  var parts = response.Split(new[] { "Id: " }, StringSplitOptions.None);
    //if (parts.Length > 1 && int.TryParse(parts[1], out int id))
    //{
      //  return id; // Devuelve el ID extraído
    //}
    //return 0; // Devuelve 0 si no se puede extraer el ID
//}



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetCfgColaboradores() 
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseColabo result = new ResponseColabo();
            result.Response = new ResponseBodyCfgColaboradores();
            result.Response.data = new List<GetCfgColaboradoresModel>();

            var CfgColaboradoresResponse = _CfgColaboradoresService.GetCfgColaboradores();

            if (CfgColaboradoresResponse != null && CfgColaboradoresResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = CfgColaboradoresResponse;
                objectResponse.response = new
                {
                    data = result.Response.data
                };
            }
            else
            {
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Error = true;
                result.Success = false;
                result.Message = "Error al obtener la información.";
            }

            return new JsonResult(result);
        }


        [HttpPut("Update")]
        public JsonResult UpdateCfgColaboradoresResponse([FromBody] UpdateCfgColaboradoresModel cfgColaboradores)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _CfgColaboradoresService.UpdateCfgColaboradores(cfgColaboradores);

                string msgDefault = "Registro actualizado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Registro actualizado con éxito.";

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
public JsonResult DeleteCfgColaboradores([FromBody] DeleteCfgColaboradoresModel cfgColaboradores)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _CfgColaboradoresService.DeleteCfgColaboradores(cfgColaboradores);

        // Suponemos que el mensaje de éxito contiene la frase "Registro eliminado con éxito"
        if (catClienteResponse.Contains("Registro eliminado con éxito", StringComparison.OrdinalIgnoreCase))
        {
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Registro eliminado con éxito.";

            objectResponse.response = new
            {
                data = catClienteResponse
            };
        }
        else
        {
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false; // Cambiado a false para indicar un error
            objectResponse.message = "Error."; // + catClienteResponse; // Incluye el mensaje de error de la SP

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