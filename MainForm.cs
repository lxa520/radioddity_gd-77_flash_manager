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
using Be.Windows.Forms;

namespace GD77_FlashManager
{
	public partial class MainForm : Form
	{
		public static byte [] eeprom = new byte[1024 * 1024];
		public static int startAddress;
		public static int transferLength;
		private FixedByteProvider _dbp;
		private bool _hexboxHasChanged = false;
		

		public MainForm()
		{
			InitializeComponent();
			hexBox.ByteProvider = _dbp = new FixedByteProvider(eeprom);
			
			_dbp.Changed += new EventHandler(onDataProviderChanged);// No point doing something every time this changes, as it only alerts to the fact that something has changed and not what specific byte has changed
		}

		public void onDataProviderChanged(object sender, EventArgs e)
		{
			_hexboxHasChanged = true;
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			CommPrgForm commPrgForm = new CommPrgForm();
			commPrgForm.StartPosition = FormStartPosition.CenterParent;
			commPrgForm.IsRead = true;
			MainForm.startAddress = int.Parse(txtStartAddr.Text, System.Globalization.NumberStyles.HexNumber);
			if (MainForm.startAddress % 32 != 0)
			{
				MessageBox.Show("Start address must be a multiple of 0x20");
				return;
			}

			MainForm.transferLength = int.Parse(txtLen.Text, System.Globalization.NumberStyles.HexNumber);
			if (MainForm.transferLength == 0)
			{
				MessageBox.Show("Length cant be zero");
				return;
			}
			if (MainForm.transferLength % 32 != 0)
			{
				MessageBox.Show("Length must be a multplie of 0x20");
				return;
			}

			if (MainForm.startAddress + MainForm.transferLength > MainForm.eeprom.Length)
			{
				MessageBox.Show("Start address and length settings would result in reading beyond the end of memory");
				return;
			}
			commPrgForm.ShowDialog();
			hexBox.ByteProvider = _dbp = new FixedByteProvider(eeprom);
			_hexboxHasChanged = false;
		}

		private void btnWrite_Click(object sender, EventArgs e)
		{
			CommPrgForm commPrgForm = new CommPrgForm();
			commPrgForm.StartPosition = FormStartPosition.CenterParent;
			commPrgForm.IsRead = false;

			MainForm.startAddress = int.Parse(txtStartAddr.Text, System.Globalization.NumberStyles.HexNumber);
			if (MainForm.startAddress % 32 != 0)
			{
				MessageBox.Show("Start address must be a multiple of 0x20");
				return;
			}
			

			MainForm.transferLength = int.Parse(txtLen.Text, System.Globalization.NumberStyles.HexNumber);
			if (MainForm.transferLength % 32 != 0)
			{
				MessageBox.Show("Length must be a multplie of 0x20");
				return;
			}

			if (MainForm.startAddress + MainForm.transferLength > MainForm.eeprom.Length)
			{
				MessageBox.Show("Start address and length settings would result in writing beyond the end of memory");
				return;
			}
			copyHexboxToEeprom();
			commPrgForm.ShowDialog();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					MainForm.eeprom = File.ReadAllBytes(openFileDialog1.FileName);
					hexBox.ByteProvider = _dbp = new FixedByteProvider(eeprom);
					_hexboxHasChanged = false;
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
				copyHexboxToEeprom();
				File.WriteAllBytes(saveFileDialog1.FileName, MainForm.eeprom);
			}
		}

		private void copyHexboxToEeprom()
		{
		//	if (_hexboxHasChanged)
			{
				Console.WriteLine("HexBox changed");
				Array.Copy(_dbp.Bytes.ToArray<byte>(), MainForm.eeprom, MainForm.eeprom.Length);
				_hexboxHasChanged = false;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}
	}
}
