using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles
{
    public class MyGlobalProjectile : GlobalProjectile
    {
        public override void ModifyHitPlayer(Projectile projectile, Player target, ref int damage, ref bool crit)
        {
            if (DLCWorld.MasomodeEX)
            {
                switch (projectile.type)
                {
                    case ProjectileID.IchorSplash:
                        if (projectile.hostile)
                            target.AddBuff(BuffID.Ichor, Main.rand.Next(600, 900));
                        break;
                }
            }
        }
    }
}