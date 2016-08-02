namespace Apothiki {
    partial class ChangeDialog {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeDialog));
            this.labelLocNew = new System.Windows.Forms.Label();
            this.textBoxKoutiOrProionNew = new System.Windows.Forms.TextBox();
            this.labelKoutiOrProionOld = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.comboBoxKoutiOrProionOld = new System.Windows.Forms.ComboBox();
            this.textBoxLocOld = new System.Windows.Forms.TextBox();
            this.labelLocOld = new System.Windows.Forms.Label();
            this.textBoxLocNew = new System.Windows.Forms.TextBox();
            this.labelKoutiOrProionNew = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLocNew
            // 
            this.labelLocNew.AutoSize = true;
            this.labelLocNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocNew.Location = new System.Drawing.Point(157, 52);
            this.labelLocNew.Name = "labelLocNew";
            this.labelLocNew.Size = new System.Drawing.Size(102, 17);
            this.labelLocNew.TabIndex = 7;
            this.labelLocNew.Text = "Νέα τοποθεσία";
            this.labelLocNew.Visible = false;
            // 
            // textBoxKoutiOrProionNew
            // 
            this.textBoxKoutiOrProionNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKoutiOrProionNew.Location = new System.Drawing.Point(12, 73);
            this.textBoxKoutiOrProionNew.Name = "textBoxKoutiOrProionNew";
            this.textBoxKoutiOrProionNew.Size = new System.Drawing.Size(64, 20);
            this.textBoxKoutiOrProionNew.TabIndex = 1;
            this.textBoxKoutiOrProionNew.TextChanged += new System.EventHandler(this.comboBoxKoutiOrProionNew_TextChanged);
            // 
            // labelKoutiOrProionOld
            // 
            this.labelKoutiOrProionOld.AutoSize = true;
            this.labelKoutiOrProionOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKoutiOrProionOld.Location = new System.Drawing.Point(12, 9);
            this.labelKoutiOrProionOld.Name = "labelKoutiOrProionOld";
            this.labelKoutiOrProionOld.Size = new System.Drawing.Size(38, 17);
            this.labelKoutiOrProionOld.TabIndex = 6;
            this.labelKoutiOrProionOld.Text = "label";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(264, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(183, 128);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // comboBoxKoutiOrProionOld
            // 
            this.comboBoxKoutiOrProionOld.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxKoutiOrProionOld.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKoutiOrProionOld.FormattingEnabled = true;
            this.comboBoxKoutiOrProionOld.Location = new System.Drawing.Point(12, 29);
            this.comboBoxKoutiOrProionOld.Name = "comboBoxKoutiOrProionOld";
            this.comboBoxKoutiOrProionOld.Size = new System.Drawing.Size(64, 21);
            this.comboBoxKoutiOrProionOld.TabIndex = 0;
            this.comboBoxKoutiOrProionOld.SelectedIndexChanged += new System.EventHandler(this.comboBoxKoutiOrProionOld_SelectedIndexChanged);
            this.comboBoxKoutiOrProionOld.TextUpdate += new System.EventHandler(this.comboBoxKoutiOrProionOld_TextUpdate);
            // 
            // textBoxLocOld
            // 
            this.textBoxLocOld.Location = new System.Drawing.Point(160, 29);
            this.textBoxLocOld.Name = "textBoxLocOld";
            this.textBoxLocOld.ReadOnly = true;
            this.textBoxLocOld.Size = new System.Drawing.Size(179, 20);
            this.textBoxLocOld.TabIndex = 8;
            this.textBoxLocOld.TabStop = false;
            this.textBoxLocOld.Visible = false;
            // 
            // labelLocOld
            // 
            this.labelLocOld.AutoSize = true;
            this.labelLocOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocOld.Location = new System.Drawing.Point(157, 9);
            this.labelLocOld.Name = "labelLocOld";
            this.labelLocOld.Size = new System.Drawing.Size(75, 17);
            this.labelLocOld.TabIndex = 9;
            this.labelLocOld.Text = "Τοποθεσία";
            this.labelLocOld.Visible = false;
            // 
            // textBoxLocNew
            // 
            this.textBoxLocNew.Location = new System.Drawing.Point(160, 72);
            this.textBoxLocNew.Name = "textBoxLocNew";
            this.textBoxLocNew.Size = new System.Drawing.Size(179, 20);
            this.textBoxLocNew.TabIndex = 2;
            this.textBoxLocNew.Visible = false;
            // 
            // labelKoutiOrProionNew
            // 
            this.labelKoutiOrProionNew.AutoSize = true;
            this.labelKoutiOrProionNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKoutiOrProionNew.Location = new System.Drawing.Point(12, 53);
            this.labelKoutiOrProionNew.Name = "labelKoutiOrProionNew";
            this.labelKoutiOrProionNew.Size = new System.Drawing.Size(63, 17);
            this.labelKoutiOrProionNew.TabIndex = 0;
            this.labelKoutiOrProionNew.Text = "Νέα τιμή";
            // 
            // ChangeDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 163);
            this.Controls.Add(this.labelKoutiOrProionNew);
            this.Controls.Add(this.textBoxLocNew);
            this.Controls.Add(this.labelLocOld);
            this.Controls.Add(this.textBoxLocOld);
            this.Controls.Add(this.comboBoxKoutiOrProionOld);
            this.Controls.Add(this.labelLocNew);
            this.Controls.Add(this.textBoxKoutiOrProionNew);
            this.Controls.Add(this.labelKoutiOrProionOld);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeDialog";
            this.Load += new System.EventHandler(this.ChangeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLocNew;
        private System.Windows.Forms.TextBox textBoxKoutiOrProionNew;
        private System.Windows.Forms.Label labelKoutiOrProionOld;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ComboBox comboBoxKoutiOrProionOld;
        private System.Windows.Forms.TextBox textBoxLocOld;
        private System.Windows.Forms.Label labelLocOld;
        private System.Windows.Forms.TextBox textBoxLocNew;
        private System.Windows.Forms.Label labelKoutiOrProionNew;
    }
}