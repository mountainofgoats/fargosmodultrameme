using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.NPCs
{
    public class MyGlobalNPC : GlobalNPC
    {
        //Slime Boss
        int[] slimeBossSpikesX = { 100, 200, 300, 0, -100, -200, -300 };
        //Eye Boss
        bool eyeBossP2 = false;
        bool eyeBossHealed = false;
        //Brain Boss
        bool brainBossP2 = false;
        //Other
        float Counter;
        float Counter2;
        int projectile;
        public override bool InstancePerEntity => true;

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
                                projectile = Projectile.NewProjectile(player.Center.X + slimeBossSpikesX[i], player.Center.Y - 500, 0f, 10f, ProjectileID.SpikedSlimeSpike, npc.damage / 4, 0f, player.whoAmI);
                                Main.projectile[projectile].tileCollide = false;
                            }
                            Counter = 0f;
                        }
                        break;
                    case NPCID.EyeofCthulhu:
                        if (npc.life <= npc.lifeMax * 0.65f && !eyeBossHealed)
                        {
                            npc.dontTakeDamage = true;
                            Counter += 1f;
                            if (Counter >= 120f)
                            {
                                int heal = npc.lifeMax - npc.life;
                                npc.life += heal;
                                npc.HealEffect(heal);
                                eyeBossHealed = true;
                                npc.dontTakeDamage = false;
                                eyeBossP2 = true;
                                Counter = 0f;
                            }
                        }
                        if (Counter2 >= 300f && eyeBossP2)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.ServantofCthulhu);
                            Counter2 = 0f;
                        }
                        if (eyeBossP2)
                            Counter2 += 1f;
                        break;
                    case NPCID.EaterofWorldsBody:
                        Counter++;
                        if (Counter >= 600f && Main.rand.Next(200) == 0) //very low chance to avoid spam
                        {
                            Vector2 velocity = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                            if (magnitude > 0)
                                velocity *= 10f / magnitude;
                            else
                                velocity = new Vector2(0f, 10f);
                            projectile = Projectile.NewProjectile(npc.Center, velocity, ProjectileID.CursedFlameHostile, npc.damage / 4, 0f, player.whoAmI);
                            Main.projectile[projectile].tileCollide = false;
                            Counter = 0f;
                        }
                        Counter2++;
                        if (Counter2 >= 300f && Main.rand.Next(2000) == 0) //very low chance to avoid spam
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.EaterofSouls);
                            Counter2 = 0f;
                        }
                        break;
                    case NPCID.BrainofCthulhu:
                        Counter += 1f;
                        if (Counter >= 60f)
                        {
                            Vector2 velocity = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                            if (magnitude > 0)
                                velocity *= 5f / magnitude;
                            else
                                velocity = new Vector2(0f, 5f);
                            projectile = Projectile.NewProjectile(npc.Center, velocity, ProjectileID.IchorSplash, npc.damage / 4, 0f, player.whoAmI);
                            Main.projectile[projectile].tileCollide = false;
                            Main.projectile[projectile].friendly = false;
                            Main.projectile[projectile].hostile = true;
                            Counter = 0f;
                        }
                        if (npc.life <= npc.lifeMax * 0.99f)
                            brainBossP2 = true;
                        if (!NPC.AnyNPCs(NPCID.Creeper) && brainBossP2)
                            Counter2 += 1f;
                        if (Counter2 >= 600f && !NPC.AnyNPCs(NPCID.Creeper) && brainBossP2)
                        {
                            for (int j = 0; j < 10; j++)
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Creeper);
                            Counter2 = 0f;
                        }
                        if (NPC.AnyNPCs(NPCID.Creeper))
                            npc.dontTakeDamage = true;
                        else
                            npc.dontTakeDamage = false;
                        npc.knockBackResist = 0f;
                        break;
                    case NPCID.QueenBee:
                        Counter += 1f;
                        if (Counter >= 60f)
                        {
                            Vector2 velocity = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                            if (magnitude > 0)
                                velocity *= 10f / magnitude;
                            else
                                velocity = new Vector2(0f, 10f);
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                            velocity.X = perturbedSpeed.X;
                            velocity.Y = perturbedSpeed.Y;
                            projectile = Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileID.Stinger, npc.damage / 4, 0f, player.whoAmI);
                            Main.projectile[projectile].tileCollide = false;
                            if (Counter >= 65f)
                                Counter = 0f;
                        }
                        npc.scale = 1.25f;
                        break;
                    case NPCID.SkeletronHead:
                        if (NPC.AnyNPCs(NPCID.SkeletronHand))
                            npc.dontTakeDamage = true;
                        else
                            npc.dontTakeDamage = false;
                        break;
                    case NPCID.WallofFleshEye:
                        Counter += 1f;
                        if (Counter >= 120f)
                        {
                            Vector2 velocity = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                            if (magnitude > 0)
                                velocity *= 65f / magnitude;
                            else
                                velocity = new Vector2(0f, 65f);
                            if (Main.rand.Next(2) == 0)
                            {
                                projectile = Projectile.NewProjectile(npc.Center, velocity, mod.ProjectileType("CursedLaser"), npc.damage / 10, 0f, player.whoAmI);
                                Main.projectile[projectile].tileCollide = false;
                            }
                            else
                            {
                                projectile = Projectile.NewProjectile(npc.Center, velocity, mod.ProjectileType("IchorLaser"), npc.damage / 10, 0f, player.whoAmI);
                                Main.projectile[projectile].tileCollide = false;
                            }
                            Main.PlaySound(SoundID.Item33, npc.position);
                            Counter = 0f;
                        }
                        break;
                    case NPCID.WallofFlesh:
                        Counter += 1f;
                        if (Counter >= 5f)
                        {
                            Vector2 velocity = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                            if (magnitude > 0)
                                velocity *= 5f / magnitude;
                            else
                                velocity = new Vector2(0f, 5f);
                            projectile = Projectile.NewProjectile(npc.Center, velocity, ProjectileID.EyeFire, npc.damage / 4, 0f, player.whoAmI);
                            Main.projectile[projectile].tileCollide = false;
                            Counter = 0f;
                        }
                        break;
                }
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
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
                    case NPCID.BrainofCthulhu:
                        target.AddBuff(BuffID.Ichor, Main.rand.Next(600, 900));
                        break;
                    case NPCID.QueenBee:
                        target.AddBuff(mod.BuffType("Allergic"), Main.rand.Next(480, 660));
                        break;
                    case NPCID.SkeletronHead:
                    case NPCID.SkeletronHand:
                        target.AddBuff(BuffID.Cursed, Main.rand.Next(120, 180));
                        break;
                }
            }
            if (modPlayer.GougedFlesh)
            {
                //blah blah blah throw flesh
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
                            damage /= 2;
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
            if (player.ZoneBeach && npc.lifeMax > 5 && !npc.friendly && Main.hardMode && NPC.downedGolemBoss)
            {
                if (Main.rand.Next(100) == 0)
                    Item.NewItem(npc.getRect(), mod.ItemType("WaterEssence"));
            }
        }
    }
}
