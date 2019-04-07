using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items
{
	public class Corn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corn");
			Tooltip.SetDefault("Why");
		}
		public override void SetDefaults()
		{

            item.damage = 69696969;
            item.shootSpeed = 10;
            item.shoot = mod.ProjectileType("CornProjectile");
			item.width = 744;
			item.height = 1473;
            item.knockBack = 1f;
			item.useStyle = 1;
			item.useAnimation = 1;
			item.useTime = 1;
			item.value = 10000;
			item.rare = 15;
            item.maxStack = 1;
			item.accessory = true;
            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;
            item.ammo = AmmoID.Arrow;
            item.ammo = AmmoID.Bullet;
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
