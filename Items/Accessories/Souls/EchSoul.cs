using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEEUFSMG2EBTGTBTMFESKKDDMCHDTENFM.Items.Accessories.Souls
{
    public class EchSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Ech");
            Tooltip.SetDefault("'Just a soul with random effects'\n10% increased melee damage and speed\n10% increased ranged damage and crit\n20% increased magic damage\n15% increased summon damage and minion knockback\nReduces damage taken by 30%\n+200 Max Life and Mana\n+2 Max Minions\nIncreased life and mana regen\nImmunity to most debuffs\nThe wearer can run super fast\nEffects of Fire Gauntlet, Sniper Scope and Mana Flower\nEffects of Bee Cloak, Star Veil and Charm of Myths\nEffects of Frostspark Boots, Lava Waders and Ankh Shield");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            { 
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(249, 170, 95));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.defense = 30;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            felinesPlayer modPlayer = player.GetModPlayer<felinesPlayer>(mod);

            //endurance stats
            player.endurance += 0.30f;
            player.starCloak = true;
            player.bee = true;
            player.longInvince = true;
            player.pStone = true;

            //life stats
            player.lifeRegen += 10;
            player.statLifeMax2 += 200;

            //mana stats
            player.manaRegen += 10;
            player.statManaMax2 += 200;

            //speed boosts
            player.accRunSpeed += 30f;

            //melee stats
            player.kbGlove = true;
            player.magmaStone = true;
            player.meleeDamage += 0.10f;
            player.meleeSpeed += 0.10f;

            //ranged stats
            player.scope = true;
            player.rangedDamage += 0.10f;
            player.rangedCrit += 10;

            //magic stats
            player.manaFlower = true;
            player.magicDamage += 0.20f;

            //summon stats
            player.maxMinions += 2;
            player.minionDamage += 0.15f;
            player.minionKB += 0.15f;

            //other
            player.iceSkate = true;
            player.noKnockback = true;
            player.waterWalk = true;
            player.fireWalk = true;

            //debuff immunities
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;    
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Burning] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireGauntlet);
            recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddIngredient(ItemID.ManaFlower);
            recipe.AddIngredient(ItemID.PapyrusScarab);
            recipe.AddIngredient(ItemID.PygmyNecklace);
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ItemID.BeeCloak);
            recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.LifeforcePotion);
            recipe.AddIngredient(ItemID.MagicPowerPotion);
            recipe.AddIngredient(ItemID.ManaRegenerationPotion);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}