using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
	public class BeeBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Bullet");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.width = 6;
			projectile.height = 8;
			projectile.ignoreWater = true;
			projectile.penetrate = 3;
			projectile.arrow = true;
			projectile.melee = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
		}

		public virtual bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i =0; i < 5; i++)
			{
				Projectile.NewProjectile(projectile.oldPosition, projectile.oldVelocity, projectile.type, projectile.damage, projectile.knockBack, ProjectileID.Bee, Main.myPlayer);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.t_Honey);
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
