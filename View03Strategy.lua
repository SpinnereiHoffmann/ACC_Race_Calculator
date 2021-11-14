--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                               View03Strategy.lua                              *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local View = {}
local Controller = require("Controller")

------------------------------------------------------------------------------------
--- tables
------------------------------------------------------------------------------------
local tOptions = Controller.Read("options")
local nLanguage = tOptions.language.value

local tTranslation = Controller.Read("translation")
local valTranslation = tTranslation.languages[nLanguage]

local tData = {}
if tOptions.sFilename ~= nil then
  tData = Controller.Read(tOptions.sFilename)
end

------------------------------------------------------------------------------------
--- GetLimitationDialog()
------------------------------------------------------------------------------------
---
local function GetLimitationDialog(limValue)

  -- labels
  local lblStintLength = iup.label {title = valTranslation.STINT}
  local lblStintHours = iup.label {title = valTranslation.HOURS}
  local lblStintMinutes = iup.label {title = valTranslation.MINUTES}

  local lblFuelAmount = iup.label {title = valTranslation.FUEL}

  -- txtFields
  local txtStintH = iup.text {
    value = 00,
    size = 15,
    alignment = "acenter"
  }
  local txtStintM = iup.text {
    value = 00,
    size = 15,
    alignment = "acenter"
  }

  local txtFuel = iup.text {
    value = 60,
    size = 20,
    alignment = "acenter"
  }

  local limitation
  if limValue == "1" then
    limitation = iup.vbox {
      lblStintLength,
      iup.hbox {
        iup.vbox {
          lblStintHours,
          txtStintH
        },
        iup.vbox {
          lblStintMinutes,
          txtStintM
        }
      },
      iup.fill {}
    }
  elseif limValue == "2" then
    limitation = iup.vbox {
      lblFuelAmount,
      iup.space {size = "0x18"},
      txtFuel,
      iup.fill {}
    }
  end

  return limitation
end
------------------------------------------------------------------------------------
--- Main()
------------------------------------------------------------------------------------
---
-- labels
local lblRacestart = iup.label {title = valTranslation.RACE_START}
local lblHours = iup.label {title = valTranslation.HOUR}
local lblMinutes = iup.label {title = valTranslation.MINUTE}

local lblRaceDuration = iup.label {title = valTranslation.DURATION}
local lblDurationHours = iup.label {title = valTranslation.HOURS}
local lblDurationMinutes = iup.label {title = valTranslation.MINUTES}

local lblLimitation = iup.label {title = valTranslation.LIMITATION}

-- dropdown
local dropStintLimit = iup.list {
  valTranslation.STINT_TIME,
  valTranslation.FUEL,
  value = tData.dLimitation,
  dropdown = "YES",
  visible_items = 4,
  size = 80
}

-- textboxes
local txtRacestartH = iup.text {
  value = 00,
  size = 15,
  alignment = "acenter"
}
local txtRacestartM = iup.text {
  value = 00,
  size = 15,
  alignment = "acenter"
}
local txtDurationH = iup.text {
  value = 00,
  size = 15,
  alignment = "acenter"
}
local txtDurationM = iup.text {
  value = 00,
  size = 15,
  alignment = "acenter"
}

View = iup.hbox {
  iup.vbox {
    lblRacestart,
    iup.hbox {
      iup.vbox {
        lblHours,
        txtRacestartH,
      },
      iup.vbox {
        lblMinutes,
        txtRacestartM
      },
    },
    iup.fill {}
  },
  iup.space {size = 25},
  iup.vbox {
    lblRaceDuration,
    iup.hbox {
      iup.vbox {
        lblDurationHours,
        txtDurationH,
      },
        iup.vbox {
        lblDurationMinutes,
        txtDurationM
      },
    },
    iup.fill {}
  },
  iup.fill {},
  iup.vbox {
    lblLimitation,
    iup.space {size = "0x18"},
    dropStintLimit,
    iup.fill {},
  },
  iup.space {size = 25},
  GetLimitationDialog(tData.dLimitation),
  alignment = "acenter",
  gap = "0",
  margin = "5x10",
}

function dropStintLimit:valuechanged_cb()
  tData.dLimitation = dropStintLimit.value
  Controller.Write(tData, tOptions.sFilename)
end

return View