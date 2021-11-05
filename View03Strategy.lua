--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
--*                               View03Strategy.lua                              *
--* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
local View = {}
local Controller = require("Controller")

------------------------------------------------------------------------------------
--- Main()
------------------------------------------------------------------------------------
---
local tOptions = Controller.Read("options")
local nLanguage = tOptions.language.value

local tTranslation = Controller.Read("translation")
local valTranslation = tTranslation.languages[nLanguage]

if tOptions.sFilename ~= nil then
  local tData = Controller.Read(tOptions.sFilename)
else
  local tData = {}
end

-- labels
local lblRacestart = iup.label {title = valTranslation.RACE_START}
local lblHours = iup.label {title = valTranslation.HOUR}
local lblMinutes = iup.label {title = valTranslation.MINUTE}

local lblRaceDuration = iup.label {title = valTranslation.DURATION}
local lblDurationHours = iup.label {title = valTranslation.HOURS}
local lblDurationMinutes = iup.label {title = valTranslation.MINUTES}

local lblStintLength = iup.label {title = valTranslation.STINT}
local lblStintHours = iup.label {title = valTranslation.HOURS}
local lblStintMinutes = iup.label {title = valTranslation.MINUTES}

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
  },
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
  },
  iup.vbox {
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
    }
  },
  alignment = "acenter",
  gap = "10",
  margin = "10x10",
}

return View