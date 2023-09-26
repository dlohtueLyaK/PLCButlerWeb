using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using Siemens.Engineering.HW;

// Struktur Geräte
struct DeviceStruct
{
    public string Name;
    public string Typ;
    public string RangeMin;
    public string RangeMax;
    public string Unit;
    public string Function;
}

namespace PLCButlerWeb
{
    // Globale Klasse
    static class Device_
    {
        //Daten Geräte
        public static DeviceStruct[] Table = new DeviceStruct[15];
        //Leeres Array um Daten zu löschen
        public static DeviceStruct[] Clear = new DeviceStruct[15];
        //Geräte-Zähler
        public static int Counter = -1;
    }

    public partial class _DeviceList : Page
    {
        // Aufgabe beim Laden der Seite
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Device_.Counter; i++)
            {//<p>&nbsp;</p>
                int j = i + 1;
                DeviceResult.Text = DeviceResult.Text + "<p>" + j + ". " + Device_.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Device_.Table[i].Typ + "&nbsp;&nbsp;&nbsp;" + Device_.Table[i].RangeMin + "&nbsp;&nbsp;&nbsp;" +
                Device_.Table[i].RangeMax + "&nbsp;&nbsp;&nbsp;" + Device_.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                Device_.Table[i].Function;
            }
            //DeviceResultCounter.Text = Convert.ToString(Device_.Counter + 1);
        }
        //Gerät hinzufügen
        protected void DeviceAddButton_Click(object sender, EventArgs e)
        {
            Device_.Counter = Device_.Counter + 1;

            Device_.Table[Device_.Counter].Name = DeviceName.Text;
            Device_.Table[Device_.Counter].Typ = DeviceTyp.Text;
            Device_.Table[Device_.Counter].RangeMin = DeviceRangeMin.Text;
            Device_.Table[Device_.Counter].RangeMax = DeviceRangeMax.Text;
            Device_.Table[Device_.Counter].Unit = DeviceUnit.Text;
            Device_.Table[Device_.Counter].Function = DeviceFunction.Text;
            
            //Label löschen
            DeviceResult.Text = "";           

            for (int i = 0; i <= Device_.Counter; i++)
            {
                int j = i + 1;
                //Label-Anzeige
                DeviceResult.Text = DeviceResult.Text + "<p>" + j + ". " + Device_.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Device_.Table[i].Typ + "&nbsp;&nbsp;&nbsp;" + Device_.Table[i].RangeMin + "&nbsp;&nbsp;&nbsp;" +
                Device_.Table[i].RangeMax + "&nbsp;&nbsp;&nbsp;" + Device_.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                Device_.Table[i].Function;
            }            
            //DeviceResultCounter.Text = Convert.ToString(Device_.Counter + 1);
        }
        //Löschen der gesamten Gerätedaten
        protected void DeviceClearButton_Click(object sender, EventArgs e)
        {
            Device_.Table = Device_.Clear;
            Device_.Counter = -1;
            DeviceResult.Text = "";
            //DeviceResultCounter.Text = "0";
        }
    }
}