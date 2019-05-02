using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
	public class FargowiltasDLC : Mod
	{
		public FargowiltasDLC()
		{
		}

		public override void Load()
		{
			DLCPlayer.stoneAbility = RegisterHotKey("Special Ability", "P");
		}
	}
}
