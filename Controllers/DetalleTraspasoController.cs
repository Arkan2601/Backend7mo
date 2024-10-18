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
    public class DetalleTraspasoController : ControllerBase
    {
        private readonly DetalleTraspasoService _DetalleTraspasoService;

        public DetalleTraspasoController(DetalleTraspasoService detalletraspasoservice)
        {
            _DetalleTraspasoService = detalletraspasoservice;

        }





        [HttpPost("Insert")]
        public JsonResult InsertDetalleTraspaso([FromBody] InsertDetalleTraspasoModel traspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTraspasoService.InsertDetalleTraspaso(traspaso);

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
        public IActionResult GetDetalleTraspaso([FromQuery] int idTraspaso)
        {
            var traspaso = new GetDetalleTraspasoModel { IdTraspaso = idTraspaso };
            var detalleTraspaso = _DetalleTraspasoService.GetDetalleTraspaso(traspaso);
            return Ok(detalleTraspaso);
        }

        [HttpPut("Update")]
        public JsonResult UpdateDetalleTraspaso([FromBody] UpdateDetalleTraspasoModel traspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTraspasoService.UpdateDetalleTrasapaso(traspaso);

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
        public JsonResult DeleteDetalleTraspaso([FromBody] DeleteDetalleTraspasoModel traspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTraspasoService.DeleteDetalleTraspaso(traspaso);

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