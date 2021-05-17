namespace CovidVaccineNotifier
{
  using System.Collections.Generic;
  using System.IO;
  using CovidVaccineNotifier.Service;
  using Newtonsoft.Json;

  public class Subscription
  {
    [JsonProperty("districtId")]
    public int? DistrictId { get; set; }

    [JsonProperty("district")]
    public string District { get; set; }

    [JsonProperty("pincode")]
    public int? Pincode { get; set; }

    [JsonProperty("blockName")]
    public string BlockName { get; set; }

    [JsonProperty("feeType")]
    public string FeeType { get; set; }

    [JsonProperty("vaccine")]
    public string Vaccine { get; set; }

    [JsonProperty("minAgeLimit")]
    public int? MinAgeLimit { get; set; }

    private static List<Subscription> subscriptions;
    private static readonly string path = Directory.GetCurrentDirectory() + "\\Data\\Subscriptions.json";

    public static List<Subscription> GetAll()
    {
      if (subscriptions == null)
      {
        FileService file = new();
        subscriptions = file.Read<List<Subscription>>(path);

        if (subscriptions.Count == 0)
        {
          Logger.Instance.Log("Subscriptions not configured.");
        }
      }

      return subscriptions;
    }

    public void Add()
    {
      var subscriptions = GetAll();
      subscriptions.Add(this);
      Update(subscriptions);
    }

    public void Delete()
    {
      var subscriptions = Subscription.GetAll();
      subscriptions.Remove(this);
      Update(subscriptions);
    }

    public static void Update(List<Subscription> subscriptions)
    {
      FileService file = new();
      file.Write<List<Subscription>>(path, subscriptions);
    }
  }
}
