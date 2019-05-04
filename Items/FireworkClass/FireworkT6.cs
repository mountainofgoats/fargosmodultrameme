using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasDLC.Items.FireworkClass;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.FireworkClass
{
    public class FireworkT6 : FireworkDamageItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RedRocket;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework Tier 6");
            Tooltip.SetDefault("Amazing firework, made from ectoplasm");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 50;
            item.crit = 8;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.rare = 8;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ProjectileID.RocketFireworkRed;
            item.shootSpeed = 10f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
