using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Misc
{
	public class BossCountMax : ModItem
	{
        public override string Texture => "FargowiltasSouls/Items/Placeholder";

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boss Count Max");
            Tooltip.SetDefault(@"Maximizes all boss kill counts
Results not guaranteed in multiplayer
You probably shouldn't be reading this...");
		}

		public override void SetDefaults()
		{
            item.width = 20;
            item.height = 20;
            item.rare = 1;
            item.useStyle = 4;
            item.useAnimation = 45;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                FargoWorld.SlimeCount = FargoWorld.MaxCountPreHM;
                FargoWorld.EyeCount = FargoWorld.MaxCountPreHM;
                FargoWorld.EaterCount = FargoWorld.MaxCountPreHM;
                FargoWorld.BrainCount = FargoWorld.MaxCountPreHM;
                FargoWorld.BeeCount = FargoWorld.MaxCountPreHM;
                FargoWorld.SkeletronCount = FargoWorld.MaxCountPreHM;
                FargoWorld.WallCount = FargoWorld.MaxCountPreHM;

                FargoWorld.TwinsCount = FargoWorld.MaxCountHM;
                FargoWorld.DestroyerCount = FargoWorld.MaxCountHM;
                FargoWorld.PrimeCount = FargoWorld.MaxCountHM;
                FargoWorld.PlanteraCount = FargoWorld.MaxCountHM;
                FargoWorld.GolemCount = FargoWorld.MaxCountHM;
                FargoWorld.FishronCount = FargoWorld.MaxCountHM;
                FargoWorld.CultistCount = FargoWorld.MaxCountHM;
                FargoWorld.MoonlordCount = FargoWorld.MaxCountHM;
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }
            return true;
        }
    }
}
