/*
 * Main form designed for drawing arts.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
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
		Stack<Byte[]> UndoStack = new Stack<Byte[]>();
		MouseButtons ActiveButton = MouseButtons.None;
		BrailleScreen LoadedScreen;
		Int32 DrawingOffsetHorizontal;
		Int32 DrawingOffsetVertical;
		Int32 DefaultDrawingAreaWidth;
		Int32 DefaultDrawingAreaHeight;
		Int32 DefaultDrawingAreaX;
		Int32 DefaultDrawingAreaY;
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
			UndoButton.Text = Localization.Get("ui_undo");
			FileName.Text = Localization.Get("ui_nofile");
			label2.Text = Localization.Get("ui_width");
			label3.Text = Localization.Get("ui_height");
			FillRadioBox.Text = Localization.Get("ui_fill");
			ClearRadioBox.Text = Localization.Get("ui_clear");
			
			LoadedScreen = new BrailleScreen(4, 4);
			
			DefaultRenderButtonX = RenderButton.Location.X;
			DefaultRenderButtonY = RenderButton.Location.Y;
			DefaultDrawingAreaWidth = DrawingArea.Width;
			DefaultDrawingAreaHeight = DrawingArea.Height;
			HeightNumber.Maximum = (decimal) (DefaultDrawingAreaHeight - (DefaultDrawingAreaHeight % 4));
			WidthNumber.Maximum = HeightNumber.Maximum;
			DefaultDrawingAreaY = DrawingArea.Location.Y;
			DefaultDrawingAreaX = DrawingArea.Location.X;
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
			RedrawElements(sender, e);
		}
		
		public void RedrawGrid()
		{
			DrawingArea.Refresh();
			DrawingOffsetHorizontal = (DrawingArea.Width/2)-((int)(ScaleNumber.Value * LoadedScreen.Width)/2);
			DrawingOffsetVertical = (DrawingArea.Height/2)-((int)(ScaleNumber.Value * LoadedScreen.Height)/2);
			
			Graphics g = DrawingArea.CreateGraphics();
			SolidBrush n = new SolidBrush(Color.Black);
			SolidBrush w = new SolidBrush(Color.White);
			g.FillRectangle(w, DrawingOffsetHorizontal, DrawingOffsetVertical, ((float) (LoadedScreen.Width*ScaleNumber.Value)), ((float) (LoadedScreen.Height*ScaleNumber.Value)));
			for (ushort i = 0; i < LoadedScreen.Width; i++)
			{
				for (ushort x = 0; x < LoadedScreen.Height; x++)
				{
					if (LoadedScreen[i, x])
					{
						g.FillRectangle(n, ((float) (i*ScaleNumber.Value))+DrawingOffsetHorizontal, ((float) (x*ScaleNumber.Value))+DrawingOffsetVertical, ((float) (ScaleNumber.Value)), ((float) (ScaleNumber.Value)));
					}
				}
			}
			for (int i = ((int) ScaleNumber.Value)+DrawingOffsetHorizontal; i <= (Math.Min(DrawingArea.Width, (LoadedScreen.Width * ScaleNumber.Value))) + DrawingOffsetHorizontal && ScaleNumber.Value >= 16; i += (int) ScaleNumber.Value)
			{
				Pen p = new Pen(Color.Blue);
				Int32 LowerLimit = Math.Min((int) ScaleNumber.Value*LoadedScreen.Height, DrawingArea.Height);
				g.DrawLine(p, new Point(i, DrawingOffsetVertical), new Point(i, LowerLimit+DrawingOffsetVertical));
			}
			for (int i = ((int) ScaleNumber.Value)+DrawingOffsetVertical; i <= (Math.Min(DrawingArea.Height, (LoadedScreen.Height * ScaleNumber.Value)))+DrawingOffsetVertical && ScaleNumber.Value >= 16; i += (int) ScaleNumber.Value)
			{
				Pen p = new Pen(Color.Blue);
				Int32 LowerLimit = Math.Min((int) ScaleNumber.Value*LoadedScreen.Width, DrawingArea.Width);
				g.DrawLine(p, new Point(DrawingOffsetHorizontal, i), new Point(LowerLimit+DrawingOffsetHorizontal, i));
			}
		}
		
		void IncreaseScreenHorizontally(object sender, EventArgs e)
		{
			PushScreen();
			WidthNumber.Value = Math.Min(Math.Ceiling(WidthNumber.Value / 2) * 2, 1024);
			
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
			PushScreen();
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
			Decimal NewScale = (decimal) Math.Min(DrawingArea.Height / LoadedScreen.Height, DrawingArea.Width / LoadedScreen.Width);
			ScaleNumber.Value = (this.Width != 0 ? Math.Max(NewScale, 1) : ScaleNumber.Value);
			
			RedrawGrid();
		}
		
		void MouseClicked(object sender, MouseEventArgs e)
		{
			if (!(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
			{
				return;
			}
			else if (e.Location.X >= DrawingOffsetHorizontal && e.Location.X < DrawingOffsetHorizontal+((int)(ScaleNumber.Value*LoadedScreen.Width)) && e.Location.Y >= 0 && e.Location.Y < ((int)(ScaleNumber.Value*LoadedScreen.Height)))
			{
				PushScreen();
				this.IsPressed = true;
				this.ActiveButton = e.Button;
			}
			
		}
		
		void PushScreen()
		{
			using (MemoryStream ms = new MemoryStream())
			{
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(ms, LoadedScreen);
				Byte[] b = ms.GetBuffer();
				UndoStack.Push(b);
			}
			// UndoStack.Push(bs);
		}
		
		void MouseReleased(object sender, MouseEventArgs e)
		{
			if (this.IsPressed)
			{
				CursorPosition.Text = "";
			}
			this.IsPressed = false;
			this.ActiveButton = MouseButtons.None;
			CursorPosition.Text = "";
			
			RedrawElements(sender, e);
		}
		
		void MouseDrag(object sender, MouseEventArgs e)
		{
			Int32 LimitX = (int) (ScaleNumber.Value * LoadedScreen.Width);
			Int32 LimitY = (int) (ScaleNumber.Value * LoadedScreen.Height);
			if (IsPressed && e.Location.X <= LimitX+DrawingOffsetHorizontal && e.Location.Y+DrawingOffsetVertical <= LimitY && e.Location.X > DrawingOffsetHorizontal && e.Location.Y > 0)
			{
				CursorPosition.Text = String.Format("[{0}, {1}]", (Math.Floor((e.Location.X-DrawingOffsetHorizontal) / ScaleNumber.Value)), (Math.Floor(e.Location.Y / ScaleNumber.Value)));
				UInt16 x = ((UInt16) (Math.Floor((e.Location.X-DrawingOffsetHorizontal) / ScaleNumber.Value)));
				UInt16 y = ((UInt16) (Math.Floor((e.Location.Y-DrawingOffsetVertical) / ScaleNumber.Value)));
				SetPixel(x, y, this.ActiveButton);
				SolidBrush sb = new SolidBrush(Color.LightBlue);
				Graphics g = DrawingArea.CreateGraphics();
				g.FillRectangle(sb, ((float) (x*ScaleNumber.Value))+DrawingOffsetHorizontal, ((float) (y*ScaleNumber.Value))+DrawingOffsetVertical, ((float) (ScaleNumber.Value)), ((float) (ScaleNumber.Value)));
			}
		}
		
		void SetPixel(UInt16 X, UInt16 Y, MouseButtons m)
		{
			if (X >= LoadedScreen.Width || Y >= LoadedScreen.Height)
			{
				return;
			}
			
			if (m == MouseButtons.Left && FillRadioBox.Checked)
			{
				LoadedScreen[X, Y] = true;
			}
			if (m == MouseButtons.Right || (m == MouseButtons.Left && ClearRadioBox.Checked))
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
				BrailleScreen bs = ((BrailleScreen) bf.Deserialize(fs));
				if (!(bs.Width > WidthNumber.Maximum || bs.Height > HeightNumber.Maximum))
				{
					LoadedScreen = bs;
				}
				else
				{
					MessageBox.Show(String.Format(Localization.Get("error_objecttoolarge"), HeightNumber.Maximum), "Braille Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				fs.Close();
				FileName.Text = Path.GetFileName(Ofd.FileName);
				UndoStack.Clear();
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
		
		void UndoButtonClick(object sender, EventArgs e)
		{
			if (UndoStack.ToArray().Length > 0)
			{
				Byte[] b = UndoStack.Pop();
				using (MemoryStream ms = new MemoryStream(b, true))
				{
					BinaryFormatter bf = new BinaryFormatter();
					BrailleScreen bs = ((BrailleScreen) bf.Deserialize(ms));
					LoadedScreen = null;
					LoadedScreen = new BrailleScreen(bs.Width, bs.Height);
					for (UInt16 i = 0; i < bs.Width; i++)
					{
						for (UInt16 x = 0; x < bs.Height; x++)
						{
							LoadedScreen[i,x] = bs[i,x];
						}
					}
				}
			}
			WidthNumber.Value = (decimal) LoadedScreen.Width;
			HeightNumber.Value = (decimal) LoadedScreen.Height;
			RedrawGrid();
			RedrawElements(sender, e);
		}
	}
}
