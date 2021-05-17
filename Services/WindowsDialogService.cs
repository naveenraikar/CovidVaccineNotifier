namespace CovidVaccineNotifier.Service
{
  public class WindowsDialogService : INotification
  {
    private static AlertForm alert;

    public void Notify(string message)
    {
      if (alert != null && !alert.IsDisposed)
      {
        alert.Update(message);
        return;
      }

      alert = new AlertForm(message);
      alert.Show();
      alert.FormClosed += (o, e) => alert = null;
    }
  }
}