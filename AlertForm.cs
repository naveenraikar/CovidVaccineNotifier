namespace CovidVaccineNotifier
{
  using System;
  using System.Windows.Forms;

  public partial class AlertForm : Form
  {
    public AlertForm(string message)
    {
      InitializeComponent();
      Update(message);
    }

    public void Update(string message)
    {
      this.message.Text = message;
      this.date.Text = DateTime.Now.ToString("dd-MM-yyyy h:mm tt");
    }
  }
}
