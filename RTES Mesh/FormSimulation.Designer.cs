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
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas1.Location = new System.Drawing.Point(12, 12);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(667, 397);
            this.canvas1.TabIndex = 0;
            // 
            // FormSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.canvas1);
            this.Name = "FormSimulation";
            this.Text = "RTES Mesh Simulation";
            this.Load += new System.EventHandler(this.FormSimulation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Node node1;
        private Node node2;
        private Node node3;
        private Node node4;
        private Node node5;
        private Node node6;
        private Canvas canvas1;
    }
}

