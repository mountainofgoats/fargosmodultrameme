using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
	public partial class DLCPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			string[] stones = new string[] { "MindStone", "PowerStone", "RealityStone", "SoulStone", "SpaceStone", "TimeStone" };

			if (stoneAbility.JustPressed)
			{
				for (int i = 0; i < stones.Length; i++)
				{
					if (stoneAbilityb == true)
					{
						Projectile.NewProjectile(player.Center, mod.ProjectileType("InfinityBeam"), Main.myPlayer); //noobas do something I am about to die
					}
				}
			}
		}
		public override void ResetEffects()
		{
			stoneAbilityb = false;
		}
	}
}