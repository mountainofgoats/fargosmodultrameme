using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;

namespace FargowiltasDLC
{
    public partial class DLCPlayer : ModPlayer
	{
		public bool PlaceholderPet;

		public override void ResetEffects()
        {
            PlaceholderPet = false;
        }

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(mod.ItemType("Placeholder"));
			items.Add(item);
			Item item2 = new Item();
			item2.SetDefaults(mod.ItemType("MasochistEX"));
			items.Add(item2);
		}
	}
}
