using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasDLC.Items.PartyClass;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.FireworkClass
{
    public class FireworkT2 : PartyDamageItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RedRocket;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework Tier 2");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 34;
            item.crit = 4;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.rare = 1;
            item.shoot = ProjectileID.RocketFireworkRed;
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FireworkT1"));
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
