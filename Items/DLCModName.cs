using Terraria.ModLoader;

namespace FargowiltasDLC.Items
{ 
    public class FargowiltasDLC : ModItem
    {
        public override string Texture => "FargowiltasDLC/Items/PlaceholderItem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FargowiltasDLC");
            Tooltip.SetDefault(
                                @"Konami's Best: New Extra Epic Ultimate Fargo's Soul Mod++ 
                                Dancing All Night Golden 2: Electric Boogaloo
                                Ultra: The Game: The Book: The Movie FES Deluxe & Knuckles & Knuckles 
                                featuring Dante from the Devil May Cry series
                                All Stars Battle Royale + Bowser's Minions at the Olympic Games HD Turbo 
                                Game of the Year Edition + Rabbids – New Funky Mode!"
                               ); 
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
        }
    }
}
