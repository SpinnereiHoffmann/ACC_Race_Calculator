--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                                View02Common.lua                               *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local View = {}

local Controller = require("Controller")

local tOptions = Controller.Read("options")
local nLanguage = tOptions.language.value

local tTranslation = Controller.Read("translation")
local valTranslation = tTranslation.languages[nLanguage]

-- local tDriver = Controller.Read(tOptions.filename)
-- local tPitstop = {}
local tData = Controller.Read(tOptions.filename)

------------------------------------------------------------------------------------
--- DlgEnterPitName()
------------------------------------------------------------------------------------
---
local function DlgEnterPitName(i)
  local tname = iup.text {
    -- value = valTranslation.PITSTOP .. tostring(i),
    value = valTranslation.PITSTOP .. i,
    size = 200
  }
  local btnOk = iup.button{
    size  = 50,
    title = "OK"
  }
  local btnCancel = iup.button {
    size  = 50,
    title = valTranslation.CANCEL
  }
  local box = iup.vbox {
    iup.hbox {
      iup.fill {},
      tname,
      iup.fill {}
    },
    iup.hbox {
      iup.fill {},
      btnOk,
      iup.fill {},
      btnCancel,
      iup.fill {}
    },
    gap = 10,
    margin = "10x10",
  }
  local dlgInsertName = iup.dialog{
    title = valTranslation.ENTER_NAME,
    box,
    -- EXPAND = "NO",
    MINSIZE = 60, 50,
    MAXBOX = "NO",
    MINBOX = "NO",
    RESIZE = "NO",
    DEFAULTENTER = btnOk,
    DEFAULTESC = btnCancel
  }

  local name = ""

  function btnOk:action()
    name = tname.value
    dlgInsertName:destroy()
    -- return name
    -- iup.Close()
  end

  function btnCancel:action()
    name = nil
    dlgInsertName:destroy()
    -- iup.Close()
  end

  -- dlgInsertName:show(iup.CENTER,iup.CENTER)--"Fahrer" .. tostring(i)
  dlgInsertName:popup()--"Fahrer" .. tostring(i)
  print(name)
  return name
end

------------------------------------------------------------------------------------
--- AddPitstop()
------------------------------------------------------------------------------------
---
local function AddPitstop()
  local i = 1
  for k, v in pairs(tData.tPitstop) do
    i = i + 1
  end
  if i < 5 then
    local pitname = DlgEnterPitName(i)
    tData.tPitstop["pit" .. i] = {sName = pitname, dValue = 0}
    Controller.Write(tData, tOptions.filename)
  else
    iup.Message(valTranslation.ERROR, valTranslation.MAX_PITS)
  end
end

-----------------------------------------------------------------------------------
--- GetPitstopName()
-----------------------------------------------------------------------------------
---
local function GetPitstopName(i)
  return tData.tPitstop["pit" .. i].sName
end

-----------------------------------------------------------------------------------
--- DlgEnterName()
-----------------------------------------------------------------------------------
---
local function DlgEnterName(i)
  local tname = iup.text {
    value = tData.tDriver["Driver" .. i].sName
  }
  local btnOk = iup.button{
    size  = 50,
    title = "OK"
  }
  local btnCancel = iup.button {
    size  = 50,
    title = valTranslation.CANCEL
  }
  local box = iup.vbox {
    iup.hbox {
      iup.fill {},
      tname,
      iup.fill {}
    },
    iup.hbox {
      iup.fill {},
      btnOk,
      iup.fill {},
      btnCancel,
      iup.fill {}
    },
    gap = 10,
    margin = "10x10",
  }
  local dlgInsertName = iup.dialog{
    title = valTranslation.ENTER_NAME,
    box,
    -- EXPAND = "NO",
    MINSIZE = 60, 50,
    MAXBOX = "NO",
    MINBOX = "NO",
    RESIZE = "NO",
    DEFAULTENTER = btnOk,
    DEFAULTESC = btnCancel
  }

  local name = "Fahrer" .. tostring(i)

  function btnOk:action()
    name = tname.value
    dlgInsertName:destroy()
    -- return name
    -- iup.Close()
  end

  function btnCancel:action()
    name = nil
    dlgInsertName:destroy()
    -- iup.Close()
  end

  -- dlgInsertName:show(iup.CENTER,iup.CENTER)--"Fahrer" .. tostring(i)
  dlgInsertName:popup()--"Fahrer" .. tostring(i)
  return name
end

-----------------------------------------------------------------------------------
--- AddDriver()
-----------------------------------------------------------------------------------
---
local function AddDriver()
  local i = #tData.tDriver + 1
  if #tData.tDriver < 6 then
    tData.tDriver["Driver" .. i].sName = DlgEnterName(i)
  else
    iup.Message(valTranslation.ERROR, valTranslation.MAX_DRIVER)
  end
end

-----------------------------------------------------------------------------------
--- GetDriverName()
-----------------------------------------------------------------------------------
---
local function GetDriverName(i)
  return tData.tDriver["Driver" .. i].sName
end

------------------------------------------------------------------------------------
--- Main()
------------------------------------------------------------------------------------
---

-- Labels
local lblEmpty = iup.label {title = ""}
local lblTime = iup.label {title = valTranslation.TIME}
local lblConsumption = iup.label {title = valTranslation.CONSUMPTION}

local lblDrivers = {
  driver1 = iup.label {
    title = "tDriver[1]",
    visible = "NO",
    size = 40
  },
  driver2 = iup.label {
    title = "tDriver[2]",
    visible = "NO",
    size = 40
  },
  driver3 = iup.label {
    title = "tDriver[3]",
    visible = "NO",
    size = 40
  },
  driver4 = iup.label {
    title = "tDriver[4]",
    visible = "NO",
    size = 40
  },
  driver5 = iup.label {
    title = "tDriver[5]",
    visible = "NO",
    size = 40
  },
  driver6 = iup.label {
    title = "tDriver[6]",
    visible = "NO",
    size = 40
  }
}

local lblPitstops = {
  pit1 = iup.label {
    title = valTranslation.PITSTOP1,
    visible = "NO",
    size = 200
  },
  pit2 = iup.label {
    title = valTranslation.PITSTOP2,
    visible = "NO",
    size = 200
  },
  pit3 = iup.label {
    title = valTranslation.PITSTOP3,
    visible = "NO",
    size = 200
  },
  pit4 = iup.label {
    title = valTranslation.PITSTOP1,
    visible = "NO",
    size = 200
  }
}

local lblSec = {}
for k, v in pairs(lblPitstops) do
  lblSec[k] = iup.label {
    title = valTranslation.SECONDS,
    visible = "NO",
    size = 72
  }
end

-- txtFields
local txtDrivers = {
  driver1 = iup.text {value = "0:00.000", visible = "NO"},
  driver2 = iup.text {value = "0:00.000", visible = "NO"},
  driver3 = iup.text {value = "0:00.000", visible = "NO"},
  driver4 = iup.text {value = "0:00.000", visible = "NO"},
  driver5 = iup.text {value = "0:00.000", visible = "NO"},
  driver6 = iup.text {value = "0:00.000", visible = "NO"}
}

local txtConsumption = {
  driver1 = iup.text {value = 0.00, visible = "NO"},
  driver2 = iup.text {value = 0.00, visible = "NO"},
  driver3 = iup.text {value = 0.00, visible = "NO"},
  driver4 = iup.text {value = 0.00, visible = "NO"},
  driver5 = iup.text {value = 0.00, visible = "NO"},
  driver6 = iup.text {value = 0.00, visible = "NO"}
}

local txtPitTime = {
  pit1 = iup.text {
    value = 0,
    size = 20,
    visible = "NO"
  },
  pit2 = iup.text {
    value = 0,
    size = 20,
    visible = "NO"
  },
  pit3 = iup.text {
    value = 0,
    size = 20,
    visible = "NO"
  },
  pit4 = iup.text {
    value = 0,
    size = 20,
    visible = "NO"
  }
}

-- buttons
local btnAddDriver = iup.button{
  size      = 95,
  title     = valTranslation.ADD_DRIVER,
  alignment = "ACENTER"
}

local btnRemoveDriver = {
  driver1 = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  },
  driver2 = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  },
  driver3 = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  },
  driver4 = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  },
  driver5 = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  },
  driver6 = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  }
}

local btnAddPitstop = iup.button {
  size = 95,
  title = valTranslation.ADD_PITSTOP
}

local btnRemovePitstop = {}
for k, v in pairs(lblPitstops) do
  btnRemovePitstop[k] = iup.button {
    size = 40,
    title = valTranslation.REMOVE,
    visible = "NO"
  }
end

local boxPitstop = iup.vbox {
  iup.hbox {lblPitstops.pit1, txtPitTime.pit1, lblSec.pit1, btnRemovePitstop.pit1},
  iup.hbox {lblPitstops.pit2, txtPitTime.pit2, lblSec.pit2, btnRemovePitstop.pit2},
  iup.hbox {lblPitstops.pit3, txtPitTime.pit3, lblSec.pit3, btnRemovePitstop.pit3},
  iup.hbox {lblPitstops.pit4, txtPitTime.pit4, lblSec.pit4, btnRemovePitstop.pit4}
}

View = iup.vbox {
  iup.hbox {
    iup.vbox {lblEmpty, lblTime, lblConsumption, gap = "15"},
    iup.vbox {
      lblDrivers.driver1,
      txtDrivers.driver1,
      txtConsumption.driver1,
      btnRemoveDriver.driver1
    },
    iup.vbox {
      lblDrivers.driver2,
      txtDrivers.driver2,
      txtConsumption.driver2,
      btnRemoveDriver.driver2
    },
    iup.vbox {
      lblDrivers.driver3,
      txtDrivers.driver3,
      txtConsumption.driver3,
      btnRemoveDriver.driver3
    },
    iup.vbox {
      lblDrivers.driver4,
      txtDrivers.driver4,
      txtConsumption.driver4,
      btnRemoveDriver.driver4
    },
    iup.vbox {
      lblDrivers.driver5,
      txtDrivers.driver5,
      txtConsumption.driver5,
      btnRemoveDriver.driver5
    },
    iup.vbox {
      lblDrivers.driver6,
      txtDrivers.driver6,
      txtConsumption.driver6,
      btnRemoveDriver.driver6
    },
    iup.vbox {btnAddDriver},
  },
  iup.hbox {boxPitstop, iup.fill {}, iup.vbox {btnAddPitstop}},
  alignment = "acenter",
  gap = "10",
  margin = "10x10",
}

function btnAddPitstop:action()
  AddPitstop()

  for i = 1, 5 do
    if tData.tPitstop["pit" .. i] ~= nil then
      lblPitstops["pit" .. i].title = GetPitstopName(i)
      lblPitstops["pit" .. i].visible = "YES"
      txtPitTime["pit" .. i].visible = "YES"
      lblSec["pit" .. i].visible = "YES"
      btnRemovePitstop["pit" .. i].visible = "YES"
    end
  end
end

local function RemovePitstop()
  local i = 1
  for k, v in pairs(tData.tPitstop) do
     i = i + 1
  end
  lblPitstops["pit" .. i].visible = "NO"
  txtPitTime["pit" .. i].visible = "NO"
  lblSec["pit" .. i].visible = "NO"
  btnRemovePitstop["pit" .. i].visible = "NO"
  Controller.Write(tData, tOptions.filename)
end


function btnRemovePitstop.pit1:action()
  tData.tPitstop["pit1"] = nil
  tData.tPitstop["pit1"] = tData.tPitstop["pit2"]
  tData.tPitstop["pit2"] = tData.tPitstop["pit3"]
  tData.tPitstop["pit3"] = tData.tPitstop["pit4"]
  tData.tPitstop["pit4"] = tData.tPitstop["pit5"]
  RemovePitstop()
end

function btnRemovePitstop.pit2:action()
  tData.tPitstop["pit2"] = nil
  tData.tPitstop["pit2"] = tData.tPitstop["pit3"]
  tData.tPitstop["pit3"] = tData.tPitstop["pit4"]
  tData.tPitstop["pit4"] = tData.tPitstop["pit5"]
  RemovePitstop()
end

function btnRemovePitstop.pit3:action()
  tData.tPitstop["pit3"] = nil
  tData.tPitstop["pit3"] = tData.tPitstop["pit4"]
  tData.tPitstop["pit4"] = tData.tPitstop["pit5"]
  RemovePitstop()
end

function btnRemovePitstop.pit4:action()
  tData.tPitstop["pit4"] = nil
  RemovePitstop()
end


function btnAddDriver:action()
  AddDriver()

  for i = 1, 6 do
    if tData.tDriver[i] ~= nil then
    lblDrivers["driver" .. i].title = GetDriverName(i)
    lblDrivers["driver" .. i].visible = "YES"
    txtDrivers["driver" .. i].visible = "YES"
    txtConsumption["driver" .. i].visible = "YES"
    btnRemoveDriver["driver" .. i].visible = "YES"
    end
  end
end

local function RemoveDriver()
  local i = 1
  for k, v in pairs(tData.tDrivers) do
    i = i + 1
  end
  lblDrivers["driver" .. i].visible = "NO"
  txtDrivers["driver" .. i].visible = "NO"
  txtConsumption["driver" .. i].visible = "NO"
  btnRemoveDriver["driver" .. i].visible = "NO"
end

function btnRemoveDriver.driver1:action()
  tData.tDriver["Driver1"] = nil
  tData.tDriver["Driver1"] = tData.tDriver["Driver2"]
  tData.tDriver["Driver2"] = tData.tDriver["Driver3"]
  tData.tDriver["Driver3"] = tData.tDriver["Driver4"]
  tData.tDriver["Driver4"] = tData.tDriver["Driver5"]
  tData.tDriver["Driver5"] = tData.tDriver["Driver6"]
  tData.tDriver["Driver6"] = tData.tDriver["Driver7"]
  RemoveDriver()
end

function btnRemoveDriver.driver2:action()
  tData.tDriver["Driver2"] = nil
  tData.tDriver["Driver2"] = tData.tDriver["Driver3"]
  tData.tDriver["Driver3"] = tData.tDriver["Driver4"]
  tData.tDriver["Driver4"] = tData.tDriver["Driver5"]
  tData.tDriver["Driver5"] = tData.tDriver["Driver6"]
  tData.tDriver["Driver6"] = tData.tDriver["Driver7"]
  RemoveDriver()
end

function btnRemoveDriver.driver3:action()
  tData.tDriver["Driver3"] = nil
  tData.tDriver["Driver3"] = tData.tDriver["Driver4"]
  tData.tDriver["Driver4"] = tData.tDriver["Driver5"]
  tData.tDriver["Driver5"] = tData.tDriver["Driver6"]
  tData.tDriver["Driver6"] = tData.tDriver["Driver7"]
  RemoveDriver()
end

function btnRemoveDriver.driver4:action()
  tData.tDriver["Driver4"] = nil
  tData.tDriver["Driver4"] = tData.tDriver["Driver5"]
  tData.tDriver["Driver5"] = tData.tDriver["Driver6"]
  tData.tDriver["Driver6"] = tData.tDriver["Driver7"]
  RemoveDriver()
end

function btnRemoveDriver.driver5:action()
  tData.tDriver["Driver5"] = nil
  tData.tDriver["Driver5"] = tData.tDriver["Driver6"]
  tData.tDriver["Driver6"] = tData.tDriver["Driver7"]
  RemoveDriver()
end

function btnRemoveDriver.driver6:action()
  tData.tDriver["Driver6"] = nil
  RemoveDriver()
end

return View