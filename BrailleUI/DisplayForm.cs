/*
 * Display form.
 */
using System;
using System.Drawing;
using System.Windows.Forms;



namespace DotGraphics.BrailleUI
{
	/// <summary>
	/// Description of DisplayForm.
	/// </summary>
	public partial class DisplayForm : Form
	{
		public DisplayForm(String[] DisplayText)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			listBox1.Items.Clear();
			foreach (String i in DisplayText)
			{
				listBox1.Items.Add(i);
			}
		}
	}
}
