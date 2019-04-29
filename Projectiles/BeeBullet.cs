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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Bee);


		public override void Kill(int timeLeft)
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.t_Honey);
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
