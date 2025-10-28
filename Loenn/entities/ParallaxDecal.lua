local drawSprite = require("structs.drawable_sprite")

local ParallaxDecal = {}

ParallaxDecal.name = "OzmasOddities/ParallaxDecal"
ParallaxDecal.placements = {
    name = "ParallaxDecal",
    data = {
        Path = "",
        ScaleX = 1.0,
        ScaleY = 1.0,
        Depth = 9500,
        Rotation = 0,
        Color = "FFFFFFFF",
        ParallaxX = 0.1,
        ParallaxY = 0.1
    }
}

ParallaxDecal.fieldOrder = {"x","y","ParallaxX","ParallaxY","Path","Color","ScaleX","ScaleY","Rotation","Depth"}

function ParallaxDecal.texture(room, entity)
    if drawSprite.fromTexture("decals/" .. entity.Path .. "00") ~= nil then
        return "decals/" .. entity.Path .. "00"
    else
        return "decals/" .. entity.Path
    end
end

function ParallaxDecal.scale(room, entity)
    return { entity.ScaleX or 1, entity.ScaleY or 1 }
end
function ParallaxDecal.rotation(room, entity)
    return (entity.Rotation or 0) * math.pi / 180
end

return ParallaxDecal