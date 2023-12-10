namespace InnovaLab_TestTask.Services.Abstract;

public interface ICacheService
{
    T? Get<T>(string key);
    void Set<T>(string key, T value, TimeSpan? absoluteExpiration = null);
}