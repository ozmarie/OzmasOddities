using System;
using System.Collections;
using Monocle;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.OzmasOddities.Entities
{
    [CustomEntity("OzmasOddities/IntermittentSoundSource")]
    public class IntermittentSoundSource : Entity
    {
        public SoundSource sfx;
        public string eventName;
        public string param;
        public string flag;
        public float lowVol;
        public float highVol;
        public float paramVal;
        public float lowTime;
        public float highTime;
        public bool playing = false;
        
        public IntermittentSoundSource(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            base.Tag = Tags.TransitionUpdate;
            Depth = -8500;
            Add(sfx = new SoundSource());
            eventName = SFX.EventnameByHandle(data.Attr("sound"));
            param = data.Attr("parameter");
            flag = data.Attr("flag");
            lowVol = data.Float("minVolume");
            highVol = data.Float("maxVolume");
            paramVal = data.Float("parameterValue");
            lowTime = data.Float("minDelay");
            highTime = data.Float("maxDelay");
        }
        public override void Update()
        {
            base.Update();
            if (!playing)
            {
                playing = true;
                Random rnd1 = new Random();
                Random rnd2 = new Random();
                Add(new Coroutine(DelayPlay(Calc.Range(rnd1, lowTime, highTime), Calc.Range(rnd2, lowVol, highVol))));
            }
        }
        private IEnumerator DelayPlay(float delay, float volume)
        {
            yield return delay;
            if ((Scene as Level).Session.GetFlag(flag) || flag == "")
            {
                if (param != "") sfx.Param(param, paramVal);
                sfx.Play(eventName);
                sfx.instance.setVolume(volume);
            }
            playing = false;
        }
    }
}
