using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
    public class EchProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ech");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Penguin);
            projectile.melee = true;
            projectile.aiStyle = 18;
            projectile.timeLeft = 999999999;
			aiType = ProjectileID.Penguin;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 4);
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            }
        }

        public override void AI()
        {
                projectile.penetrate = 1000000;
                projectile.maxPenetrate = 1000000;
                projectile.width = 128;
                projectile.height = 128;
                projectile.ignoreWater = true;
                projectile.friendly = true;
                projectile.hostile = false;
	    }
		        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(BuffID.Ichor, 300);
                target.AddBuff(BuffID.CursedInferno, 300);
                target.AddBuff(BuffID.Frostburn, 300);
                target.AddBuff(BuffID.OnFire, 300);
        }
	}
}