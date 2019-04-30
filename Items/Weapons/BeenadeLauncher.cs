using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Weapons
{
    public class BeenadeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beenade Launcher");
            Tooltip.SetDefault("™");
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.damage = 15;
            item.ranged = true;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.UseSound = SoundID.Item11;
            item.rare = 3;
            item.knockBack = 6f;
            item.shoot = ProjectileID.Beenade;
            item.shootSpeed = 10f;
            item.autoReuse = true;
            item.noMelee = true;
        }
	
	public override Vector2? HoldoutOffset()
	{
	    return new Vector2(-10, 0);
	}
    }
}
 
