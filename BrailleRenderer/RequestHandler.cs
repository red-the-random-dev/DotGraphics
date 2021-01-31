/*
 * Section that responds for manipulating Braille object files.
 */
using System;
using System.Drawing;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using DotGraphics.Screens;

/// <summary>
/// Console version of request handler. Change namespace's name if you intend to replicate this class (i.e. for UI application).
/// </summary>
namespace DotGraphics.Requests.NoUI
{
	/// <summary>
	/// Description of RequestHandler.
	/// </summary>
	public class RequestHandler
	{
		/// <summary>
  		/// Method that uses the ImageConverter object in .Net Framework to convert a byte array, 
  		/// presumably containing a JPEG or PNG file image, into a Bitmap object, which can also be 
  		/// used as an Image object.
  		/// </summary>
  		/// <param name="byteArray">byte array containing JPEG or PNG file image or similar</param>
  		/// <returns>Bitmap object if it works, else exception is thrown</returns>
  		public static Bitmap GetImageFromByteArray(byte[] byteArray)
  		{
  			ImageConverter _imageConverter = new ImageConverter();
     		Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);
			
     		if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution || bm.VerticalResolution != (int)bm.VerticalResolution))
     		{
        		// Correct a strange glitch that has been observed in the test program when converting 
        		//  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
        		//  slightly away from the nominal integer value
        		bm.SetResolution((int)(bm.HorizontalResolution + 0.5f), (int)(bm.VerticalResolution + 0.5f));
     		}

     		return bm;
  		}
		
		/// <summary>
		/// Conditional method for console output. Will be silenced by sending 'true' parameter into 'jamming' field.
		/// </summary>
		/// <param name="s">Object to output.</param>
		/// <param name="jamming">Takes a boolean variable. If it is true, display part will be skipped.</param>
		public static void CondVox(object s, Boolean jamming = false)
		{
			if (!jamming)
			{
				Console.WriteLine(s);
			}
		}
		
		/// <summary>
		/// Conditional method for waiting. Will be silenced by sending 'true' parameter into 'jamming' field.
		/// </summary>
		/// <param name="ms">Amount of milliseconds to wait through.</param>
		/// <param name="jamming">Takes a boolean variable. If it is true, waiting part will be skipped.</param>
		public static void CondWait(Int32 ms, Boolean jamming = false)
		{
			if (!jamming)
			{
				Thread.Sleep(ms);
			}
		}
		
		/// <summary>
		/// Conditional method for throwing exceptions. Will be triggered by sending 'true' parameter into 'jamming' field.
		/// </summary>
		/// <param name="e">Thrown exception.</param>
		/// <param name="jamming">Takes a boolean variable. If it is true, an exception will be thrown.</param>
		public static void CondThrow(Exception e, Boolean jamming = false)
		{
			if (jamming)
			{
				throw e;
			}
		}
		
		public static Boolean CondAssert(Boolean Condition, String VoxString = "", Boolean jamming = true)
		{
			if (!Condition)
			{
				CondVox(VoxString, jamming);
				CondThrow(new ArgumentException(VoxString), jamming);
			}
			return !Condition;
		}
		
		public static void RenderBrailleToTextFile(BrailleScreen Source, StreamWriter Target, Boolean EchoOff = false)
		{
			try
			{
				CondVox("Rendering image to text file...", EchoOff);
				String[] Container = new String[Source.Height / 4];
				Source.Render(ref Container);
				foreach (String x in Container)
				{
					Target.WriteLine(x);
				}
				CondWait(500, EchoOff);
				CondVox("Render complete!", EchoOff);
			}
			catch (Exception e)
			{
				CondVox("Error occured while trying to render an image to file.", EchoOff);
				CondVox(e, EchoOff);
				CondThrow(e, EchoOff);
			}
		}
		
		public static void RenderBrailleToTextFile(BrailleScreen Source, String SavePath, Boolean EchoOff = false)
		{
			try
			{
				CondVox("Making target file...", EchoOff);
				StreamWriter s = new StreamWriter(SavePath);
				CondWait(500, EchoOff);
				RenderBrailleToTextFile(Source, s, EchoOff);
				s.Close();
			}
			catch (Exception e)
			{
				CondVox("We were unsuccessful in creating an output file.", EchoOff);
				CondThrow(e, EchoOff);
			}
		}
		public static void RenderBrailleToTextFile(String StartPath, String EndPath, Boolean EchoOff = false)
		{
			BinaryFormatter bf = new BinaryFormatter();
			try
			{
				CondVox("Loading screen instance...", EchoOff);
				FileStream fs = new FileStream(StartPath, FileMode.Open);
				BrailleScreen bs = ((BrailleScreen) bf.Deserialize(fs));
				fs.Close();
				CondWait(500, EchoOff);
				RenderBrailleToTextFile(bs, EndPath, EchoOff);
			}
			catch (FileNotFoundException e)
			{
				CondVox("Unable to find given object file: "+StartPath, EchoOff);
				CondThrow(e, EchoOff);
			}
			catch (Exception e)
			{
				CondVox("Oh noes! Looks like something is wrong with the file!", EchoOff);
				CondVox(e, EchoOff);
				CondThrow(e, EchoOff);
			}
		}
		
		public static BrailleScreen ConstructBrailleFromImage(Bitmap Source, Boolean EchoOff = true)
		{
			CondVox("Validating image...", EchoOff);
			if (CondAssert(((Source.Width % 2) == 0 && (Source.Height % 4) == 0), "Image does not fit in following parameters: width is not multiple of 2 & height is not multiple of 4.", EchoOff))
			{
				return new BrailleScreen(2, 4);
			}
			if (CondAssert(((Source.Width >= 0 && Source.Width < 65536) || (Source.Height >= 0 && Source.Height < 65536)), "Image size is too large: width and height should be less than 65536.", EchoOff))
			{
				return new BrailleScreen(2, 4);
			}
			CondVox("Copying data to braille screen...", EchoOff);
			BrailleScreen bs = new BrailleScreen((UInt16)(Source.Width), (UInt16)(Source.Height));
			for (UInt16 i = 0; i < bs.Height; i++)
			{
				for (UInt16 x = 0; x < bs.Width; x++)
				{
					bs[x,i] = (Source.GetPixel(x, i).A != 0);
				}
			}
			
			return bs;
		}
		
		public static void CompileBrailleFromImage(Bitmap Source, FileStream Target, Boolean EchoOff = false)
		{
			BrailleScreen bs = ConstructBrailleFromImage(Source, EchoOff);
			CondVox("Braille screen built successfully.", EchoOff);
			CondVox("Dumping screen to file...", EchoOff);
			CondWait(500, EchoOff);
			BinaryFormatter bf = new BinaryFormatter();
			CondVox("bum, bum, be-dum, bum, bum, be-dum, bum...", EchoOff);
			CondWait(3500, EchoOff);
			bf.Serialize(Target, bs);
			CondVox("Procedure complete!", EchoOff);
			CondWait(500, EchoOff);
		}
		
		public static void CompileBrailleFromImage(Bitmap Source, String EndName, Boolean EchoOff = false)
		{
			CondVox(String.Format("Opening end file stream: {0}...", EndName), EchoOff);
			CondWait(1000, EchoOff);
			FileStream fs = new FileStream(EndName, FileMode.Create);
			CompileBrailleFromImage(Source, fs, EchoOff);
			fs.Close();
		}
		
		public static void CompileBrailleFromImage(String StartName, String EndName, Boolean EchoOff = false)
		{
			CondVox(String.Format("Receiving image: {0}...", StartName), EchoOff);
			CondWait(500, EchoOff);
			if (CondAssert(File.Exists(StartName), "Could not find image you're looking for.", EchoOff))
			{
				return;
			}
			
			Byte[] Data = File.ReadAllBytes(StartName);
			Bitmap bm = GetImageFromByteArray(Data);
			CondVox(String.Format("Dimensions: {0}x{1}", bm.Width, bm.Height), EchoOff);
			CompileBrailleFromImage(bm, EndName, EchoOff);
		}
	}
}
