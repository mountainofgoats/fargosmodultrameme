using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace FargowiltasDLC.Items.Ammo
{
	public class HiveArrow : ModItem
	{
		public int craftindex;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Hive arrow that releases bees on collision!");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.rare = 3;
			item.value = 100;
			item.knockBack = 2f;
			item.shootSpeed = 5f;
			item.maxStack = 999;
			item.width = 14;
			item.height = 32;
			item.ranged = true;
			item.consumable = false;
			item.ammo = AmmoID.Arrow;
			item.shoot = mod.ProjectileType("HiveArrow");
		}

		public override void OnCraft(Recipe recipe)
		{
			craftindex++;
		}

		public virtual void SpawnBoss(Player player, ref int type)
		{
			if (Main.hardMode && craftindex == 250)
			{
				NPC.NewNPC((int)player.position.X, (int)player.position.Y, type, NPCID.KingSlime);
			}
			else
			{
				NPC.NewNPC((int)player.position.X, (int)player.position.Y, type, NPCID.SkeletronPrime);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HoneyBucket, 5);
			recipe.AddIngredient(ItemID.WoodenArrow, 1);
			recipe.AddIngredient(ItemID.Beenade, 1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}
