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
			ImageSelectButton.Text = Localization.Get("ui_loadbutton");
			ObjectSelectButton.Text = Localization.Get("ui_loadbutton");
			ObjectPathSelectButton.Text = Localization.Get("ui_savebutton");
			TextLocationSelectButton.Text = Localization.Get("ui_savebutton");
			PNGLocationBox.Text = Localization.Get("ui_pnglabel");
			ObjectLocationBox.Text = Localization.Get("ui_objlabel");
			TargetObjectLocationBox.Text = Localization.Get("ui_targetlabel");
			TextSaveLocationBox.Text = Localization.Get("ui_txtlabel");
			ShowResultTickBox.Text = Localization.Get("ui_showresult");
			label1.Text = Localization.Get("ui_complabel");
			label2.Text = Localization.Get("ui_renderlabel");
			
			ofd.InitialDirectory = Environment.GetEnvironmentVariable("userprofile");
			sfd.InitialDirectory = Environment.GetEnvironmentVariable("userprofile");
		}
		
		void ImageSelectButtonClick(object sender, EventArgs e)
		{
			ofd.Title = "Select image file to open";
			ofd.DefaultExt = "png";
			ofd.Filter = Localization.Get("filter_png");
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
			sfd.Filter = Localization.Get("filter_o");
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
			ofd.Filter = Localization.Get("filter_o");
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
			sfd.Filter = Localization.Get("filter_txt");
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
