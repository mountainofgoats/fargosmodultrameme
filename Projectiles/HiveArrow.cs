using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
	public class HiveArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.width = 14;
			projectile.height = 32;
			projectile.penetrate = 1;
			projectile.arrow = true;
			projectile.ignoreWater = true;
			projectile.melee = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
		}

		public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit, int type) => Projectile.NewProjectile(target.position, projectile.velocity,projectile.type, projectile.damage, projectile.knockBack, ProjectileID.Bee, Main.myPlayer);

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.t_Honey);
			}
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
