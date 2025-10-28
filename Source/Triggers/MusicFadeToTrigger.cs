using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.OzmasOddities.Triggers
{
    [CustomEntity("OzmasOddities/MusicFadeToTrigger")]
    public class MusicFadeToTrigger : MusicFadeTrigger
    {
        private float val;
        private bool revertOnLeave;
        public MusicFadeToTrigger(EntityData data, Vector2 offset) : base(data, offset)
        {
            revertOnLeave = data.Bool("revertOnLeave", false);
            Audio.CurrentMusicEventInstance.getParameterValue(Parameter, out val, out float fval);
            FadeA = val;
            FadeB = data.Float("fadeTo", 1f);
        }
        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            Audio.CurrentMusicEventInstance.getParameterValue(Parameter, out val, out float fval);
            FadeA = val;
        }
        public override void OnLeave(Player player)
        {
            base.OnLeave(player);
            if(revertOnLeave)
            {
                Audio.SetMusicParam(Parameter, val);
            }
        }
    }
}