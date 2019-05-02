using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items
{
    public class OceanicElixir : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oceanic Elixir");
            Tooltip.SetDefault("Grants immunity to Oceanic Maul");
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.rare = 8;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.buffType = mod.BuffType("OceanicElixir");
            item.buffTime = 3600;
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(mod.ItemType("WaterEssence"));
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}