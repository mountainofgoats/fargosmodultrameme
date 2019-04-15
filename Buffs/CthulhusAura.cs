using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs
{
    public class CthulhusAura : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cthulhu's Aura");
            Description.SetDefault("Unable to use life restoring items");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>(mod).CthulhusAura = true;
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Buffs/PlaceholderDebuff";
            return true;
        }
    }
}
