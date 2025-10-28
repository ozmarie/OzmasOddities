local FlagIfParamTrigger = {}

FlagIfParamTrigger.name = "OzmasOddities/FlagIfParamTrigger"
FlagIfParamTrigger.category = "audio"
FlagIfParamTrigger.placements = {
    name = "FlagIfParamTrigger",
    data = {
        flag = "",
        paramValue = 1.0,
        parameter = "fade"
    }
}

FlagIfParamTrigger.fieldOrder = {"x","y","width","height","parameter","paramValue","flag"}

return FlagIfParamTrigger