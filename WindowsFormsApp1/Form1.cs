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
    string[] drivers = new string[10];

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

      // einen Eintrag erstellen
      xmlWrite.WriteStartElement("Fahrer");

      //for (int i = 1; i < driverCount; i++)
      foreach(string driver in drivers)
      {
        if (drivers[driverCount] != "")
        {
          // einen Namen mit Wert schreiben
          xmlWrite.WriteElementString("Fahrer", drivers[driverCount]);
        }
      }

      // Punkte mit Wert schreiben
      xmlWrite.WriteElementString("punkte", "100");

      // den Eintrag abschließen
      xmlWrite.WriteEndElement();

      // und noch einen Eintrag erstellen
      xmlWrite.WriteStartElement("eintrag");

      // einen Namen mit Wert schreiben
      xmlWrite.WriteElementString("name", "Maier");

      // Punkte mit Wert schreiben
      xmlWrite.WriteElementString("punkte", "1000");

      // den Eintrag abschließen
      xmlWrite.WriteEndElement();

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
          if (xmlVorhanden)
          {
            //MessageBox.Show("\"" + GetFilename() + "\"" + " wird geöffnet");
            XmlReader xmlRead = XmlReader.Create(GetFilename());
            xmlRead.Close();
          }
          //else
            //MessageBox.Show("\"" + GetFilename() + "\"" + " ist nicht vorhanden");
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

      //WriteToXML("");
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

    private void DynText_TextChanged(object sender, EventArgs e)
    {
      string driver = sender.ToString();
      drivers[driverCount] = driver.Substring(36);
    }

    int driverCount = 1;
    int driverIndex = 0;
    int driverPosX  = 0;
    //int dPosY = 0;
    private void buttonAddDriver_Click(object sender, EventArgs e)
    {
      TextBox name = new TextBox
      {
        Text = "Name",
        Name = "Fahrer" + driverCount.ToString(),
        Size = new Size(90, 20),
        Location = new Point(95 * (driverPosX + 1), 15),
      };
      name.TextChanged += DynText_TextChanged;

      TextBox timeMin = new TextBox
      {
        Name = "timeMin" + driverCount.ToString(),
        Text = "m",
        Size = new Size(15, 20),
        Location = new Point(95 * (driverPosX + 1), 40)
      };

      TextBox timeSec = new TextBox
      {
        Name = "timeSec" + driverCount.ToString(),
        Text = "ss",
        Size = new Size(20, 20),
        Location = new Point(15 + 95 * (driverPosX + 1), 40)
      };

      TextBox timeTho = new TextBox
      {
        Name = "timeTho" + driverCount.ToString(),
        Text = "ttt",
        Size = new Size(25, 20),
        Location = new Point(35 + 95 * (driverPosX + 1), 40)
      };

      TextBox consumption = new TextBox
      {
        Name = "consumption" + driverCount.ToString(),
        Text = "l/lap",
        Size = new Size(30, 20),
        Location = new Point(60 + 95 * (driverPosX + 1), 40)
      };

      driverIndex+=5;
      driverCount++;
      driverPosX++;

      groupBox3.Controls.Add(name);
      groupBox3.Controls.Add(timeMin);
      groupBox3.Controls.Add(timeSec);
      groupBox3.Controls.Add(timeTho);
      groupBox3.Controls.Add(consumption);
    }

    private void buttonRemoveDriver_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < 5; i++)
      {
        if (driverIndex >= 5)
          groupBox3.Controls.RemoveAt(driverIndex - 3);
      }
      if (driverIndex >= 5)
      {
        driverIndex -= 5;
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

      pitCount++;
      pitPosY++;
      pitIndex += 2;

      groupBox1.Controls.Add(description);
      groupBox1.Controls.Add(duration);
    }

    private void buttonRemovePitstop_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < 2; i++)
        if (pitIndex >= 2)
          groupBox1.Controls.RemoveAt(pitIndex);

      if (pitIndex >= 2)
      {
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
