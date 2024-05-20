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

        public sealed override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EmpressBlade);
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

        
    }
}
