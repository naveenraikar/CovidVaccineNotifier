namespace CovidVaccineNotifier
{
  using System.ComponentModel;
  using System.Drawing;
  using System.Windows.Forms;
  using CovidVaccineNotifier.Modal;

  partial class SettingsForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private IContainer components = null;

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
      this.SuspendLayout();

      this.btnDistrict.Text = "Search by District";
      this.btnDistrict.AutoSize = true;
      this.btnDistrict.Location = new Point(215, 25);
      this.btnDistrict.Click += SearchByDistrict;

      this.btnPincode.Text = "Search by PIN";
      this.btnPincode.AutoSize = true;
      this.btnPincode.Location = new Point(375, 25);
      this.btnPincode.Click += SearchByPincode;

      // State
      this.lblState.AutoSize = true;
      this.lblState.Location = new Point(0, 0);
      this.lblState.Text = "State : ";

      this.lblStateRequired.Location = new Point(50, 0);
      this.lblStateRequired.AutoSize = true;
      this.lblStateRequired.ForeColor = Color.Red;
      this.lblStateRequired.Text = "*";

      this.cbState.Location = new Point(85, 0);
      this.cbState.Size = new Size(250, 15);
      this.cbState.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbState.SelectedValueChanged += OnStateSelectedChanged;
      this.cbState.DisplayMember = nameof(State.state_name);
      this.cbState.ValueMember = nameof(State.state_id);
      this.cbState.TabIndex = 1;

      // District
      this.lblDistrict.AutoSize = true;
      this.lblDistrict.Location = new Point(360, 0);
      this.lblDistrict.Text = "District : ";

      this.lblDistrictRequired.Location = new Point(425, 0);
      this.lblDistrictRequired.AutoSize = true;
      this.lblDistrictRequired.ForeColor = Color.Red;
      this.lblDistrictRequired.Text = "*";

      this.cbDistrict.Location = new Point(445, 0);
      this.cbDistrict.Size = new Size(250, 15);
      this.cbDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbDistrict.DisplayMember = nameof(District.district_name);
      this.cbDistrict.ValueMember = nameof(District.district_id);
      this.cbDistrict.TabIndex = 2;

      this.pnlDistrict.Location = new Point(15, 75);
      this.pnlDistrict.AutoSize = true;
      this.pnlDistrict.Controls.Add(lblState);
      this.pnlDistrict.Controls.Add(lblStateRequired);
      this.pnlDistrict.Controls.Add(cbState);
      this.pnlDistrict.Controls.Add(lblDistrict);
      this.pnlDistrict.Controls.Add(lblDistrictRequired);
      this.pnlDistrict.Controls.Add(cbDistrict);
      this.pnlDistrict.Height = 35;

      // Pincode
      this.lblPincode.AutoSize = true;
      this.lblPincode.Location = new Point(0, 0);
      this.lblPincode.Text = "Pincode : ";

      this.lblPincodeRequired.Location = new Point(70, 0);
      this.lblPincodeRequired.AutoSize = true;
      this.lblPincodeRequired.ForeColor = Color.Red;
      this.lblPincodeRequired.Text = "*";

      this.txtPincode.Location = new Point(85, 0);
      this.txtPincode.Size = new Size(250, 15);
      this.txtPincode.KeyPress += AllowOnlyNumber;
      this.txtPincode.TabIndex = 3;

      this.pnlPincode.AutoSize = true;
      this.pnlPincode.Location = new Point(15, 75);
      this.pnlPincode.Controls.Add(lblPincode);
      this.pnlPincode.Controls.Add(lblPincodeRequired);
      this.pnlPincode.Controls.Add(txtPincode);
      this.pnlPincode.Height = 35;
      this.pnlPincode.Visible = false;

      // Vaccine
      this.lblVaccine.AutoSize = true;
      this.lblVaccine.Location = new Point(15, 115);
      this.lblVaccine.Text = "Vaccine : ";

      this.cbVaccine.Location = new Point(100, 115);
      this.cbVaccine.Size = new Size(250, 15);
      this.cbVaccine.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbVaccine.TabIndex = 4;

      // Fee
      this.lblFee.AutoSize = true;
      this.lblFee.Location = new Point(375, 115);
      this.lblFee.Text = "Fee : ";

      this.cbFee.Location = new Point(460, 115);
      this.cbFee.Size = new Size(250, 15);
      this.cbFee.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbFee.TabIndex = 5;

      // MinimumAge
      this.lblMinimumAge.AutoSize = true;
      this.lblMinimumAge.Location = new Point(15, 155);
      this.lblMinimumAge.Text = "Age : ";

      this.cbMinimumAge.Location = new Point(100, 155);
      this.cbMinimumAge.Size = new Size(250, 15);
      this.cbMinimumAge.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbMinimumAge.TabIndex = 6;

      // BlockName
      this.lblBlockName.AutoSize = true;
      this.lblBlockName.Location = new Point(375, 155);
      this.lblBlockName.Text = "Block : ";

      this.txtBlockName.Location = new Point(460, 155);
      this.txtBlockName.Size = new Size(250, 15);
      this.txtBlockName.TabIndex = 7;

      this.lblError.AutoSize = true;
      this.lblError.Location = new Point(345, 195);
      this.lblError.ForeColor = Color.Red;
      this.lblError.Visible = false;

      // Subscribe
      this.btnSubscribe.Text = "Subscribe";
      this.btnSubscribe.AutoSize = true;
      this.btnSubscribe.Location = new Point(350, 215);
      this.btnSubscribe.Click += Subscribe;

      this.gbAddSubscription.Location = new Point(15, 15);
      this.gbAddSubscription.Padding = new Padding(0, 0, 15, 0);
      this.gbAddSubscription.Text = "Add Subscription";
      this.gbAddSubscription.AutoSize = true;

      this.district.DataPropertyName = this.district.HeaderText = nameof(Subscription.District);
      this.pincode.DataPropertyName = this.pincode.HeaderText = nameof(Subscription.Pincode);
      this.vaccine.DataPropertyName = this.vaccine.HeaderText = nameof(Subscription.Vaccine);

      this.fee.DataPropertyName = nameof(Subscription.FeeType);
      this.fee.HeaderText = "Fee";

      this.age.DataPropertyName = nameof(Subscription.MinAgeLimit);
      this.age.HeaderText = "Min Age";

      this.block.DataPropertyName = nameof(Subscription.BlockName);
      this.block.HeaderText = "Block";

      this.delete.Image = Resources.DeleteImage;

      // 
      // grdSubscriptions
      // 
      ((System.ComponentModel.ISupportInitialize)(this.grdSubscriptions)).BeginInit();
      this.grdSubscriptions.AllowUserToAddRows = false;
      this.grdSubscriptions.BackgroundColor = SystemColors.Control;
      this.grdSubscriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.grdSubscriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdSubscriptions.Columns.AddRange(new DataGridViewColumn[] {
            this.district,
            this.pincode,
            this.vaccine,
            this.fee,
            this.age,
            this.block,
            this.delete
            });
      this.grdSubscriptions.Location = new Point(0, 0);
      this.grdSubscriptions.ReadOnly = true;
      this.grdSubscriptions.BorderStyle = BorderStyle.None;
      this.grdSubscriptions.AutoGenerateColumns = false;
      this.grdSubscriptions.ScrollBars = ScrollBars.Both;
      this.grdSubscriptions.Dock = DockStyle.Fill;
      this.grdSubscriptions.MultiSelect = true;
      this.grdSubscriptions.CellClick += grdSubscriptions_CellClick;
      this.grdSubscriptions.KeyDown += grdSubscriptions_KeyDown;
      this.delete.Width = 10;
      ((System.ComponentModel.ISupportInitialize)(this.grdSubscriptions)).EndInit();

      this.pnlSubscriptions.Location = new Point(15, 300);
      this.pnlSubscriptions.Size = new Size(735, 200);
      this.pnlSubscriptions.BackColor = Color.LightGray;
      this.pnlSubscriptions.Padding = new Padding(1, 0, 1, 1);
      this.pnlSubscriptions.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);

      this.pnlSubscriptions.Controls.Add(this.grdSubscriptions);
      // 
      // MainForm
      // 
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(760, 510);
      this.MinimumSize = new Size(780, 525);

      this.Icon = Resources.AppIcon;
      this.Text = "Covid Vaccine Notifier";

      this.gbAddSubscription.Controls.Add(this.btnDistrict);
      this.gbAddSubscription.Controls.Add(this.btnPincode);

      this.gbAddSubscription.Controls.Add(this.pnlPincode);
      this.gbAddSubscription.Controls.Add(this.pnlDistrict);

      this.gbAddSubscription.Controls.Add(this.lblVaccine);
      this.gbAddSubscription.Controls.Add(this.cbVaccine);

      this.gbAddSubscription.Controls.Add(this.lblFee);
      this.gbAddSubscription.Controls.Add(this.cbFee);

      this.gbAddSubscription.Controls.Add(this.lblMinimumAge);
      this.gbAddSubscription.Controls.Add(this.cbMinimumAge);

      this.gbAddSubscription.Controls.Add(this.lblBlockName);
      this.gbAddSubscription.Controls.Add(this.txtBlockName);

      this.gbAddSubscription.Controls.Add(this.lblError);
      this.gbAddSubscription.Controls.Add(this.btnSubscribe);

      this.Controls.Add(this.gbAddSubscription);
      this.Controls.Add(this.pnlSubscriptions);

      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void AllowOnlyNumber(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
      {
        e.Handled = true;
      }
    }
    #endregion

    private GroupBox gbAddSubscription = new();
    private Button btnDistrict = new();
    private Button btnPincode = new();
    private Panel pnlDistrict = new();
    private Panel pnlPincode = new();
    private Label lblState = new();
    private Label lblStateRequired = new();
    private ComboBox cbState = new();
    private Label lblDistrict = new();
    private Label lblDistrictRequired = new();
    private ComboBox cbDistrict = new();
    private Label lblPincode = new();
    private Label lblPincodeRequired = new();
    private TextBox txtPincode = new();
    private Label lblVaccine = new();
    private ComboBox cbVaccine = new();
    private Label lblFee = new();
    private ComboBox cbFee = new();
    private Label lblMinimumAge = new();
    private ComboBox cbMinimumAge = new();
    private Label lblBlockName = new();
    private TextBox txtBlockName = new();
    private Label lblError = new();
    private Button btnSubscribe = new();

    private Panel pnlSubscriptions = new();
    private DataGridView grdSubscriptions = new();
    private DataGridViewTextBoxColumn district = new();
    private DataGridViewTextBoxColumn pincode = new();
    private DataGridViewTextBoxColumn vaccine = new();
    private DataGridViewTextBoxColumn fee = new();
    private DataGridViewTextBoxColumn age = new();
    private DataGridViewTextBoxColumn block = new();

    private DataGridViewImageColumn delete = new DataGridViewImageColumn();
  }
}


