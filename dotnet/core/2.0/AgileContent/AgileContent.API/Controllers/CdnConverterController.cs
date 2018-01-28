using System;
using AgileContent.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgileContent.API.Controllers
{
    [Produces("application/json")]
    [Route("/")]
    public class CdnConverterController : Controller
    {
        CDN _CDN;
        ILogger<CdnConverterController> _logger;

        public CdnConverterController(ILogger<CdnConverterController> logger, CDN CDN)
        {
            _logger = logger;
            _CDN = CDN;
        } 

        [HttpPost()]
        public IActionResult Post([FromBody]string sourceUrl, string targetPath)
        {
            try
            {
                _CDN.Converter("MINHA CDN", sourceUrl, targetPath);
                return Ok();
            }
            catch (Exception ex)
            {
                if (_logger != null) _logger.LogError($"Fail to submit logs: {ex}");
                return BadRequest("Fail to submit logs");
            }
        }

    }
}
