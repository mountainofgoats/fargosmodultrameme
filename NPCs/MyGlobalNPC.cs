using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.NPCs
{
    public class MyGlobalNPC : GlobalNPC
    {
        float Counter;
        float Counter2;
        int projectile;
        int[] positions = { 100, 200, 300, -100, -200, -300 };
        public override bool InstancePerEntity => true;
        bool alreadyHealed = false;
        bool EoCPhase2 = false;

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
                    case NPCID.EyeofCthulhu:
                        npc.lifeMax *= 2;
                        npc.damage *= 2;
                        npc.defense = 10;
                        break;
                    case NPCID.ServantofCthulhu:
                        npc.lifeMax *= 5;
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
                        Counter += 1f;
                        if (Counter >= 120f)
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
                            Counter = 0f;
                        }
                        break;
                    case NPCID.EyeofCthulhu:
                        if (npc.life <= npc.lifeMax * 0.65f && !alreadyHealed)
                        {
                            npc.dontTakeDamage = true;
                            Counter += 1f;
                            if (Counter >= 120f)
                            {
                                int heal = npc.lifeMax - npc.life;
                                npc.life += heal;
                                npc.HealEffect(heal);
                                Counter = 0f;
                                alreadyHealed = true;
                                npc.dontTakeDamage = false;
                                EoCPhase2 = true;
                            }
                        }
                        if (Counter2 >= 300f && EoCPhase2)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.ServantofCthulhu);
                            Counter2 = 0f;
                        }
                        if (EoCPhase2)
                        {
                            player.AddBuff(mod.BuffType("CthulhusAura"), 2);
                            npc.damage *= 2;
                            Counter2 += 1f;
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
                    case NPCID.EyeofCthulhu:
                        target.AddBuff(BuffID.Obstructed, Main.rand.Next(60, 120));
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
                    case NPCID.EyeofCthulhu:
                        Item.NewItem(npc.getRect(), mod.ItemType("CoreofEvil"));
                        break;
                }
            }
        }
    }
}
