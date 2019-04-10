using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Projectiles;
using NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Buffs;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Souls
{
    public class SoulofEch : ModItem
    {
        public int i = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Ech");
            Tooltip.SetDefault("Does a bunch of things :begone: \nEquipable\nQuest Item\nVanity Item\n69 defense\nRestores 500 life\nRestores 500 mana\nCan be placed\n278 minute duration\nExpert\nSummons the ECH Gods");
        }
        public override void SetDefaults()
        {
            item.width = 52;
            item.height = 60;
            item.value = 10000;
			item.shootSpeed = 10f;
		    item.shoot = mod.ProjectileType("EchProjectile");
            item.UseSound = SoundID.DD2_BetsyDeath;
            item.damage = 13000;
			item.knockBack = 10f;
			item.useStyle = 1;
			item.useAnimation = 10;
			item.useTime = 10;
			item.width = 50;
			item.height = 50;
			item.maxStack = 1;
			item.rare = 10;
			item.consumable = false;
			item.noUseGraphic = false;
			item.noMelee = false;
			item.autoReuse = true;
			item.melee = true;
            item.noUseGraphic = true;
            item.crit = 100;


            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float posX = player.position.X;
            float posY = player.position.Y;

            Projectile.NewProjectile(posX, posY, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            return true;
        }

        public static bool CanUseItem()
        {
            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            if (!player.HasBuff(mod.BuffType("ECH Cooldown")))
            {
                player.statLife += 500;
                player.statMana += 500;

                if (Main.myPlayer == player.whoAmI)
                {
                    player.HealEffect(500, true);
                }
                player.AddBuff(mod.BuffType("ECH Cooldown"), 600);

                return true;
            }
            else
            {
                Main.NewText("The ECH Gods refuse to give you their healing powers.");
                return false;
            }
        }

        public override void RightClick(Player player)
        {
            i++;
            item.stack++;

            if (i < 14)
            {
                Main.NewText("Do not anger the ECH!", 255, 0, 0);
            }
            else if (i == 15)
            {
                Main.NewText("You have brought this upon yourself...", 255, 0, 0);
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.MoonLordCore);
                i = 0;
            }
        }

        public override bool CanRightClick()
        {
            return true;
        }
        
    }
}