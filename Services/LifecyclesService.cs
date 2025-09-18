namespace MyFirstApi.Services;

public class LifecyclesService
{
    private readonly int _randomNumber;

    public int GetRandomNumber() => _randomNumber;

    public LifecyclesService()
    {
        _randomNumber = new Random().Next(1, 100);
    }
    
}