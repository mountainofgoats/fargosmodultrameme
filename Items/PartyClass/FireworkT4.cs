using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasDLC.Items.PartyClass;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.FireworkClass
{
    public class FireworkT4 : PartyDamageItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.RedRocket;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firework Tier 4");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 80;
            item.crit = 8;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.rare = 6;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ProjectileID.RocketFireworkRed;
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("FireworkT3"));
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
