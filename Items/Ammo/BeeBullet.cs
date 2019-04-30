using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Ammo
{
	public class BeeBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Bullet");
		}

		public override void SetDefaults()
		{
			item.damage = 7;
			item.rare = 2;
			item.value = 100;
			item.knockBack = 2f;
			item.shootSpeed = 6f;
			item.maxStack = 999;
			item.width = 6;
			item.height = 8;
			item.ranged = true;
			item.consumable = false;
			item.ammo = AmmoID.Bullet;
			item.shoot = mod.ProjectileType("BeeBullet");
		}

		public override void AddRecipes()
		{
			ModRecipe b = new ModRecipe(mod);
			b.AddIngredient(ItemID.HoneyBucket, 2);
			b.AddIngredient(ItemID.Beenade, 1);
			b.SetResult(this, 30);
			b.AddRecipe();
		}
	}
}
