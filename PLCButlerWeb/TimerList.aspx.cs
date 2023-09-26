using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;

// Struktur Timer
struct TimerStruct
{
    public string Name;
    public string GoalValue;
    public string Unit;
    public string Function;
}
namespace PLCButlerWeb
{
    // Globale Klasse
    static class Timer
    {
        //Daten Timer
        public static TimerStruct[] Table = new TimerStruct[10];
        //Leeres Array um Daten zu löschen
        public static TimerStruct[] Clear = new TimerStruct[10];
        //Timer-Zähler
        public static int Counter = -1;
    }

    public partial class _TimerList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Timer.Counter; i++)
            {
                int j = i + 1;
                TimerResult.Text = TimerResult.Text + "<p>" + j + ". " + Timer.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Timer.Table[i].GoalValue + "&nbsp;&nbsp;&nbsp;" + Timer.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                Timer.Table[i].Function;
            }
            //TimerResultCounter.Text = Convert.ToString(Timer.Counter + 1);
        }

        //Timer hinzufügen
        protected void TimerAddButton_Click(object sender, EventArgs e)
        {
            Timer.Counter = Timer.Counter + 1;

            Timer.Table[Timer.Counter].Name = TimerName.Text;
            Timer.Table[Timer.Counter].GoalValue = TimerGoalValue.Text;
            Timer.Table[Timer.Counter].Unit = TimerUnit.Text;
            Timer.Table[Timer.Counter].Function = TimerFunction.Text;

            //Label löschen
            TimerResult.Text = "";

            for (int i = 0; i <= Timer.Counter; i++)
            {
                int j = i + 1;
                TimerResult.Text = TimerResult.Text + "<p>" + j + ". " + Timer.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Timer.Table[i].GoalValue + "&nbsp;&nbsp;&nbsp;" + Timer.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                Timer.Table[i].Function;
            }

            //TimerResultCounter.Text = Convert.ToString(Timer.Counter + 1);

        }
        //Löschen der gesamten Gerätedaten
        protected void TimerClearButton_Click(object sender, EventArgs e)
        {
            Timer.Table = Timer.Clear;
            Timer.Counter = -1;
            TimerResult.Text = "";
            //TimerResultCounter.Text = "0";
        }

        protected void TimerImpButton_Click(object sender, EventArgs e)
        {

        }

        protected void TimerExpButton_Click(object sender, EventArgs e)
        {

        }
    }
}