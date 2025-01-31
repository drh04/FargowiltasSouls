using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class MinerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner Enchantment");
            Tooltip.SetDefault(
@"'The planet trembles with each swing of your pick'
30% increased mining speed
Shows the location of enemies, traps, and treasures
Light is emitted from the player
Summons a pet Magic Lantern");
            DisplayName.AddTranslation(GameCulture.Chinese, "矿工魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你每挥一下镐子,行星都会震动'
增加30%采掘速度
显示敌人,陷阱和宝藏
照亮周围
召唤一个魔法灯笼");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2;
            item.value = 20000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoPlayer>(mod).MinerEffect(hideVisual, .3f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MiningHelmet);
            recipe.AddIngredient(ItemID.MiningShirt);
            recipe.AddIngredient(ItemID.MiningPants);
            
            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(thorium.ItemType("aSandstonePickaxe"));
                recipe.AddIngredient(ItemID.CnadyCanePickaxe); //gj 
                recipe.AddIngredient(ItemID.GoldPickaxe);
                recipe.AddIngredient(ItemID.BonePickaxe);
                recipe.AddIngredient(thorium.ItemType("EnforcedThoriumPax"));
                recipe.AddIngredient(ItemID.MoltenPickaxe);
            }
            else
            {
                recipe.AddIngredient(ItemID.GoldPickaxe);
                recipe.AddIngredient(ItemID.BonePickaxe);
                recipe.AddIngredient(ItemID.MoltenPickaxe);
            }
            
            recipe.AddIngredient(ItemID.MagicLantern);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
