using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
    public class IchorLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Laser");
        }

        public override void SetDefaults()
        {

            projectile.width = 8;               
            projectile.height = 8;              
            projectile.aiStyle = 1;            
            projectile.friendly = false;        
            projectile.hostile = true;         
            projectile.ranged = true;          
            projectile.penetrate = -1;           
            projectile.timeLeft = 600;          
            projectile.ignoreWater = true;          
            projectile.tileCollide = true;
            projectile.scale = 2f;
            projectile.light = 2f;
            aiType = ProjectileID.Bullet;
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(BuffID.Ichor, 900);
        }
    }
}