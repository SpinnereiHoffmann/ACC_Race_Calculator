--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                                 Controller.lua                                *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local json = require("Libs.libJson")

local Controller = {}

------------------------------------------------------------------------------------
--- GetFileTable()
------------------------------------------------------------------------------------
---
function Controller.Read(filename)
  local uData = io.open(filename .. ".json", "r")
  local sData = uData:read("*a")
  uData:close()
  local tData = json.decode(sData)
  return tData
end

------------------------------------------------------------------------------------
--- SetFileTable()
------------------------------------------------------------------------------------
function Controller.Write(tTable, name)
  local uTable = io.open(name .. ".json", "w")
  uTable:write(json.encode(tTable))
  uTable:close()
end

------------------------------------------------------------------------------------
--- Main()
------------------------------------------------------------------------------------
---

return Controller
