using Terraria.GameInput;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
	public partial class MyPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			string[] stones = new string[] { "MindStone", "PowerStone", "RealityStone", "SoulStone", "SpaceStone", "TimeStone" };

			if (stoneAbility.JustPressed)
			{
				for (int i = 0; i < stones.Length; i++)
				{
					if (player.HasItem(mod.ItemType(stones[i])))
					{
						//create a new projectile depending on the type of the stone, with different colors.
					}
				}
			}
		}
	}
}