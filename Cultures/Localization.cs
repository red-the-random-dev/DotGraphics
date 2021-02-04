/*
 * Localization class.
 */
using System;
using System.Globalization;
using System.Collections.Generic;

namespace DotGraphics.Cultures
{
	/// <summary>
	/// Container for localization lines.
	/// </summary>
	public static partial class Localization
	{
		static Dictionary<String, Localization.D_Receive> LanguageGetters = new Dictionary<string, Localization.D_Receive>();
		static List<String> Languages = new List<String>();
		
		static Boolean Ready = false;
		public delegate String D_Receive(String Key);
		
		/// <summary>
		/// Method to be run in entry point.
		/// </summary>
		public static void Initialize()
		{
			InitializeEnglish();
			InitializeRussian();
			
			Ready = true;
		}
		
		static Boolean HasLang(String Lang)
		{
			foreach (String i in Languages)
			{
				if (Lang == i)
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Return one of supported keys.
		/// </summary>
		/// <param name="Key">String that corresponds with needed key.</param>
		/// <returns>Language-dependent text line.</returns>
		public static String Get(String Key)
		{
			if (!Ready)
			{
				Initialize();
			}
			
			String Lang = CultureInfo.CurrentCulture.ToString();
			return LanguageGetters[(HasLang(Lang) ? Lang : "en-US")](Key);
		}
	}
}
