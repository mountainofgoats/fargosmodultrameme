using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.NPCs
{
    public class MyGlobalNPC : GlobalNPC
    {
        int projectile;
        int[] positions = { 100, 200, 300, -100, -200, -300 };
        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            if (MyWorld.masoEX)
            {
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        npc.lifeMax *= 2;
                        npc.damage *= 2;
                        npc.defense = 10;
                        break;
                }
            }
        }

        public override void AI(NPC npc)
        {
            Player player = Main.player[npc.target];
            if (MyWorld.masoEX)
            {
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        npc.ai[1] += 1f;
                        if (npc.ai[1] >= 120f)
                        {
                            if (Main.rand.Next(2) == 0)
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SlimeSpiked);
                            else
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BlueSlime);
                            projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y - 500, 0f, 10f, ProjectileID.SpikedSlimeSpike, 25, 0f, player.whoAmI);
                            Main.projectile[projectile].tileCollide = false;
                            for (int i = 0; i < 6; i++)
                            {
                                projectile = Projectile.NewProjectile(player.Center.X + positions[i], player.Center.Y - 500, 0f, 10f, ProjectileID.SpikedSlimeSpike, 25, 0f, player.whoAmI);
                                Main.projectile[projectile].tileCollide = false;
                            }
                            npc.ai[1] = 0f;
                        }
                        break;
                }
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (MyWorld.masoEX)
            {
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        target.AddBuff(BuffID.OgreSpit, Main.rand.Next(60, 120));
                        break;
                }
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (MyWorld.masoEX)
            {
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        Item.NewItem(npc.getRect(), mod.ItemType("SlimyShield"));
                        break;
                }
            }
        }
    }
}