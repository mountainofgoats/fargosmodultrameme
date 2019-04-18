﻿using Terraria;
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
                        npc.lifeMax *= 2; //5600
                        npc.damage *= 2; //128
                        npc.defense = 10;
                        break;
                    case NPCID.EyeofCthulhu:
                        npc.lifeMax *= 2; //7280
                        npc.damage *= 2; //60
                        npc.defense = 10;
                        break;
                    case NPCID.ServantofCthulhu:
                        npc.lifeMax *= 5; //60
                        npc.damage *= 2; //48
                        npc.defense = 10;                        
                        break;
                    case NPCID.EaterofWorldsHead:
                    case NPCID.EaterofWorldsBody:
                    case NPCID.EaterofWorldsTail:
                        npc.lifeMax = 350; //489
                        npc.damage = 40; //88
                        npc.defense = 10; //12
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
                    case NPCID.EaterofWorldsBody:
                        Counter++;
                        if (Counter >= 420f && Main.rand.Next(200) == 0) //very low chance to avoid spam
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
                            Projectile.NewProjectile(npc.Center, velocity, ProjectileID.CursedFlameHostile, 20, 0f);
                            Counter = 0f;
                        }
                        Counter2++;
                        if (Counter2 >= 300f && Main.rand.Next(1500) == 0) //very low chance to avoid spam
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
            if (MyWorld.masoEX)
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
    }
}
