/*
 * Created by SharpDevelop.
 * User: Lenovo Yoga
 * Date: 30.01.2021
 * Time: 17:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BrailleRenderer
{
	partial class DisplayForm
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Items.AddRange(new object[] {
									"Here is your text",
									"(Actually, this form was supposed to contain some kind of art, you know)"});
			this.listBox1.Location = new System.Drawing.Point(12, 13);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(911, 468);
			this.listBox1.TabIndex = 0;
			// 
			// DisplayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(935, 493);
			this.Controls.Add(this.listBox1);
			this.Name = "DisplayForm";
			this.Text = "Braille Screen Display";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox listBox1;
	}
}
