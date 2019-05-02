using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
	public class NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM : Mod
	{
		public NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM()
		{
		}

		public override void Load()
		{
			DLCPlayer.stoneAbility = RegisterHotKey("Special Ability", "P");
		}
	}
}
