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
    public class DetalleOrdenCompraController : ControllerBase
    {
        private readonly DetalleOrdenCompraService _detalleOrdenCompraService;

        public DetalleOrdenCompraController(DetalleOrdenCompraService detalleordencompraservice)
        {
            _detalleOrdenCompraService = detalleordencompraservice;
        }





        [HttpPost("Insert")]
          public JsonResult InsertDetalleOrdenCompra([FromBody] InsertDetalleOrdenCompraModel DOC)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _detalleOrdenCompraService.InsertDetalleOrdenCompra(DOC);

                string msgDefault = "Insumo agregado con éxito.";

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



        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetDetalleOrdenCompra( GetDetalleOrdenCompraModel DOC)
        {
            var detalleOrdenCompra = _detalleOrdenCompraService.GetDetalleOrdenCompra(DOC);
            return Ok(detalleOrdenCompra);
        }


        [HttpPut("Update")]
        public JsonResult UpdateDetalleOrdenCompra([FromBody] UpdateDetalleOrdenCompraModel DOC)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _detalleOrdenCompraService.UpdateDetalleOrdenCompra(DOC);

                string msgDefault = "Insumo actualizado con éxito.";

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
        public JsonResult DeleteDetalleOrdenCompra([FromBody] DeleteDetalleOrdenCompraModel DOC)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _detalleOrdenCompraService.DeleteDetalleOrdenCompra(DOC);

                string msgDefault = "Insumo eliminado con éxito";

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