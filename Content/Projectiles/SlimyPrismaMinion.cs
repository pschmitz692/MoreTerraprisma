using Microsoft.Xna.Framework;
using MoreTerraprisma.Content.Buffs;
using rail;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreTerraprisma.Content.Projectiles
{
    public class SlimyPrismaMinion : ModProjectile
    {
        /*
         * These are the default values for the Terraprisma summon
         
         this.netImportant = true;
         this.width = 10;
         this.height = 10;
         this.penetrate = -1;
         this.ignoreWater = true;
         this.tileCollide = false;
         this.friendly = true;
         this.minion = true;
         this.minionSlots = 1f;
         this.timeLeft *= 5;
         this.usesLocalNPCImmunity = true;
         this.localNPCHitCooldown = 15;
         this.aiStyle = 156;
         this.scale = 0.75f;
         this.manualDirectionChange = true;
         this.hide = true;
        */

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

            Main.projPet[Projectile.type] = true;

            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public sealed override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EmpressBlade);
            //Projectile.aiStyle = ProjectileID.EmpressBlade;
            AIType = ProjectileID.EmpressBlade;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            base.AI();

            CheckActive(Main.player[Projectile.owner]);
        }

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<SlimyPrismaBuff>());
                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<SlimyPrismaBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }
    }
}
