--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                                View02Common.lua                               *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local View = {}

local Controller = require("Controller")

local tOptions = Controller.Read("options")
local nLanguage = tOptions.language.value

local tTranslation = Controller.Read("translation")
local valTranslation = tTranslation.languages[nLanguage]

local tDriver = {} -- Controller.Read("driver") or {}
local tPitstop = {}

------------------------------------------------------------------------------------
--- DlgEnterPitName()
------------------------------------------------------------------------------------
---
local function DlgEnterPitName(i)
  local tname = iup.text {
    value = valTranslation.PITSTOP .. tostring(i),
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

------------------------------------------------------------------------------------
--- AddPitstop()
------------------------------------------------------------------------------------
---
local function AddPitstop()
  local i = #tPitstop + 1
  if #tPitstop < 4 then
    tPitstop[i] = DlgEnterPitName(i)
  else
    iup.Message(valTranslation.ERROR, valTranslation.MAX_PITS)
  end
end

-----------------------------------------------------------------------------------
--- GetPitstopName()
-----------------------------------------------------------------------------------
---
local function GetPitstopName(i)
  return tPitstop[i]
end

-----------------------------------------------------------------------------------
--- DlgEnterName()
-----------------------------------------------------------------------------------
---
local function DlgEnterName(i)
  local tname = iup.text {value = valTranslation.DRIVER .. tostring(i)}
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
  local i = #tDriver + 1
  if #tDriver < 6 then
    tDriver[i] = DlgEnterName(i)
  else
    iup.Message(valTranslation.ERROR, valTranslation.MAX_DRIVER)
  end
end

-----------------------------------------------------------------------------------
--- GetDriverName()
-----------------------------------------------------------------------------------
---
local function GetDriverName(i)
  return tDriver[i]
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
    title = valTranslation.PITSTOP4,
    visible = "NO",
    size = 200
  }
}

local lblSec = {}
for k, v in pairs(lblPitstops) do
  lblSec[k] = iup.label {
    title = valTranslation.SECONDS,
    visible = "NO",
    size = 90
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
  pit1 = iup.text {value = 00, size = 20, visible = "NO"},
  pit2 = iup.text {value = 00, size = 20, visible = "NO"},
  pit3 = iup.text {value = 00, size = 20, visible = "NO"},
  pit4 = iup.text {value = 00, size = 20, visible = "NO"}
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

local boxPitstop = iup.vbox {
  iup.hbox {lblPitstops.pit1, txtPitTime.pit1, lblSec.pit1},
  iup.hbox {lblPitstops.pit2, txtPitTime.pit2, lblSec.pit2},
  iup.hbox {lblPitstops.pit3, txtPitTime.pit3, lblSec.pit3},
  iup.hbox {lblPitstops.pit4, txtPitTime.pit4, lblSec.pit4}
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
    if tPitstop[i] ~= nil then
      lblPitstops["pit" .. i].title = GetPitstopName(i)
      lblPitstops["pit" .. i].visible = "YES"
      txtPitTime["pit" .. i].visible = "YES"
      lblSec["pit" .. i].visible = "YES"
    end
  end
end

function btnAddDriver:action()
  AddDriver()

  for i = 1, 6 do
    if tDriver[i] ~= nil then
    lblDrivers["driver" .. i].title = GetDriverName(i)
    lblDrivers["driver" .. i].visible = "YES"
    txtDrivers["driver" .. i].visible = "YES"
    txtConsumption["driver" .. i].visible = "YES"
    btnRemoveDriver["driver" .. i].visible = "YES"
    end
  end
end

local function RemoveDriver()
  lblDrivers["driver" .. #tDriver+1].visible = "NO"
  txtDrivers["driver" .. #tDriver+1].visible = "NO"
  txtConsumption["driver" .. #tDriver+1].visible = "NO"
  btnRemoveDriver["driver" .. #tDriver+1].visible = "NO"
end

function btnRemoveDriver.driver1:action()
  tDriver[1] = nil
  tDriver[1] = tDriver[2]
  tDriver[2] = tDriver[3]
  tDriver[3] = tDriver[4]
  tDriver[4] = tDriver[5]
  tDriver[5] = tDriver[6]
  tDriver[6] = tDriver[7]
  RemoveDriver()
end

function btnRemoveDriver.driver2:action()
  tDriver[2] = nil
  tDriver[2] = tDriver[3]
  tDriver[3] = tDriver[4]
  tDriver[4] = tDriver[5]
  tDriver[5] = tDriver[6]
  tDriver[6] = tDriver[7]
  RemoveDriver()
end

function btnRemoveDriver.driver3:action()
  tDriver[3] = nil
  tDriver[3] = tDriver[4]
  tDriver[4] = tDriver[5]
  tDriver[5] = tDriver[6]
  tDriver[6] = tDriver[7]
  RemoveDriver()
end

function btnRemoveDriver.driver4:action()
  tDriver[4] = nil
  tDriver[4] = tDriver[5]
  tDriver[5] = tDriver[6]
  tDriver[6] = tDriver[7]
  RemoveDriver()
end

function btnRemoveDriver.driver5:action()
  tDriver[5] = nil
  tDriver[5] = tDriver[6]
  tDriver[6] = tDriver[7]
  RemoveDriver()
end

function btnRemoveDriver.driver6:action()
  tDriver[6] = nil
  RemoveDriver()
end

return View