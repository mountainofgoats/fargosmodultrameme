using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace FargowiltasDLC.Items.SpecialWeapons
{
	public class InfinityGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinity Gauntlet");
			Tooltip.SetDefault("A gauntlet capable of wielding the power of the 6 infinity stones.\n~~Right click to put the Infinity Stone in."); 
            Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 100;
			//item.value = Int32.MaxValue;
			item.rare = 11;
			item.maxStack = 1;
			item.useStyle = 5;
            item.useTime = 20;
            item.useAnimation = 20;
            item.UseSound = SoundID.Item123;
		}
	}
}
