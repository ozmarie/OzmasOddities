using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.OzmasOddities.Triggers
{
    [CustomEntity("OzmasOddities/CustomDashRemover")]
    public class CustomDashRemover : Trigger
    {
        bool clearCloud;
        bool clearShadow;
        bool clearDream;
        public CustomDashRemover(EntityData data, Vector2 offset) : base(data, offset)
        {
            clearCloud = data.Bool("ClearCloudDash", true);
            clearShadow = data.Bool("ClearShadowDash", true);
            clearDream = data.Bool("ClearDreamDash", true);
        }
        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            if (OzmasOdditiesModule.hasAnonHelper && clearCloud) clearCloudDash();
            if (OzmasOdditiesModule.hasCherryHelper && clearShadow) clearShadowDash();
            if (OzmasOdditiesModule.hasCommunalHelper && clearDream) clearDreamDash();
        }
        private void clearCloudDash() => Anonhelper.AnonModule.Session.HasCloudDash = false;
        private void clearShadowDash() => CherryHelper.CherryHelper.Session.HasShadowDash = false;
        private void clearDreamDash() => CommunalHelper.DashStates.DreamTunnelDash.DreamTunnelDashCount = 0;
    }
}
