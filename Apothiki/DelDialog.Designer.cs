namespace Apothiki {
    partial class DelDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelDialog));
            this.labelKoutiOrProion = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.comboBoxKoutiOrProion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelKoutiOrProion
            // 
            this.labelKoutiOrProion.AutoSize = true;
            this.labelKoutiOrProion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKoutiOrProion.Location = new System.Drawing.Point(9, 40);
            this.labelKoutiOrProion.Name = "labelKoutiOrProion";
            this.labelKoutiOrProion.Size = new System.Drawing.Size(38, 17);
            this.labelKoutiOrProion.TabIndex = 3;
            this.labelKoutiOrProion.Text = "label";
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(255, 117);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(174, 117);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // comboBoxKoutiOrProion
            // 
            this.comboBoxKoutiOrProion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxKoutiOrProion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKoutiOrProion.FormattingEnabled = true;
            this.comboBoxKoutiOrProion.Location = new System.Drawing.Point(12, 60);
            this.comboBoxKoutiOrProion.Name = "comboBoxKoutiOrProion";
            this.comboBoxKoutiOrProion.Size = new System.Drawing.Size(64, 21);
            this.comboBoxKoutiOrProion.TabIndex = 0;
            this.comboBoxKoutiOrProion.SelectedIndexChanged += new System.EventHandler(this.comboBoxKoutiOrProion_SelectedIndexChanged);
            this.comboBoxKoutiOrProion.TextUpdate += new System.EventHandler(this.comboBoxKoutiOrProion_TextUpdate);
            // 
            // DelDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(351, 163);
            this.Controls.Add(this.comboBoxKoutiOrProion);
            this.Controls.Add(this.labelKoutiOrProion);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DelDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelKoutiOrProion;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ComboBox comboBoxKoutiOrProion;
    }
}