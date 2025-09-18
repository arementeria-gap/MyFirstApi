namespace MyFirstApi.Services;

public class LifecyclesSupportService
{
    private readonly LifecyclesService _service;

    public LifecyclesSupportService(LifecyclesService service)
    {
        _service = service;
    }
    public int Get()
    {
        return _service.GetRandomNumber();
    }
}