using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasDLC.Items.Accessories.Souls
{
    public class ExpertSoul : ModItem
    {
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";
        Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Expert");
            Tooltip.SetDefault("'Fortune & Glory, Kid'\nEffects of all expert mode accessories");
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 50;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //royal gel
            player.npcTypeNoAggro[1] = true;
            player.npcTypeNoAggro[16] = true;
            player.npcTypeNoAggro[59] = true;
            player.npcTypeNoAggro[71] = true;
            player.npcTypeNoAggro[81] = true;
            player.npcTypeNoAggro[138] = true;
            player.npcTypeNoAggro[121] = true;
            player.npcTypeNoAggro[122] = true;
            player.npcTypeNoAggro[141] = true;
            player.npcTypeNoAggro[147] = true;
            player.npcTypeNoAggro[183] = true;
            player.npcTypeNoAggro[184] = true;
            player.npcTypeNoAggro[204] = true;
            player.npcTypeNoAggro[225] = true;
            player.npcTypeNoAggro[244] = true;
            player.npcTypeNoAggro[302] = true;
            player.npcTypeNoAggro[333] = true;
            player.npcTypeNoAggro[335] = true;
            player.npcTypeNoAggro[334] = true;
            player.npcTypeNoAggro[336] = true;
            player.npcTypeNoAggro[537] = true;
            //shield of cthulhu
            player.dash = 2;
            //worm scarf
            player.endurance += 0.17f;
            //brain of confusion
            player.brainOfConfusion = true;
            //hive pack
            player.strongBees = true;
            //spore sac
            player.SporeSac();
            player.sporeSac = true;
            //shiny stone
            player.shinyStone = true;
            //gravity globe
            player.gravControl2 = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RoyalGel);
            recipe.AddIngredient(ItemID.EoCShield);
            recipe.AddIngredient(ItemID.WormScarf);
            recipe.AddIngredient(ItemID.BrainOfConfusion);
            recipe.AddIngredient(ItemID.HiveBackpack);
            recipe.AddIngredient(ItemID.BoneGlove);
            recipe.AddIngredient(ItemID.DemonHeart);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
            recipe.AddIngredient(ItemID.MechanicalWagonPiece);
            recipe.AddIngredient(ItemID.MechanicalWheelPiece);
            recipe.AddIngredient(ItemID.SporeSac);
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddIngredient(ItemID.ShrimpyTruffle);
            recipe.AddIngredient(ItemID.GravityGlobe);
            recipe.AddTile(FargowiltasSouls != null ? FargowiltasSouls.TileType("CrucibleCosmosSheet") : TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}