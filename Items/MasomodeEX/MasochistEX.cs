﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls;

namespace FargowiltasDLC.Items.MasomodeEX
{
    public class MasochistEX : ModItem
    {
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";

        public override void SetStaticDefaults()
        {
            string tooltip = "Activates/Deactivates Masochist Mode EX\nUse in Expert Mode";
            if (FargowiltasSouls != null)
                tooltip = "Activates/Deactivates Masochist Mode EX\nUse in Masochist Mode";
            DisplayName.SetDefault("Abominationn's Gift");
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.maxStack = 1;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 4;
            item.rare = 1;
            item.UseSound = SoundID.Item44;
        }

        public override bool CanUseItem(Player player)
        {
            return FargowiltasSouls != null ? FargoWorld.MasochistMode : Main.expertMode;
        }

        public override bool UseItem(Player player)
        {
            if (!DLCWorld.MasomodeEX)
            {
                DLCWorld.MasomodeEX = true;
                Main.NewText("Masochist Mode EX enabled.", 175, 55);
            }
            else
            {
                DLCWorld.MasomodeEX = false;
                Main.NewText("Masochist Mode EX disabled.", 175, 55);
            }
            return true;
        }
    }
}
