using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;

// Struktur Counter
struct CounterStruct
{
    public string Name;
    public string GoalValue;
    public string CountUp;
    public string IncreaseValue;
    public string Unit;
    public string ResetValue;
    public string Function;
}

namespace PLCButlerWeb
{
    // Globale Klasse
    static class Counters
    {
        //Daten Geräte
        public static CounterStruct[] Table = new CounterStruct[10];
        //Leeres Array um Daten zu löschen
        public static CounterStruct[] Clear = new CounterStruct[10];
        //Geräte-Zähler
        public static int Counter = -1;
    }
    public partial class _CounterList : Page
    {
        // Aufgabe beim Laden der Seite
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Counters.Counter; i++)
            {
                int j = i + 1;
                CounterResult.Text = CounterResult.Text + "<p>" + j + ". " + Counters.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Counters.Table[i].GoalValue + "&nbsp;&nbsp;&nbsp;" + Counters.Table[i].CountUp + "&nbsp;&nbsp;&nbsp;" +
                Counters.Table[i].IncreaseValue + "&nbsp;&nbsp;&nbsp;" + Counters.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                Counters.Table[i].ResetValue + "&nbsp;&nbsp;&nbsp;" + Counters.Table[i].Function;
            }
            //CounterResultCounter.Text = Convert.ToString(Counters.Counter + 1);
        }

        //Counter hinzufügen
        protected void CounterAddButton_Click(object sender, EventArgs e)
        {
            Counters.Counter = Counters.Counter + 1;

             Counters.Table[ Counters.Counter].Name =  CounterName.Text;
             Counters.Table[ Counters.Counter].GoalValue =  CounterGoalValue.Text;
             Counters.Table[ Counters.Counter].CountUp =  CounterCountUp.Text;
             Counters.Table[ Counters.Counter].IncreaseValue =  CounterIncreaseValue.Text;
             Counters.Table[ Counters.Counter].Unit =  CounterUnit.Text;
             Counters.Table[Counters.Counter].ResetValue = CounterResetValue.Text;
             Counters.Table[ Counters.Counter].Function =  CounterFunction.Text;

            //Label löschen
             CounterResult.Text = "";

            for (int i = 0; i <= Counters.Counter; i++)
            {
                int j = i + 1;
                CounterResult.Text = CounterResult.Text + "<p>" + j + ". " + Counters.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Counters.Table[i].GoalValue + "&nbsp;&nbsp;&nbsp;" + Counters.Table[i].CountUp + "&nbsp;&nbsp;&nbsp;" +
                Counters.Table[i].IncreaseValue + "&nbsp;&nbsp;&nbsp;" + Counters.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                Counters.Table[i].ResetValue + "&nbsp;&nbsp;&nbsp;" + Counters.Table[i].Function;
            }

            //CounterResultCounter.Text = Convert.ToString( Counters.Counter + 1);

        }
        //Löschen der gesamten Gerätedaten
        protected void  CounterClearButton_Click(object sender, EventArgs e)
        {
             Counters.Table =  Counters.Clear;
             Counters.Counter = -1;
             CounterResult.Text = "";
             //CounterResultCounter.Text = "0";
        }

        protected void CounterImpButton_Click(object sender, EventArgs e)
        {

        }

        protected void CounterExpButton_Click(object sender, EventArgs e)
        {

        }
    }
}