--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                           ACC Race Calculator                                 *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
require("iuplua")
require("Libs.libJson")

-----------------------------------------------------------------------------------
--- Driver
-----------------------------------------------------------------------------------
local tDriver = {}

-----------------------------------------------------------------------------------
--- dlgEnterName()
-----------------------------------------------------------------------------------
---
local function dlgEnterName(i)
  local tname = iup.text {value = "Fahrer" .. tostring(i)}
  local btnOk = iup.button{
    size  = 50,
    title = "OK"
  }
  local btnCancel = iup.button {
    size  = 50,
    title = "Abbrechen"
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
    title = "Name eingeben",
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
    iup.Message("@ERROR","Maximale Anzahl an Fahrern erreicht.")
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
  local lDrivers = {
    driver1 = iup.label {
      title = "tDriver[1]",
      visible = "NO",
    },
    driver2 = iup.label {
      title = "tDriver[2]",
      visible = "NO"
    },
    driver3 = iup.label {
      title = "tDriver[3]",
      visible = "NO"
    },
    driver4 = iup.label {
      title = "tDriver[4]",
      visible = "NO"
    },
    driver5 = iup.label {
      title = "tDriver[5]",
      visible = "NO"
    },
    driver6 = iup.label {
      title = "tDriver[6]",
      visible = "NO"
    }
  }

  -- txtFields
  local txtDrivers = {
    driver1 = iup.text {value = "Zeit", visible = "NO"},
    driver2 = iup.text {value = "Zeit", visible = "NO"},
    driver3 = iup.text {value = "Zeit", visible = "NO"},
    driver4 = iup.text {value = "Zeit", visible = "NO"},
    driver5 = iup.text {value = "Zeit", visible = "NO"},
    driver6 = iup.text {value = "Zeit", visible = "NO"}
  }

  local txtConsumption = {
    driver1 = iup.text {value = "Verbrauch", visible = "NO"},
    driver2 = iup.text {value = "Verbrauch", visible = "NO"},
    driver3 = iup.text {value = "Verbrauch", visible = "NO"},
    driver4 = iup.text {value = "Verbrauch", visible = "NO"},
    driver5 = iup.text {value = "Verbrauch", visible = "NO"},
    driver6 = iup.text {value = "Verbrauch", visible = "NO"}
  }

  -- Buttons
  local btnAddDriver = iup.button{
    size      = 70,
    title     = "@ADD_DRIVER",
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

  function button:action()
    -- Exits the main loop

    --todo vorher noch Daten in .json File schreiben!
    return iup.CLOSE
  end

  local box = iup.vbox {
    iup.hbox {
      iup.vbox {lDrivers.driver1, txtDrivers.driver1, txtConsumption.driver1},
      iup.vbox {lDrivers.driver2, txtDrivers.driver2, txtConsumption.driver2},
      iup.vbox {lDrivers.driver3, txtDrivers.driver3, txtConsumption.driver3},
      iup.vbox {lDrivers.driver4, txtDrivers.driver4, txtConsumption.driver4},
      iup.vbox {lDrivers.driver5, txtDrivers.driver5, txtConsumption.driver5},
      iup.vbox {lDrivers.driver6, txtDrivers.driver6, txtConsumption.driver6},
      btnAddDriver,
    },
    iup.hbox {
      btnRefresh,
      button
    },
    alignment = "acenter",
    gap = "10",
    margin = "10x10"
  }
  local dlg = iup.dialog{
    box,
    title = "ACC Race Calculator"
  }

  function btnRefresh:action()
  end

  function btnAddDriver:action()
    AddDriver()

    for i = 1, 6 do
      print(tDriver[i])
      if tDriver[i] ~= nil then
      lDrivers["driver" .. i].title = GetDriverName(i)
      lDrivers["driver" .. i].visible = "YES"
      txtDrivers["driver" .. i].visible = "YES"
      txtConsumption["driver" .. i].visible = "YES"
      end
    end
    -- for k, v in pairs(lDrivers) do
      -- print(k, v)
      -- 
    -- end
  end

  dlg:showxy(iup.CENTER,iup.CENTER)
end

-- to be able to run this script inside another context
if (iup.MainLoopLevel()==0) then
  Start()
  iup.MainLoop()
  iup.Close()
end
