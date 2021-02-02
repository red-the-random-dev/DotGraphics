/*
 * Created by SharpDevelop.
 * User: Lenovo Yoga
 * Date: 01.02.2021
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DotGraphics.BrailleUI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.ConstructButton = new System.Windows.Forms.Button();
			this.PNGLocationBox = new System.Windows.Forms.TextBox();
			this.ImageSelectButton = new System.Windows.Forms.Button();
			this.ObjectLocationBox = new System.Windows.Forms.TextBox();
			this.ObjectPathSelectButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.RenderButton = new System.Windows.Forms.Button();
			this.TargetObjectLocationBox = new System.Windows.Forms.TextBox();
			this.TextSaveLocationBox = new System.Windows.Forms.TextBox();
			this.ObjectSelectButton = new System.Windows.Forms.Button();
			this.TextLocationSelectButton = new System.Windows.Forms.Button();
			this.ShowResultTickBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(489, 43);
			this.label1.TabIndex = 0;
			this.label1.Text = "Instantiate Braille screen object from image:";
			// 
			// ConstructButton
			// 
			this.ConstructButton.Location = new System.Drawing.Point(508, 12);
			this.ConstructButton.Name = "ConstructButton";
			this.ConstructButton.Size = new System.Drawing.Size(120, 23);
			this.ConstructButton.TabIndex = 1;
			this.ConstructButton.Text = "Construct";
			this.ConstructButton.UseVisualStyleBackColor = true;
			this.ConstructButton.Click += new System.EventHandler(this.ConstructButtonClick);
			// 
			// PNGLocationBox
			// 
			this.PNGLocationBox.Enabled = false;
			this.PNGLocationBox.Location = new System.Drawing.Point(12, 59);
			this.PNGLocationBox.Name = "PNGLocationBox";
			this.PNGLocationBox.ReadOnly = true;
			this.PNGLocationBox.Size = new System.Drawing.Size(489, 22);
			this.PNGLocationBox.TabIndex = 2;
			this.PNGLocationBox.Text = "Choose PNG file location...";
			// 
			// ImageSelectButton
			// 
			this.ImageSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ImageSelectButton.Location = new System.Drawing.Point(509, 57);
			this.ImageSelectButton.Name = "ImageSelectButton";
			this.ImageSelectButton.Size = new System.Drawing.Size(120, 23);
			this.ImageSelectButton.TabIndex = 3;
			this.ImageSelectButton.Text = "Load from...";
			this.ImageSelectButton.UseVisualStyleBackColor = true;
			this.ImageSelectButton.Click += new System.EventHandler(this.ImageSelectButtonClick);
			// 
			// ObjectLocationBox
			// 
			this.ObjectLocationBox.Enabled = false;
			this.ObjectLocationBox.Location = new System.Drawing.Point(13, 88);
			this.ObjectLocationBox.Name = "ObjectLocationBox";
			this.ObjectLocationBox.ReadOnly = true;
			this.ObjectLocationBox.Size = new System.Drawing.Size(489, 22);
			this.ObjectLocationBox.TabIndex = 4;
			this.ObjectLocationBox.Text = "Choose where to serialize object to...";
			// 
			// ObjectPathSelectButton
			// 
			this.ObjectPathSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ObjectPathSelectButton.Location = new System.Drawing.Point(509, 86);
			this.ObjectPathSelectButton.Name = "ObjectPathSelectButton";
			this.ObjectPathSelectButton.Size = new System.Drawing.Size(120, 23);
			this.ObjectPathSelectButton.TabIndex = 5;
			this.ObjectPathSelectButton.Text = "Save to...";
			this.ObjectPathSelectButton.UseVisualStyleBackColor = true;
			this.ObjectPathSelectButton.Click += new System.EventHandler(this.ObjectPathSelectButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(489, 43);
			this.label2.TabIndex = 0;
			this.label2.Text = "Render object to text file:";
			// 
			// RenderButton
			// 
			this.RenderButton.Location = new System.Drawing.Point(509, 133);
			this.RenderButton.Name = "RenderButton";
			this.RenderButton.Size = new System.Drawing.Size(120, 23);
			this.RenderButton.TabIndex = 1;
			this.RenderButton.Text = "Render";
			this.RenderButton.UseVisualStyleBackColor = true;
			this.RenderButton.Click += new System.EventHandler(this.RenderButtonClick);
			// 
			// TargetObjectLocationBox
			// 
			this.TargetObjectLocationBox.Enabled = false;
			this.TargetObjectLocationBox.Location = new System.Drawing.Point(14, 182);
			this.TargetObjectLocationBox.Name = "TargetObjectLocationBox";
			this.TargetObjectLocationBox.ReadOnly = true;
			this.TargetObjectLocationBox.Size = new System.Drawing.Size(489, 22);
			this.TargetObjectLocationBox.TabIndex = 2;
			this.TargetObjectLocationBox.Text = "Choose serialized object...";
			// 
			// TextSaveLocationBox
			// 
			this.TextSaveLocationBox.Enabled = false;
			this.TextSaveLocationBox.Location = new System.Drawing.Point(14, 210);
			this.TextSaveLocationBox.Name = "TextSaveLocationBox";
			this.TextSaveLocationBox.ReadOnly = true;
			this.TextSaveLocationBox.Size = new System.Drawing.Size(489, 22);
			this.TextSaveLocationBox.TabIndex = 4;
			this.TextSaveLocationBox.Text = "Choose where to render object to...";
			// 
			// ObjectSelectButton
			// 
			this.ObjectSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ObjectSelectButton.Location = new System.Drawing.Point(509, 181);
			this.ObjectSelectButton.Name = "ObjectSelectButton";
			this.ObjectSelectButton.Size = new System.Drawing.Size(120, 23);
			this.ObjectSelectButton.TabIndex = 3;
			this.ObjectSelectButton.Text = "Load from...";
			this.ObjectSelectButton.UseVisualStyleBackColor = true;
			this.ObjectSelectButton.Click += new System.EventHandler(this.ObjectSelectButtonClick);
			// 
			// TextLocationSelectButton
			// 
			this.TextLocationSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.TextLocationSelectButton.Location = new System.Drawing.Point(509, 209);
			this.TextLocationSelectButton.Name = "TextLocationSelectButton";
			this.TextLocationSelectButton.Size = new System.Drawing.Size(120, 23);
			this.TextLocationSelectButton.TabIndex = 5;
			this.TextLocationSelectButton.Text = "Save to...";
			this.TextLocationSelectButton.UseVisualStyleBackColor = true;
			this.TextLocationSelectButton.Click += new System.EventHandler(this.TextLocationSelectButtonClick);
			// 
			// ShowResultTickBox
			// 
			this.ShowResultTickBox.Location = new System.Drawing.Point(14, 239);
			this.ShowResultTickBox.Name = "ShowResultTickBox";
			this.ShowResultTickBox.Size = new System.Drawing.Size(489, 24);
			this.ShowResultTickBox.TabIndex = 6;
			this.ShowResultTickBox.Text = "Show result when render finishes";
			this.ShowResultTickBox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(641, 278);
			this.Controls.Add(this.ShowResultTickBox);
			this.Controls.Add(this.TextLocationSelectButton);
			this.Controls.Add(this.ObjectPathSelectButton);
			this.Controls.Add(this.TextSaveLocationBox);
			this.Controls.Add(this.ObjectLocationBox);
			this.Controls.Add(this.ObjectSelectButton);
			this.Controls.Add(this.ImageSelectButton);
			this.Controls.Add(this.TargetObjectLocationBox);
			this.Controls.Add(this.PNGLocationBox);
			this.Controls.Add(this.RenderButton);
			this.Controls.Add(this.ConstructButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "DotGraphics Braille Converter";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox ShowResultTickBox;
		private System.Windows.Forms.Button TextLocationSelectButton;
		private System.Windows.Forms.Button ObjectSelectButton;
		private System.Windows.Forms.TextBox TextSaveLocationBox;
		private System.Windows.Forms.TextBox TargetObjectLocationBox;
		private System.Windows.Forms.Button RenderButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button ObjectPathSelectButton;
		private System.Windows.Forms.TextBox ObjectLocationBox;
		private System.Windows.Forms.Button ImageSelectButton;
		private System.Windows.Forms.TextBox PNGLocationBox;
		private System.Windows.Forms.Button ConstructButton;
		private System.Windows.Forms.Label label1;
	}
}
