using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.OzmasOddities.Triggers
{
    [CustomEntity("OzmasOddities/DarknessFadeToTrigger")]
    public class DarknessFadeToTrigger : Trigger
    {
        private bool revertOnLeave;
        private float fadeFrom;
        private float fadeTo;
        private PositionModes positionMode;
        private bool isSet;

        public DarknessFadeToTrigger(EntityData data, Vector2 offset) : base(data, offset)
        {
            isSet = false;
            revertOnLeave = data.Bool("revertOnLeave", false);
            fadeTo = data.Float("fadeTo", 0.1f);
            positionMode = data.Enum<PositionModes>("positionMode");
        }
        public override void OnEnter(Player player)
        {
            if (!isSet)
            {
                fadeFrom = SceneAs<Level>().Lighting.Alpha;
                isSet = true;
            }
        }
        public override void OnStay(Player player)
        {
            SceneAs<Level>().Lighting.Alpha = Calc.ClampedMap(GetPositionLerp(player, positionMode), 0f, 1f, fadeFrom, fadeTo);
        }
        public override void OnLeave(Player player)
        {
            if(revertOnLeave)
            {
                SceneAs<Level>().Lighting.Alpha = fadeFrom;
            }
        }
    }
}