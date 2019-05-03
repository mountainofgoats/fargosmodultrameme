using Terraria.ModLoader;

namespace FargowiltasDLC
{
	public class FargowiltasDLC : Mod
	{
		#region Internals
		internal static FargowiltasDLC CheckLoad;
		#endregion

		public FargowiltasDLC()
		{

		}

		public override void Load()
		{
			CheckLoad = this;
		}
	}
}
