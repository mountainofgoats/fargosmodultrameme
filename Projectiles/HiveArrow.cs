using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items;

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
			projectile.ignoreWater = true;
			projectile.penetrate = 1;
			projectile.aiStyle = 0;
			projectile.arrow = true;
			projectile.melee = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
		}

		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 5; i++)
			{
				Projectile.NewProjectile(projectile.oldPosition, projectile.oldVelocity, projectile.type, projectile.damage, projectile.knockBack, ProjectileID.Bee, Main.myPlayer);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Player player = new Player();

			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.t_Honey);
			}
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
