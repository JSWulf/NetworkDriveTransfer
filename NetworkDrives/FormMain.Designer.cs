namespace NetworkDrives
{
	partial class FormMain
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.Source = new System.Windows.Forms.TextBox();
			this.destination = new System.Windows.Forms.TextBox();
			this.buttonSubmit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonBrowseSource = new System.Windows.Forms.Button();
			this.buttonBrowseDestination = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(13, 13);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(264, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "User is Online (uncheck if accessing HDD directly)";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// Source
			// 
			this.Source.Location = new System.Drawing.Point(11, 65);
			this.Source.Name = "Source";
			this.Source.Size = new System.Drawing.Size(238, 20);
			this.Source.TabIndex = 1;
			this.Source.Text = "\\\\LTxxxxxx\\D$\\Users\\username";
			this.Source.TextChanged += new System.EventHandler(this.Source_TextChanged);
			// 
			// destination
			// 
			this.destination.Location = new System.Drawing.Point(12, 116);
			this.destination.Name = "destination";
			this.destination.Size = new System.Drawing.Size(237, 20);
			this.destination.TabIndex = 2;
			this.destination.Text = "\\\\LTxxxxxx\\C$\\Users\\username\\Desktop\\";
			this.destination.TextChanged += new System.EventHandler(this.destination_TextChanged);
			// 
			// buttonSubmit
			// 
			this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSubmit.Location = new System.Drawing.Point(198, 146);
			this.buttonSubmit.Name = "buttonSubmit";
			this.buttonSubmit.Size = new System.Drawing.Size(113, 24);
			this.buttonSubmit.TabIndex = 3;
			this.buttonSubmit.Text = "Generate File";
			this.buttonSubmit.UseVisualStyleBackColor = true;
			this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Old Profile";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Destination";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 139);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "\\NetworkDrives.vbs";
			// 
			// buttonBrowseSource
			// 
			this.buttonBrowseSource.Location = new System.Drawing.Point(255, 63);
			this.buttonBrowseSource.Name = "buttonBrowseSource";
			this.buttonBrowseSource.Size = new System.Drawing.Size(56, 23);
			this.buttonBrowseSource.TabIndex = 7;
			this.buttonBrowseSource.Text = "Browse";
			this.buttonBrowseSource.UseVisualStyleBackColor = true;
			this.buttonBrowseSource.Click += new System.EventHandler(this.buttonBrowseSource_Click);
			// 
			// buttonBrowseDestination
			// 
			this.buttonBrowseDestination.Location = new System.Drawing.Point(255, 114);
			this.buttonBrowseDestination.Name = "buttonBrowseDestination";
			this.buttonBrowseDestination.Size = new System.Drawing.Size(56, 23);
			this.buttonBrowseDestination.TabIndex = 8;
			this.buttonBrowseDestination.Text = "Browse";
			this.buttonBrowseDestination.UseVisualStyleBackColor = true;
			this.buttonBrowseDestination.Click += new System.EventHandler(this.buttonBrowseDestination_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(31, 156);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(323, 182);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonBrowseDestination);
			this.Controls.Add(this.buttonBrowseSource);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSubmit);
			this.Controls.Add(this.destination);
			this.Controls.Add(this.Source);
			this.Controls.Add(this.checkBox1);
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Transfer Network Drives v0.2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_unLoad);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox Source;
		private System.Windows.Forms.TextBox destination;
		private System.Windows.Forms.Button buttonSubmit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonBrowseSource;
		private System.Windows.Forms.Button buttonBrowseDestination;
		private System.Windows.Forms.Button button1;
	}
}

