namespace CovidVaccineNotifier
{
  using System.ComponentModel;
  using System.Drawing;
  using System.Windows.Forms;

  partial class AlertForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private IContainer components;

    private Label message = new Label();
    private Label date = new Label();

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new Container();
      this.Icon = Resources.AppIcon;

      this.message.Location = new Point(15, 15);
      this.message.AutoSize = true;

      this.date.Location = new Point(15, 55);
      this.date.ForeColor = Color.Gray;
      this.date.AutoSize = true;

      this.Controls.Add(message);
      this.Controls.Add(date);

      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(500, 100);
      this.AutoSize = true;
      this.MaximizeBox = false;
      this.CenterToScreen();
    }

    #endregion
  }
}

