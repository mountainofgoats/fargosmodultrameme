using Terraria.GameInput;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
	public partial class MyPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			string[] stones = new string[] { "MindStoneBuff", "PowerStoneBuff", "RealityStoneBuff", "SoulStoneBuff", "SpaceStoneBuff", "TimeStoneBuff" };

			if (stoneAbility.JustPressed)
			{
				for (int i = 0; i < stones.Length; i++)
				{
					if (player.HasBuff(mod.BuffType(stones[i])))
					{
						//create a new projectile depending on the type of the stone, with different colors.
					}
				}
			}
		}
	}
}