namespace CovidVaccineNotifier.Service
{
  using System;
  using CovidVaccineNotifier.Modal;
  using Microsoft.Toolkit.Uwp.Notifications;
  using Windows.Foundation.Metadata;
  using Windows.System.Profile;

  public class WindowsNotification : INotification
  {
    public void Notify(string message)
    {
      var toast = new ToastContentBuilder();
      toast.AddText(message);
      if (SupportsCustomAudio)
      {
        var path = "C:\\Windows\\Media\\Apps\\Notification.wav";
        toast.AddAudio(new Uri(path));
      }

      var expirationTime = DateTime.Now.AddMinutes(Settings.PollInterval);
      toast.Show(toast => toast.ExpirationTime = expirationTime);
    }

    private static bool SupportsCustomAudio
    {
      get
      {
        if (supportsCustomAudio == null)
        {
          supportsCustomAudio = DoesSystemSupportsCustomAudio();
        }

        return supportsCustomAudio.Value;
      }
    }

    private static bool? supportsCustomAudio;

    private static bool DoesSystemSupportsCustomAudio()
    {
      // If we're running on Desktop before Version 1511, do NOT include custom audio
      // since it was not supported until Version 1511, and would result in a silent toast.
      return !(AnalyticsInfo.VersionInfo.DeviceFamily.Equals("Windows.Desktop")
                    && !ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 2));
    }
  }
}