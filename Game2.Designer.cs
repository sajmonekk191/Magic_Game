namespace test_RPG
{
    partial class Game2
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
            this.scorelbl = new System.Windows.Forms.Label();
            this.counterlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scorelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.scorelbl.Location = new System.Drawing.Point(12, 9);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(81, 28);
            this.scorelbl.TabIndex = 3;
            this.scorelbl.Text = "Score: 1";
            // 
            // counterlbl
            // 
            this.counterlbl.AutoSize = true;
            this.counterlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.counterlbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.counterlbl.ForeColor = System.Drawing.SystemColors.Control;
            this.counterlbl.Location = new System.Drawing.Point(1797, 1042);
            this.counterlbl.Name = "counterlbl";
            this.counterlbl.Size = new System.Drawing.Size(79, 28);
            this.counterlbl.TabIndex = 4;
            this.counterlbl.Text = "counter";
            this.counterlbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.counterlbl.Visible = false;
            // 
            // Game2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.counterlbl);
            this.Controls.Add(this.scorelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scorelbl;
        private System.Windows.Forms.Label counterlbl;
    }
}