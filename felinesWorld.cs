﻿using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public class felinesWorld : ModWorld
    {
        public static bool masoEX;
        
        public override void Load(TagCompound tag)
        {
            masoEX = tag.GetBool("masoEX");
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"masoEX", masoEX }
            };
        }
    }
}
