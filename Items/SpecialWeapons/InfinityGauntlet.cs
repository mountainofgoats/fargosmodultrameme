using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.SpecialWeapons
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
			item.rare = 13;
			item.maxStack = 1;
			item.useStyle = 5;
            item.useTime = 20;
            item.useAnimation = 20;
            item.UseSound = SoundID.Item123;
			item.ranged = false;
			item.consumable = false;
			item.expertOnly = true;
			item.questItem = false;
			item.thrown = false;
		}

		public override void RightClick(Player player)
		{
			item.stack++;

			int powerS = player.FindItem(mod.ItemType("PowerStone"));
			int soulS = player.FindItem(mod.ItemType("SoulStone"));
			int spaceS = player.FindItem(mod.ItemType("SpaceStone"));
			int timeS = player.FindItem(mod.ItemType("TimeStone"));
			int realityS = player.FindItem(mod.ItemType("RealityStone"));
			int mindS = player.FindItem(mod.ItemType("MindStone"));

			int[] x = new int[] { powerS, soulS, spaceS, timeS, realityS, mindS };

			if (player.HasItem(x[0]))
			{
				Main.NewText("You have gained the power of the Power Stone.", 172, 19);
			}
			else if (player.HasItem(x[1]))
			{
				Main.NewText("You have obtained the power of the Soul Stone.", 232, 129);
			}
			else if (player.HasItem(x[2]))
			{
				Main.NewText("You have obtained the power of the Space Stone.", 25, 86);
			}
			else if (player.HasItem(x[3]))
			{
				Main.NewText("You have ontained the power of the Time Stone.", 42, 172);
			}
			else if (player.HasItem(x[4]))
			{
				Main.NewText("You have ontained the power of the Reality Stone.", 184, 30);
			}
			else if (player.HasItem(x[5]))
			{
				Main.NewText("You have obtained the power of the Mind Stone.", 219, 231);
			} //БЛЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯ
		}

		public override bool CanRightClick()
		{
			Player player = new Player();

			int powerS = player.FindItem(mod.ItemType("PowerStone"));
			int soulS = player.FindItem(mod.ItemType("SoulStone"));
			int spaceS = player.FindItem(mod.ItemType("SpaceStone"));
			int timeS = player.FindItem(mod.ItemType("TimeStone"));
			int realityS = player.FindItem(mod.ItemType("RealityStone"));
			int mindS = player.FindItem(mod.ItemType("MindStone"));

			int[] x = new int[] { powerS, soulS, spaceS, timeS, realityS, mindS };

			if (player.HasItem(x[0]) && player.HasItem(mod.ItemType("InfinityGauntlet")))
			{
				return true;
			}
			else if (player.HasItem(x[1]) && player.HasItem(mod.ItemType("InfinityGauntlet")))
			{
				return true;
			}
			else if (player.HasItem(x[2]) && player.HasItem(mod.ItemType("InfinityGauntlet")))
			{
				return true;
			}
			else if (player.HasItem(x[3]) && player.HasItem(mod.ItemType("InfinityGauntlet")))
			{
				return true;
			}
			else if (player.HasItem(x[4]) && player.HasItem(mod.ItemType("InfinityGauntlet")))
			{
				return true;
			}
			else if (player.HasItem(x[5]) && player.HasItem(mod.ItemType("InfinityGauntlet")))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
