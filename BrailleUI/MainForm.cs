/*
 * Main window of application.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using DotGraphics.Requests.WinUI;
using DotGraphics.Cultures;

namespace DotGraphics.BrailleUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		protected OpenFileDialog ofd = new OpenFileDialog();
		protected SaveFileDialog sfd = new SaveFileDialog();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			ConstructButton.Text = Localization.Get("ui_compilebutton");
			RenderButton.Text = Localization.Get("ui_renderbutton");
			
			ofd.InitialDirectory = Environment.GetEnvironmentVariable("userprofile");
			sfd.InitialDirectory = Environment.GetEnvironmentVariable("userprofile");
		}
		
		void ImageSelectButtonClick(object sender, EventArgs e)
		{
			ofd.Title = "Select image file to open";
			ofd.DefaultExt = "png";
			ofd.Filter = "PNG files (*.png)|*.png";
			DialogResult dr = ofd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				PNGLocationBox.Text = ofd.FileName;
				PNGLocationBox.Enabled = true;
			}
		}
		
		void ObjectPathSelectButtonClick(object sender, EventArgs e)
		{
			sfd.Title = "Select location to save object in";
			sfd.DefaultExt = "o";
			sfd.Filter = "Serialized object (*.o)|*.o";
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				ObjectLocationBox.Text = sfd.FileName;
				ObjectLocationBox.Enabled = true;
			}
		}
		
		void ConstructButtonClick(object sender, EventArgs e)
		{
			if (PNGLocationBox.Enabled && ObjectLocationBox.Enabled)
			{
				RequestHandler.CompileBrailleFromImage(PNGLocationBox.Text, ObjectLocationBox.Text);
			}
		}
		
		void ObjectSelectButtonClick(object sender, EventArgs e)
		{
			ofd.Title = "Select object file to open";
			ofd.DefaultExt = "o";
			ofd.Filter = "Serialized object (*.o)|*.o";
			DialogResult dr = ofd.ShowDialog();
			if (dr == DialogResult.OK && File.Exists(ofd.FileName))
			{
				TargetObjectLocationBox.Text = ofd.FileName;
				TargetObjectLocationBox.Enabled = true;
			}
		}
		
		void TextLocationSelectButtonClick(object sender, EventArgs e)
		{
			sfd.Title = "Select location to save text file in";
			sfd.DefaultExt = "txt";
			sfd.Filter = "Text document (*.txt)|*.txt";
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				TextSaveLocationBox.Text = sfd.FileName;
				TextSaveLocationBox.Enabled = true;
			}
		}
		
		void RenderButtonClick(object sender, EventArgs e)
		{
			if (TargetObjectLocationBox.Enabled && TextSaveLocationBox.Enabled)
			{
				String[] h = RequestHandler.RenderBrailleToTextFile(TargetObjectLocationBox.Text, TextSaveLocationBox.Text);
				if (ShowResultTickBox.Checked && h.Length > 0)
				{
					DisplayForm df = new DisplayForm(h);
					df.ShowDialog();
				}
			}
		}
	}
}
