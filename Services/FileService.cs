namespace CovidVaccineNotifier.Service
{
  using System.IO;
  using Newtonsoft.Json;

  public class FileService
  {
    public T Read<T>(string path) where T : new()
    {
      if (!File.Exists(path))
      {
        return new T();
      }

      using var reader = new StreamReader(path);
      string json = reader.ReadToEnd();
      var data = JsonConvert.DeserializeObject<T>(json);
      return data;
    }

    public void Write<T>(string path, T data)
    {
      string json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore
      });

      File.WriteAllText(path, json);
    }
  }
}