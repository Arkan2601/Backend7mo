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
    [ApiController]
    public class ReportKardexMovController : ControllerBase
    {
        private readonly ReportKardexMovService _reportKardexMovService;

        public ReportKardexMovController(ReportKardexMovService reportKardexMovService)
        {
            _reportKardexMovService = reportKardexMovService;
        }

[HttpGet("Get")]
public IActionResult GetReportKardexMov([FromQuery] string FechaInicio, string FechaFinal)
{
    var DOC = new GetReportKardexMovModel { FechaInicio = FechaInicio, FechaFinal = FechaFinal };
    var detalleOC = _reportKardexMovService.GetReportKardexMov(DOC);
    return Ok(detalleOC);
}
    }
}