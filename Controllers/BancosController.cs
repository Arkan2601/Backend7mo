using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Linq;

namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class BancosController : ControllerBase
    {
        private readonly BancosService _bancosService;

        public BancosController(BancosService bancosservice)
        {
            _bancosService = bancosservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertBancos([FromBody] InsertBancosModel bancos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _bancosService.InsertBancos(bancos);

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



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetBancos()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseBancos result = new ResponseBancos();
            result.Response = new ResponseBodyBanco();
            result.Response.data = new DataResponseBanco();

            // Aquí llamamos al servicio para obtener los movimientos (que devuelve una lista)
            var BancoResponse = _bancosService.GetBancos();

            if (BancoResponse != null && BancoResponse.Any()) // Verificar si hay datos
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Éxito.";
                result.Response.data.Status = true;
                result.Response.data.Mensaje = "Información obtenida con éxito.";

                // Asignar toda la lista de movimientos
                result.Response.data.Bancos = BancoResponse;  // MovResponse es List<GetMovimientosModel>

                objectResponse.response = new
                {
                    data = result.Response.data.Bancos
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
        public JsonResult UpdateBancos([FromBody] UpdateBancosModel bancos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _bancosService.UpdateBancos(bancos);

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
        public JsonResult DeleteBancos([FromBody] DeleteBancosModel bancos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _bancosService.DeleteBancos(bancos);

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