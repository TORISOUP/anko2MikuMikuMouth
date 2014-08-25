namespace anko2SpeachMiku {
	partial class SampleForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
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
            this.checkBoxAlwaysRun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxAlwaysRun
            // 
            this.checkBoxAlwaysRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAlwaysRun.AutoSize = true;
            this.checkBoxAlwaysRun.Location = new System.Drawing.Point(200, 234);
            this.checkBoxAlwaysRun.Name = "checkBoxAlwaysRun";
            this.checkBoxAlwaysRun.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAlwaysRun.TabIndex = 0;
            this.checkBoxAlwaysRun.Text = "自動開始";
            this.checkBoxAlwaysRun.UseVisualStyleBackColor = true;
            this.checkBoxAlwaysRun.CheckedChanged += new System.EventHandler(this.checkBoxAlwaysRun_CheckedChanged);
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkBoxAlwaysRun);
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SampleForm_FormClosing);
            this.Load += new System.EventHandler(this.SampleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxAlwaysRun;
	}
}