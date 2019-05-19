using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasDLC.Items.PartyClass;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.FireworkClass
{
    public class FireworkT6 : PartyDamageItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RedRocket;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework Tier 6");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 150;
            item.crit = 8;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.rare = 10;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ProjectileID.RocketFireworkRed;
            item.shootSpeed = 15f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FireworkT5"));
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
