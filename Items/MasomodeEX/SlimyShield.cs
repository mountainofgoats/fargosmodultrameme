using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.MasomodeEX
{
    public class SlimyShield : ModItem
    {
        public override string Texture => "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Items/PlaceholderItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Shield");
            Tooltip.SetDefault("Immunity to Oozed\nImmunity to knockback");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(149, 225, 18));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.rare = 1;
            item.defense = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.OgreSpit] = true;
            player.noKnockback = true;
        }
    }
}