namespace CovidVaccineNotifier
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Linq;
  using System.Threading.Tasks;
  using System.Windows.Forms;
  using CovidVaccineNotifier.Modal;
  using CovidVaccineNotifier.Service;

  public class AppContext : ApplicationContext
  {
    private IContainer components;
    private NotifyIcon trayIcon;
    private ContextMenuStrip systemTrayMenu;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private AboutForm aboutForm;
    private SettingsForm settingsForm;
    private Form hiddenForm;

    private System.Threading.Timer timer;

    public AppContext()
    {
      InitializeContext();
      InitializeHiddenForm();
      ShowEditor();

      timer = new(
        e => CheckVaccineAvailability(),
        null,
        TimeSpan.Zero,
        TimeSpan.FromMinutes(Settings.PollInterval));
    }

    private void ShowEditor()
    {
      var subscriptions = Subscription.GetAll();
      if (subscriptions.Count == 0)
      {
        ShowSettingsEditor();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeContext()
    {
      this.components = new Container();
      this.trayIcon = new NotifyIcon(this.components);
      this.systemTrayMenu = new ContextMenuStrip(this.components);
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.settingsToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.systemTrayMenu.SuspendLayout();

      // 
      // trayIcon
      // 
      this.trayIcon.ContextMenuStrip = this.systemTrayMenu;
      this.trayIcon.Icon = Resources.AppIcon;
      this.trayIcon.Text = "Covid Vaccine Notifier";
      this.trayIcon.Visible = true;

      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Size = new Size(131, 24);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += (sender, e) => ShowAboutEditor();

      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Size = new Size(131, 24);
      this.settingsToolStripMenuItem.Text = "Settings";
      this.settingsToolStripMenuItem.Click += (sender, e) => ShowSettingsEditor();
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Size = new Size(131, 24);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += Exit;

      // 
      // systemTrayMenu
      // 
      this.systemTrayMenu.ImageScalingSize = new Size(20, 20);
      this.systemTrayMenu.Items.AddRange(new ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.systemTrayMenu.Size = new Size(132, 52);

      this.systemTrayMenu.ResumeLayout(false);
    }

    private void InitializeHiddenForm()
    {
      hiddenForm = new Form();
      NativeWindow.FromHandle(hiddenForm.Handle);
    }

    private void ShowSettingsEditor()
    {
      if (settingsForm != null && !settingsForm.IsDisposed)
      {
        settingsForm.Activate();
        return;
      }

      settingsForm = new SettingsForm();
      settingsForm.Show();
      settingsForm.FormClosed += (sender, e) => { settingsForm = null; };
    }

    private void ShowAboutEditor()
    {
      if (aboutForm != null && !aboutForm.IsDisposed)
      {
        aboutForm.Activate();
        return;
      }

      aboutForm = new AboutForm();
      aboutForm.Show();
      aboutForm.FormClosed += (sender, e) => { aboutForm = null; };
    }

    void Exit(object sender, EventArgs e)
    {
      trayIcon.Visible = false;
      Application.Exit();
    }

    private async void CheckVaccineAvailability()
    {
      var subscriptions = Subscription.GetAll();
      foreach (var s in subscriptions)
      {
        DateTime date = DateTime.Now;
        for (int i = 0; i < 4; i++)
        {
          var vaccineAvailability = await GetVaccineAvailability(date, s);
          if (vaccineAvailability != null)
          {
            string message = GetMessage(vaccineAvailability);
            Notify(message);
            break;
          }

          date = date.AddDays(7);
        }
      }
    }

    private static string GetMessage(VaccineAvailability vaccineAvailability)
    {
      return $"{vaccineAvailability.Vaccine} is available at {vaccineAvailability.Location} on {vaccineAvailability.Date}." +
      Environment.NewLine + $"Number of dosages available : {vaccineAvailability.AvailableCapacity}";
    }

    private void Notify(string message)
    {
      hiddenForm.Invoke(new MethodInvoker(() =>
      {
        var factory = new NotificationFactory();
        foreach (var notificationService in factory.GetNotifications())
        {
          notificationService.Notify(message);
        }
      }));
    }

    private async Task<VaccineAvailability> GetVaccineAvailability(DateTime date, Subscription options)
    {
      CowinService service = new();
      List<VaccineCenter> vaccineCenters;

      if (options.Pincode != null)
      {
        vaccineCenters = await service.GetVaccineCentersBasedOnPincode(options.Pincode.Value, date);
      }
      else if (options.DistrictId != null)
      {
        vaccineCenters = await service.GetVaccineCentersInDistrict(options.DistrictId.Value, date);
      }
      else
      {
        return null;
      }

      var centers = vaccineCenters.Where(c =>
        (options.FeeType == null || c.fee_type == options.FeeType) &&
        (options.BlockName == null || c.block_name == options.BlockName));

      foreach (var center in centers)
      {
        foreach (var session in center.sessions)
        {
          if ((options.MinAgeLimit == null || options.MinAgeLimit == session.min_age_limit) &&
              (options.Vaccine == null || options.Vaccine == session.vaccine) &&
              session.available_capacity > 0)
          {
            return new VaccineAvailability
            {
              Location = GetLocation(center),
              FeeType = center.fee_type,
              Date = session.date,
              AvailableCapacity = session.available_capacity,
              Vaccine = session.vaccine,
              MinAgeLimit = session.min_age_limit
            };
          }
        }
      }

      return null;
    }

    private static string GetLocation(VaccineCenter center)
    {
      string location;
      if (!string.IsNullOrEmpty(center.block_name) && center.block_name != "Not Applicable")
      {
        location = center.block_name;
      }
      else
      {
        location = $"{center.district_name} district";
      }

      return location;
    }
  }
}