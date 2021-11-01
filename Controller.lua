--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                                 Controller.lua                                *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local json = require("Libs.libJson")

local Controller = {}

------------------------------------------------------------------------------------
--- GetFileTable()
------------------------------------------------------------------------------------
---
function Controller.GetFileTable(filename)
  local uData = io.open(filename .. ".json", "r") "options.json"
  local sData = uData:read("*a")
  uData:close()
  local tData = json.decode(sData)
  return tData
end

------------------------------------------------------------------------------------
--- SetFileTable()
------------------------------------------------------------------------------------
function Controller.SetFileTable(tTable, name)
    local uTable = io.open(name .. ".json", "w")
    uTable:write(json.encode(tTable))
    uTable:close()
end

------------------------------------------------------------------------------------
--- Main()
------------------------------------------------------------------------------------
---

return Controller
