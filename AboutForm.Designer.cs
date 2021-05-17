namespace CovidVaccineNotifier
{
  using System;
  using System.ComponentModel;
  using System.Drawing;
  using System.Windows.Forms;

  partial class AboutForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private IContainer components;

    private Label content = new Label();

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

      this.content.Location = new Point(15, 15);
      this.content.AutoSize = true;
      this.content.Text = $"This app is developed by Naveen Raikar.{Environment.NewLine}Version 1.0.0";

      this.Controls.Add(content);

      this.AutoScaleMode = AutoScaleMode.Font;
      this.MinimizeBox = false;
      this.MaximizeBox = false;

      this.Size = this.MinimumSize = this.MaximumSize = new Size(350, 125);
      this.AutoSize = true;
      this.CenterToScreen();
    }

    #endregion
  }
}

