/*
 * Root class for any monochrome screens in existence.
 */
using System;
using System.Collections.Generic;

namespace DotGraphics.Screens
{
	[Serializable]
	public abstract class MonochromeScreen
	{
		protected abstract void Render();
		protected Boolean[,] BinaryMatrix;
		public UInt16 Width
		{
			get; protected set;
		}
		public UInt16 Height
		{
			get; protected set;
		}
	}
}