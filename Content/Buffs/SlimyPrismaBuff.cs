using MoreTerraprisma.Content.Items;
using Terraria;
using MoreTerraprisma.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreTerraprisma.Content.Buffs
{
    public class SlimyPrismaBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SlimyPrismaMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
