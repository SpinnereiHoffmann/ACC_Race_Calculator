using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    // Felder
    string  version = "0.0.3";
    bool    local   = false;

    List<Driver>  drivers   = new List<Driver>();
    List<Pitstop> pitstops  = new List<Pitstop>();
    List<Stint>   stints    = new List<Stint>();

    class Driver
    {
      public double nStints { get; set; }
      public string Counter { get; set; }
      public string Name    { get; set; }
      public string Mins    { get; set; }
      public string Secs    { get; set; }
      public string Thos    { get; set; }
      public string Cons    { get; set; }
      public double firstStintLaps    { get; set; }
      public double firstStintMins    { get; set; }
      public double firstStintFuel    { get; set; }
      public double regularStintLaps  { get; set; }
      public double regularStintMins  { get; set; }
      public double regularStintFuel  { get; set; }
      public double lastStintLaps     { get; set; }
      public double lastStintMins     { get; set; }
      public double lastStintFuel     { get; set; }
      public double totalMins         { get; set; }
      public double DriverDuration    { get; set; }
    }

    class Pitstop
    {
      public string counter { get; set; }
      public string name    { get; set; }
      public string seconds { get; set; }
    }

    class Stint
    {
      public string Counter         { get; set; }
      public string StartH          { get; set; }
      public string StartM          { get; set; }
      public int    Inlap           { get; set; }
      public string Temp            { get; set; }
      public string PressureFL      { get; set; }
      public string PressureFR      { get; set; }
      public string PressureRL      { get; set; }
      public string PressureRR      { get; set; }
      public string StintLength     { get; set; }
      public string StintFuel       { get; set; }
      public string StintLaps       { get; set; }
      public string Driver          { get; set; }
      public string Spotter         { get; set; }
      public string PitDescription  { get; set; }
      public double PitTime         { get; set; }
    }

    // helpers
    private string GetText(string driver, TextBox box, string key)
    {
      XmlReader xmlRead = XmlReader.Create(GetFilename());

      if (xmlRead.ReadToDescendant(key, driver))
        box.Text = xmlRead.ReadElementString();

      xmlRead.Close();

      return box.Text;
    }

    private string GetLaps(int stint, Label label, int index)
    {
      if (stint == 1)
        label.Text = drivers[index].firstStintLaps.ToString();
      else
        label.Text = drivers[index].regularStintLaps.ToString();
      return label.Text;
    }

    private string GetFuel(int stint, Label label, int index)
    {
      if (stint == 1)
        label.Text = drivers[index].firstStintFuel.ToString();
      else
        label.Text = drivers[index].regularStintFuel.ToString();
      return label.Text;
    }

    private string GetDuration(int stint, Label label, int index)
    {
      if (stint == 1)
      {
        double seconds = Math.Round((drivers[index].firstStintMins - Math.Truncate(drivers[index].firstStintMins)) * 60);
        label.Text = Convert.ToString(Math.Truncate(drivers[index].firstStintMins)) + ":" + seconds.ToString();
      }
      else
      {
        double seconds = Math.Round((drivers[index].regularStintMins - Math.Truncate(drivers[index].regularStintMins)) * 60);
        label.Text = Convert.ToString(Math.Truncate(drivers[index].regularStintMins)) + ":" + seconds.ToString();
      }
      return label.Text;
    }

    private void CreateStintbox(int stint, int posY, string timeH, string timeM)
    {
      GroupBox stintbox = new GroupBox
      {
        Name = "Stint" + Convert.ToString(stint),
        Text = "Stint" + Convert.ToString(stint+1),
        Size = new Size(455, 100),
        Anchor = AnchorStyles.Left | AnchorStyles.Top,
        Location = new Point(5, 100 * (posY))
      };

      TextBox clockH = new TextBox
      {
        Name = "clockH" + stint.ToString(),
        Text = timeH,
        Size = new Size(25, 20),
        Location = new Point(5,30)
      };
      if (GetText(Convert.ToString(stint + 1), clockH, "startH") != "00")
        clockH.Text = GetText(Convert.ToString(stint + 1), clockH, "startH");
      else
        clockH.Text = timeH;
      //clockH.TextChanged += DynClockH_TextChanged;
      clockH.Leave += DynClockH_Leave;

      Label seperator = new Label
      {
        Name = "seperator" + stint.ToString(),
        Text = ":",
        Size = new Size(10, 20),
        Location = new Point(30, 33)
      };

      TextBox clockM = new TextBox
      {
        Name = "clockM" + stint.ToString(),
        Text = timeM,
        Size = new Size(25, 20),
        Location = new Point(40, 30)
      };
      clockM.Text = GetText(Convert.ToString(stint + 1), clockM, "startM");
      clockM.Text = CheckZero(clockM);
      //clockH.TextChanged += DynClockM_TextChanged;

      Label time = new Label
      {
        Name = "time" + stint.ToString(),
        Text = "Uhr",
        Size = new Size(30, 20),
        Location = new Point(65, 34)
      };

      TextBox inlap = new TextBox
      {
        Name = "inlap" + stint.ToString(),
        Text = stints[stint].Inlap.ToString(),
        Size = new Size(30, 20),
        Location = new Point(5, 55)
      };
      inlap.Text = GetText(Convert.ToString(stint + 1), inlap, "inlap");
      //clockH.TextChanged += DynClockH_TextChanged;

      Label labelInlap = new Label
      {
        Name = "labelInlap" + stint.ToString(),
        Text = "Inlap",
        Size = new Size(40, 20),
        Location = new Point(35, 59)
      };

      Label labelTemp = new Label
      {
        Name = "labelTemp" + stint.ToString(),
        Text = "Temp",
        Size = new Size(35, 20),
        Location = new Point(100, 14)
      };

      TextBox temp = new TextBox
      {
        Name = "temp" + stint.ToString(),
        Text = "20/20",
        Size = new Size(45, 20),
        Location = new Point(135, 10)
      };

      TextBox psiFL = new TextBox
      {
        Name = "psiFL" + stint.ToString(),
        Text = "VL",
        Size = new Size(30, 20),
        Location = new Point(100, 35)
      };

      TextBox psiFR = new TextBox
      {
        Name = "psiFR" + stint.ToString(),
        Text = "VR",
        Size = new Size(30, 20),
        Location = new Point(150, 35)
      };

      Label labelPsi = new Label
      {
        Name = "labelPsi" + stint.ToString(),
        Text = "psi",
        Size = new Size(30, 20),
        Location = new Point(130, 55)
      };

      TextBox psiRL = new TextBox
      {
        Name = "psiRL" + stint.ToString(),
        Text = "HL",
        Size = new Size(30, 20),
        Location = new Point(100, 70)
      };

      TextBox psiRR = new TextBox
      {
        Name = "psiRR" + stint.ToString(),
        Text = "HR",
        Size = new Size(30, 20),
        Location = new Point(150, 70)
      };

      Label labelDuration = new Label
      {
        Name = "labelDuration" + stint.ToString(),
        Text = "Stintlänge:   " + stints[stint].StintLength + " min",
        Size = new Size(120, 20),
        Location = new Point(200, 20)
      };

      Label labelFuel = new Label
      {
        Name = "labelFuel" + stint.ToString(),
        Text = "Spritmenge: " + stints[stint].StintFuel + " l",
        Size = new Size(120, 20),
        Location = new Point(200, 45)
      };

      Label labelLaps = new Label
      {
        Name = "labelLaps" + stint.ToString(),
        Text = "Runden:       " + stints[stint].StintLaps,
        Size = new Size(120, 20),
        Location = new Point(200, 70)
      };

      Label labelDriver = new Label
      {
        Name = "labelDriver" + stint.ToString(),
        Text = "Fahrer",
        Size = new Size(45, 20),
        Location = new Point(325, 20)
      };

      ComboBox driver = new ComboBox
      {
        Name = "comboBoxDriver" + stint.ToString(),
        Size = new Size(80, 20),
        Location = new Point(370, 16)
      };
      foreach (Driver elements in drivers)
        driver.Items.Add(elements.Name);
      if (driver.Items.Count > 0)
      {
        driver.SelectedIndex = 0;
        //drivers[0].totalMins += drivers[0].firstStintMins;
      }
      //driver.SelectedValueChanged += DynDriver_SelectedValueChanged;


      Label labelSpotter = new Label
      {
        Name = "labelSpotter" + stint.ToString(),
        Text = "Spotter",
        Size = new Size(45, 20),
        Location = new Point(325, 45)
      };

      ComboBox spotter = new ComboBox
      {
        Name = "comboBoxSpotter" + stint.ToString(),
        Size = new Size(80, 20),
        Location = new Point(370, 41),
      };
      foreach (Driver elements in drivers)
        spotter.Items.Add(elements.Name);
      if (driver.Items.Count > 1)
        spotter.SelectedIndex = 1;

      Label labelPitstop = new Label
      {
        Name = "labelPitstop" + stint.ToString(),
        Text = "Pitstopp",
        Size = new Size(45, 20),
        Location = new Point(325, 70)
      };

      Label labelStint = new Label
      {
        Name = "labelStint" + stint.ToString(),
        Text = (stint + 1).ToString() + "." + driver.Text + "/" + spotter.Text + " " + clockH.Text.ToString() + ":" + clockM.Text.ToString(),
        Size = new Size(128, 20),
        Location = new Point(5, 25 * (posY))
      };

      ComboBox pitstop = new ComboBox
      {
        Name = "comboBoxPitstop" + stint.ToString(),
        Size = new Size(80, 20),
        Location = new Point(370, 66)
      };
      foreach (Pitstop elements in pitstops)
        pitstop.Items.Add(elements.name);
      if (pitstop.Items.Count > 0)
        pitstop.SelectedIndex = 0;
      //pitstop.SelectedValueChanged += Pitstop_SelectedValueChanged;

      string CheckZero(TextBox clock)
      {
        if (clock.Text == "0")
          clock.Text = "00";
        else if (clock.Text != "00" && Convert.ToInt32(clock.Text) < 10)
          clock.Text = "0" + clock.Text;
        return clock.Text;
      }

      void DynClockH_TextChanged(object dynSender, EventArgs dynE)
      {
        int txtH = Convert.ToInt32(clockH.Name.Substring(6));
        stints[txtH].StartH = clockH.Text;
      }

      void DynClockH_Leave(object dynSender, EventArgs dynE)
      {
        int txtH = Convert.ToInt32(clockH.Name.Substring(6));
        MessageBox.Show(clockH.Name.ToString());
        stints[txtH].StartH = clockH.Text;
        //buttonCalculate_Click(dynSender, dynE);
      }

      void DynDriver_SelectedValueChanged(object dynSender, EventArgs dynE)
      {
        if (stint == 1)
        {
          //inlap.Text = GetText(inlap)
          //name.Text = GetText(name.Name, name, "name");
          //TextBox inlapN = "inlap" + stint.ToString();
        }
      }

      panelStints.Controls.Add(stintbox);
      panel1.Controls.Add(labelStint);
      stintbox.Controls.Add(clockH);
      stintbox.Controls.Add(seperator);
      stintbox.Controls.Add(clockM);
      stintbox.Controls.Add(time);
      stintbox.Controls.Add(inlap);
      stintbox.Controls.Add(labelInlap);
      stintbox.Controls.Add(labelTemp);
      stintbox.Controls.Add(temp);
      stintbox.Controls.Add(psiFL);
      stintbox.Controls.Add(psiFR);
      stintbox.Controls.Add(labelPsi);
      stintbox.Controls.Add(psiRL);
      stintbox.Controls.Add(psiRR);
      stintbox.Controls.Add(labelDuration);
      stintbox.Controls.Add(labelLaps);
      stintbox.Controls.Add(labelFuel);
      stintbox.Controls.Add(labelDriver);
      stintbox.Controls.Add(driver);
      stintbox.Controls.Add(labelSpotter);
      stintbox.Controls.Add(spotter);
      stintbox.Controls.Add(labelPitstop);
      stintbox.Controls.Add(pitstop);
    }

    private void Pitstop_SelectedValueChanged(object sender, EventArgs e)
    {
      //pitstop = Pitstop[nDriver]
    }

    private void ReloadForm(object sender, EventArgs e)
    {
      labelVersion.Text = "Version: ";
      
      // foreach driver
      int nDrivers = 0;
      foreach (Driver element in drivers)
        nDrivers++;

      while (nDrivers > 0)
      {
        buttonRemoveDriver_Click(sender, e);
        nDrivers--;
      }

      // foreach pitstop
      int nPitstops = 0;
      foreach (Pitstop element in pitstops)
        nPitstops++;
      while (nPitstops > 0)
      {
        buttonRemovePitstop_Click(sender, e);
        nPitstops--;
      }

      SetWindowSizeAndPosition();
      Form1_Load(sender, e);
    }

    private void SetWindowSizeAndPosition()
    {
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        // set window size and position
        regKey.SetValue("Top", Convert.ToString(this.Top));
        regKey.SetValue("Left", Convert.ToString(this.Left));
        regKey.SetValue("Height", Convert.ToString(this.Height));
        regKey.SetValue("Width", Convert.ToString(this.Width));
      }
    }

  private string GetFilename()
    {
      string filename;

      using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\ACC-RC"))
      {
        string gPath = Convert.ToString(regKey.GetValue("GlobalPath"));
        string lPath = Convert.ToString(regKey.GetValue("LocalPath"));
        string track = Convert.ToString(regKey.GetValue("Track"));
        string duration = Convert.ToString(regKey.GetValue("Duration"));
        filename = gPath + track + duration + ".xml";
        
        if (local)
          filename = lPath + track + duration + ".xml";
      }
      
      return filename;
    }

    private void WriteToXML()
    {
      string track = comboBoxTracks.Text;
      track = track.Replace(" ", "_");
      // die Einstellungen für XmlWriter setzen
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;

      // eine Instanz von XmlWriter erzeugen und die Datei anlegen
      XmlWriter xmlWrite = XmlWriter.Create(GetFilename(), settings);

      // die Deklaration schreiben
      xmlWrite.WriteStartDocument();

      // den Wurzelknoten erstellen
      xmlWrite.WriteStartElement(track);

      int i = 0;
      foreach(Driver driver in drivers)
      {
        // einen Eintrag erstellen
        xmlWrite.WriteStartElement("Fahrer", drivers[i].Counter);

        // einen Namen mit Wert schreiben
        xmlWrite.WriteElementString("name", drivers[i].Name);
        xmlWrite.WriteElementString("minutes", drivers[i].Mins);
        xmlWrite.WriteElementString("seconds", drivers[i].Secs);
        xmlWrite.WriteElementString("thousands", drivers[i].Thos);
        xmlWrite.WriteElementString("consumption", drivers[i].Cons);

        // den Eintrag abschließen
        xmlWrite.WriteEndElement();
        
        i++;
      }

      xmlWrite.WriteStartElement("duration");
      xmlWrite.WriteElementString("hours", textBoxDurationHours.Text);
      xmlWrite.WriteElementString("mins", textBoxDurationMins.Text);
      xmlWrite.WriteElementString("limitation", comboBox1.Text);
      xmlWrite.WriteElementString("fuelQuantity", textBoxFuelQuantity.Text);
      xmlWrite.WriteElementString("stintTime", textBoxStintTime.Text);
      xmlWrite.WriteEndElement();

      int pitIndex = 0;
      foreach(Pitstop pitstop in pitstops)
      {
        xmlWrite.WriteStartElement("pitstops", pitstops[pitIndex].counter);

        xmlWrite.WriteElementString("description", pitstops[pitIndex].name);
        xmlWrite.WriteElementString("seconds", pitstops[pitIndex].seconds);

        xmlWrite.WriteEndElement();
        pitIndex++;
      }

      // Racestart
      xmlWrite.WriteStartElement("racestart");
      xmlWrite.WriteElementString("startH", textBoxStartHour.Text);
      xmlWrite.WriteElementString("startM", textBoxStartMin.Text);
      xmlWrite.WriteEndElement();

      int stintIndex = 0;
      foreach (Stint stint in stints)
      {
        xmlWrite.WriteStartElement("stints", stints[stintIndex].Counter);
        xmlWrite.WriteElementString("startH", stints[stintIndex].StartH);
        xmlWrite.WriteElementString("startM", stints[stintIndex].StartM);
        xmlWrite.WriteElementString("inlap",  stints[stintIndex].Inlap.ToString());
        xmlWrite.WriteElementString("temp", stints[stintIndex].Temp);
        xmlWrite.WriteElementString("pressureVL", stints[stintIndex].PressureFL);
        xmlWrite.WriteElementString("pressureVR", stints[stintIndex].PressureFR);
        xmlWrite.WriteElementString("pressureRL", stints[stintIndex].PressureRL);
        xmlWrite.WriteElementString("pressureRR", stints[stintIndex].PressureRR);
        xmlWrite.WriteElementString("stintLength", stints[stintIndex].StintLength);
        xmlWrite.WriteElementString("stintFuel", stints[stintIndex].StintFuel);
        xmlWrite.WriteElementString("stintLaps", stints[stintIndex].StintLaps);
        xmlWrite.WriteElementString("driver", stints[stintIndex].Driver);
        xmlWrite.WriteElementString("spotter", stints[stintIndex].Spotter);
        xmlWrite.WriteElementString("pitDescription", stints[stintIndex].PitDescription);
        xmlWrite.WriteElementString("pitTime", stints[stintIndex].PitTime.ToString());

        xmlWrite.WriteEndElement();
        stintIndex++;
      }

      // den Wurzelknoten abschließen
      xmlWrite.WriteEndElement();

      // das gesamte Dokument schließen
      xmlWrite.WriteEndDocument();

      // die Datei schließen
      // erst jetzt werden die Daten auch tatsächlich geschrieben
      xmlWrite.Close();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\ACC-RC"))
      {

        labelVersion.Text += version;

        if (regKey == null)
        {
          comboBoxTracks.Text = "";
        }
        else
        {
          // get position of the window
          this.Top    = Convert.ToInt32(regKey.GetValue("Top"));
          this.Left   = Convert.ToInt32(regKey.GetValue("Left"));
          this.Height = Convert.ToInt32(regKey.GetValue("Height"));
          this.Width  = Convert.ToInt32(regKey.GetValue("Width"));

          // get latest values
          comboBoxTracks.Text     = Convert.ToString(regKey.GetValue("Track"));
          textBoxTimerSek.Text    = Convert.ToString(regKey.GetValue("Timer"));
          textBoxLocalPath.Text   = Convert.ToString(regKey.GetValue("LocalPath"));
          textBoxGlobalPath.Text  = Convert.ToString(regKey.GetValue("GlobalPath"));

          //prüfen, ob es die Datei bereits gibt
          bool xmlVorhanden = System.IO.File.Exists(GetFilename());

          // open .xml file
          if (xmlVorhanden == false)
          {
            // wenn nicht, verlassen wir die Methode direkt wieder
            //MessageBox.Show("Datei nicht vorhanden");
            return;
          }
          else
          {
            XmlReader xmlRead = XmlReader.Create(GetFilename());

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlRead);

            // foreach driver
            foreach(var fahrer in doc.GetElementsByTagName("Fahrer").OfType<XmlElement>())
            {
              buttonAddDriver_Click(sender, e);
            }

            // for racedata
            XmlReader raceData = XmlReader.Create(GetFilename());
            
            raceData.ReadToFollowing("hours");
            textBoxDurationHours.Text = raceData.ReadElementString();

            raceData.ReadToFollowing("mins");
            textBoxDurationMins.Text = raceData.ReadElementString();

            raceData.ReadToFollowing("limitation");
            comboBox1.Text = raceData.ReadElementString();

            raceData.ReadToFollowing("fuelQuantity");
            textBoxFuelQuantity.Text = raceData.ReadElementString();

            raceData.ReadToFollowing("stintTime");
            textBoxStintTime.Text = raceData.ReadElementString();

            raceData.Close();
            //xmlRead.    

            // foreach pitstop
            foreach (var pitstop in doc.GetElementsByTagName("pitstops").OfType<XmlElement>())
              buttonAddPitstop_Click(sender, e);

            // for stint data
            textBoxStartHour.Text = "12";
            textBoxStartMin.Text = "00";

            xmlRead.Close();
          }
        }
      }
    }

    private void comboBoxTracks_SelectedValueChanged(object sender, EventArgs e)
    {
      // set registry keys
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        regKey.SetValue("Track", comboBoxTracks.Text);
      }
    }

    private void buttonWrite_Click(object sender, EventArgs e)
    {
      string duration = "";

      if (textBoxDurationHours.Text != "hh" && Convert.ToInt32(textBoxDurationHours.Text) != 0)
        duration = textBoxDurationHours.Text.ToString() + "h";
      if (textBoxDurationMins.Text != "mm" && Convert.ToInt32(textBoxDurationMins.Text) != 0)
        duration += textBoxDurationMins.Text.ToString() + "min";
      
      // write Duration to registry
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        regKey.SetValue("Duration", duration.ToString());
      }

      local = true;
      WriteToXML();
      
      local = false;
      WriteToXML();
    }

    private void textBoxLocalPath_TextChanged(object sender, EventArgs e)
    {
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        regKey.SetValue("LocalPath", textBoxLocalPath.Text);
      }
    }

    private void textBoxGlobalPath_TextChanged(object sender, EventArgs e)
    {
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        regKey.SetValue("GlobalPath", textBoxGlobalPath.Text);
      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      SetWindowSizeAndPosition();
    }

    int driverCount = 1;
    int driverPosX  = 0;
    private void buttonAddDriver_Click(object sender, EventArgs e)
    {
      GroupBox groupDriver = new GroupBox()
      {
        Name = driverCount.ToString(),
        Size = new Size(100, 100),
        Location = new Point(100 * (driverPosX + 1), 10),
      };

      TextBox name = new TextBox
      {
        Text = "Name",
        Name = "Fahrer" + driverCount.ToString(),
        Size = new Size(90, 20),
        Location = new Point(5, 10),
      };
      name.Text = GetText(name.Name, name, "name");
      name.TextChanged += DynName_TextChanged;

      TextBox timeMin = new TextBox
      {
        Name = "timeMin" + driverCount.ToString(),
        Text = "m",
        Size = new Size(15, 20),
        Location = new Point(5, 35)
      };
      timeMin.Text = GetText(name.Name, timeMin, "minutes");
      timeMin.TextChanged += DynTimeMin_TextChanged;

      TextBox timeSec = new TextBox
      {
        Name = "timeSec" + driverCount.ToString(),
        Text = "ss",
        Size = new Size(20, 20),
        Location = new Point(20, 35)
      };
      timeSec.Text = GetText(name.Name, timeSec, "seconds");
      timeSec.TextChanged += DynTimeSec_TextChanged;

      TextBox timeTho = new TextBox
      {
        Name = "timeTho" + driverCount.ToString(),
        Text = "ttt",
        Size = new Size(25, 20),
        Location = new Point(40, 35)
      };
      timeTho.Text = GetText(name.Name, timeTho, "thousands");
      timeTho.TextChanged += DynTimeTho_TextChanged;

      TextBox consumption = new TextBox
      {
        Name = "consumption" + driverCount.ToString(),
        Text = "l/lap",
        Size = new Size(30, 20),
        Location = new Point(65, 35)
      };
      consumption.Text = GetText(name.Name, consumption, "consumption");
      consumption.TextChanged += DynConsumption_TextChanged;

      // erstelle einen neuen Fahrer
      drivers.Add(new Driver() { 
        Counter = name.Name,
        Name = name.Text,
        Mins = timeMin.Text,
        Secs = timeSec.Text,
        Thos = timeTho.Text,
        Cons = consumption.Text
      });

      void DynName_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(name.Name.Substring(6));
        drivers[groupBox-1].Name = name.Text;
      }

      void DynTimeMin_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(name.Name.Substring(6));
        drivers[groupBox - 1].Mins = timeMin.Text;
      }

      void DynTimeSec_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(name.Name.Substring(6));
        drivers[groupBox - 1].Secs = timeSec.Text;
      }

      void DynTimeTho_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(name.Name.Substring(6));
        drivers[groupBox - 1].Thos = timeTho.Text;
      }

      void DynConsumption_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(name.Name.Substring(6));
        drivers[groupBox - 1].Cons = consumption.Text;
      }

      driverCount++;
      driverPosX++;

      groupBox3.Controls.Add(groupDriver);
      groupDriver.Controls.Add(name);
      groupDriver.Controls.Add(timeMin);
      groupDriver.Controls.Add(timeSec);
      groupDriver.Controls.Add(timeTho);
      groupDriver.Controls.Add(consumption);
    }

    private void buttonRemoveDriver_Click(object sender, EventArgs e)
    {
      if (drivers.Count > 0)
      {
        drivers.RemoveAt(drivers.Count - 1);
      }

      if (driverCount > 1)
      {
        groupBox3.Controls.RemoveAt(groupBox3.Controls.Count - 1);
        driverCount--;
        driverPosX--;
      }
    }

    int pitIndex  = 0;
    int pitCount  = 1;
    int pitPosY   = 0;
    private void buttonAddPitstop_Click(object sender, EventArgs e)
    {
      TextBox description = new TextBox
      {
        Text = "Kennung",
        Name = "Pit" + pitCount.ToString(),
        Size = new Size(120, 20),
        Location = new Point(100, 25 * (pitPosY + 1))
      };
      description.Text = GetText(description.Name, description, "description");
      description.TextChanged += DynDescription_TextChanged;

      TextBox duration = new TextBox
      {
        Text = "sec",
        Name = "Duration" + pitCount.ToString(),
        Size = new Size(30, 20),
        Location = new Point(220, 25 * (pitPosY + 1))
      };
      duration.Text = GetText(description.Name, duration, "seconds");
      duration.TextChanged += DynDuration_TextChanged;

      // erstelle einen neuen Pitstopp
      pitstops.Add(new Pitstop()
      {
        counter = description.Name,
        name = description.Text,
        seconds = duration.Text,
      });

      void DynDescription_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(description.Name.Substring(3));
        pitstops[groupBox - 1].name = description.Text;
      }

      void DynDuration_TextChanged(object dynSender, EventArgs dynE)
      {
        int groupBox = Convert.ToInt32(description.Name.Substring(3));
        pitstops[groupBox - 1].seconds = duration.Text;
      }

      pitCount++;
      pitPosY++;
      pitIndex += 2;

      groupBox1.Controls.Add(description);
      groupBox1.Controls.Add(duration);
    }

    private void buttonRemovePitstop_Click(object sender, EventArgs e)
    {
      if (pitstops.Count > 0)
      {
        pitstops.RemoveAt(pitstops.Count - 1);
      }

      for (int i = 0; i < 2; i++)
        if (pitIndex >= 2)
          groupBox1.Controls.RemoveAt(pitIndex);

      if (pitIndex >= 2)
      {
        pitCount--;
        pitIndex -= 2;
        pitPosY--;
      }
    }

    private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == 1)
      {
        labelFuelQuantity.Text = "Tankvolumen";
        textBoxStintTime.Enabled = true;
      }
      else
      {
        labelFuelQuantity.Text = "Spritmenge";
        textBoxStintTime.Enabled = false;
      }
    }

    private void buttonOpenLocal_Click(object sender, EventArgs e)
    {
      local = true;
      ReloadForm(sender, e);
    }

    private void buttonOpenGlobal_Click(object sender, EventArgs e)
    {
      local = false;
      ReloadForm(sender, e);
    }

    private string DynTotalStintTime_ChangeText(string name, double duration)
    {
      string label = name + ":    " + duration.ToString();
      return label;
    }

    //int stint = 1;
    int stintboxPosY;
    private void buttonCalculate_Click(object sender, EventArgs e)
    {
      stints.Clear();
      stintboxPosY = 0;
      panelStints.Controls.Clear();
      groupBoxTotalStintTime.Controls.Clear();
      panel1.Controls.Clear();

      // get duration in minutes
      double duration = Convert.ToInt32(textBoxDurationHours.Text) * 60 + Convert.ToInt32(textBoxDurationMins.Text);

      // which stint limitation
      if (comboBox1.SelectedIndex == 0) // Tankvolumen (no stint limitation)
      {
        foreach (Driver driver in drivers)
        {
          // calculate first stint
          // fuelQuantity - consumption ("outlap")
          double fuelQuantity = Convert.ToDouble(textBoxFuelQuantity.Text) - Convert.ToDouble(driver.Cons);

          // use Math.Truncate() to get 3 from 3.98
          driver.firstStintLaps = Math.Truncate(fuelQuantity / Convert.ToDouble(driver.Cons));

          double lapSeconds = Convert.ToDouble(driver.Mins) * 60 + Convert.ToDouble(driver.Secs + "," + driver.Thos);
          driver.firstStintMins = driver.firstStintLaps * lapSeconds / 60;

          driver.firstStintFuel = Math.Truncate((driver.firstStintLaps + 1) * Convert.ToDouble(driver.Cons)) + 1;

          // calculate regular stint
          driver.regularStintLaps = Math.Truncate(Convert.ToDouble(textBoxFuelQuantity.Text) / Convert.ToDouble(driver.Cons));

          lapSeconds = Convert.ToDouble(driver.Mins) * 60 + Convert.ToDouble(driver.Secs + "," + driver.Thos);
          driver.regularStintMins = driver.regularStintLaps * lapSeconds / 60;

          driver.regularStintFuel = Math.Truncate((driver.regularStintLaps) * Convert.ToDouble(driver.Cons)) + 1;
        }
      }
      // else: stinttime
      else
      {
        foreach (Driver driver in drivers)
        {
          double stintTime = Convert.ToDouble(textBoxStintTime.Text);
          driver.nStints = duration / stintTime / drivers.Count();

          // calculate first stint
          double fuelQuantity = Convert.ToDouble(textBoxFuelQuantity.Text) - Convert.ToDouble(driver.Cons);

          double lapSeconds = Convert.ToDouble(driver.Mins) * 60 + Convert.ToDouble(driver.Secs + "," + driver.Thos);
          double stintSeconds = Convert.ToDouble(textBoxStintTime.Text) * 60;
          driver.firstStintLaps = Math.Truncate(stintSeconds / lapSeconds);

          driver.firstStintMins = driver.firstStintLaps * lapSeconds / 60;

          driver.firstStintFuel = Math.Truncate((driver.firstStintLaps + 1) * Convert.ToDouble(driver.Cons)) + 1;

          bool lessFuel = false;

          while (fuelQuantity < driver.firstStintLaps * Convert.ToDouble(driver.Cons))
          {
            if (lessFuel == false)
            {
              MessageBox.Show("Das Tankvolumen reicht nicht aus\n Es werden Runden abgezogen");
              lessFuel = true;
            }
            driver.firstStintLaps--;
            driver.firstStintMins -= lapSeconds / 60;
            driver.firstStintFuel = Math.Truncate((driver.firstStintLaps + 1) * Convert.ToDouble(driver.Cons)) + 1;
          }

          // calculate regular stint
          driver.regularStintLaps = driver.firstStintLaps;
          driver.regularStintMins = driver.firstStintMins;
          driver.regularStintFuel = Math.Truncate((driver.regularStintLaps) * Convert.ToDouble(driver.Cons)) + 1;
        }
      }

      // for first stint
      int nDriver = 0;
      int nStint = 0;

      stints.Add(new Stint()
      {
        Counter = "1",
        StartH = textBoxStartHour.Text.ToString(),
        StartM = textBoxStartMin.Text.ToString(),
        Inlap = Convert.ToInt32(drivers[nDriver].firstStintLaps - 1),
        Temp = "20/20",
        PressureFL = "FL",
        PressureFR = "FR",
        PressureRL = "RL",
        PressureRR = "RR",
        StintLength = Math.Round(drivers[nDriver].firstStintMins, 2).ToString(),
        StintFuel = drivers[nDriver].firstStintFuel.ToString(),
        StintLaps = drivers[nDriver].firstStintLaps.ToString(),
        Driver = drivers[nDriver].Name, // Get Driver
        Spotter = "", // Get Spotter
        PitDescription = pitstops[0].name,
        PitTime = Convert.ToDouble(pitstops[0].seconds) / 60,
      });

      CreateStintbox(nStint, stintboxPosY++, textBoxStartHour.Text, textBoxStartMin.Text);

      double stintWithPit = Convert.ToDouble(stints[nStint].StintLength) + stints[nStint].PitTime;
      duration -= stintWithPit;
      drivers[nDriver].nStints--;
      nStint++;

      foreach (Driver driver in drivers)
      {
        stintWithPit = Convert.ToDouble(driver.regularStintMins) + stints[0].PitTime;

        while (driver.nStints >= 0.5 && duration >= stintWithPit)
        {
          double startH = Convert.ToDouble(stints[nStint - 1].StartH);
          double startM = Convert.ToDouble(stints[nStint - 1].StartM) + stintWithPit;
          if (startM >= 60)
          {
            startH++;
            startM -= 60;
          }
          if (startH >= 24)
            startH -= 24;

          stints.Add(new Stint()
          {
            Counter = (nStint + 1).ToString(),
            StartH = Math.Truncate(startH).ToString(),
            StartM = Math.Truncate(startM).ToString(),
            Inlap = Convert.ToInt32(stints[nStint - 1].Inlap) + Convert.ToInt32(drivers[nDriver].regularStintLaps),
            Temp = "20/20",
            PressureFL = "FL",
            PressureFR = "FR",
            PressureRL = "RL",
            PressureRR = "RR",
            StintLength = Math.Round(drivers[nDriver].regularStintMins, 2).ToString(),
            StintFuel = drivers[nDriver].regularStintFuel.ToString(),
            StintLaps = drivers[nDriver].regularStintLaps.ToString(),
            Driver = drivers[nDriver].Name, // Get Driver
            Spotter = "", // Get Spotter
            PitDescription = pitstops[0].name,
            PitTime = Convert.ToDouble(pitstops[0].seconds) / 60,
          });

          CreateStintbox(nStint, stintboxPosY++, stints[nStint].StartH, stints[nStint].StartM);

          duration -= stintWithPit;

          if (driver.nStints >= 1)
            driver.nStints -= 1;

          nStint++;
        }
        if (nDriver < drivers.Count() - 1)
          nDriver++;
      }

      double lapLastSeconds = Convert.ToDouble(drivers[nDriver].Mins) * 60 + Convert.ToDouble(drivers[nDriver].Secs + "," + drivers[nDriver].Thos);
      double lapLastMinutes = lapLastSeconds / 60;

      double finalLaps = duration / lapLastMinutes;
      double finalStintTime = finalLaps * lapLastMinutes;

      //double stintLength = finalStintTime + lapLastMinutes;
      double stintFuel = (Math.Truncate(finalLaps) + 2) * Convert.ToDouble(drivers[nDriver].Cons);

      double startLastH = Convert.ToDouble(stints[nStint - 1].StartH);
      double startLastM = Convert.ToDouble(stints[nStint - 1].StartM) + stintWithPit;
      if (startLastM >= 60)
      {
        startLastH++;
        startLastM -= 60;
      }
      if (startLastH >= 24)
        startLastH -= 24;

      stints.Add(new Stint()
      {
        Counter = (nStint + 1).ToString(),
        StartH = Math.Truncate(startLastH).ToString(),
        StartM = Math.Truncate(startLastM).ToString(),
        Inlap = Convert.ToInt32(stints[nStint - 1].Inlap) + Convert.ToInt32(finalLaps),
        Temp = "20/20",
        PressureFL = "FL",
        PressureFR = "FR",
        PressureRL = "RL",
        PressureRR = "RR",
        StintLength = Math.Round(finalStintTime, 2).ToString(),
        StintFuel = stintFuel.ToString(),
        StintLaps = Convert.ToString(Math.Truncate(finalLaps)),
        Driver = drivers[nDriver].Name, // Get Driver
        Spotter = "", // Get Spotter
        PitDescription = "",
        PitTime = 0,
      });

      // foreach driver
      int posY = 1;
      foreach (Driver driver in drivers)
      {
        driver.DriverDuration = duration / drivers.Count;

        // create Label for every Driver
        Label totalStintNames = new Label
        {
          Name = driver.Counter,
          Text = driver.Name,
          Size = new Size(70, 15),
          Anchor = AnchorStyles.Right | AnchorStyles.Top,
          Location = new Point(5, 20 * (posY))
        };

        Label totalStintTime = new Label
        {
          Name = driver.Counter,
          //Text = "0",
          Size = new Size(50, 15),
          Anchor = AnchorStyles.Right | AnchorStyles.Top,
          Location = new Point(75, 20 * (posY))
        };
        totalStintTime.Text = CalculateTotalStintTime(totalStintTime, 0);

        string CalculateTotalStintTime(Label totalTime, int nGivenStint)
        {
          double mins = 0;
          mins = driver.totalMins;
          totalTime.Text = mins.ToString();
          return totalTime.Text;
        }

        //MessageBox.Show(driver.totalMins.ToString());

        posY++;
        groupBoxTotalStintTime.Controls.Add(totalStintNames);
        groupBoxTotalStintTime.Controls.Add(totalStintTime);
      }

      CreateStintbox(nStint, stintboxPosY++, stints[nStint].StartH, stints[nStint].StartM);

      duration -= stintWithPit;

      if (drivers[nDriver].nStints >= 1)
        drivers[nDriver].nStints -= 1;

      //nStint++;
    }

    private void textBoxStartHour_TextChanged(object sender, EventArgs e)
    {
      if (stints.Count() != 0)
        stints[0].StartH = textBoxStartHour.Text.ToString();
      else
      {
        stints.Add(new Stint()
        {
          StartH = textBoxStartHour.Text.ToString()
        });
      }
    }

    private void textBoxStartMin_TextChanged(object sender, EventArgs e)
    {
      if (stints.Count() != 0)
        stints[0].StartM = textBoxStartMin.Text.ToString();
      else
      {
        stints.Add(new Stint()
        {
          StartM = textBoxStartMin.Text.ToString(),
        });
      }
    }

    int nSeconds;
    private void buttonStartTimer_Click(object sender, EventArgs e)
    {
      try
      {
        nSeconds = Convert.ToInt32(textBoxTimerSek.Text);
        timerSec.Start();
      }
      catch
      {
        textBoxTimerSek.Text = "180";
        timerSec.Start();
      }
    }

    private void buttonStopTimer_Click(object sender, EventArgs e)
    {
      timerSec.Stop();
    }

    private void timerSec_Tick(object sender, EventArgs e)
    {
      if (nSeconds >= 1)
      {
        nSeconds--;
        labelTimer.Text = nSeconds.ToString();
      }
      else
      {
        try
        {
          nSeconds = Convert.ToInt32(textBoxTimerSek.Text);
        }
        catch
        {
          textBoxTimerSek.Text = "180";
        }
      }
    }

    private void textBoxTimerSek_TextChanged(object sender, EventArgs e)
    {
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        regKey.SetValue("Timer", textBoxTimerSek.Text);
      }
    }
  }
}
