using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
	public class StormBreakerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning released by the Stormbreaker");
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.damage = 112;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.melee = false;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC target = Main.npc[i];

				if (Collision.CanHitLine(projectile.Center, 0, 0, target.Center, 0, 0))
				{
					projectile.damage /= 2;
				}

				DLCGlobalProjectile lightning = new DLCGlobalProjectile();
			}
		}
	}
}