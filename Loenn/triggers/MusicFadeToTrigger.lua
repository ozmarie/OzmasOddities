local enums = require("consts.celeste_enums")

local MusicFadeToTrigger = {}

MusicFadeToTrigger.name = "OzmasOddities/MusicFadeToTrigger"
MusicFadeToTrigger.category = "audio"
MusicFadeToTrigger.fieldInformation = {
    positionMode = {
        options = enums.trigger_position_modes,
        editable = false
    }
}

MusicFadeToTrigger.placements = {
    name = "MusicFadeToTrigger",
    data = {
        positionMode = "LeftToRight",
        fadeTo = 1.0,
        parameter = "",
        revertOnLeave = false
    }
}

MusicFadeToTrigger.fieldOrder = {"x","y","width","height","parameter","fadeTo","positionMode","revertOnLeave"}

return MusicFadeToTrigger