using System.Collections.Generic;
// using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class OidcConfigurationController : Controller
    {
        // private readonly ILogger<OidcConfigurationController> _logger;

        // private IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        // public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger)
        // {
        //     ClientRequestParametersProvider = clientRequestParametersProvider;
        //     _logger = logger;
        // }
        //
        // [HttpGet("_configuration/{clientId}")]
        // public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        // {
        //     IDictionary<string, string> parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
        //     return Ok(parameters);
        // }
    }
}