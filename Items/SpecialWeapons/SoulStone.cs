using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.SpecialWeapons
{
	public class SoulStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Stone");
			Tooltip.SetDefault("One of the 6 Infinity Stones, capable of manipulating others souls.");
		}
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(181, 97, 27));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 26;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		}
    }
}