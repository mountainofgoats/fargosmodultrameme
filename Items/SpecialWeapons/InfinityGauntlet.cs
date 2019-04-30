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
			item.ranged = false;
			item.consumable = false;
			item.expertOnly = true;
			item.questItem = false;
			item.thrown = false;
		}

		public override void HoldItem(Player player)
		{
			
		}

		public virtual void DetectInfinityStones(Player player)
		{
			int indexerpS = 0;
			int indexersS = 0;
			int indexerspS = 0;
			int indexertS = 0;
			int indexerrS = 0;
			int indexermS = 0;

			int pS = player.FindItem(mod.ItemType("PowerStone"));
			int sS = player.FindItem(mod.ItemType("SoulStone"));
			int spS = player.FindItem(mod.ItemType("SpaceStone"));
			int tS = player.FindItem(mod.ItemType("TimeStone"));
			int rS = player.FindItem(mod.ItemType("RealityStone"));
			int mS = player.FindItem(mod.ItemType("MindStone"));

			if (player.HasItem(pS))
			{
				Main.NewText("You have gained the power of the Power Stone.", 172, 19);
				indexerpS++;
			}
			if (player.HasItem(sS))
			{
				Main.NewText("You have obtained the power of the Soul Stone.", 232, 129);
				indexersS++;
			}
			if (player.HasItem(spS))
			{
				Main.NewText("You have obtained the power of the Space Stone.", 25, 86);
				indexerspS++;
			}
			if (player.HasItem(tS))
			{
				Main.NewText("You have ontained the power of the Time Stone.", 42, 172);
				indexertS++;
			}
			if (player.HasItem(rS))
			{
				Main.NewText("You have ontained the power of the Reality Stone.", 184, 30);
				indexerrS++;
			}
			if (player.HasItem(mS))
			{
				Main.NewText("You have obtained the power of the Mind Stone.", 219, 231);
				indexermS++;
			}
			if (indexermS == 1 && indexersS == 1 && indexertS == 1 && indexerspS == 1 && indexerrS == 1 && indexerpS == 1)
			{
				Main.NewText("You have gained the power of all the Infinity Stones.");
			}
		}
	}
}
