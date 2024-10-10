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
    public class OrdenCompraController : ControllerBase
    {
        private readonly OrdenCompraService _OrdenCompraService;

        public OrdenCompraController(OrdenCompraService ordenCompraService)
        {
            _OrdenCompraService = ordenCompraService;
        }





        [HttpPost("Insert")]
        public JsonResult InsertOrdenCompra([FromBody] InsertarOrdenCompraModel orden)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var ordenModels = _OrdenCompraService.InsertOrdenCompra(orden);

                if (ordenModels.Count > 0)
                {
                    var Id = ordenModels[0].Id;
                    var Msg = ordenModels[0].Mensaje;

                    string msgDefault = "Registro insertado con éxito.";

                    if (msgDefault == Msg)
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.OK;
                        objectResponse.success = true;
                        objectResponse.message = "Éxito.";

                        objectResponse.response = new
                        {
                            data = Id,
                            Msg
                        };
                    }
                    else
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        objectResponse.success = true;
                        objectResponse.message = "Error.";

                        objectResponse.response = new
                        {
                            data = Id,
                            Msg
                        };
                    }
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error: No se devolvió ningún resultado.";

                    objectResponse.response = null;
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);

        }



/*         [Authorize(AuthenticationSchemes = "Bearer")] */
        [HttpGet("Get")]
        public IActionResult GetOrdenCompras()
        {
            var orden = _OrdenCompraService.getOrdenCompras();
            return Ok(orden);
        }




        [HttpPut("Update")]
        public JsonResult UpdateOrdenCompra([FromBody] UpdateOrdenCompraModel orden)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _OrdenCompraService.UpdateOrdenCompra(orden);

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

/*         [HttpPut("Delete")]
        public JsonResult DeleteEntradas([FromBody] DeleteEntradasModel entradas)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _.DeleteEntradas(entradas);

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

        } */

    }
}