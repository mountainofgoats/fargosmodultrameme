using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM
{
    public class MyWorld : ModWorld
    {
        public static bool MasomodeEX;
        
        public override void Initialize()
        {
            MasomodeEX = false;
        }
        
        public override void Load(TagCompound tag)
        {
            MasomodeEX = tag.GetBool("MasomodeEX");
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"MasomodeEX", MasomodeEX }
            };
        }
    }
}
