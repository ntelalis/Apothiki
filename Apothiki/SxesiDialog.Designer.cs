namespace Apothiki
{
    partial class SxesiDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SxesiDialog));
            this.labelProion = new System.Windows.Forms.Label();
            this.labelKouti = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.comboBoxKouti = new System.Windows.Forms.ComboBox();
            this.comboBoxProion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelProion
            // 
            this.labelProion.AutoSize = true;
            this.labelProion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProion.Location = new System.Drawing.Point(12, 60);
            this.labelProion.Name = "labelProion";
            this.labelProion.Size = new System.Drawing.Size(121, 17);
            this.labelProion.TabIndex = 5;
            this.labelProion.Text = "Όνομα προϊόντος";
            // 
            // labelKouti
            // 
            this.labelKouti.AutoSize = true;
            this.labelKouti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKouti.Location = new System.Drawing.Point(12, 16);
            this.labelKouti.Name = "labelKouti";
            this.labelKouti.Size = new System.Drawing.Size(115, 17);
            this.labelKouti.TabIndex = 4;
            this.labelKouti.Text = "Αριθμός Κουτιού";
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(264, 128);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(183, 128);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // comboBoxKouti
            // 
            this.comboBoxKouti.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxKouti.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKouti.FormattingEnabled = true;
            this.comboBoxKouti.Location = new System.Drawing.Point(12, 36);
            this.comboBoxKouti.Name = "comboBoxKouti";
            this.comboBoxKouti.Size = new System.Drawing.Size(64, 21);
            this.comboBoxKouti.TabIndex = 0;
            this.comboBoxKouti.SelectedIndexChanged += new System.EventHandler(this.comboBoxKouti_SelectedIndexChanged);
            this.comboBoxKouti.TextUpdate += new System.EventHandler(this.comboBoxKouti_TextUpdate);
            // 
            // comboBoxProion
            // 
            this.comboBoxProion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProion.FormattingEnabled = true;
            this.comboBoxProion.Location = new System.Drawing.Point(12, 80);
            this.comboBoxProion.Name = "comboBoxProion";
            this.comboBoxProion.Size = new System.Drawing.Size(224, 21);
            this.comboBoxProion.TabIndex = 1;
            this.comboBoxProion.SelectedIndexChanged += new System.EventHandler(this.comboBoxProion_SelectedIndexChanged);
            this.comboBoxProion.TextUpdate += new System.EventHandler(this.comboBoxProion_TextUpdate);
            // 
            // SxesiDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(351, 163);
            this.Controls.Add(this.comboBoxProion);
            this.Controls.Add(this.comboBoxKouti);
            this.Controls.Add(this.labelProion);
            this.Controls.Add(this.labelKouti);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SxesiDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SxesiDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProion;
        private System.Windows.Forms.Label labelKouti;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ComboBox comboBoxKouti;
        private System.Windows.Forms.ComboBox comboBoxProion;
    }
}