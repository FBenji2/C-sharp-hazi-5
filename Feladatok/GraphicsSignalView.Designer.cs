namespace Signals
{
    partial class GraphicsSignalView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bPlusZoom = new System.Windows.Forms.Button();
            this.bMinuszoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPlusZoom
            // 
            this.bPlusZoom.Location = new System.Drawing.Point(3, 3);
            this.bPlusZoom.Name = "bPlusZoom";
            this.bPlusZoom.Size = new System.Drawing.Size(75, 23);
            this.bPlusZoom.TabIndex = 0;
            this.bPlusZoom.Text = "+";
            this.bPlusZoom.UseVisualStyleBackColor = true;
            this.bPlusZoom.Click += new System.EventHandler(this.BPlusZoom_Click);
            // 
            // bMinuszoom
            // 
            this.bMinuszoom.Location = new System.Drawing.Point(3, 32);
            this.bMinuszoom.Name = "bMinuszoom";
            this.bMinuszoom.Size = new System.Drawing.Size(75, 23);
            this.bMinuszoom.TabIndex = 1;
            this.bMinuszoom.Text = "-";
            this.bMinuszoom.UseVisualStyleBackColor = true;
            this.bMinuszoom.Click += new System.EventHandler(this.BMinuszoom_Click);
            // 
            // GraphicsSignalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bMinuszoom);
            this.Controls.Add(this.bPlusZoom);
            this.Name = "GraphicsSignalView";
            this.Size = new System.Drawing.Size(723, 337);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPlusZoom;
        private System.Windows.Forms.Button bMinuszoom;
    }
}
