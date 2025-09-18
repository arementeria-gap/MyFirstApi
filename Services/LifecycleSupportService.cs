namespace MyFirstApi.Services;

public class LifecyclesSupportService(LifecyclesService service)
{
    private readonly LifecyclesService _service = service;

    public int Get()
    {
        return _service.GetRandomNumber();
    }
}