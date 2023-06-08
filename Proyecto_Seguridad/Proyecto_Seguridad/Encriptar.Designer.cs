
namespace Proyecto_Seguridad
{
    partial class Encrypt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encrypt));
            this.inputbox = new System.Windows.Forms.TextBox();
            this.stepsbox = new System.Windows.Forms.TextBox();
            this.Encriptbtn = new System.Windows.Forms.Button();
            this.outputbox = new System.Windows.Forms.TextBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.grabar = new System.Windows.Forms.Button();
            this.recordingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // inputbox
            // 
            this.inputbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.inputbox.ForeColor = System.Drawing.Color.DarkRed;
            this.inputbox.Location = new System.Drawing.Point(12, 55);
            this.inputbox.Multiline = true;
            this.inputbox.Name = "inputbox";
            this.inputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputbox.Size = new System.Drawing.Size(355, 177);
            this.inputbox.TabIndex = 0;
            // 
            // stepsbox
            // 
            this.stepsbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stepsbox.ForeColor = System.Drawing.Color.DarkRed;
            this.stepsbox.Location = new System.Drawing.Point(12, 290);
            this.stepsbox.Multiline = true;
            this.stepsbox.Name = "stepsbox";
            this.stepsbox.ReadOnly = true;
            this.stepsbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stepsbox.Size = new System.Drawing.Size(355, 148);
            this.stepsbox.TabIndex = 3;
            // 
            // Encriptbtn
            // 
            this.Encriptbtn.Location = new System.Drawing.Point(552, 290);
            this.Encriptbtn.Name = "Encriptbtn";
            this.Encriptbtn.Size = new System.Drawing.Size(133, 39);
            this.Encriptbtn.TabIndex = 4;
            this.Encriptbtn.Text = "Encriptar mensaje";
            this.Encriptbtn.UseVisualStyleBackColor = true;
            this.Encriptbtn.Click += new System.EventHandler(this.Encriptbtn_Click);
            // 
            // outputbox
            // 
            this.outputbox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.outputbox.ForeColor = System.Drawing.Color.DarkRed;
            this.outputbox.Location = new System.Drawing.Point(433, 55);
            this.outputbox.Multiline = true;
            this.outputbox.Name = "outputbox";
            this.outputbox.ReadOnly = true;
            this.outputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputbox.Size = new System.Drawing.Size(355, 177);
            this.outputbox.TabIndex = 6;
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(552, 369);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(133, 39);
            this.Guardar.TabIndex = 7;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // grabar
            // 
            this.grabar.Location = new System.Drawing.Point(391, 290);
            this.grabar.Name = "grabar";
            this.grabar.Size = new System.Drawing.Size(133, 39);
            this.grabar.TabIndex = 8;
            this.grabar.Text = "Grabar voz";
            this.grabar.UseVisualStyleBackColor = true;
            this.grabar.Click += new System.EventHandler(this.grabar_Click);
            // 
            // recordingTimer
            // 
            this.recordingTimer.Interval = 5000;
            this.recordingTimer.Tick += new System.EventHandler(this.recordingTimer_Tick);
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grabar);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.outputbox);
            this.Controls.Add(this.Encriptbtn);
            this.Controls.Add(this.stepsbox);
            this.Controls.Add(this.inputbox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Encrypt";
            this.Text = "Encriptar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputbox;
        private System.Windows.Forms.TextBox stepsbox;
        private System.Windows.Forms.Button Encriptbtn;
        private System.Windows.Forms.TextBox outputbox;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button grabar;
        private System.Windows.Forms.Timer recordingTimer;
    }
}