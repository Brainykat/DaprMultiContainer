using BrainyFrontEnd.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrainyFrontEnd.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;
    private readonly DaprClient _daprClient;
    public IndexModel(ILogger<IndexModel> logger, DaprClient daprClient)
    {
      _logger = logger;
      _daprClient = daprClient;
    }

    public async Task OnGet()
    {
      var forecasts = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
            HttpMethod.Get,
            "BrainyBackEnd",
            "weatherforecast");

      ViewData["WeatherForecastData"] = forecasts;
    }
  }
}