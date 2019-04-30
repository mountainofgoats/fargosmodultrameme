using Microsoft.Xna.Framework;
using System.Collections.Generic;
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
			Tooltip.SetDefault("A gauntlet capable of wielding the power of the 6 infinity stones.");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 100;
			item.value = Int32.MaxValue;
			item.rare = 13;
			item.maxStack = 1;
			item.useStyle = 3;
			item.damage = 30000;
			item.knockBack = 6f;
			item.ranged = false;
			item.consumable = false;
			item.expertOnly = true;
			item.questItem = false;
			item.thrown = false;
		}

		public override void RightClick(Player player)
		{
			int infg = player.FindItem(mod.ItemType("InfinityGauntlet"));
			int powerS = player.FindItem(mod.ItemType("PowerStone"));
			int soulS = player.FindItem(mod.ItemType("SoulStone"));
			int spaceS = player.FindItem(mod.ItemType("SpaceStone"));
			int timeS = player.FindItem(mod.ItemType("TimeStone"));
			int realityS = player.FindItem(mod.ItemType("RealityStone"));
			int mindS = player.FindItem(mod.ItemType("MindStone"));
		}

		public override bool CanRightClick()
		{
			Player player = new Player();

			int infg = player.FindItem(mod.ItemType("InfinityGauntlet"));
			int powerS = player.FindItem(mod.ItemType("PowerStone"));
			int soulS = player.FindItem(mod.ItemType("SoulStone"));
			int spaceS = player.FindItem(mod.ItemType("SpaceStone"));
			int timeS = player.FindItem(mod.ItemType("TimeStone"));
			int realityS = player.FindItem(mod.ItemType("RealityStone"));
			int mindS = player.FindItem(mod.ItemType("MindStone"));

			int[] x = new int[] { powerS, soulS, spaceS, timeS, realityS, mindS};

			for (int i = 0; i < 6; i++)
			{
				if (player.HasItem(infg) && player.HasItem(x[i]))
				{
					return true;
				}
			}
			return false;
		}
	}
}
