/*
 * Display form.
 */
namespace DotGraphics.BrailleUI
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
			this.listBox1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Items.AddRange(new object[] {
									"Take your text"});
			this.listBox1.Location = new System.Drawing.Point(15, 12);
			this.listBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(1138, 424);
			this.listBox1.TabIndex = 0;
			// 
			// DisplayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1138, 462);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("OCR A Std", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "DisplayForm";
			this.Text = "Braille Screen Display";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox listBox1;
	}
}
