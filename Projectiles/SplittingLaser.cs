using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Projectiles
{
    public class SplittingLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splitting Laser");
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
            projectile.timeLeft = 120;          
            projectile.ignoreWater = true;          
            projectile.tileCollide = true;
            projectile.scale = 2f;
            projectile.light = 2f;
            aiType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 32.5f, ProjectileID.DeathLaser, projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -32.5f, ProjectileID.DeathLaser, projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 32.5f, 0f, ProjectileID.DeathLaser, projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -32.5f, 0f, ProjectileID.DeathLaser, projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 65f, 65f, mod.ProjectileType("TileIgnoringLaser"), projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -65f, -65f, mod.ProjectileType("TileIgnoringLaser"), projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 65f, -65f, mod.ProjectileType("TileIgnoringLaser"), projectile.damage / 4, 0f, player.whoAmI);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -65f, 65f, mod.ProjectileType("TileIgnoringLaser"), projectile.damage / 4, 0f, player.whoAmI);
            Main.PlaySound(SoundID.Item33, projectile.position);
        }
    }
}