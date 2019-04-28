﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles.Pets
{
    public class PlaceholderPet : ModProjectile
    {
        public override string Texture => "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Projectiles/PlaceholderProjectile";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Placeholder Pet"); 
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; //Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (player.dead)
                modPlayer.PlaceholderPet = false;
            if (modPlayer.PlaceholderPet)
                projectile.timeLeft = 2;
        }
    }
}
