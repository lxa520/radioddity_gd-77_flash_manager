using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.IO;

namespace GD77_FlashManager
{
	public partial class MainForm : Form
	{
		public static byte [] eeprom = new byte[1024 * 1024];
		public static int startAddress;
		public static int transferLength;
		private ByteViewer _bv;


		public MainForm()
		{
			InitializeComponent();
			this.Controls.Remove(grpHexView);
			_bv = new ByteViewer();
			_bv.Location = grpHexView.Location;// new Point(200, 20);
			_bv.SetBytes(eeprom); // or SetBytes
			this.Controls.Add(_bv);
			Console.WriteLine();
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			int correction = 0;
			CommPrgForm commPrgForm = new CommPrgForm();
			commPrgForm.StartPosition = FormStartPosition.CenterParent;
			commPrgForm.IsRead = true;
			MainForm.startAddress = int.Parse(txtStartAddr.Text, System.Globalization.NumberStyles.HexNumber);
			correction = MainForm.startAddress % 32;
			if (correction != 0)
			{
				MainForm.startAddress = (MainForm.startAddress / 32) * 32;
				txtStartAddr.Text = MainForm.startAddress.ToString("X");
				int trLen = correction + int.Parse(txtLen.Text, System.Globalization.NumberStyles.HexNumber);
				if (trLen % 32 != 0)
				{
					trLen = (trLen / 32) * 32 + 32;
				}
				txtLen.Text = trLen.ToString("X");
				MessageBox.Show("Read and Write addresses must be a multiple of 32. The address and potentially the length has been changed");
			}

			MainForm.transferLength = int.Parse(txtLen.Text, System.Globalization.NumberStyles.HexNumber);
			correction = MainForm.transferLength % 32;
			if (correction != 0)
			{
				MainForm.transferLength = (MainForm.transferLength / 32) * 32 + 32;
				txtLen.Text = MainForm.transferLength.ToString("X");
				MessageBox.Show("Transfer length must be a multiple of 32. The length has been increased to a multiple of 32");
			}

			commPrgForm.ShowDialog();
			_bv.Refresh();

		}

		private void btnWrite_Click(object sender, EventArgs e)
		{
			CommPrgForm commPrgForm = new CommPrgForm();
			commPrgForm.StartPosition = FormStartPosition.CenterParent;
			commPrgForm.IsRead = false;

			commPrgForm.ShowDialog();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			//openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					MainForm.eeprom = File.ReadAllBytes(openFileDialog1.FileName);
					_bv.SetBytes(MainForm.eeprom);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
			
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(saveFileDialog1.FileName, MainForm.eeprom);
			}
		}
	}
}
