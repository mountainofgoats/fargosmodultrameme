using Terraria.ModLoader;

namespace FargowiltasDLC
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
