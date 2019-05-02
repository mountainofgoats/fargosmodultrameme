﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.MasomodeEX
{
    public class BrainyBrain : ModItem
    {
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brainy Brain");
            Tooltip.SetDefault("Immunity to Ichor\nAll attacks inflict Ichor");
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
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            DLCPlayer modPlayer = player.GetModPlayer<DLCPlayer>(mod);
            player.buffImmune[BuffID.Ichor] = true;
            modPlayer.BrainyBrain = true;
        }
    }
}