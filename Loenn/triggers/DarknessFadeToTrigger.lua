local enums = require("consts.celeste_enums")

local DarknessFadeToTrigger = {}

DarknessFadeToTrigger.name = "OzmasOddities/DarknessFadeToTrigger"
DarknessFadeToTrigger.category = "visual"
DarknessFadeToTrigger.fieldInformation = {
    positionMode = {
        options = enums.trigger_position_modes,
        editable = false
    }
}
DarknessFadeToTrigger.placements = {
    name = "DarknessFadeToTrigger",
    data = {
        positionMode = "LeftToRight",
        fadeTo = 0.1,
        revertOnLeave = false;
    }
}

return DarknessFadeToTrigger