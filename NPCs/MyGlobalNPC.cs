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
        int[] positions = { 100, 200, 300, 0, -100, -200, -300 };
        public override bool InstancePerEntity => true;
        bool alreadyHealed = false;
        bool EoCPhase2 = false;

        public override void AI(NPC npc)
        {
            Player player = Main.player[npc.target];
            if (MyWorld.MasomodeEX)
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
                            for (int i = 0; i < 7; i++)
                            {
                                projectile = Projectile.NewProjectile(player.Center.X + positions[i], player.Center.Y - 500, 0f, 10f, ProjectileID.SpikedSlimeSpike, 15, 0f, player.whoAmI);
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
                    case NPCID.EaterofWorldsBody:
                        Counter++;
                        if (Counter >= 600f && Main.rand.Next(200) == 0) //very low chance to avoid spam
                        {
                            Vector2 velocity = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); 
                            if (magnitude > 0)
                            {
                                velocity *= 10f / magnitude;
                            }
                            else
                            {
                                velocity = new Vector2(0f, 10f);
                            }
                            Projectile.NewProjectile(npc.Center, velocity, ProjectileID.CursedFlameHostile, 15, 0f);
                            Counter = 0f;
                        }
                        Counter2++;
                        if (Counter2 >= 300f && Main.rand.Next(2000) == 0) //very low chance to avoid spam
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.EaterofSouls);
                            Counter2 = 0f;
                        }
                        break;
                }
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (MyWorld.MasomodeEX)
            {
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        target.AddBuff(BuffID.OgreSpit, Main.rand.Next(60, 120));
                        break;
                    case NPCID.EyeofCthulhu:
                        target.AddBuff(BuffID.Obstructed, Main.rand.Next(60, 120));
                        break;
                    case NPCID.EaterofWorldsHead:
                    case NPCID.EaterofWorldsBody:
                    case NPCID.EaterofWorldsTail:
                        target.AddBuff(BuffID.WitheredArmor, Main.rand.Next(120, 180));
                        target.AddBuff(BuffID.WitheredWeapon, Main.rand.Next(120, 180));
                        break;
                }
            }
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (MyWorld.MasomodeEX)
            {
                switch (npc.type)
                {
                    case NPCID.EaterofWorldsHead:
                    case NPCID.EaterofWorldsBody:
                    case NPCID.EaterofWorldsTail:
                        if (projectile.penetrate > 1 || projectile.penetrate == -1)
                        {
                            damage = 0;
                            crit = false;
                            knockback = 0f;
                        }
                        break;
                }
            }
        }
        
        public override void NPCLoot(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            switch (npc.type)
            {
                case NPCID.QueenBee:
                    if (Main.rand.Next(10) == 0)
                        Item.NewItem(npc.getRect(), mod.ItemType("BeenadeLauncher"));
                    break;               
            }
            if (player.ZoneBeach && npc.lifeMax > 5 && !npc.friendly && Main.hardMode)
            {
                if (Main.rand.Next(100) == 0)
                    Item.NewItem(npc.getRect(), mod.ItemType("WaterEssence"));
            }
        }
    }
}
