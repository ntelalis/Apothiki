namespace Apothiki
{
    partial class NewDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDialog));
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.labelKouti = new System.Windows.Forms.Label();
            this.textBoxKouti = new System.Windows.Forms.TextBox();
            this.textBoxProionOrLoc = new System.Windows.Forms.TextBox();
            this.labelProionOrLoc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(159, 129);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(240, 129);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // labelKouti
            // 
            this.labelKouti.AutoSize = true;
            this.labelKouti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKouti.Location = new System.Drawing.Point(12, 9);
            this.labelKouti.Name = "labelKouti";
            this.labelKouti.Size = new System.Drawing.Size(113, 17);
            this.labelKouti.TabIndex = 4;
            this.labelKouti.Text = "Αριθμός κουτιού";
            this.labelKouti.Visible = false;
            // 
            // textBoxKouti
            // 
            this.textBoxKouti.Location = new System.Drawing.Point(15, 29);
            this.textBoxKouti.Name = "textBoxKouti";
            this.textBoxKouti.Size = new System.Drawing.Size(64, 20);
            this.textBoxKouti.TabIndex = 0;
            this.textBoxKouti.Visible = false;
            this.textBoxKouti.TextChanged += new System.EventHandler(this.textBoxKouti_TextChanged);
            // 
            // textBoxProionOrLoc
            // 
            this.textBoxProionOrLoc.Location = new System.Drawing.Point(15, 72);
            this.textBoxProionOrLoc.Name = "textBoxProionOrLoc";
            this.textBoxProionOrLoc.Size = new System.Drawing.Size(179, 20);
            this.textBoxProionOrLoc.TabIndex = 1;
            this.textBoxProionOrLoc.TextChanged += new System.EventHandler(this.textBoxProionOrLoc_TextChanged);
            // 
            // labelProionOrLoc
            // 
            this.labelProionOrLoc.AutoSize = true;
            this.labelProionOrLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProionOrLoc.Location = new System.Drawing.Point(12, 52);
            this.labelProionOrLoc.Name = "labelProionOrLoc";
            this.labelProionOrLoc.Size = new System.Drawing.Size(38, 17);
            this.labelProionOrLoc.TabIndex = 5;
            this.labelProionOrLoc.Text = "label";
            // 
            // NewDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(327, 164);
            this.Controls.Add(this.labelProionOrLoc);
            this.Controls.Add(this.textBoxProionOrLoc);
            this.Controls.Add(this.textBoxKouti);
            this.Controls.Add(this.labelKouti);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label labelKouti;
        private System.Windows.Forms.TextBox textBoxKouti;
        private System.Windows.Forms.TextBox textBoxProionOrLoc;
        private System.Windows.Forms.Label labelProionOrLoc;
    }
}