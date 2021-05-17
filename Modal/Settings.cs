
namespace CovidVaccineNotifier.Modal
{
  using System.Collections.Generic;
  using System.IO;
  using CovidVaccineNotifier.Service;

  public class Settings
  {
    private static readonly string path = Directory.GetCurrentDirectory() + "\\Data\\Settings.json";
    public static int? pollInterval;
    public static int PollInterval
    {
      get
      {
        return pollInterval ??= GetPollInterval();
      }
    }

    private static int GetPollInterval()
    {
      var file = new FileService();
      var settings = file.Read<Dictionary<string, int>>(path);
      return settings.GetValueOrDefault(nameof(pollInterval), 60);
    }
  }
}