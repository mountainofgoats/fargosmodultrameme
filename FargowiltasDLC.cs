using System;
using Terraria.ModLoader;

namespace FargowiltasDLC
{
	internal class FargowiltasDLC : Mod
	{
		#region Internals
		internal static FargowiltasDLC DLCInstance;

		#endregion

		#region bools
		internal bool DBTLoaded;
		#endregion

		public override void Load()
		{
			DLCInstance = this;
		}

		public override void PostSetupContent()
		{
			try
			{
				DBTLoaded = ModLoader.GetMod("DBZMOD") != null;
			}
			catch (Exception e)
			{
				ErrorLogger.Log("FargowiltasDLC PostSetupContent method Error: " + e.StackTrace + e.Message);
			}
		}
	}
}
