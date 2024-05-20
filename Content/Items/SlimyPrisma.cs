using Microsoft.Xna.Framework;
using MoreTerraprisma.Content.Buffs;
using MoreTerraprisma.Content.Projectiles;
using System.Composition.Convention;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreTerraprisma.Content.Items
{
    public class SlimyPrisma : ModItem
    {
        /*
         * These are the default values for the TerraPrisma
         
          this.mana = 10;
          this.damage = 90;
          this.useStyle = 1;
          this.shootSpeed = 10f;
          this.shoot = 946;
          this.buffType = 322;
          this.width = 26;
          this.height = 28;
          this.UseSound = SoundID.Item113;
          this.useAnimation = 36;
          this.useTime = 36;
          this.rare = 5;
          this.noMelee = true;
          this.knockBack = 4f;
          this.value = Item.sellPrice(0, 20, 0, 0);
          this.summon = true;
        */

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.EmpressBlade);
            Item.damage = 10;
            Item.color = Color.Blue;
            Item.shoot = ModContent.ProjectileType<SlimyPrismaMinion>();
            Item.buffType = ModContent.BuffType<SlimyPrismaBuff>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            //base.Shoot(player, source, position, velocity, type, damage, knockback);
            //player.AddBuff(Item.buffType, 2);
            //var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            //projectile.originalDamage = Item.damage;

            //return false;
        }
    }
}
