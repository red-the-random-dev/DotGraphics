/*
 * Main form designed for drawing arts.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using DotGraphics.Screens;
using DotGraphics.Cultures;
using DotGraphics.Requests.WinUI;

namespace DotGraphics.BrailleEditor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		BrailleScreen LoadedScreen;
		Int32 DefaultDrawingAreaWidth;
		Int32 DefaultDrawingAreaHeight;
		Int32 DefaultRenderButtonX;
		Int32 DefaultRenderButtonY;
		Int32 DefaultFormWidth;
		Int32 DefaultFormHeight;
		Boolean IsPressed = false;
		
		OpenFileDialog Ofd = new OpenFileDialog();
		SaveFileDialog So = new SaveFileDialog();
		SaveFileDialog St = new SaveFileDialog();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.SizeChanged += RedrawElements;
			this.Shown += PoppedUp;
			ScaleNumber.ValueChanged += RedrawElements;
			WidthNumber.ValueChanged += IncreaseScreenHorizontally;
			HeightNumber.ValueChanged += IncreaseScreenVertically;
			LoadButton.Text = Localization.Get("ui_loadbutton");
			SaveButton.Text = Localization.Get("ui_savebutton");
			RenderButton.Text = Localization.Get("ui_renderbutton");
			FileName.Text = Localization.Get("ui_nofile");
			label1.Text = Localization.Get("ui_scale");
			label2.Text = Localization.Get("ui_width");
			label3.Text = Localization.Get("ui_height");
			FillRadioBox.Text = Localization.Get("ui_fill");
			ClearRadioBox.Text = Localization.Get("ui_clear");
			
			LoadedScreen = new BrailleScreen(2, 4);
			
			DefaultRenderButtonX = RenderButton.Location.X;
			DefaultRenderButtonY = RenderButton.Location.Y;
			DefaultDrawingAreaWidth = DrawingArea.Width;
			DefaultDrawingAreaHeight = DrawingArea.Height;
			DefaultFormWidth = this.Width;
			DefaultFormHeight = this.Height;
			
			DrawingArea.MouseDown += MouseClicked;
			DrawingArea.MouseUp += MouseReleased;
			DrawingArea.MouseMove += MouseDrag;
			
			FillRadioBox.Checked = true;
			
			// RedrawGrid();
		}
		
		void PoppedUp(object sender, EventArgs e)
		{
			RedrawGrid();
		}
		
		public void RedrawGrid()
		{
			DrawingArea.Refresh();
			Graphics g = DrawingArea.CreateGraphics();
			SolidBrush n = new SolidBrush(Color.Black);
			SolidBrush w = new SolidBrush(Color.White);
			g.FillRectangle(w, 0, 0, ((float) (LoadedScreen.Width*ScaleNumber.Value)), ((float) (LoadedScreen.Height*ScaleNumber.Value)));
			for (ushort i = 0; i < LoadedScreen.Width; i++)
			{
				for (ushort x = 0; x < LoadedScreen.Height; x++)
				{
					if (LoadedScreen[i, x])
					{
						g.FillRectangle(n, ((float) (i*ScaleNumber.Value)), ((float) (x*ScaleNumber.Value)), ((float) (ScaleNumber.Value)), ((float) (ScaleNumber.Value)));
					}
				}
			}
			for (int i = (int) ScaleNumber.Value; i <= Math.Min(DrawingArea.Width, (LoadedScreen.Width * ScaleNumber.Value)) && ScaleNumber.Value >= 16; i += (int) ScaleNumber.Value)
			{
				Pen p = new Pen(Color.Blue);
				Int32 LowerLimit = Math.Min((int) ScaleNumber.Value*LoadedScreen.Height, DrawingArea.Height);
				g.DrawLine(p, new Point(i, 0), new Point(i, LowerLimit));
			}
			for (int i = (int) ScaleNumber.Value; i <= Math.Min(DrawingArea.Height, (LoadedScreen.Height * ScaleNumber.Value)) && ScaleNumber.Value >= 16; i += (int) ScaleNumber.Value)
			{
				Pen p = new Pen(Color.Blue);
				Int32 LowerLimit = Math.Min((int) ScaleNumber.Value*LoadedScreen.Width, DrawingArea.Width);
				g.DrawLine(p, new Point(0, i), new Point(LowerLimit, i));
			}
		}
		
		void IncreaseScreenHorizontally(object sender, EventArgs e)
		{
			WidthNumber.Value = Math.Ceiling(WidthNumber.Value / 2) * 2;
			
			if (WidthNumber.Value > LoadedScreen.Width)
			{
				BrailleScreen x = new BrailleScreen(((UInt16) (WidthNumber.Value)), LoadedScreen.Height);
				LoadedScreen = BrailleScreen.Merge(LoadedScreen, x);
			}
			else if (WidthNumber.Value < LoadedScreen.Width)
			{
				for (UInt16 x = ((UInt16) (WidthNumber.Value)); x < LoadedScreen.Width; x++)
				{
					for (UInt16 y = 0; y < LoadedScreen.Height; y++)
					{
						if (LoadedScreen[x, y])
						{
							WidthNumber.Value = ((decimal) (LoadedScreen.Width));
							return;
						}
					}
				}
				BrailleScreen bs = new BrailleScreen((UInt16) (WidthNumber.Value), LoadedScreen.Height);
				for (UInt16 x = 0; x < WidthNumber.Value; x++)
				{
					for (UInt16 y = 0; y < bs.Height; y++)
					{
						bs[x, y] = LoadedScreen[x, y];
					}
				}
				LoadedScreen = bs;
			}
			RedrawElements(sender, e);
			
			WidthNumber.Value = ((decimal) (LoadedScreen.Width));
		}
		
		void IncreaseScreenVertically(object sender, EventArgs e)
		{
			HeightNumber.Value = Math.Ceiling(HeightNumber.Value / 4) * 4;
			
			if (HeightNumber.Value > LoadedScreen.Height)
			{
				BrailleScreen x = new BrailleScreen(LoadedScreen.Width, ((UInt16) (HeightNumber.Value)));
				LoadedScreen = BrailleScreen.Merge(LoadedScreen, x);
			}
			else if (HeightNumber.Value < LoadedScreen.Height)
			{
				for (UInt16 y = ((UInt16) (HeightNumber.Value)); y < LoadedScreen.Height; y++)
				{
					for (UInt16 x = 0; x < LoadedScreen.Width; x++)
					{
						if (LoadedScreen[x, y])
						{
							HeightNumber.Value = ((decimal) (LoadedScreen.Height));
							return;
						}
					}
				}
				BrailleScreen bs = new BrailleScreen(LoadedScreen.Width, ((UInt16) HeightNumber.Value));
				for (UInt16 y = 0; y < bs.Height; y++)
				{
					for (UInt16 x = 0; x < bs.Width; x++)
					{
						bs[x, y] = LoadedScreen[x, y];
					}
				}
				LoadedScreen = bs;
			}
			RedrawElements(sender, e);
			
			HeightNumber.Value = ((decimal) (LoadedScreen.Height));
		}
		
		public void RedrawElements(object sender, EventArgs e)
		{
			RenderButton.Location = new Point(DefaultRenderButtonX+(this.Width - DefaultFormWidth), DefaultRenderButtonY);
			DrawingArea.Width = DefaultDrawingAreaWidth+(this.Width - DefaultFormWidth);
			DrawingArea.Height = DefaultDrawingAreaHeight+(this.Height - DefaultFormHeight);
			this.Height = Math.Max(this.Height, this.DefaultFormHeight);
			this.Width = Math.Max(this.Width, this.Height);
			ScaleNumber.Value = (Math.Min(ScaleNumber.Value, Math.Min(((decimal) (DrawingArea.Width / LoadedScreen.Width)), ((decimal) (DrawingArea.Height / LoadedScreen.Height)))));
			RedrawGrid();
		}
		
		void MouseClicked(object sender, MouseEventArgs e)
		{
			this.IsPressed = true;
		}
		
		void MouseReleased(object sender, MouseEventArgs e)
		{
			this.IsPressed = false;
			CursorPosition.Text = "";
			RedrawElements(sender, e);
		}
		
		void MouseDrag(object sender, MouseEventArgs e)
		{
			Int32 LimitX = (int) (ScaleNumber.Value * LoadedScreen.Width);
			Int32 LimitY = (int) (ScaleNumber.Value * LoadedScreen.Height);
			if (IsPressed && e.Location.X <= LimitX && e.Location.Y <= LimitY && e.Location.X > 0 && e.Location.Y > 0)
			{
				UInt16 x = ((UInt16) (Math.Floor(e.Location.X / ScaleNumber.Value)));
				UInt16 y = ((UInt16) (Math.Floor(e.Location.Y / ScaleNumber.Value)));
				SetPixel(x, y);
				SolidBrush sb = new SolidBrush(Color.LightBlue);
				Graphics g = DrawingArea.CreateGraphics();
				g.FillRectangle(sb, ((float) (x*ScaleNumber.Value)), ((float) (y*ScaleNumber.Value)), ((float) (ScaleNumber.Value)), ((float) (ScaleNumber.Value)));
			}
			if (IsPressed && e.Location.X <= LimitX && e.Location.Y <= LimitY)
			{
				CursorPosition.Text = String.Format("[{0}, {1}]", (Math.Floor(e.Location.X / ScaleNumber.Value)), (Math.Floor(e.Location.Y / ScaleNumber.Value)));
			}
		}
		
		void SetPixel(UInt16 X, UInt16 Y)
		{
			if (X >= LoadedScreen.Width || Y >= LoadedScreen.Height)
			{
				return;
			}
			
			if (FillRadioBox.Checked)
			{
				LoadedScreen[X, Y] = true;
			}
			if (ClearRadioBox.Checked)
			{
				LoadedScreen[X, Y] = false;
			}
		}
		
		void LoadButtonClick(object sender, EventArgs e)
		{
			Ofd.Title = "Select object file to open";
			Ofd.DefaultExt = "o";
			Ofd.Filter = Localization.Get("filter_o");
			DialogResult dr = Ofd.ShowDialog();
			if (dr == DialogResult.OK && File.Exists(Ofd.FileName))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream fs = new FileStream(Ofd.FileName, FileMode.Open);
				LoadedScreen = ((BrailleScreen) bf.Deserialize(fs));
				fs.Close();
				FileName.Text = Path.GetFileName(Ofd.FileName);
			}
			WidthNumber.Value = (decimal) (LoadedScreen.Width);
			HeightNumber.Value = (decimal) (LoadedScreen.Height);
			RedrawElements(sender, e);
		}
		
		void SaveButtonClick(object sender, EventArgs e)
		{
			So.Title = "Select location to save object in";
			So.DefaultExt = "o";
			So.Filter = Localization.Get("filter_o");
			DialogResult dr = So.ShowDialog();
			if (dr == DialogResult.OK)
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream fs = new FileStream(So.FileName, FileMode.Create);
				bf.Serialize(fs, LoadedScreen);
				fs.Close();
				FileName.Text = Path.GetFileName(So.FileName);
			}
			WidthNumber.Value = (decimal) (LoadedScreen.Width);
			HeightNumber.Value = (decimal) (LoadedScreen.Height);
			RedrawElements(sender, e);
		}
		
		void RenderButtonClick(object sender, EventArgs e)
		{
			St.Title = "Select location to save text file in";
			St.DefaultExt = "txt";
			St.Filter = Localization.Get("filter_txt");
			DialogResult dr = St.ShowDialog();
			if (dr == DialogResult.OK)
			{
				RequestHandler.RenderBrailleToTextFile(LoadedScreen, St.FileName);
			}
		}
	}
}
