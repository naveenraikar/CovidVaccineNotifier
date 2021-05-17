namespace CovidVaccineNotifier.Modal
{
  public class VaccineAvailability
  {
    public string Location { get; set; }
    public string Date { get; set; }
    public string FeeType { get; set; }
    public int AvailableCapacity { get; set; }
    public string Vaccine { get; set; }
    public int? MinAgeLimit { get; set; }
  }
}
