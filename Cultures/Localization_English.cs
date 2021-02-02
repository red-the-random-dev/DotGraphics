/*
 * English localization.
 */
using System;
using System.Globalization;
using System.Collections.Generic;

namespace DotGraphics.Cultures
{
	public static partial class Localization
	{
		static Dictionary<String, String> English = new Dictionary<string, string>();
		
		static void InitializeEnglish()
		{
			// Window titles
			English.Add("wintitle", "DotGraphics Braille Renderer");
			English.Add("alerttitle", "Braille Renderer");
			// Success
			English.Add("ok_render", "Render complete!");
			English.Add("ok_compiled", "Compilation complete!");
			// Errors
			English.Add("error_pngnotfound", "Could not find image you're looking for.");
			English.Add("error_objectnotfound", "Unable to find given object file: ");
			English.Add("error_renderdumpfail", "We were unsuccessful in creating an output file.");
			English.Add("error_objectloadfail", "Oh noes! Looks like something is wrong with the file!");
			English.Add("error_imageaspectratio", "Image does not fit in following parameters: width is not multiple of 2 & height is not multiple of 4.");
			English.Add("error_imagetoolarge", "Image size is too large: width and height should be less than 65536.");
			English.Add("error_renderfail", "Error occured while trying to render an image to file.");
			// Section titles
			English.Add("ui_complabel", "Instantiate Braille screen object from image:");
			English.Add("ui_renderlabel", "Render object to text file:");
			// Compile section
			English.Add("ui_pnglabel", "Choose PNG file location...");
			English.Add("ui_objlabel", "Choose where to serialize object to...");
			English.Add("ui_compilebutton", "Construct");
			// Render section
			English.Add("ui_targetlabel", "Choose serialized object...");
			English.Add("ui_txtlabel", "Choose where to render object to...");
			English.Add("ui_renderbutton", "Render");
			// Save, Load, and Show result
			English.Add("ui_loadbutton", "Load from...");
			English.Add("ui_savebutton", "Save to...");
			English.Add("ui_showresult", "Show result when render finishes");
			// File type filters
			English.Add("filter_txt", "Text document (*.txt)|*.txt");
			English.Add("filter_png", "PNG image file (*.png)|*.png");
			English.Add("filter_o", "Serialized object (*.o)|*.o");
			
			LanguageGetters.Add("en-US", GetEnglish);
			Languages.Add("en-US");
		}
		
		static String GetEnglish(String Key)
		{
			if (!Ready)
			{
				Initialize();
				return GetEnglish(Key);
			}
			
			return English[Key];
		}
	}
}
