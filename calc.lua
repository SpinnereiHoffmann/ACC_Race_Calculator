--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                           ACC Race Calculator                                 *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
require("iuplua")
local json = require("Libs.libJson")

-----------------------------------------------------------------------------------
--- Driver
-----------------------------------------------------------------------------------
local tDriver = {}

-----------------------------------------------------------------------------------
--- Translation
-----------------------------------------------------------------------------------
local uOptions = io.open("options.json", "r")
local sOptions = uOptions:read("*a")
local tOptions = json.decode(sOptions)
local nLanguage = tOptions.language.value
uOptions:close()

local uTranslation = io.open("translation.json", "r")
local sTranslation = uTranslation:read("*a")
local tTranslation = json.decode(sTranslation)
local valTranslation = tTranslation.languages[nLanguage]

-----------------------------------------------------------------------------------
--- dlgEnterName()
-----------------------------------------------------------------------------------
---
local function dlgEnterName(i)
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
    tDriver[i] = dlgEnterName(i)
  else
    iup.Message(valTranslation.ERROR,valTranslation.MAX_DRIVER) --Maximale Anzahl an Fahrern erreicht.
  end
end


-----------------------------------------------------------------------------------
--- GetDriverName()
-----------------------------------------------------------------------------------
---
local function GetDriverName(i)
  return tDriver[i]
end

-----------------------------------------------------------------------------------
--- Start
-----------------------------------------------------------------------------------
---
local function Start()
  
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

  -- dropdown
  local dropLang = iup.list {
    "Deutsch", 
    "English",
    value = nLanguage,
    dropdown = "YES",
    visible_items = 4,
    size = 80
  }

  function dropLang:valuechanged_cb()
    print("value changed")
    tOptions.language.value = dropLang.value
    local uOptions = io.open("options.json", "w")
    uOptions:write(json.encode(tOptions))
    uOptions:close()
    print(tOptions.language.value)
    -- iup.Refresh(dlg)
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

  -- Buttons
  local btnAddDriver = iup.button{
    size      = 80,
    title     = valTranslation.ADD_DRIVER,
    alignment = "ACENTER"
  }
  
  local button = iup.button {
    size  = 50,
    title = "OK"
  }

  local btnRefresh = iup.button {
    size  = 50,
    title = "refresh"
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

  function button:action()
    -- Exits the main loop
    -- hier kommt die json - Lib zum Einsatz!
    --todo vorher noch Daten in .json File schreiben!
    return iup.CLOSE
  end

  local box = iup.vbox {
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
      iup.vbox {dropLang, btnAddDriver}
    },
    iup.hbox {
      btnRefresh,
      button
    },
    alignment = "acenter",
    gap = "10",
    margin = "10x10",
  }

  local dlg = iup.dialog {
    box,
    title = "ACC Race Calculator",
    DEFAULTENTER = btnAddDriver,
    DEFAULTESC = button
  }

  function btnRefresh:action()
    iup.Map(box)
    box:show()
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
    RemoveDriver()
  end

  function btnRemoveDriver.driver2:action()
    tDriver[2] = nil
    tDriver[2] = tDriver[3]
    tDriver[3] = tDriver[4]
    tDriver[4] = tDriver[5]
    tDriver[5] = tDriver[6]
    RemoveDriver()
  end

  function btnRemoveDriver.driver3:action()
    tDriver[3] = nil
    tDriver[3] = tDriver[4]
    tDriver[4] = tDriver[5]
    tDriver[5] = tDriver[6]
    RemoveDriver()
  end

  function btnRemoveDriver.driver4:action()
    tDriver[4] = nil
    tDriver[4] = tDriver[5]
    tDriver[5] = tDriver[6]
    RemoveDriver()
  end

  function btnRemoveDriver.driver5:action()
    tDriver[5] = nil
    tDriver[5] = tDriver[6]
    RemoveDriver()
  end

  function btnRemoveDriver.driver6:action()
    tDriver[6] = nil
    RemoveDriver()
  end

  dlg:showxy(iup.CENTER,iup.CENTER)
end

-----------------------------------------------------------------------------------
--- Main()
-----------------------------------------------------------------------------------
-- to be able to run this script inside another context
if (iup.MainLoopLevel()==0) then
  Start()
  iup.MainLoop()
  iup.Close()
end

uTranslation:close()