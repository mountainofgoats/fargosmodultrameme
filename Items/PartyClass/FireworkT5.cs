using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasDLC.Items.PartyClass;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.FireworkClass
{
    public class FireworkT5 : PartyDamageItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RedRocket;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework Tier 5");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 110;
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
            item.shootSpeed = 12.5f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FireworkT4"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
