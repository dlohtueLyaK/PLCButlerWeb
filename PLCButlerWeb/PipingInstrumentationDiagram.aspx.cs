using System;
using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Drawing;
// MindFusion
using MindFusion.Diagramming;
//using MindFusion.Diagramming.WebForms;
using MindFusion.Svg;
//***********
//using System.Text;
//using System.Threading.Tasks;
//using System.Drawing.Imaging;



struct ItemsStruct
{
    public int ID;
    public string Name;
    public string Typ;
    public int Active;
}
struct StepStruct
{
    //public int Step;
    public int Status;
}

namespace PLCButlerWeb
{
    
    // Globale Klasse
    static class Items_
    {
        //Daten Geräte
        public static ItemsStruct[] Items = new ItemsStruct[10];
        //Leeres Array um Daten zu löschen
        public static ItemsStruct[] ItemsClear = new ItemsStruct[10];
        //Items-Zähler
        public static int Counter = 0;

        public static Dictionary<String, String> database = new Dictionary<string, string>();
    }

    static class Steps_
    {
        // Data Steps
        public static StepStruct[,] Steps = new StepStruct[10,10];
        //Clear step information
        public static StepStruct[,] StepsClear = new StepStruct[10,10];
        public static int StepNumber;
        public static int SimCounter;
    }

    public partial class PipingInstrumentationDiagram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Steps_.Steps = Steps_.StepsClear;
            StepNumber.Text = "Step:" + Steps_.StepNumber.ToString();
            //this.diagramView.LinkCascadeOrientation = MindFusion.Diagramming.Orientation.Vertical;
            //this.diagramView.LinkStyle = MindFusion.Diagramming.LinkStyle.Cascading;
            if (!IsPostBack)
            {
                diagramView.Behavior = Behavior.DrawLinks;//Behavior.Modify;

                //diagramView.Diagram.RoutingOptions.Anchoring = Anchoring.Reassign;


                ///diagramView.Diagram.LinkBaseShape = LinkShape.Bezier;
                diagramView.Diagram.LinkShape = LinkShape.Polyline;
                
                //Set Routlinks to true
                diagramView.Diagram.RoundedLinks = true;
                //diagramView.Diagram.LinkBaseShape.IsArrowhead = false;
                diagramView.Diagram.LinkHeadShape.IsArrowhead = false;
                
                //Set end of line symbol
                diagramView.Diagram.LinkBaseShape = ArrowHeads.Arrow;
                //diagramView.Diagram.LinkHeadShape = ArrowHeads.None;

                //diagramView.Diagram.AllowLinksRepeat = RerouteLinks.Never;
                //diagramView.Diagram.LinkHeadShape = ArrowHeads.None;

                //diagramView.Diagram.LinkBrush = LinkBrush.Color.Blue;
                
                diagramView.Diagram.AutoResize = AutoResize.None;
                diagramView.Diagram.Bounds = new RectangleF(0, 0, 270, 135);
                //Grid enable
                diagramView.Diagram.ShowGrid = true;

                diagramView.Diagram.AllowUnconnectedLinks = false;
                diagramView.Diagram.AllowSplitLinks = false;
                //diagramView.Behavior = true;

                //Disable multiply selection - but dont work
                diagramView.Diagram.Selection.AllowMultipleSelection = false;
                


                var image = System.Drawing.Image.FromFile(Server.MapPath("./Pictures/white.png"));
                diagramView.Diagram.BackgroundImage = image;

                //AddNode(new RectangleF(55, 5, 25, 25), "sign.svg", true);
                /*
                //Read DeviceList
                for (int i = 0; i <= Device_.Counter; i++)
                {
                    int j = i + 1;
                    DeviceResult.Text = DeviceResult.Text + "<p>&nbsp;</p>" + j + ". " + Device_.Table[i].Name + "&nbsp;&nbsp;&nbsp;" +
                    Device_.Table[i].Typ + "&nbsp;&nbsp;&nbsp;" + Device_.Table[i].RangeMin + "&nbsp;&nbsp;&nbsp;" +
                    Device_.Table[i].RangeMax + "&nbsp;&nbsp;&nbsp;" + Device_.Table[i].Unit + "&nbsp;&nbsp;&nbsp;" +
                    Device_.Table[i].Function;
                }
                //DeviceResultCounter.Text = Convert.ToString(Device_.Counter + 1);  
                */
                var id = Request.QueryString["id"];
                if (id != null && Items_.database.ContainsKey(id)) {
                    diagramView.LoadFromString(Items_.database[id]);
                }
                Items_.Items = Items_.ItemsClear;
            }
        }

        public SvgNode AddNode(RectangleF bounds, string fileName, bool locked = false)
        {
            var node = diagramView.Diagram.Factory.CreateSvgNode(bounds);
            node.Transparent = true;
            node.Locked = locked;
            var content = new SvgContent();
            content.Parse(Server.MapPath(fileName));
            node.Content = content;
          
            return node;
        }
        // Save to file
        protected void btnSave_Click(object sender, EventArgs e)
        {
            diagramView.Diagram.SaveToFile(@"./test.xml");

            string key = Guid.NewGuid().ToString();
            Items_.database.Add(key, diagramView.Diagram.SaveToString());
            //redirect?
            Response.Redirect("PipingInstrumentationDiagram.aspx?id=" + key, true);

        }
        // Load form file
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            diagramView.Diagram.LoadFromFile(@"./test.xml");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IndexOfItem();

            //delete
            var delete = diagramView.Diagram.ActiveItem;
            diagramView.Diagram.Items.Remove(delete);
            Items_.Items = Items_.ItemsClear;


        }
        // Reset page
        protected void btnReset_Click(object sender, EventArgs e)
        {
            diagramView.Diagram.ClearAll();

            diagramView.Behavior = Behavior.Modify;
            diagramView.Diagram.AutoResize = AutoResize.None;
            diagramView.Diagram.Bounds = new RectangleF(0, 0, 270, 135);
            //Grid enable
            diagramView.Diagram.ShowGrid = true;

            diagramView.Diagram.AllowUnconnectedLinks = true;
            //diagramView.Behavior = true;

            //Disable multiply selection - but dont work
            diagramView.Diagram.Selection.AllowMultipleSelection = false;

            var image = System.Drawing.Image.FromFile(Server.MapPath("./Pictures/white.png"));
            diagramView.Diagram.BackgroundImage = image;
        }

        protected void CreateItemMember(int ID, string Name, string Typ, int Active)
        {
            Items_.Items[Items_.Counter].ID = Items_.Counter;
            Items_.Items[Items_.Counter].Name = Name;
            Items_.Items[Items_.Counter].Typ = Typ;
            Items_.Items[Items_.Counter].Active = Active;

            //Zähler hochzählen
            Items_.Counter = Items_.Counter + 1;
        }

        protected void btnValve_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(105, 45, 14, 20), "./Pictures/P&ID_SVG/Ventil/IN-LINE_VALVES_GENERIC.svg");
            //space.ToolTip = "Valve";
            space.Text = Textbox.Text;// "Valve";

            CreateItemMember(Items_.Counter, space.Text, "Valve", 0);
        }

        protected void btnPump_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(105, 85, 15, 40), "./Pictures/P&ID_SVG/Pump/PUMPS_GENERIC.svg"); // , true für locked
            //space.ToolTip = "Pump";
            space.Text = Textbox.Text;//"Pump";


            CreateItemMember(Items_.Counter, space.Text, "Pump", 0);
        }

        protected void btnTank_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(10, 85, 50, 25), "./Pictures/P&ID_SVG/Tank/NON_SANITARY_TANKS_3_VERSION_2.svg");
            //space.ToolTip = "Tank";           
            space.Text = Textbox.Text;//"Tank";

            CreateItemMember(Items_.Counter, space.Text, "Tank", 0);
        }

        protected void btnMem_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(10, 85, 50, 25), "./Pictures/P&ID_SVG/Membrane/MEMBRANES_SPIRAL_2.svg");
            //space.ToolTip = "Tank";           
            space.Text = "Membrane";

            CreateItemMember(Items_.Counter, space.Text, "Membrane", 0);
        }

        protected void btnDrain_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(10, 85, 15, 15), "./Pictures/P&ID_SVG/Drain/DRAIN2.svg");
            //space.ToolTip = "Tank";           
            //has no name
            //space.Text = "Drain";

            CreateItemMember(Items_.Counter, space.Text, "Drain", 0);
        }

        protected void btnIni_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(30, 50, 5, 5), "./Pictures/P&ID_SVG/Initiator/INI.svg");
            //space.ToolTip = "Tank";           
            //has no name
            space.Text = Textbox.Text;// "Initiator";
            
            CreateItemMember(Items_.Counter, space.Text, "Initiator", 0);
        }

        protected void btnTimer_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int index = r.Next(1, 5);
            var space = AddNode(new RectangleF(40, 60, 5, 5), "./Pictures/P&ID_SVG/Timer/TIMER.svg");
            //space.ToolTip = "Tank";           
            //has no name
            
            space.Text = Textbox.Text;// "Timer";
            
            CreateItemMember(Items_.Counter, space.Text, "Timer", 0);
        }

        protected void btnUndone_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            int index;
            var path = "";

            //Load index
            index = IndexOfItem();
            //Index to string to show
            Textbox.Text = index.ToString();

            if (Items_.Items[index].Typ == "Pump")
            {
                if(Items_.Items[index].Active == 0)
                {
                    path = "./Pictures/P&ID_SVG/Pump/PUMPS_GENERIC_ACITVE.svg";
                    Items_.Items[index].Active = 1;
                }
                else
                {
                    path = "./Pictures/P&ID_SVG/Pump/PUMPS_GENERIC.svg";
                    Items_.Items[index].Active = 0;
                }
            }
            if (Items_.Items[index].Typ == "Valve")
            {
                if (Items_.Items[index].Active == 0)
                {
                    path = "./Pictures/P&ID_SVG/Ventil/IN-LINE_VALVES_GENERIC_ACTIVE.svg";
                    Items_.Items[index].Active = 1;
                }
                else
                {
                    path = "./Pictures/P&ID_SVG/Ventil/IN-LINE_VALVES_GENERIC.svg";
                    Items_.Items[index].Active = 0;
                }
            }
            if (Items_.Items[index].Typ == "Initiator")
            {
                if (Items_.Items[index].Active == 0)
                {
                    path = "./Pictures/P&ID_SVG/Initiator/INI_ACTIVE.svg";
                    Items_.Items[index].Active = 1;
                }
                else
                {
                    path = "./Pictures/P&ID_SVG/Initiator/INI.svg";
                    Items_.Items[index].Active = 0;
                }
            }

            if (Items_.Items[index].Typ == "Timer")
            {
                if (Items_.Items[index].Active == 0)
                {
                    path = "./Pictures/P&ID_SVG/Timer/TIMER_ACTIVE.svg";
                    Items_.Items[index].Active = 1;
                }
                else
                {
                    path = "./Pictures/P&ID_SVG/Timer/TIMER.svg";
                    Items_.Items[index].Active = 0;
                }
            }
            else
            {
                Textbox.Text = "neee!";
            }

            //path = "./Pictures/P&ID_SVG/Pump/PUMPS_GENERIC_ACITVE.svg";
            var x = diagramView.Diagram.ActiveItem as SvgNode;

            var content = new SvgContent();
            content.Parse(Server.MapPath(path));

            x.Content = content;

            InfoBox();
        }
        // Just to look what happend
        protected void InfoBox()
        {
            ItemsLabel.Text = "";
            for (int i = 0; i < Items_.Counter; i++)
            {
                int j = i + 1;
                //"<p>&nbsp;</p>"
                ItemsLabel.Text = ItemsLabel.Text + "<p></p>" + Items_.Items[i].ID + "&nbsp;&nbsp;&nbsp;" +
                Items_.Items[i].Name + "&nbsp;&nbsp;&nbsp;" + Items_.Items[i].Typ + "&nbsp;&nbsp;&nbsp;" +
                Items_.Items[i].Active;
            }
        }
        //Give Index of active item
        protected int IndexOfItem()
        {
            int index;
            var x = diagramView.Diagram.ActiveItem as SvgNode;
            var items = diagramView.Diagram.Items;
            index = items.IndexOf(x);
            return index;
        }
         
        //Next Step and save the last step information
        protected void btnNext_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Items_.Counter; i++)
            {
                Steps_.Steps[Steps_.StepNumber, Items_.Items[i].ID].Status = Items_.Items[i].Active;  
            }

            //Step number increase
            Steps_.StepNumber = Steps_.StepNumber + 1;
            //Steps_.Steps.GetLength(1);

            for(int i = 0; i < Steps_.StepNumber; i++)
            {
                for (int j = 0; j < Items_.Counter; j++)
                { 
                    StepNumber.Text = StepNumber.Text + " " + Steps_.Steps[i, Items_.Items[j].ID].Status.ToString();
                }
                StepNumber.Text = StepNumber.Text + "<p></p>";
            }

        //var x = diagramView.Diagram.Items.GetAt(0) as SvgNode;
        //Wartezeit
        //System.Threading.Thread.Sleep(2300);
        //Textbox.Text = x.Text;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
            //
            //var test = diagramView.Diagram.ActiveItem;
            //diagramView.Diagram.
    }

    protected void btnPlay_Click(object sender, EventArgs e)
    {

            //for (int j = 0; j < Steps_.StepNumber; j++)// 
            //{
            var j = Steps_.SimCounter;
            Simulation(j);
            Steps_.SimCounter = Steps_.SimCounter + 1;
            if(Steps_.SimCounter >= Steps_.StepNumber)
            {
                Steps_.SimCounter = 0;
            }
            //System.Threading.Thread.Sleep(1000);
            //}
        }

        protected void Simulation(int j)
        {

                for (int i = 0; i < Items_.Counter; i++)
                {
                    var path = "";
                    var x = diagramView.Diagram.Items.GetAt(Items_.Items[i].ID) as SvgNode;

                    if (Steps_.Steps[j, i].Status == 1)
                    {

                        if (Items_.Items[i].Typ == "Pump")
                        {
                            path = "./Pictures/P&ID_SVG/Pump/PUMPS_GENERIC_ACITVE.svg";
                        }
                        if (Items_.Items[i].Typ == "Valve")
                        {
                            path = "./Pictures/P&ID_SVG/Ventil/IN-LINE_VALVES_GENERIC_ACTIVE.svg";
                        }
                    }
                    else
                    {
                        if (Items_.Items[i].Typ == "Pump")
                        {
                            path = "./Pictures/P&ID_SVG/Pump/PUMPS_GENERIC.svg";
                        }
                        if (Items_.Items[i].Typ == "Valve")
                        {
                            path = "./Pictures/P&ID_SVG/Ventil/IN-LINE_VALVES_GENERIC.svg";
                        }
                    }
                    var content = new SvgContent();
                    content.Parse(Server.MapPath(path));
                    x.Content = content;

                }    
        }

    }
}