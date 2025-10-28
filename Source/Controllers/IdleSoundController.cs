using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;

namespace Celeste.Mod.OzmasOddities.Controllers
{
    [CustomEntity("OzmasOddities/IdleSoundController")]
    public class IdleSoundController : Entity
    {
        private bool scratch;
        private bool sneeze;
        private bool crackknuckles;

        public static ILHook hook_KillScratch;
        public static ILHook hook_KillSneeze;
        public static ILHook hook_KillKnuckles;
        public IdleSoundController(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            scratch = data.Bool("muteScratch", false);
            sneeze = data.Bool("muteSneeze", false);
            crackknuckles = data.Bool("muteKnuckleCrack", false);
        }
        public override void Awake(Scene scene)
        {
            base.Awake(scene);
            OzmasOdditiesModule.Session.KillScratch = scratch;
            OzmasOdditiesModule.Session.KillSneeze = sneeze;
            OzmasOdditiesModule.Session.KillCrackKnuckles = crackknuckles;
        }
        public override void SceneEnd(Scene scene)
        {
            base.SceneEnd(scene);
            OzmasOdditiesModule.Session.KillScratch = false;
            OzmasOdditiesModule.Session.KillSneeze = false;
            OzmasOdditiesModule.Session.KillCrackKnuckles = false;
        }
        public static void KillIdleScratch(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);
            if (!cursor.TryGotoNext(MoveType.After, instr => instr.MatchLdstr("event:/char/madeline/idle_scratch"))) { return; }
            cursor.EmitDelegate(IdleScratchDelegate);
        }
        public static void KillIdleSneeze(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);
            if (!cursor.TryGotoNext(MoveType.After, instr => instr.MatchLdstr("event:/char/madeline/idle_sneeze"))) { return; }
            cursor.EmitDelegate(IdleSneezeDelegate);
        }
        public static void KillIdleCrackKnuckles(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);
            if (!cursor.TryGotoNext(MoveType.After, instr => instr.MatchLdstr("event:/char/madeline/idle_crackknuckles"))) { return; }
            cursor.EmitDelegate(IdleCrackKnucklesDelegate);
        }
        private static string IdleScratchDelegate(string oldstr) => OzmasOdditiesModule.Session.KillScratch ? "event:/none" : oldstr;
        private static string IdleSneezeDelegate(string oldstr) => OzmasOdditiesModule.Session.KillSneeze ? "event:/none" : oldstr;
        private static string IdleCrackKnucklesDelegate(string oldstr) => OzmasOdditiesModule.Session.KillCrackKnuckles ? "event:/none" : oldstr;
    }
}
