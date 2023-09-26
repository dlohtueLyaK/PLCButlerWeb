using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;

// Struktur Geräte
struct ControllerStruct
{
    public string Name;
    public string Controller;
    public string Function;
}

namespace PLCButlerWeb
{
    // Globale Klasse
    static class Controller
    {
        //Daten Geräte
        public static ControllerStruct[] Table = new ControllerStruct[10];
        //Leeres Array um Daten zu löschen
        public static ControllerStruct[] Clear = new ControllerStruct[10];
        //Geräte-Zähler
        public static int Counter = -1;
    }

    public partial class _ControllerList : Page
    {
        // Aufgabe beim Laden der Seite
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Controller.Counter; i++)
            {
                int j = i + 1;
                ControllerResult.Text = ControllerResult.Text + "<p>" + j + ". " + Controller.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Controller.Table[i].Controller + "&nbsp;&nbsp;&nbsp;" + Controller.Table[i].Function;
            }
            //ControllerResultCounter.Text = Convert.ToString(Controller.Counter + 1);
        }
        //Gerät hinzufügen
        protected void ControllerAddButton_Click(object sender, EventArgs e)
        {
            Controller.Counter = Controller.Counter + 1;

            Controller.Table[Controller.Counter].Name = ControllerName.Text;
            Controller.Table[Controller.Counter].Controller = ControllerController.Text;
            Controller.Table[Controller.Counter].Function = ControllerFunction.Text;

            //Label löschen
            ControllerResult.Text = "";

            for (int i = 0; i <= Controller.Counter; i++)
            {
                int j = i + 1;
                //Label-Anzeige
                ControllerResult.Text = ControllerResult.Text + "<p>" + j + ". " + Controller.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                Controller.Table[i].Controller + "&nbsp;&nbsp;&nbsp;" + Controller.Table[i].Function;
            }

            //ControllerResultCounter.Text = Convert.ToString(Controller.Counter + 1);

        }
        //Löschen der gesamten Gerätedaten
        protected void ControllerClearButton_Click(object sender, EventArgs e)
        {
            Controller.Table = Controller.Clear;
            Controller.Counter = -1;
            ControllerResult.Text = "";
            //ControllerResultCounter.Text = "0";
        }

        protected void ControllerImpButton_Click(object sender, EventArgs e)
        {

        }

        protected void ControllerExpButton_Click(object sender, EventArgs e)
        {

        }
    }
}