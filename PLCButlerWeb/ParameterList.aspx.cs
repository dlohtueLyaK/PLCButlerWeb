using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;

// Struktur Parameter
struct ParameterStruct
{
    public string Name;
    public string Typ; // REAL und INT
    public string RangeMin;
    public string RangeMax;
    public string DefaultValue;
    public string Unit;
    public string Function;
}

namespace PLCButlerWeb
{
    // Globale Klasse
    static class Parameter
    {
        //Daten Geräte
        public static ParameterStruct[] Table = new ParameterStruct[10];
        //Leeres Array um Daten zu löschen
        public static ParameterStruct[] Clear = new ParameterStruct[10];
        //Geräte-Zähler
        public static int Counter = -1;
    }

    public partial class _ParameterList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Anzeige der Parameterdaten
            for (int i = 0; i <= Parameter.Counter; i++)
            {
                int j = i + 1;
                //Label-Anzeige
                ParameterResult.Text = ParameterResult.Text + "<p>" + j + ". " + Parameter.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Parameter.Table[i].Typ + "&nbsp;&nbsp;&nbsp;" + Parameter.Table[i].RangeMin + "&nbsp;&nbsp;&nbsp;" +
                Parameter.Table[i].RangeMax + "&nbsp;&nbsp;&nbsp;" + Parameter.Table[i].DefaultValue + "&nbsp;&nbsp;&nbsp;" +
                Parameter.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" + Parameter.Table[i].Function;
            }
            //ParameterResultCounter.Text = Convert.ToString(Device_.Counter + 1);

        }

        protected void ParameterAddButton_Click(object sender, EventArgs e)
        {
            Parameter.Counter = Parameter.Counter + 1;

            Parameter.Table[Parameter.Counter].Name = ParameterName.Text;
            Parameter.Table[Parameter.Counter].Typ = ParameterTyp.Text;
            Parameter.Table[Parameter.Counter].RangeMin = ParameterRangeMin.Text;
            Parameter.Table[Parameter.Counter].RangeMax = ParameterRangeMax.Text;
            Parameter.Table[Parameter.Counter].DefaultValue = ParameterDefaultValue.Text;
            Parameter.Table[Parameter.Counter].Unit = ParameterUnit.Text;
            Parameter.Table[Parameter.Counter].Function = ParameterFunction.Text;

            //Label löschen
            ParameterResult.Text = "";

            for (int i = 0; i <= Parameter.Counter; i++)
            {
                int j = i + 1;
                //Label-Anzeige
                ParameterResult.Text = ParameterResult.Text + "<p>" + j + ". " + Parameter.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Parameter.Table[i].Typ + "&nbsp;&nbsp;&nbsp;" + Parameter.Table[i].RangeMin + "&nbsp;&nbsp;&nbsp;" +
                Parameter.Table[i].RangeMax + "&nbsp;&nbsp;&nbsp;" + Parameter.Table[i].DefaultValue + "&nbsp;&nbsp;&nbsp;" +
                Parameter.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" + Parameter.Table[i].Function;
            }

            //ParameterResultCounter.Text = Convert.ToString(Parameter.Counter + 1);
        }

        protected void ParameterClearButton_Click(object sender, EventArgs e)
        {
            Parameter.Table = Parameter.Clear;
            Parameter.Counter = -1;
            ParameterResult.Text = "";
            //ParameterResultCounter.Text = "0";
        }

        protected void ParameterImpButton_Click(object sender, EventArgs e)
        {

        }

        protected void ParameterExpButton_Click(object sender, EventArgs e)
        {

        }
    }
}