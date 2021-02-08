/*
 * Main form used designed for drawing arts.
 */
namespace DotGraphics.BrailleEditor
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
			this.LoadButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.RenderButton = new System.Windows.Forms.Button();
			this.DrawingArea = new System.Windows.Forms.Panel();
			this.FileName = new System.Windows.Forms.Label();
			this.ScaleNumber = new System.Windows.Forms.NumericUpDown();
			this.WidthNumber = new System.Windows.Forms.NumericUpDown();
			this.HeightNumber = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.FillRadioBox = new System.Windows.Forms.RadioButton();
			this.ClearRadioBox = new System.Windows.Forms.RadioButton();
			this.CursorPosition = new System.Windows.Forms.Label();
			this.UndoButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ScaleNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WidthNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// LoadButton
			// 
			this.LoadButton.Location = new System.Drawing.Point(13, 13);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(110, 23);
			this.LoadButton.TabIndex = 0;
			this.LoadButton.Text = "Load from...";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButtonClick);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(129, 13);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(110, 23);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save to...";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
			// 
			// RenderButton
			// 
			this.RenderButton.Location = new System.Drawing.Point(824, 13);
			this.RenderButton.Name = "RenderButton";
			this.RenderButton.Size = new System.Drawing.Size(110, 23);
			this.RenderButton.TabIndex = 0;
			this.RenderButton.Text = "Render";
			this.RenderButton.UseVisualStyleBackColor = true;
			this.RenderButton.Click += new System.EventHandler(this.RenderButtonClick);
			// 
			// DrawingArea
			// 
			this.DrawingArea.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.DrawingArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.DrawingArea.Location = new System.Drawing.Point(13, 104);
			this.DrawingArea.Name = "DrawingArea";
			this.DrawingArea.Size = new System.Drawing.Size(921, 448);
			this.DrawingArea.TabIndex = 1;
			// 
			// FileName
			// 
			this.FileName.Location = new System.Drawing.Point(13, 43);
			this.FileName.Name = "FileName";
			this.FileName.Size = new System.Drawing.Size(226, 23);
			this.FileName.TabIndex = 2;
			this.FileName.Text = "No file loaded";
			// 
			// ScaleNumber
			// 
			this.ScaleNumber.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.ScaleNumber.Location = new System.Drawing.Point(94, 64);
			this.ScaleNumber.Maximum = new decimal(new int[] {
									720,
									0,
									0,
									0});
			this.ScaleNumber.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.ScaleNumber.Name = "ScaleNumber";
			this.ScaleNumber.ReadOnly = true;
			this.ScaleNumber.Size = new System.Drawing.Size(54, 22);
			this.ScaleNumber.TabIndex = 3;
			this.ScaleNumber.Value = new decimal(new int[] {
									16,
									0,
									0,
									0});
			// 
			// WidthNumber
			// 
			this.WidthNumber.Increment = new decimal(new int[] {
									2,
									0,
									0,
									0});
			this.WidthNumber.Location = new System.Drawing.Point(235, 64);
			this.WidthNumber.Maximum = new decimal(new int[] {
									256,
									0,
									0,
									0});
			this.WidthNumber.Minimum = new decimal(new int[] {
									2,
									0,
									0,
									0});
			this.WidthNumber.Name = "WidthNumber";
			this.WidthNumber.Size = new System.Drawing.Size(54, 22);
			this.WidthNumber.TabIndex = 3;
			this.WidthNumber.Value = new decimal(new int[] {
									4,
									0,
									0,
									0});
			// 
			// HeightNumber
			// 
			this.HeightNumber.Increment = new decimal(new int[] {
									4,
									0,
									0,
									0});
			this.HeightNumber.Location = new System.Drawing.Point(376, 64);
			this.HeightNumber.Maximum = new decimal(new int[] {
									256,
									0,
									0,
									0});
			this.HeightNumber.Minimum = new decimal(new int[] {
									4,
									0,
									0,
									0});
			this.HeightNumber.Name = "HeightNumber";
			this.HeightNumber.Size = new System.Drawing.Size(54, 22);
			this.HeightNumber.TabIndex = 3;
			this.HeightNumber.Value = new decimal(new int[] {
									4,
									0,
									0,
									0});
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(154, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 22);
			this.label2.TabIndex = 4;
			this.label2.Text = "Width";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(295, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 22);
			this.label3.TabIndex = 4;
			this.label3.Text = "Height";
			// 
			// FillRadioBox
			// 
			this.FillRadioBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FillRadioBox.Location = new System.Drawing.Point(245, 14);
			this.FillRadioBox.Name = "FillRadioBox";
			this.FillRadioBox.Size = new System.Drawing.Size(75, 24);
			this.FillRadioBox.TabIndex = 5;
			this.FillRadioBox.TabStop = true;
			this.FillRadioBox.Text = "Fill";
			this.FillRadioBox.UseVisualStyleBackColor = true;
			// 
			// ClearRadioBox
			// 
			this.ClearRadioBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ClearRadioBox.Location = new System.Drawing.Point(326, 14);
			this.ClearRadioBox.Name = "ClearRadioBox";
			this.ClearRadioBox.Size = new System.Drawing.Size(75, 24);
			this.ClearRadioBox.TabIndex = 5;
			this.ClearRadioBox.TabStop = true;
			this.ClearRadioBox.Text = "Clear";
			this.ClearRadioBox.UseVisualStyleBackColor = true;
			// 
			// CursorPosition
			// 
			this.CursorPosition.Location = new System.Drawing.Point(407, 13);
			this.CursorPosition.Name = "CursorPosition";
			this.CursorPosition.Size = new System.Drawing.Size(66, 22);
			this.CursorPosition.TabIndex = 4;
			// 
			// UndoButton
			// 
			this.UndoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.UndoButton.Location = new System.Drawing.Point(13, 63);
			this.UndoButton.Name = "UndoButton";
			this.UndoButton.Size = new System.Drawing.Size(75, 23);
			this.UndoButton.TabIndex = 6;
			this.UndoButton.Text = "Undo";
			this.UndoButton.UseVisualStyleBackColor = true;
			this.UndoButton.Click += new System.EventHandler(this.UndoButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 564);
			this.Controls.Add(this.UndoButton);
			this.Controls.Add(this.ClearRadioBox);
			this.Controls.Add(this.FillRadioBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CursorPosition);
			this.Controls.Add(this.HeightNumber);
			this.Controls.Add(this.WidthNumber);
			this.Controls.Add(this.ScaleNumber);
			this.Controls.Add(this.FileName);
			this.Controls.Add(this.DrawingArea);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.RenderButton);
			this.Controls.Add(this.LoadButton);
			this.ImeMode = System.Windows.Forms.ImeMode.On;
			this.Name = "MainForm";
			this.Text = "BrailleEditor";
			((System.ComponentModel.ISupportInitialize)(this.ScaleNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WidthNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightNumber)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button UndoButton;
		private System.Windows.Forms.Label CursorPosition;
		private System.Windows.Forms.RadioButton ClearRadioBox;
		private System.Windows.Forms.RadioButton FillRadioBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown HeightNumber;
		private System.Windows.Forms.NumericUpDown WidthNumber;
		private System.Windows.Forms.NumericUpDown ScaleNumber;
		private System.Windows.Forms.Label FileName;
		private System.Windows.Forms.Panel DrawingArea;
		private System.Windows.Forms.Button RenderButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button LoadButton;
	}
}
