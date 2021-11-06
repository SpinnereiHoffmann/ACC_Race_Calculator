--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                                 View01Main.lua                                *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
require("iuplua")
local json = require("Libs.libJson")
local Controller = require("Controller")

local CommonView = require("View02Common")
local StrategyView = require("View03Strategy")
local View = {}

-------------------------------------------------------------------------------
--- file-tables
-------------------------------------------------------------------------------
local tOptions = Controller.Read("options")
local nLanguage = tOptions.language.value

local tTranslation = Controller.Read("translation")
local valTranslation = tTranslation.languages[nLanguage]

local tDriver = Controller.Read("driver")

if tOptions.filename ~= nil and tOptions.filename ~= "" then
  local tData = Controller.Read(tOptions.filename)
else
  local tData = {}
end

------------------------------------------------------------------------------------
--- Common()
------------------------------------------------------------------------------------
local function Common()

  -- label
  local lblFilename = iup.label {
    title = "Springfield Racetrack",
    alignment = "acenter"
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

  -- Buttons
  local btnLoadFile = iup.button {
    title = valTranslation.LOAD_FILE,
    size = 60
  }

  local btnSaveFile = iup.button {
    title = valTranslation.SAVE_FILE,
    size = 60
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
    for k, v in pairs(tDriver) do
      print(k, v)
    end
    return iup.CLOSE
  end

  local box = iup.hbox {
    btnLoadFile,
    btnSaveFile,
    iup.fill {},
    btnRefresh,
    button,
    alignment = "acenter",
    gap = "10",
    margin = "10x10",
  }
  local tabCommon = CommonView
  tabCommon.tabtitle = valTranslation.COMMON

  local tabStrategy = StrategyView
  tabStrategy.tabtitle = valTranslation.STRATEGY

  local tabs = iup.vbox {
    iup.hbox {
      iup.fill {},
      lblFilename,
      iup.fill {},
      dropLang
    },
    iup.tabs {
      tabCommon,
      tabStrategy
    },
    box
  }

  local dlg = iup.dialog {
    tabs,
    box,
    title = "ACC Race Calculator",
    DEFAULTESC = button
  }

  function btnSaveFile:action()
    local dlg = iup.filedlg {
      dialogtype = "SAVE",
      title = valTranslation.SAVE_FILE,
      filter = "*.json",
      filterinfo = valTranslation.JSON_FILES,
      directory = "c:\\users\\steff\\documents\\Events",
      value = ""
    }
    dlg:popup(iup.ANYWHERE, iup.ANYWHERE)
    local status = dlg.status
    local name = dlg.value
    if status == "1" then
      -- write table to file
      if string.find(dlg.value, ".json") then
        name = string.sub(dlg.value, 0, -6)
      else
        name = dlg.value
      end
      Controller.Write(tDriver, name)
      tOptions.filename = name
      Controller.Write(tOptions, "options")
    elseif status == "0" then
      name = string.sub(dlg.value, 0, -6)
      Controller.Write(tDriver, name)
      tOptions.filename = name
      Controller.Write(tOptions, "options")
    elseif status == "-1" then
      -- do nothing
    end
  end

  function btnLoadFile:action()
    local dlg = iup.filedlg {
      dialogtype = "LOAD",
      title = valTranslation.LOAD_FILE,
      filter = "*.json",
      filterinfo = valTranslation.JSON_FILES,
      directory = "c:\\users\\steff\\documents"
    }
    dlg:popup (iup.ANYWHERE, iup.ANYWHERE)
    local status = dlg.status
    if status == "1" then 
      iup.Message("New file", dlg.value)
    elseif status == "0" then
      iup.Message("File already exists", dlg.value)
    elseif status == "-1" then 
      iup.Message("IupFileDlg","Operation canceled")
    end
  end

  function btnRefresh:action()
    -- iup.SetAttribute(dlg, "SIZE", 800)
    -- iup.Refresh(dlg)

    -- iup.SetAttribute(dlg, "SIZE", 800)
    -- iup.Map(dlg)
    -- iup.Refresh(dlg)
    -- iup.Redraw(dlg,0)
  end

  function dropLang:valuechanged_cb()
    tOptions.language.value = dropLang.value
    Controller.Write(tOptions, "options")

    -- btnRemoveDriver.driver1.value = "something"
    -- print(btnRemoveDriver.driver1.value)
    -- iup.SetAttribute(dlg, "SIZE", 800)
    -- iup.Message(valTranslation.INFORMATION ,valTranslation.REBOOT)
    -- iup.Update(dlg)
    -- iup.Refresh(dlg)
    -- iup.Redraw(dlg, 1)
  end

  dlg:showxy(iup.CENTER,iup.CENTER)
end

------------------------------------------------------------------------------------
--- StartDialog()
------------------------------------------------------------------------------------
---
function View.Dialog(tDriver)
  if (iup.MainLoopLevel()==0) then
    Common(tDriver)
    iup.MainLoop()
    iup.Close()
  end
end

return View