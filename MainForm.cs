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

			_bv = new ByteViewer();
			_bv.Location = new Point(200, 20);
			_bv.SetBytes(eeprom); // or SetBytes
			this.Controls.Add(_bv);
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			CommPrgForm commPrgForm = new CommPrgForm();
			commPrgForm.StartPosition = FormStartPosition.CenterParent;
			commPrgForm.IsRead = true;
			MainForm.startAddress = int.Parse(txtStartAddr.Text, System.Globalization.NumberStyles.HexNumber);
			MainForm.transferLength = int.Parse(txtLen.Text, System.Globalization.NumberStyles.HexNumber);
			//commPrgForm.endAddress = int.Parse(txtEndAddr.Text, System.Globalization.NumberStyles.HexNumber); 
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

		}

		private void btnSave_Click(object sender, EventArgs e)
		{

		}

	}
}
