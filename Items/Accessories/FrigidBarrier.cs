using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Accessories
{
	public class FrigidBarrier : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Barrier");
			Tooltip.SetDefault("'Made from magical unmelting snow'");
		}
		public override void SetDefaults()
		{
            item.accessory = true;
            item.defense = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
