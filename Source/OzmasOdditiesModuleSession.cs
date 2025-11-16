namespace Celeste.Mod.OzmasOddities;

public class OzmasOdditiesModuleSession : EverestModuleSession {
    public bool KillScratch { get; set; } = false;
    public bool KillSneeze { get; set; } = false;
    public bool KillCrackKnuckles { get; set; } = false;
    public bool DisablePauseSnapshot { get; set; } = false;
    public bool DisableDialogSnapshot { get; set; } = false;
    public bool DisableMiniDialogSnapshot { get; set; } = false;
}