using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasDLC.Items.PartyClass;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.FireworkClass
{
    public class FireworkT1 : PartyDamageItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RedRocket;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework Tier 1");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 16;
            item.crit = 4;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ProjectileID.RocketFireworkRed;
            item.shootSpeed = 2.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 75);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
