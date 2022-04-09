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
    //string durationHours;
    //string durationMins;
    //string stintLimitation;
    //string fuelQuantity;
    //string stintTime;
    List<Driver>  drivers   = new List<Driver>();
    List<Pitstop> pitstops  = new List<Pitstop>();

    class Driver
    {
      public string Counter { get; set; }
      public string Name { get; set; }
      public string Mins { get; set; }
      public string Secs { get; set; }
      public string Thos { get; set; }
      public string Cons { get; set; }
    }

    class Pitstop
    {
      public string counter { get; set; }
      public string name    { get; set; }
      public string seconds { get; set; }
    }

    // helpers
    private string GetFilename()
    {
      string filename;

      using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\ACC-RC"))
      {
        string gPath = Convert.ToString(regKey.GetValue("GlobalPath"));
        string track = Convert.ToString(regKey.GetValue("Track"));
        string duration = Convert.ToString(regKey.GetValue("Duration"));
        filename = gPath + track + duration + ".xml";
      }
      
      return filename;
    }

    private string GetText(string driver, TextBox box, string key)
    {
      //MessageBox.Show(box.Name);
      XmlReader xmlRead = XmlReader.Create(GetFilename());
      xmlRead.ReadToDescendant(key, driver);
      
      box.Text = xmlRead.ReadElementString();
      
      xmlRead.Close();
      
      return box.Text;
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

        if (regKey == null)
        {
          comboBoxTracks.Text = "";
        }
        else
        {
          // get position of the window
          this.Top = Convert.ToInt32(regKey.GetValue("Top"));
          this.Left = Convert.ToInt32(regKey.GetValue("Left"));
          this.Height = Convert.ToInt32(regKey.GetValue("Height"));
          this.Width = Convert.ToInt32(regKey.GetValue("Width"));

          // get latest values
          comboBoxTracks.Text = Convert.ToString(regKey.GetValue("Track"));
          textBoxLocalPath.Text = Convert.ToString(regKey.GetValue("LocalPath"));
          textBoxGlobalPath.Text = Convert.ToString(regKey.GetValue("GlobalPath"));

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

            //xmlRead.ReadToFollowing("name");
            //MessageBox.Show(xmlRead.ReadElementString());

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlRead);

            // foreach driver
            foreach(var fahrer in doc.GetElementsByTagName("Fahrer").OfType<XmlElement>())
            {
              buttonAddDriver_Click(sender, e);
              //MessageBox.Show(sender.ToString());
              //MessageBox.Show(e.ToString());

              //MessageBox.Show(xmlRead.Read().ToString());
            }
            //xmlRead.    

            //XmlReader xmlReadnew = XmlReader.Create(GetFilename());
            //for (int i = 0; i < 2; i++)
            //{
              //xmlReadnew.ReadToFollowing("name");

              //MessageBox.Show(xmlReadnew.ReadElementString());
              //xmlReadnew.ReadToFollowing("name");
              //MessageBox.Show(xmlReadnew.ReadElementString());
            //}


            // foreach pitstop
            foreach (var pitstop in doc.GetElementsByTagName("pitstops").OfType<XmlElement>())
              buttonAddPitstop_Click(sender, e);

            xmlRead.Close();
          }
        }
      }
    }

    private void comboBoxTracks_SelectedValueChanged(object sender, EventArgs e)
    {
      // set Label
      labelTrack.Text = comboBoxTracks.Text;

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
      using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ACC-RC"))
      {
        // set window size and position
        regKey.SetValue("Top", Convert.ToString(this.Top));
        regKey.SetValue("Left", Convert.ToString(this.Left));
        regKey.SetValue("Height", Convert.ToString(this.Height));
        regKey.SetValue("Width", Convert.ToString(this.Width));
      }
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

      TextBox duration = new TextBox
      {
        Text = "sec",
        Name = "Duration" + pitCount.ToString(),
        Size = new Size(30, 20),
        Location = new Point(220, 25 * (pitPosY + 1))
      };

      // erstelle einen neuen Pitstopp
      pitstops.Add(new Pitstop()
      {
        counter = description.Name,
        name = description.Text,
        seconds = duration.Text,
      });

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
  }
}
