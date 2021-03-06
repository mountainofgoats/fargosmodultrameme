﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC
{
	public class DLCGlobalItem : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (DLCWorld.MasomodeEX)
			{
				switch (arg)
				{
					case ItemID.KingSlimeBossBag:
						player.QuickSpawnItem(mod.ItemType("SlimyShield"));
						break;
					case ItemID.EyeOfCthulhuBossBag:
						player.QuickSpawnItem(mod.ItemType("CoreofEvil"));
						break;
					case ItemID.EaterOfWorldsBossBag:
						player.QuickSpawnItem(mod.ItemType("RottenFlesh"));
						break;
					case ItemID.BrainOfCthulhuBossBag:
						player.QuickSpawnItem(mod.ItemType("BrainyBrain"));
						break;
					case ItemID.QueenBeeBossBag:
						player.QuickSpawnItem(mod.ItemType("GiantStinger"));
						break;
					case ItemID.SkeletronBossBag:
						player.QuickSpawnItem(mod.ItemType("BoneShield"));
						break;
					case ItemID.WallOfFleshBossBag:
						player.QuickSpawnItem(mod.ItemType("GougedFlesh"));
						break;
				}
			}
		}
	}
}