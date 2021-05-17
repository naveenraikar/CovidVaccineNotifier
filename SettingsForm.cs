namespace CovidVaccineNotifier
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Threading.Tasks;
  using System.Windows.Forms;
  using CovidVaccineNotifier.Modal;
  using CovidVaccineNotifier.Service;

  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
    }

    protected override async void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      await LoadStates();

      var metadata = Metadata.Get();
      LoadVaccines(metadata);
      LoadFee(metadata);
      LoadAge(metadata);
      LoadSubscriptions();
    }

    private async void OnStateSelectedChanged(object sender, EventArgs e)
    {
      var state = cbState.SelectedItem as State;
      if (state != null)
      {
        await LoadDistricts(state.state_id);
      }
    }

    private void SearchByPincode(object sender, EventArgs e)
    {
      pnlPincode.Visible = true;
      pnlDistrict.Visible = false;
      lblError.Visible = false;
    }

    private void SearchByDistrict(object sender, EventArgs e)
    {
      pnlPincode.Visible = false;
      pnlDistrict.Visible = true;
      lblError.Visible = false;
    }

    private void Subscribe(object sender, EventArgs e)
    {
      btnSubscribe.Enabled = false;
      lblError.Visible = false;
      Subscription subscription = new();

      if (pnlDistrict.Visible)
      {
        var district = cbDistrict.SelectedItem as District;
        if (district == null || district.district_id == 0)
        {
          lblError.Text = "Select district.";
          lblError.Visible = true;
          btnSubscribe.Enabled = true;
          return;
        }

        subscription.DistrictId = district.district_id;
        subscription.District = district.district_name;
      }
      else
      {
        if (!int.TryParse(txtPincode.Text, out int pincode))
        {
          lblError.Text = "Enter Pincode.";
          lblError.Visible = true;
          btnSubscribe.Enabled = true;
          return;
        }
        subscription.Pincode = pincode;
      }

      if (!string.IsNullOrEmpty(cbVaccine.SelectedItem as string))
      {
        subscription.Vaccine = cbVaccine.SelectedItem.ToString();
      }

      if (!string.IsNullOrEmpty(cbFee.SelectedItem as string))
      {
        subscription.FeeType = cbFee.SelectedItem.ToString();
      }

      int.TryParse(cbMinimumAge.SelectedValue as string, out int age);
      if (age > 0)
      {
        subscription.MinAgeLimit = age;
      }

      if (!string.IsNullOrEmpty(txtBlockName.Text))
      {
        subscription.BlockName = txtBlockName.Text;
      }

      subscription.Add();
      LoadSubscriptions();
      btnSubscribe.Enabled = true;
    }

    private async Task LoadStates()
    {
      CowinService service = new();
      var states = await service.GetStates();
      cbState.DataSource = states;
    }

    private async Task LoadDistricts(int stateId)
    {
      CowinService service = new();
      var districts = await service.GetDistricts(stateId);
      cbDistrict.DataSource = districts;
    }

    private void LoadVaccines(Metadata metadata)
    {
      cbVaccine.DataSource = metadata.Vaccines;
    }

    private void LoadFee(Metadata metadata)
    {
      cbFee.DataSource = metadata.FeeTypes;
    }

    private void LoadAge(Metadata metadata)
    {
      cbMinimumAge.DataSource = new BindingSource(metadata.MinAgeLimit, null);
      cbMinimumAge.DisplayMember = "Value";
      cbMinimumAge.ValueMember = "Key";
    }

    private void LoadSubscriptions()
    {
      List<Subscription> subscriptions = Subscription.GetAll();

      BindingList<Subscription> dataSource = new(subscriptions);
      grdSubscriptions.DataSource = dataSource;
    }

    private void grdSubscriptions_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != grdSubscriptions.ColumnCount - 1 || e.RowIndex < 0)
      {
        return;
      }

      var subscription = grdSubscriptions.Rows[e.RowIndex].DataBoundItem as Subscription;
      if (subscription != null)
      {
        subscription.Delete();
        LoadSubscriptions();
      }
    }

    private void grdSubscriptions_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        var subscriptions = Subscription.GetAll();
        foreach (DataGridViewRow row in grdSubscriptions.SelectedRows)
        {
          var subscription = row.DataBoundItem as Subscription;
          if (subscription != null)
          {
            subscriptions.Remove(subscription);
          }
        }

        Subscription.Update(subscriptions);
        LoadSubscriptions();
      }
    }
  }
}
