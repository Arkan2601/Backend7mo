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
    public class DetalleMovimientosController : ControllerBase
    {
        private readonly DetalleMovimientosService _DetalleMovimientosService;

        public DetalleMovimientosController(DetalleMovimientosService detallemovimientosservice)
        {
            _DetalleMovimientosService = detallemovimientosservice;

        }





        [HttpPost("Insert")]
        public JsonResult InsertDetalleMovimientos([FromBody] InsertDetalleMovimientosModel dm)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleMovimientosService.InsertDetalleMovimientos(dm);

                string msgDefault = "Registro insertado con éxito.";

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



/*         [Authorize(AuthenticationSchemes = "Bearer")]
 */     [HttpGet("Get")]
        public IActionResult GetDetalleMovimientos([FromQuery] int idMovimiento)
        {
            var DOC = new GetDetalleMovimientosModel { IdMovimiento = idMovimiento };
            var detalleOC = _DetalleMovimientosService.GetDetalleMovimientos(DOC);
            return Ok(detalleOC);
        }

        [HttpPut("Update")]
        public JsonResult UpdateDetalleMovimientos([FromBody] UpdateDetalleMovimientosModel dm)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleMovimientosService.UpdateDetalleMovimientos(dm);

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
        public JsonResult DeleteDetalleMovimientos([FromBody] DeleteDetalleMovimientosModel dm)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleMovimientosService.DeleteDetalleMovimientos(dm);

                string msgDefault = "Registro eliminado con éxito.";

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


    }
}