using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
	public class FargowiltasDLC : Mod
	{
		#region Hotkeys
		public static ModHotKey stoneAbility;
		public static ModHotKey stoneSpecialAbility;
		#endregion

		public FargowiltasDLC()
		{
		}

		public override void Load()
		{
			stoneAbility = RegisterHotKey("Special Ability", "P");
		}
	}
}
