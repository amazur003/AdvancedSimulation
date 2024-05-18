namespace AdvancedSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.comboBoxColorScheme = new System.Windows.Forms.ComboBox();
            this.trackBarTimerInterval = new System.Windows.Forms.TrackBar();
            this.labelTimerInterval = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimerInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 425);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(499, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Uruchom symulację";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(499, 54);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 35);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Zakończ symulację";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(499, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 35);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(607, 13);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(73, 13);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "Czas trwania: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(499, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(499, 177);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 35);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Wczytaj";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // comboBoxColorScheme
            // 
            this.comboBoxColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorScheme.FormattingEnabled = true;
            this.comboBoxColorScheme.Items.AddRange(new object[] {
            "Standardowy",
            "Pastelowy",
            "Nocny"});
            this.comboBoxColorScheme.Location = new System.Drawing.Point(593, 191);
            this.comboBoxColorScheme.Name = "comboBoxColorScheme";
            this.comboBoxColorScheme.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColorScheme.TabIndex = 7;
            this.comboBoxColorScheme.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorScheme_SelectedIndexChanged);
            // 
            // trackBarTimerInterval
            // 
            this.trackBarTimerInterval.LargeChange = 50;
            this.trackBarTimerInterval.Location = new System.Drawing.Point(590, 84);
            this.trackBarTimerInterval.Maximum = 1000;
            this.trackBarTimerInterval.Minimum = 10;
            this.trackBarTimerInterval.Name = "trackBarTimerInterval";
            this.trackBarTimerInterval.Size = new System.Drawing.Size(178, 45);
            this.trackBarTimerInterval.SmallChange = 10;
            this.trackBarTimerInterval.TabIndex = 8;
            this.trackBarTimerInterval.TickFrequency = 50;
            this.trackBarTimerInterval.Value = 10;
            this.trackBarTimerInterval.ValueChanged += new System.EventHandler(this.trackBarTimerInterval_ValueChanged);
            // 
            // labelTimerInterval
            // 
            this.labelTimerInterval.AutoSize = true;
            this.labelTimerInterval.Location = new System.Drawing.Point(607, 65);
            this.labelTimerInterval.Name = "labelTimerInterval";
            this.labelTimerInterval.Size = new System.Drawing.Size(83, 13);
            this.labelTimerInterval.TabIndex = 9;
            this.labelTimerInterval.Text = "Interwał timera: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AdvancedSimulation.Properties.Resources.istockphoto_1354565720_612x612;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTimerInterval);
            this.Controls.Add(this.trackBarTimerInterval);
            this.Controls.Add(this.comboBoxColorScheme);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Advanced Simulation - Conway";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimerInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox comboBoxColorScheme;
        private System.Windows.Forms.TrackBar trackBarTimerInterval;
        private System.Windows.Forms.Label labelTimerInterval;
    }
}

