namespace KeyphPro.App
{
    using KeyphPro.Domain.Entities.Models;
    using KeyphPro.Domain.Services;
    using System;
    using System.Windows.Forms;

    public class AddAssessmentForm : Form
    {
        private readonly IAssessmentService _assessmentService;
        private Label lblDate, lblHeight, lblWeight, lblBMI, lblBodyFat, lblViseralFat, lblMuscleMass, lblDailyCalories;
        private Label lblShoulder, lblArm, lblWaist, lblHip, lblLeg, lblCalf, lblMetabolicState;
        private TextBox txtWeight, txtHeight, txtBMI, txtBodyFat, txtViseralFat, txtMuscleMass, txtDailyCalories;
        private TextBox txtShoulder, txtArm, txtWaist, txtHip, txtLeg, txtCalf;
        private ComboBox cmbMetabolicState;
        private DateTimePicker dtpDate;
        private Button btnSave;

        public AddAssessmentForm(IAssessmentService assessmentService)
        {
            Text = "Agregar valoración";
            Size = new System.Drawing.Size(400, 700);
            _assessmentService = assessmentService;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Labels
            lblDate = CreateLabel("Fecha:", 20, 20);
            lblWeight = CreateLabel("Peso (kg):", 20, 60);
            lblHeight = CreateLabel("Altura (cm):", 20, 100);
            lblBodyFat = CreateLabel("Grasa corporal (%):", 20, 140);
            lblViseralFat = CreateLabel("Grasa viseral (%):", 20, 180);
            lblMuscleMass = CreateLabel("Masa muscular (%):", 20, 220);
            lblDailyCalories = CreateLabel("Calorias:", 20, 260);
            lblShoulder = CreateLabel("Hombro (cm):", 20, 300);
            lblArm = CreateLabel("Brazo (cm):", 20, 340);
            lblWaist = CreateLabel("Cintura (cm):", 20, 380);
            lblHip = CreateLabel("Cadera (cm):", 20, 420);
            lblLeg = CreateLabel("Pierna (cm):", 20, 460);
            lblCalf = CreateLabel("Pantorrilla (cm):", 20, 500);
            lblMetabolicState = CreateLabel("Estado metabolico:", 20, 540);
            lblBMI = CreateLabel("BMI (Calculado):", 20, 580);

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
            txtViseralFat = CreateTextBox(180, 180, true);
            txtMuscleMass = CreateTextBox(180, 220, true);
            txtDailyCalories = CreateTextBox(180, 260, true);
            txtShoulder = CreateTextBox(180, 300, true);
            txtArm = CreateTextBox(180, 340, true);
            txtWaist = CreateTextBox(180, 380, true);
            txtHip = CreateTextBox(180, 420, true);
            txtLeg = CreateTextBox(180, 460, true);
            txtCalf = CreateTextBox(180, 500, true);
            cmbMetabolicState = new ComboBox
            {
                Location = new System.Drawing.Point(180, 540),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "Normal", "Altered", "Not Measured" },
                SelectedIndex = 0,
                Width = 180
            };
            txtBMI = CreateTextBox(180, 580, true);
            txtBMI.Enabled = false;

            // Save Button
            btnSave = new Button
            {
                Text = "Guardar",
                Location = new System.Drawing.Point(150, 620),
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
                lblViseralFat, txtViseralFat,
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
                    ViseralFat = decimal.Parse(txtViseralFat.Text),
                    MuscleMassPercentage = decimal.Parse(txtMuscleMass.Text),
                    DailyCalories = int.Parse(txtDailyCalories.Text),
                    Shoulder = decimal.Parse(txtShoulder.Text),
                    Arm = decimal.Parse(txtArm.Text),
                    Waist = decimal.Parse(txtWaist.Text),
                    Hip = decimal.Parse(txtHip.Text),
                    Leg = decimal.Parse(txtLeg.Text),
                    Calf = decimal.Parse(txtCalf.Text),
                    MetabolicState = cmbMetabolicState.Text,
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
