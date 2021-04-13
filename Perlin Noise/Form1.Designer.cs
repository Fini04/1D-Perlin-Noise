
namespace Perlin_Noise
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnArray = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnAnzeige = new System.Windows.Forms.Panel();
            this.pnAnzeigeTerrain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnArray
            // 
            this.btnArray.Location = new System.Drawing.Point(565, 50);
            this.btnArray.Name = "btnArray";
            this.btnArray.Size = new System.Drawing.Size(75, 23);
            this.btnArray.TabIndex = 0;
            this.btnArray.Text = "Array";
            this.btnArray.UseVisualStyleBackColor = true;
            this.btnArray.Click += new System.EventHandler(this.btnArray_Click);
            // 
            // txtLog
            // 
            this.txtLog.AllowDrop = true;
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(546, 320);
            this.txtLog.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(565, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnAnzeige
            // 
            this.pnAnzeige.BackColor = System.Drawing.Color.DimGray;
            this.pnAnzeige.Location = new System.Drawing.Point(12, 338);
            this.pnAnzeige.Name = "pnAnzeige";
            this.pnAnzeige.Size = new System.Drawing.Size(776, 100);
            this.pnAnzeige.TabIndex = 3;
            this.pnAnzeige.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAnzeige_Paint);
            // 
            // pnAnzeigeTerrain
            // 
            this.pnAnzeigeTerrain.BackColor = System.Drawing.Color.DimGray;
            this.pnAnzeigeTerrain.Location = new System.Drawing.Point(12, 444);
            this.pnAnzeigeTerrain.Name = "pnAnzeigeTerrain";
            this.pnAnzeigeTerrain.Size = new System.Drawing.Size(776, 100);
            this.pnAnzeigeTerrain.TabIndex = 4;
            this.pnAnzeigeTerrain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAnzeigeTerrain_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 555);
            this.Controls.Add(this.pnAnzeigeTerrain);
            this.Controls.Add(this.pnAnzeige);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnArray);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArray;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnAnzeige;
        private System.Windows.Forms.Panel pnAnzeigeTerrain;
    }
}

