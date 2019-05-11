using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Projectiles
{
    public class MusicalNote : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Musical Note");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;               
            projectile.height = 8;              
            projectile.aiStyle = 1;            
            projectile.friendly = true;        
            projectile.hostile = false;         
            projectile.ranged = true;          
            projectile.penetrate = -1;           
            projectile.timeLeft = 600;          
            projectile.ignoreWater = true;          
            projectile.tileCollide = true;
            projectile.scale = 1.5f;
            projectile.light = 2f;
            aiType = ProjectileID.Bullet;
        }
    }
}