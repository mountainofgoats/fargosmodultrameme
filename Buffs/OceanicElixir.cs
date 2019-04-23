using Terraria;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs
{
    public class OceanicElixir : ModBuff
    {
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Oceanic Elixir");
            Description.SetDefault("You are immune to Oceanic Maul");
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[FargowiltasSouls.BuffType("OceanicMaul")] = true;
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM/Buffs/PlaceholderBuff";
            return true;
        }
    }
}
