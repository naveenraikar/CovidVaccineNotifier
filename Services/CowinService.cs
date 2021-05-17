namespace CovidVaccineNotifier.Service
{
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;
  using CovidVaccineNotifier.Modal;
  using Newtonsoft.Json.Linq;

  public class CowinService
  {
    private const string baseUrl = "https://cdn-api.co-vin.in/api/v2/";

    private static HttpClient http = new();

    public async Task<List<State>> GetStates()
    {
      var states = await Get<List<State>>("admin/location/states", "states");
      return states;
    }

    public async Task<List<District>> GetDistricts(int stateId)
    {
      var districts = await Get<List<District>>($"admin/location/districts/{stateId}", "districts");
      return districts;
    }

    public async Task<List<VaccineCenter>> GetVaccineCentersInDistrict(int districtId, DateTime date)
    {
      string _date = date.ToString("dd-MM-yyyy");
      string url = $"appointment/sessions/public/calendarByDistrict?district_id={districtId}&date={_date}";
      var vaccineCenters = await Get<List<VaccineCenter>>(url, "centers");
      return vaccineCenters;
    }

    public async Task<List<VaccineCenter>> GetVaccineCentersBasedOnPincode(int pincode, DateTime date)
    {
      string _date = date.ToString("dd-MM-yyyy");
      string url = $"appointment/sessions/public/calendarByPin?pincode={pincode}&date={_date}";
      var vaccineCenters = await Get<List<VaccineCenter>>(url, "centers");
      return vaccineCenters;
    }

    private async Task<T> Get<T>(string url, string responseKey) where T : new()
    {
      try
      {
        var response = await http.GetStringAsync($"{baseUrl}{url}");
        var data = JObject.Parse(response);
        bool hasData = data.TryGetValue(responseKey, out JToken value);
        if (hasData)
        {
          return value.ToObject<T>();
        }
      }
      catch (HttpRequestException e)
      {
        Logger.Instance.LogExeption(e.Message);
      }

      return new T();
    }
  }
}