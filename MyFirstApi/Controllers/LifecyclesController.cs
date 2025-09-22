using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LifecyclesController : ControllerBase
{
    private readonly LifecyclesService _service;
    private readonly LifecyclesSupportService _supportService;

    public LifecyclesController(LifecyclesService service, LifecyclesSupportService supportService)
    {
        _service = service;
        _supportService = supportService;
    }

    [HttpGet]
    public async Task<List<int>> Get()
    {
        var list = new List<int>
        {
            _service.GetRandomNumber()
        };
        await Task.Delay(1000);
        list.Add(_supportService.Get());
        await Task.Delay(1000);
        list.Add(_service.GetRandomNumber());
        return list;
    }
}