﻿/*
 * Created by SharpDevelop.
 * User: Lenovo Yoga
 * Date: 30.01.2021
 * Time: 17:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;



namespace BrailleRenderer
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
