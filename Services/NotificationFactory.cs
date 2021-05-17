namespace CovidVaccineNotifier.Service
{
  using System.Collections.Generic;

  public class NotificationFactory
  {
    public IEnumerable<INotification> GetNotifications()
    {
      yield return new WindowsNotification();
      yield return new WindowsDialogService();
    }
  }
}