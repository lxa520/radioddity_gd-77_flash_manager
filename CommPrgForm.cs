using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GD77_FlashManager
{
	public class CommPrgForm : Form
	{
		//private IContainer components;
		private Label lblPrompt;
		private ProgressBar prgComm;
		private Button btnCancel;
        private Button btnOK;
		private FirmwareUpdate firmwareUpdate;
		private CodeplugComms hidComm;


		public bool IsRead
		{
			get;
			set;
		}

		public bool IsSucess
		{
			get;
			set;
		}



		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblPrompt = new Label();
			this.prgComm = new ProgressBar();
			this.btnCancel = new Button();
            this.btnOK = new Button();
			base.SuspendLayout();
			this.lblPrompt.BorderStyle = BorderStyle.Fixed3D;
			this.lblPrompt.Location = new Point(43, 118);
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.Size = new Size(380, 26);
			this.lblPrompt.TabIndex = 0;
            this.lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            //this.lblPrompt.Text = "";// Percentage display goes here


			this.prgComm.Location = new Point(43, 70);
			this.prgComm.Margin = new Padding(3, 4, 3, 4);
			this.prgComm.Name = "prgComm";
			this.prgComm.Size = new Size(380, 31);
			this.prgComm.TabIndex = 1;

			this.btnCancel.Location = new Point(184, 161);
			this.btnCancel.Margin = new Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(87, 31);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += this.btnCancel_Click;

            this.btnOK.Location = new Point(336, 161);
            this.btnOK.Margin = new Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(87, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += this.btnOK_Click;
            this.btnOK.Visible = false;


			base.AutoScaleDimensions = new SizeF(7f, 16f);
//			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(468, 214);
			base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
			base.Controls.Add(this.prgComm);
			base.Controls.Add(this.lblPrompt);
			this.Font = new Font("Arial", 10f, FontStyle.Regular);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Margin = new Padding(3, 4, 3, 4);
			base.Name = "CommPrgForm";
			base.ShowInTaskbar = false;
			base.Load += this.CommPrgForm_Load;
			base.FormClosing += this.CommPrgForm_FormClosing;
			base.ResumeLayout(false);
		}

		public CommPrgForm()
		{
			
			this.firmwareUpdate = new FirmwareUpdate();
			this.hidComm = new CodeplugComms();
			this.InitializeComponent();
			
		}

		private void CommPrgForm_Load(object sender, EventArgs e)
		{
			this.prgComm.Minimum = 0;
			this.prgComm.Maximum = 100;
			this.firmwareUpdate.method_3(this.IsRead);
			if (this.IsRead)
			{
				this.Text = "Read";
			}
			else
			{
				this.Text = "Write";
			}
			this.hidComm.setIsRead(this.IsRead);
			if (this.IsRead)
			{
				this.hidComm.START_ADDR = new int[7]
				{
					128,
					304,
					21392,
					29976,
					32768,
					44816,
					95776
				};
				this.hidComm.END_ADDR = new int[7]
				{
					297,
					14208,
					22056,
					30208,
					32784,
					45488,
					126624
				};
			}
			else
			{
				this.hidComm.START_ADDR = new int[7]
				{
					128,
					304,
					21392,
					29976,
					32768,
					44816,
					95776
				};
				this.hidComm.END_ADDR = new int[7]
				{
					297,
					14208,
					22056,
					30208,
					32784,
					45488,
					126624
				};
			}
			this.hidComm.method_9(this.method_0);
            this.hidComm.startCodeplugReadOrWriteInNewThread();
		}

		private void CommPrgForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.hidComm.isThreadAlive())
			{
				this.hidComm.setCancelComm(true);
				this.hidComm.joinThreadIfAlive();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
			this.Close();
        }


		private void method_0(object sender, FirmwareUpdateProgressEventArgs e)
		{
			if (this.prgComm.InvokeRequired)
			{
				base.BeginInvoke(new EventHandler<FirmwareUpdateProgressEventArgs>(this.method_0), sender, e);
			}
			else
			{
				if (e.Failed)
				{
					if (!string.IsNullOrEmpty(e.Message))
					{
						MessageBox.Show(e.Message, "");
					}
					base.Close();
				}
				else
				{
					if (!e.Closed)
					{
						this.prgComm.Value = (int)e.Percentage;
						if (e.Percentage == (float)this.prgComm.Maximum)
						{
							this.IsSucess = true;


							if (this.IsRead)
							{
								this.lblPrompt.Text = "Read Complete";
							}
							else
							{
								this.lblPrompt.Text = "Write Complete";
							}
							this.btnOK.Visible = true;
							this.btnCancel.Visible = false;
						}
						else
						{
							this.lblPrompt.Text = string.Format("{0}%", this.prgComm.Value);
						}
					}
				}
			}
		}
	}
}
