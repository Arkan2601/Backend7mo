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
    public class DetalleRecetaController : ControllerBase
    {
        private readonly DetalleRecetaService _DetalleRecetaService;

        public DetalleRecetaController(DetalleRecetaService detallerecetaservice)
        {
            _DetalleRecetaService = detallerecetaservice;

        }





        [HttpPost("Insert")]
        public JsonResult InsertDetalleReceta([FromBody] InsertDetalleRecetaModel dr)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleRecetaService.InsertDetalleReceta(dr);

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



        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")]
        public IActionResult GetDetalleReceta(GetDetalleRecetaModel dr)
        {
            var DR = _DetalleRecetaService.GetDetalleReceta(dr);
            return Ok(DR);
        }

        [HttpPut("Update")]
        public JsonResult UpdateDetalleReceta([FromBody] UpdateDetalleRecetaModel dr)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleRecetaService.UpdateDetalleReceta(dr);

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
        public JsonResult DeleteDetalleReceta([FromBody] DeleteDetalleRecetaModel dr)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleRecetaService.DeleteDetalleReceta(dr);

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