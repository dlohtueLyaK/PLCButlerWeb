using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;

// Struktur Berechnungen
struct CalculationStruct
{
    public string Name;
    public string Calculation;
    public string Function;
}

namespace PLCButlerWeb
{
    // Globale Klasse
    static class Calculation
    {
        //Daten Berechnung
        public static CalculationStruct[] Table = new CalculationStruct[10];
        //Leeres Array um Daten zu löschen
        public static CalculationStruct[] Clear = new CalculationStruct[10];
        //Geräte-Zähler
        public static int Counter = -1;
    }

    public partial class _CalculationList : Page
    {
        // Aufgabe beim Laden der Seite
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Calculation.Counter; i++)
            {
                int j = i + 1;
                CalculationResult.Text = CalculationResult.Text + "<p>" + j + ". " + Calculation.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Calculation.Table[i].Calculation + "&nbsp;&nbsp;&nbsp;" + Calculation.Table[i].Function;
            }
            //CalculationResultCounter.Text = Convert.ToString(Calculation.Counter + 1);
        }
        //Berechnung hinzufügen
        protected void CalculationAddButton_Click(object sender, EventArgs e)
        {
            Calculation.Counter = Calculation.Counter + 1;

            Calculation.Table[Calculation.Counter].Name = CalculationName.Text;
            Calculation.Table[Calculation.Counter].Calculation = CalculationFormula.Text;
            Calculation.Table[Calculation.Counter].Function = CalculationFunction.Text;

            //Label löschen
            CalculationResult.Text = "";

            for (int i = 0; i <= Calculation.Counter; i++)
            {
                //Label-Anzeige
                int j = i + 1;
                CalculationResult.Text = CalculationResult.Text + "<p>" + j + ". " + Calculation.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Calculation.Table[i].Calculation + "&nbsp;&nbsp;&nbsp;" + Calculation.Table[i].Function;
            }

            //CalculationResultCounter.Text = Convert.ToString(Calculation.Counter + 1);

        }
        //Löschen der gesamten Berechnungsdaten
        protected void CalculationClearButton_Click(object sender, EventArgs e)
        {
            Calculation.Table = Calculation.Clear;
            Calculation.Counter = -1;
            CalculationResult.Text = "";
            //CalculationResultCounter.Text = "0";
        }

        protected void CalculationImpButton_Click(object sender, EventArgs e)
        {

        }

        protected void CalculationExpButton_Click(object sender, EventArgs e)
        {

        }
    }
}