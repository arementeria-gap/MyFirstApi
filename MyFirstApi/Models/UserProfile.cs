namespace MyFirstApi.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Theme { get; set; } = "light";
    public bool EnableNotifications { get; set; } = true;
    public string Language { get; set; } = "en-US";

    public UserProfile Clone()
    {
        return (UserProfile)this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"User: {UserName}, Theme: {Theme}, Notifications: {EnableNotifications}, Language: {Language}";
    }
}