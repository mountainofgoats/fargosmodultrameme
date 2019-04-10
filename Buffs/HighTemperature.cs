using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs
{
    public class HighTemperature : ModBuff  
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("High Temperature");
            Description.SetDefault("When your body reaches extreme temperatures, your protein starts decomposing in it's primary form rendering it useless, destroying your body from inside on a cellular level.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(int buff, Player player, ref int buffIndex)
        {

            if (player.statLife % 2 != 0)
                player.statLife = (player.statLife + 1) / 2;
            else
                player.statLife /= 2;

            player.lifeRegen -= 2;

            player.statDefense -= 5;
        }
    }
}
