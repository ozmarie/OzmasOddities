using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using System;

namespace Celeste.Mod.OzmasOddities.Triggers
{
    [CustomEntity("OzmasOddities/FlagIfParamTrigger")]
    public class FlagIfParamTrigger : Trigger
    {
        public string flag;
        public float paramval;
        public string param;

        public FlagIfParamTrigger(EntityData data, Vector2 offset) : base(data, offset)
        {
            flag = data.Attr("flag", "");
            paramval = data.Float("paramValue", 1.0f);
            param = data.Attr("parameter", "fade");
        }

        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            Level level = SceneAs<Level>();
            Audio.currentMusicEvent.getParameterValue(param, out float val, out float finalval);
            level.Session.SetFlag(flag, Math.Abs(val - paramval) < 0.01);
        }
    }
}