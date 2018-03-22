namespace GD77_FlashManager
{
	partial class MainForm
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
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtStartAddr = new System.Windows.Forms.TextBox();
			this.txtLen = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEndAddr = new System.Windows.Forms.TextBox();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnWrite = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(21, 22);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open File";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(21, 51);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "SaveFile";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Start address (hex)";
			// 
			// txtStartAddr
			// 
			this.txtStartAddr.Location = new System.Drawing.Point(9, 102);
			this.txtStartAddr.Name = "txtStartAddr";
			this.txtStartAddr.Size = new System.Drawing.Size(100, 20);
			this.txtStartAddr.TabIndex = 3;
			this.txtStartAddr.Text = "0";
			this.txtStartAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtLen
			// 
			this.txtLen.Location = new System.Drawing.Point(9, 151);
			this.txtLen.Name = "txtLen";
			this.txtLen.Size = new System.Drawing.Size(100, 20);
			this.txtLen.TabIndex = 5;
			this.txtLen.Text = "0";
			this.txtLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Length (hex)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 191);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "End address (hex)";
			// 
			// txtEndAddr
			// 
			this.txtEndAddr.Location = new System.Drawing.Point(9, 207);
			this.txtEndAddr.Name = "txtEndAddr";
			this.txtEndAddr.Size = new System.Drawing.Size(100, 20);
			this.txtEndAddr.TabIndex = 5;
			this.txtEndAddr.Text = "0";
			this.txtEndAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(21, 242);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(75, 23);
			this.btnRead.TabIndex = 0;
			this.btnRead.Text = "Read";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnWrite
			// 
			this.btnWrite.Location = new System.Drawing.Point(21, 271);
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.Size = new System.Drawing.Size(75, 23);
			this.btnWrite.TabIndex = 0;
			this.btnWrite.Text = "Write";
			this.btnWrite.UseVisualStyleBackColor = true;
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 633);
			this.Controls.Add(this.txtEndAddr);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtLen);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtStartAddr);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnWrite);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnOpen);
			this.Name = "MainForm";
			this.Text = "GD-77 Flash manager";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtStartAddr;
		private System.Windows.Forms.TextBox txtLen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEndAddr;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnWrite;
	}
}

