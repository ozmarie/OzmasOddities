using Microsoft.Xna.Framework.Input;

namespace Celeste.Mod.OzmasOddities;

public class OzmasOdditiesModuleSettings : EverestModuleSettings {

    // Define a custom button binding
    // Defaults to the A button on controller, and the C key on keyboard
    [DefaultButtonBinding(Buttons.RightStick, key: Keys.L)]
    public ButtonBinding ViewLogBinding { get; set; }
}