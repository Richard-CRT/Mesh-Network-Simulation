namespace RTES_Mesh
{
    partial class FormSimulation
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
            this.canvas1 = new RTES_Mesh.Canvas();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas1.Location = new System.Drawing.Point(12, 12);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(413, 411);
            this.canvas1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.canvas1);
            this.Name = "FormSimulation";
            this.Text = "RTES Mesh Simulation";
            this.Load += new System.EventHandler(this.FormSimulation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Canvas canvas1;
        private System.Windows.Forms.Button button1;
    }
}

