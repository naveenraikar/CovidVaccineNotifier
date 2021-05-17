namespace CovidVaccineNotifier.Modal
{
  using System.Collections.Generic;

  public class VaccineCenter
  {
    public int center_id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string state_name { get; set; }
    public string district_name { get; set; }
    public string block_name { get; set; }
    public int pincode { get; set; }
    public string fee_type { get; set; }
    public List<Session> sessions { get; set; }
  }

  public class Session
  {
    public string session_id { get; set; }
    public string date { get; set; }
    public int available_capacity { get; set; }
    public int min_age_limit { get; set; }
    public string vaccine { get; set; }
    public string[] slots { get; set; }
  }
}