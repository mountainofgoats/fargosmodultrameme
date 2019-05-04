using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FargowiltasDLC.Items.Special
{
	public class InfinityGauntlet : ModItem
	{
		public override string Texture => "FargowiltasDLC/Items/PlaceholderItem"; 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinity Gauntlet");
			Tooltip.SetDefault("A gauntlet capable of wielding the power of the 6 infinity stones.\n~~Right click to put the Infinity Stone in.~~"); 
            Item.staff[item.type] = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine tooltipLine in list)
			{
				if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.overrideColor = new Color?(new Color(204, 0, 0));
				}
			}
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 100;
			item.value = 1000000;
			item.rare = 11;
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 200;
			item.useAnimation = 20;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/InfinityGauntlet");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod fargosouls = ModLoader.GetMod("FargowiltasSouls");

			recipe.AddIngredient(mod.ItemType("PowerStone"), 1);
			recipe.AddIngredient(mod.ItemType("MindStone"), 1);
			recipe.AddIngredient(mod.ItemType("SpaceStone"), 1);
			recipe.AddIngredient(mod.ItemType("TimeStone"), 1);
			recipe.AddIngredient(mod.ItemType("SoulStone"), 1);
			recipe.AddIngredient(mod.ItemType("RealityStone"), 1);
			recipe.AddIngredient(ItemID.IronBar, 2000);
			recipe.AddTile(fargosouls.TileType("CrucibleCosmosSheet"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
