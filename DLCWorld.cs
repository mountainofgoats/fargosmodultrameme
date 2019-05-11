using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace FargowiltasDLC
{
    public class DLCWorld : ModWorld
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
