using System;
using Terraria.ModLoader;

namespace FargowiltasDLC
{
	public class FargowiltasDLC : Mod
	{
		#region Internals
		internal static FargowiltasDLC CheckLoad;
		#endregion

		#region bools
		public bool DBTLoaded;
		#endregion

		public FargowiltasDLC()
		{

		}

		public override void Load()
		{
			CheckLoad = this;
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
