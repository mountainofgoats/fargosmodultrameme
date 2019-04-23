using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Weapons
{
    public class FARGOYOYO : ModItem
    {
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");
        public override string Texture => "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Items/PlaceholderItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fargo");
            Tooltip.SetDefault("FARGO YOYO");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(271, 72, 62));
                }
            }
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 50;
            item.height = 50;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;     
            item.knockBack = 6f;
            item.damage = 400;
            item.rare = 11;
            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 1);
            item.shoot = mod.ProjectileType("FARGOYOYOPROJ");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Terrarian);
            recipe.AddIngredient(FargowiltasSouls.ItemType("TophatSquirrel"), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}