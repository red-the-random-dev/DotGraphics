/*
 * Braille screen class definition.
 * Used for storing and rendering monochrome pictures in Braille code.
 */
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotGraphics.Screens
{
	/// <summary>
	/// 8-dot Braille matrix screen. Can be serialized for easier saving.
	/// </summary>
	[Serializable]
	public class BrailleScreen : MonochromeScreen
	{
		protected static Int32 StarterIndex = 0x2800;
		protected Char[,] BrailleMatrix;
		
		/// <summary>
		/// Indexator for boolean matrix. First coordinate is offset from left edge, second: offset from right edge.
		/// </summary>
		/// <exception cref="System.IndexOutOfRangeException">Thrown if index exceeds screen's dimensions.</exception>
		public Boolean this[UInt16 X, UInt16 Y]
		{
			get
			{
				if (X >= Width || Y >= Height)
				{
					throw new IndexOutOfRangeException("Value is out of screen's bounds.");
				}
				return this.BinaryMatrix[Y,X];
			}
			set
			{
				this.BinaryMatrix[Y,X] = value;
			}
		}
		
		/// <summary>
		/// Creates an instance of Braille matrix screen.
		/// </summary>
		/// <param name="width">Width of screen that must represent multiple of 2.</param>
		/// <param name="height">Height of screen that must represent multiple of 3.</param>
		/// <exception cref="System.ArgumentException">Received width or height values that do not fit given parameter conditions.</exception>
		public BrailleScreen(UInt16 width, UInt16 height)
		{
			if (width % 2 != 0)
			{
				throw new ArgumentException("Width value must be multiple of 2.");
			}
			if (height % 4 != 0)
			{
				throw new ArgumentException("Height value must be multiple of 4.");
			}
			this.Width = width;
			this.Height = height;
			
			BinaryMatrix = new Boolean[height,width];
			BrailleMatrix = new Char[height/4,width/2];
		}
		
		/// <summary>
		/// Internal function that renders an image in Braille art from boolean array.
		/// </summary>
		protected override void Render()
		{
			UInt16 NewSizeX = (UInt16) (this.Width / 2);
			UInt16 NewSizeY = (UInt16) (this.Height / 4);
			
			for (UInt16 i = 0; i < NewSizeY; i++)
			{
				for (UInt16 x = 0; x < NewSizeX; x++)
				{
					// Console.WriteLine("{0} {1}", i, x);
					Char Symbol = ((Char) (((UInt16) (0x2800)) + (((BinaryMatrix[(i*4)+3,(x*2)+1] ? 1 : 0) << 7)+((BinaryMatrix[(i*4)+3,(x*2)] ? 1 : 0) << 6)+((BinaryMatrix[(i*4)+2,(x*2)+1] ? 1 : 0) << 5) + ((BinaryMatrix[(i*4)+1,(x*2)+1] ? 1 : 0) << 4) + ((BinaryMatrix[(i*4),(x*2)+1] ? 1 : 0) << 3) + ((BinaryMatrix[(i*4)+2,(x*2)] ? 1 : 0) << 2) + ((BinaryMatrix[(i*4)+1,(x*2)] ? 1 : 0) << 1) + ((BinaryMatrix[(i*4),(x*2)] ? 1 : 0)))));
					BrailleMatrix[i,x] = Symbol;
				}
			}
		}
		
		/// <summary>
		/// Public render function that uses unloading buffer.
		///	</summary>
		/// <param name="UnloadingBuffer">String array to render image into.</param>
		/// <exception cref="System.ArgumentException">Thrown if unloading buffer has mismatching length (length of array must be equal to screen's height divided by 3).</exception>
		public void Render(ref String[] UnloadingBuffer)
		{
			this.Render();
			
			UInt16 NewSizeX = (UInt16) (this.Width / 2);
			UInt16 NewSizeY = (UInt16) (this.Height / 4);
			
			if (UnloadingBuffer.Length != NewSizeY)
			{
				throw new ArgumentException("Unloading buffer must have length equal to screen's height divided by 4.");
			}
			
			for (ushort i = 0; i < NewSizeY; i++)
			{
				String ToAdd = "";
				for (ushort x = 0; x < NewSizeX; x++)
				{
					ToAdd += this.BrailleMatrix[i,x];
				}
				UnloadingBuffer[i] = ToAdd;
			}
		}
		
		/// <summary>
		/// Static method that conjoins foreground with background.
		/// </summary>
		/// <param name="Foreground">Screen with contect that must be added on top.</param>
		/// <param name="Background">Screen with contect that will be added with foreground's content.</param>
		/// <returns>New instance of screen that contains merged image.</returns>
		public static BrailleScreen Merge(BrailleScreen Foreground, BrailleScreen Background, UInt16 OffsetLeft=0, UInt16 OffsetTop=0)
		{
			BrailleScreen Returned = new BrailleScreen(Background.Width, Background.Height);
			Returned.BinaryMatrix = Background.BinaryMatrix;
			
			if (OffsetLeft + Foreground.Width > Background.Width || OffsetTop + Foreground.Height > Background.Height)
			{
				throw new IndexOutOfRangeException("Cannot merge two given screens: foreground out of bounds.");
			}
			
			for (UInt16 i = OffsetTop; i < (OffsetTop+Foreground.Height); i++)
			{
				for (UInt16 x = OffsetLeft; x < (OffsetLeft+Foreground.Width); x++)
				{
					
					Returned[x,i] = (Foreground[((UInt16) (x-OffsetLeft)),((UInt16) (i-OffsetTop))] || Background[x,i]);
				}
			}
			return Returned;
		}
	}
}
