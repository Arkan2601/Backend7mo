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



        [HttpGet("ExportarMovimientosAExcel")]
        public IActionResult ExportarMovimientosAExcel()
        {
            try
            {
                var excelData = _movimientosService.ExportarMovimientosAExcel();


                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Movimientos.xlsx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error interno del servidor.");
            }
        }




        [HttpPost("Insert")]
        public JsonResult InsertarMovimiento([FromBody] InsertMovimientosModel movimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var MovModels = _movimientosService.InsertarMovimientos(movimiento);

                if (MovModels.Count > 0)
                {
                    var Id = MovModels[0].Id;
                    var Msg = MovModels[0].Mensaje;

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