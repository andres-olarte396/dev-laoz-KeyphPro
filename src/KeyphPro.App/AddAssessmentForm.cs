namespace KeyphPro.App
{
    using KeyphPro.Domain.Entities.Models;
    using KeyphPro.Domain.Services;
    using System;
    using System.Windows.Forms;

    public class AddAssessmentForm : Form
    {
        private readonly IAssessmentService _assessmentService;
        private Label lblDate, lblHeight, lblWeight, lblBMI, lblBodyFat, lblMuscleMass, lblDailyCalories;
        private Label lblShoulder, lblArm, lblWaist, lblHip, lblLeg, lblCalf, lblMetabolicState;
        private TextBox txtWeight, txtHeight, txtBMI, txtBodyFat, txtMuscleMass, txtDailyCalories;
        private TextBox txtShoulder, txtArm, txtWaist, txtHip, txtLeg, txtCalf;
        private ComboBox cmbMetabolicState;
        private DateTimePicker dtpDate;
        private Button btnSave;

        public AddAssessmentForm(IAssessmentService assessmentService)
        {
            Text = "Add Assessment";
            Size = new System.Drawing.Size(400, 660);
            _assessmentService = assessmentService;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Labels
            lblDate = CreateLabel("Date:", 20, 20);
            lblWeight = CreateLabel("Weight (kg):", 20, 60);
            lblHeight = CreateLabel("Height (cm):", 20, 100);
            lblBodyFat = CreateLabel("Body Fat (%):", 20, 140);
            lblMuscleMass = CreateLabel("Muscle Mass (%):", 20, 180);
            lblDailyCalories = CreateLabel("Daily Calories:", 20, 220);
            lblShoulder = CreateLabel("Shoulder (cm):", 20, 260);
            lblArm = CreateLabel("Arm (cm):", 20, 300);
            lblWaist = CreateLabel("Waist (cm):", 20, 340);
            lblHip = CreateLabel("Hip (cm):", 20, 380);
            lblLeg = CreateLabel("Leg (cm):", 20, 420);
            lblCalf = CreateLabel("Calf (cm):", 20, 460);
            lblMetabolicState = CreateLabel("Metabolic State:", 20, 500);
            lblBMI = CreateLabel("BMI (Auto-Calculated):", 20, 540);

            // Controls
            dtpDate = new DateTimePicker
            {
                Location = new System.Drawing.Point(180, 20),
                Enabled = false,
                Width = 180,
                Value = DateTime.Now,
                Format = DateTimePickerFormat.Short
            };
            txtWeight = CreateTextBox(180, 60, true);
            txtHeight = CreateTextBox(180, 100, true);
            txtBodyFat = CreateTextBox(180, 140, true);
            txtMuscleMass = CreateTextBox(180, 180, true);
            txtDailyCalories = CreateTextBox(180, 220, true);
            txtShoulder = CreateTextBox(180, 260, true);
            txtArm = CreateTextBox(180, 300, true);
            txtWaist = CreateTextBox(180, 340, true);
            txtHip = CreateTextBox(180, 380, true);
            txtLeg = CreateTextBox(180, 420, true);
            txtCalf = CreateTextBox(180, 460, true);
            txtBMI = CreateTextBox(180, 540, true);
            txtBMI.Enabled = false;
            cmbMetabolicState = new ComboBox
            {
                Location = new System.Drawing.Point(180, 500),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "Normal", "Altered", "Not Measured" },
                SelectedIndex = 0,
                Width = 180
            };

            // Save Button
            btnSave = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(150, 580),
                AutoSize = true,
                Width = 100
            };
            btnSave.Click += BtnSave_Click;

            // Add Controls to Form
            Controls.AddRange(
            [
                lblDate, dtpDate,
                lblWeight, txtWeight,
                lblHeight, txtHeight,
                lblBMI, txtBMI,
                lblBodyFat, txtBodyFat,
                lblMuscleMass, txtMuscleMass,
                lblDailyCalories, txtDailyCalories,
                lblShoulder, txtShoulder,
                lblArm, txtArm,
                lblWaist, txtWaist,
                lblHip, txtHip,
                lblLeg, txtLeg,
                lblCalf, txtCalf,
                lblMetabolicState, cmbMetabolicState,
                btnSave
            ]);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // Basic Input Validation
            if (string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtBodyFat.Text) ||
                string.IsNullOrWhiteSpace(txtMuscleMass.Text) || string.IsNullOrWhiteSpace(cmbMetabolicState.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Example: Save Logic
            try
            {
                var assessment = new AssessmentModel
                {
                    Date = dtpDate.Value,
                    Weight = decimal.Parse(txtWeight.Text),
                    Heigth = decimal.Parse(txtHeight.Text),
                    BodyFatPercentage = decimal.Parse(txtBodyFat.Text),
                    MuscleMassPercentage = decimal.Parse(txtMuscleMass.Text),
                    DailyCalories = int.Parse(txtDailyCalories.Text),
                    Shoulder = decimal.Parse(txtShoulder.Text),
                    Arm = decimal.Parse(txtArm.Text),
                    Waist = decimal.Parse(txtWaist.Text),
                    Hip = decimal.Parse(txtHip.Text),
                    Leg = decimal.Parse(txtLeg.Text),
                    Calf = decimal.Parse(txtCalf.Text),
                    MetabolicState = cmbMetabolicState.Text
                };

                // Calculate BMI
                assessment.BMI = _assessmentService.ComputeBMI(assessment.Weight, assessment.Heigth);
                txtBMI.Text = assessment.BMI.ToString();

                // Validate Assessment
                var validationResult = _assessmentService.ValidateAssessmentData(assessment);
                if (!validationResult.Success)
                {
                    MessageBox.Show($"Error saving assessment: \n \n - {validationResult.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check Warning Conditions
                var warningConditions = _assessmentService.CheckWarningConditions(assessment.BodyFatPercentage, assessment.MuscleMassPercentage);
                if (!warningConditions.Success)
                {
                    MessageBox.Show($"{warningConditions.Message} \n \n - {string.Join("\n - ", warningConditions.Result)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save to database or pass to service layer (to be implemented)
                var result = await _assessmentService.CreateAssessment(assessment);
                if (!result.Success)
                {
                    MessageBox.Show($"Error saving assessment: \n \n - {result.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Assessment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving assessment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label CreateLabel(string text, int x, int y) => new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true
        };

        private TextBox CreateTextBox(int x, int y, bool isNumeric = false)
        {

            var txt = new TextBox
            {
                Location = new Point(x, y),
                Width = 180
            };

            if (isNumeric)
            {
                txt.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                        (e.KeyChar != '.') && (e.KeyChar != '-'))
                    {
                        e.Handled = true;
                    }
                    // only allow one decimal point
                    if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
                    }
                };
            }

            return txt;
        }
    }
}
