using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.NPCs
{
    public class felinesGlobalNPC : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (felinesWorld.masoEX)
            {
                switch (npc.type)
                {
                    case NPCID.CultistBoss:
                        npc.lifeMax *= 4;
                        npc.damage *= 3;
                        npc.defense *= 2;
                        break;
                    default:
                        break;
                }
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (felinesWorld.masoEX)
            {
                switch (npc.type)
                {
                    case NPCID.ArmedZombieSlimed:
                    case NPCID.BabySlime:
                    case NPCID.BigSlimedZombie:
                    case NPCID.BlackSlime:
                    case NPCID.BlueSlime:
                    case NPCID.CorruptSlime:
                    case NPCID.DungeonSlime:
                    case NPCID.GreenSlime:
                    case NPCID.IceSlime:
                    case NPCID.IlluminantSlime:
                    case NPCID.JungleSlime:
                    case NPCID.KingSlime:
                    case NPCID.LavaSlime:
                    case NPCID.MotherSlime:
                    case NPCID.PurpleSlime:
                    case NPCID.RainbowSlime:
                    case NPCID.RedSlime:
                    case NPCID.SandSlime:
                    case NPCID.SlimedZombie:
                    case NPCID.Slimeling:
                    case NPCID.SlimeMasked:
                    case NPCID.Slimer:
                    case NPCID.Slimer2:
                    case NPCID.SlimeRibbonGreen:
                    case NPCID.SlimeRibbonRed:
                    case NPCID.SlimeRibbonWhite:
                    case NPCID.SlimeRibbonYellow:
                    case NPCID.SlimeSpiked:
                    case NPCID.SmallSlimedZombie:
                    case NPCID.SpikedIceSlime:
                    case NPCID.SpikedJungleSlime:
                    case NPCID.UmbrellaSlime:
                    case NPCID.YellowSlime:
                        target.AddBuff(BuffID.OgreSpit, 150);
                        break;
                }
            }
        }
    }
}
