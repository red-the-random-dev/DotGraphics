/*
 * Head file For BrailleRenderer.
 * Defines console application for handling requests regarding Braille image objects.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using DotGraphics.Screens;
using DotGraphics.Requests.NoUI;

namespace DotGraphics.BrailleRenderer
{
	public class Program
	{
		// static String BrailleReference = " A1B'K2L@CIF/MSP\"E3H9O6R^DJG>NTQ,*5<-U8V.%[$+X!&;:4\\0Z7(_?W]#Y)=";
		// static Int32 StarterIndex = 0x2800;
		
		public static void Example(Boolean EchoOff = false)
		{
			RequestHandler.CondVox("Creating an example file...", EchoOff);
			StreamWriter w = new StreamWriter("take your output.txt");
			BrailleScreen y = new BrailleScreen(16, 12);
			
			RequestHandler.CondWait(2000, EchoOff);
			y[0,0] = true;
			y[15,0] = true;
			y[0,8] = true;
			y[15,8] = true;
			RequestHandler.CondVox("bum, bum, be-dum, bum, bum, be-dum, bum...", EchoOff);
			RequestHandler.CondWait(3000, EchoOff);
			BrailleScreen x = new BrailleScreen(4, 4);
			x[0,0] = true;
			x[3,0] = true;
			x[0,2] = true;
			x[3,2] = true;
			BrailleScreen s = BrailleScreen.Merge(x, y, 6, 3);
			RequestHandler.CondVox("Rendering results...", EchoOff);
			RequestHandler.RenderBrailleToTextFile(s, w, false);
			w.Close();
			RequestHandler.CondWait(2000, EchoOff);
			RequestHandler.CondVox("Results saved to 'take your output.txt'.", EchoOff);
			RequestHandler.CondWait(1500, EchoOff);
		}
		
		public static void Main(string[] args)
		{
			try
			{
				BrailleScreen s = new BrailleScreen(4, 4);
			}
			catch (Exception)
			{
				Console.WriteLine("No 'DotGraphics.Screens' library connected!");
				Environment.Exit(-1);
			}
			List<String> Arguments = new List<string>();
			foreach (String i in args)
			{
				Arguments.Add(i);
			}
			
			Process(args.Length, Arguments, false);
		}
		
		public static void Process(Int32 argc, List<String> argv, Boolean EchoOff = false)
		{
			Boolean HasSilence = false;
			String Silencer = "";
			foreach (String i in argv)
			{
				if (i == "-silent" || i == "-s" || i == "-noecho" || i == "-nofeedback")
				{
					Silencer = i;
					HasSilence = true;
					break;
				}
			}
			
			if (HasSilence)
			{
				argv.Remove(Silencer);
				Process(argc-1, argv, true);
				return;
			}
			
			if (argc == 0)
			{
				if (!EchoOff)
				{
					Console.Beep(1000, 500);
					Thread.Sleep(500);
				}
				String[] Scrollable = {
					"BRAILLE RENDERER",
					"VERSION 1.0.1",
					"",
					"Usage:",
					"br.exe -silent | -s | -noecho | -nofeedback [parameters]: \n____ run a program without text and audial feedback (except for help list)",
					"br.exe -example: \n____render an example file (saved as 'take your output.txt')",
					"br.exe -o <png_file_here> <result_file_here>: \n____ compile PNG file as matrix screen instance (any opaque pixel is lit dot, any transparent pixel is empty dot)",
					"br.exe -rt <braille_screen_object_file_here> <result_file_here>: \n____ render compiled image as text file."
				};
				
				foreach (String i in Scrollable)
				{
					Console.WriteLine(i);
					if (!EchoOff)
					{
						Console.Beep(345, 75);
						Thread.Sleep(80 + (i.Length * 10));
					}
				}
				return;
			}
			
			if (argc == 1)
			{
				switch (argv[0])
				{
					case "-example":
					{
						try
						{
							Example(EchoOff);
						}
						catch (FileNotFoundException)
						{
							Console.WriteLine("MatrixScreen library is not connected. Reinstall the application and try again.");
						}
						catch (IOException)
						{
							Console.WriteLine("Unable to write data into ouput file. Check if no other processes use output file and close them if necessary.");
						}
						
						break;
					}
					case "-h":
					case "-help":
						Process(0, new List<String>(), EchoOff);
						break;
					/*
					 * Legacy debug code for displaying image data.
					case "-imgtest":
						if (!File.Exists("sample.png"))
						{
							Console.WriteLine("Could not find file 'sample.png'.");
							Console.ReadKey(true);
							return;
						}
						Byte[] Data = File.ReadAllBytes("sample.png");
						Int32 ImageWidth = ((Convert.ToInt32(Data[16]) << 24) + (Convert.ToInt32(Data[17]) << 16) + (Convert.ToInt32(Data[18]) << 8) + (Convert.ToInt32(Data[19])));
						Int32 ImageHeight = ((Convert.ToInt32(Data[20]) << 24) + (Convert.ToInt32(Data[21]) << 16) + (Convert.ToInt32(Data[22]) << 8) + (Convert.ToInt32(Data[23])));
						Console.WriteLine("Dimensions: {0}x{1}", ImageWidth, ImageHeight);
						Console.WriteLine("-------\n[IHDR]");
						ConsoleColor DefaultColor = Console.ForegroundColor;
						Int32 Cut = 0;
						for (Int32 x = 0; x < Data.Length; x++)
						{
							if (x == 33)
							{
								Console.WriteLine("\n[IDAT]");
							}
							else if (x <= Data.Length-8)
							{
								if (Data[x] == 73 && Data[x+1] == 69 && Data[x+2] == 78 && Data[x+3] == 68 && Data[x+4] == 174 && Data[x+5] == 66 && Data[x+6] == 96 && Data[x+7] == 130)
								{
									Cut = Data.Length - x;
									Console.WriteLine("\n[IEND]");
								}
							}
							if (Data.Length - x <= Cut && Data.Length - x >= Cut - 7)
							{
								Console.ForegroundColor = ConsoleColor.Green;
							}
							else
							{
								Console.ForegroundColor = DefaultColor;
							}
							Console.Write(Data[x]);
							Console.Write(x < Data.Length-1 ? " " : "\n");
						}
						Console.ForegroundColor = DefaultColor;
						Console.WriteLine("-------\nIHDR: 33; IDAT: {0}; IEND: {1}", (Data.Length - 33 - Cut), Cut);
						Bitmap bm = RequestHandler.GetImageFromByteArray(Data);
						Console.WriteLine(bm.PixelFormat);
						if (bm.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
						{
							Console.WriteLine("This image has no transparency!");
						}
						Color[,] c = new Color[ImageWidth,ImageHeight];
						for (int i = 0; i < ImageWidth; i++)
						{
							for (int x = 0; x < ImageHeight; x++)
							{
								c[i,x] = bm.GetPixel(i, x);
							}
						}
						
						for (int i = 0; i < ImageHeight; i++)
						{
							for (int x = 0; x < ImageWidth; x++)
							{
								Console.Write(c[x,i].A);
								Console.Write(" ");
							}
							Console.WriteLine();
						}
						RequestHandler.CompileBrailleFromImage("sample.png", "mybitmap.o", false);
						RequestHandler.RenderBrailleToTextFile("mybitmap.o", "sample.txt", false);
						Console.ReadKey(true);
						break;
					*/
					default:
					{
						if (!EchoOff)
						{
							Console.WriteLine("Could not find an option you're looking for. Run file without arguments or with '-help' parameter for list of suitable parameters.");
						}
						break;
					}
				}
			}
			if (argc >= 3)
			{
				switch (argv[0])
				{
					case "-o":
						RequestHandler.CompileBrailleFromImage(argv[1], argv[2], EchoOff);
						break;
					case "-rt":
						RequestHandler.RenderBrailleToTextFile(argv[1], argv[2], EchoOff);
						break;
					default:
						RequestHandler.CondVox("Unable to perform this operation as it's not listed in command list. Try checking the set of parameters.", EchoOff);
						break;
				}
				
				Int32 NewArgCount = argc - 3;
				argv.Remove(argv[0]);
				argv.Remove(argv[0]);
				argv.Remove(argv[0]);
				if (NewArgCount > 0)
				{
					Process(NewArgCount, argv, EchoOff);
				}
			}
		}
	}
}