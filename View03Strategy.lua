--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                               View03Strategy.lua                              *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local View = {}
local Controller = require("Controller")

------------------------------------------------------------------------------------
--- Main()
------------------------------------------------------------------------------------
---
local tTranslation = Controller.Read("translation")
local tOptions = Controller.Read("options")
if tOptions.sFilename ~= nil then
  print("if")
  local tData = Controller.Read(tOptions.sFilename)
else
  print("else")
  local tData = {}
end
-- labels
local lblDriver = iup.label {

}
View = iup.vbox {}

return View