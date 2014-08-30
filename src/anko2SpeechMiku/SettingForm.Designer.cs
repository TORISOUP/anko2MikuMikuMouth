namespace anko2SpeachMiku {
	partial class SettingForm {
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
            this.OpenBoyomichanDictionaryPathButton = new System.Windows.Forms.Button();
            this.label_boyomiFilePath = new System.Windows.Forms.Label();
            this.gridViewDictionary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDictionary)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenBoyomichanDictionaryPathButton
            // 
            this.OpenBoyomichanDictionaryPathButton.Location = new System.Drawing.Point(12, 12);
            this.OpenBoyomichanDictionaryPathButton.Name = "OpenBoyomichanDictionaryPathButton";
            this.OpenBoyomichanDictionaryPathButton.Size = new System.Drawing.Size(139, 30);
            this.OpenBoyomichanDictionaryPathButton.TabIndex = 0;
            this.OpenBoyomichanDictionaryPathButton.Text = "辞書ファイルを指定する";
            this.OpenBoyomichanDictionaryPathButton.UseVisualStyleBackColor = true;
            this.OpenBoyomichanDictionaryPathButton.Click += new System.EventHandler(this.OpenBoyomichanDictionaryPathButton_Click);
            // 
            // label_boyomiFilePath
            // 
            this.label_boyomiFilePath.AutoSize = true;
            this.label_boyomiFilePath.Location = new System.Drawing.Point(19, 51);
            this.label_boyomiFilePath.Name = "label_boyomiFilePath";
            this.label_boyomiFilePath.Size = new System.Drawing.Size(0, 12);
            this.label_boyomiFilePath.TabIndex = 1;
            // 
            // gridViewDictionary
            // 
            this.gridViewDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewDictionary.Location = new System.Drawing.Point(12, 69);
            this.gridViewDictionary.Name = "gridViewDictionary";
            this.gridViewDictionary.RowTemplate.Height = 21;
            this.gridViewDictionary.Size = new System.Drawing.Size(362, 450);
            this.gridViewDictionary.TabIndex = 2;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 524);
            this.Controls.Add(this.gridViewDictionary);
            this.Controls.Add(this.label_boyomiFilePath);
            this.Controls.Add(this.OpenBoyomichanDictionaryPathButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingForm";
            this.Text = "みくみくまうす-辞書設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SampleForm_FormClosing);
            this.Load += new System.EventHandler(this.SampleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDictionary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button OpenBoyomichanDictionaryPathButton;
        private System.Windows.Forms.Label label_boyomiFilePath;
        private System.Windows.Forms.DataGridView gridViewDictionary;

    }
}