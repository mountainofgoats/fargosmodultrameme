using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.Special
{
	public class PowerStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Power Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, wielding infinite power.");
		}

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(60, 36, 181));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 26;
            item.accessory = true;
        }

		public float indexer = 0f;
		public int counter;

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			indexer += 0.01f;
			counter = 0;

			base.OnHitNPC(player, target, damage, knockBack, crit);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			Mod DBTR = ModLoader.GetMod("DBT");
			Mod DBZMOD = ModLoader.GetMod("DBZMOD");
			counter++;

			while (indexer < 1.51f && counter <= 1200)
			{
				player.meleeDamage += 1.5f + indexer;
				player.magicDamage += 1.5f + indexer;
				player.minionDamage += 1.5f + indexer;
				player.rangedDamage += 1.5f + indexer;
				player.thrownDamage += 1.5f + indexer;
				player.GetModPlayer<DBZMOD.MyPlayer>(DBZMOD).kiDamage += 1.5f + indexer;
				player.GetModPlayer<DBZMOD.MyPlayer>(DBZMOD).kiMax2 += 3500;
				player.GetModPlayer<DBZMOD.MyPlayer>(DBZMOD).kiRegen += counter;
				player.GetModPlayer<FireworkClass.FireworkDamagePlayer>().fireworkDamage += 1.5f + indexer;

				if (counter > 1200)
				{
					indexer = 0f;
					break;
				}
			}
			player.GetModPlayer<DLCPlayer>().stoneAbilityPb = true;
		}
    }
}

