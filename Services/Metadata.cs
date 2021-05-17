namespace CovidVaccineNotifier
{
  using System.Collections.Generic;
  using System.IO;
  using CovidVaccineNotifier.Service;
  using Newtonsoft.Json;

  public class Metadata
  {
    [JsonProperty("feeTypes")]
    public string[] FeeTypes { get; set; }

    [JsonProperty("vaccines")]
    public string[] Vaccines { get; set; }

    [JsonProperty("minAgeLimit")]
    public Dictionary<string, string> MinAgeLimit { get; set; }

    private static readonly string path = Directory.GetCurrentDirectory() + "\\Data\\Metadata.json";

    public static Metadata Get()
    {
      FileService file = new();
      var metadata = file.Read<Metadata>(path);
      return metadata;
    }
  }
}
