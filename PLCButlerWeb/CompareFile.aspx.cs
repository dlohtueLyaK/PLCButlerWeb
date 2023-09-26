using System;
using System.IO;
//using System.Net;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Microsoft.Ajax.Utilities;
//using Microsoft.Win32;
//using System.Windows;
//using Microsoft.AspNetCore.Http;

namespace PLCButlerWeb
{
    public partial class CompareFile : System.Web.UI.Page
    {

        void Page_Load(object sender, EventArgs e)
        {
            // Convert.ToString -> String erstellen
            // Variable.Text -> Information in der Textbox
            // Variable.Substring(0,1) -> erstes Zeichen

        }

        public void ClearButton_Click(object sender, EventArgs e)
        {
            ResultCompare1.Text = String.Empty;
            ResultCompare2.Text = String.Empty;
        }

        public void Path1Button_Click(object sender, EventArgs e)
        {

        }

        // public void OnPost(IFormFile file)
        // {
        //     CompareTextBox1.Text = Convert.ToString(file);
        // }

        public void CompareButton_Click(object sender, EventArgs e)
        {
            int i = 0;

            ResultCompare1.Text = String.Empty;
            ResultCompare2.Text = String.Empty;

            // lade Pfad eins
            string CompareTextboxString1 = Convert.ToString(CompareTextBox1.Text);

            //example for getting the filename but not the full path
            //string CompareTextboxString1 = filepath1.Value;

            // lade Pfad zwei
            string CompareTextBoxString2 = Convert.ToString(CompareTextBox2.Text);


            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr1 = new StreamReader(CompareTextboxString1);
                StreamReader sr2 = new StreamReader(CompareTextBoxString2);

                //Read the first line of text
                string line1 = sr1.ReadLine();
                string line2 = sr2.ReadLine();


                //Continue to read until you reach end of file
                while (line1 != null && line2 != null)
                {
                    //write the line to the result textbox
                    if (line1 != line2)
                    {
                        ResultCompare1.Text = ResultCompare1.Text + "\n" + i + "\t" + line1;
                        ResultCompare2.Text = ResultCompare2.Text + "\n" + i + "\t" + line2;
                    }
                    else { }
                    //read next line
                    line1 = sr1.ReadLine();
                    line2 = sr2.ReadLine();
                    //count line
                    i++;
                }

                //close file
                sr1.Close();
                sr2.Close();
            }
            catch (Exception ex)
            {
                ResultCompare1.Text = "Exception: " + ex.Message;
            }
            finally
            {
                //ResultCompare1.Text = ResultCompare1.Text + "Executing finally block.";
            }
            /*
                for (int i = 0; i < CompareTextboxString1.Length; i++)
            {
                if(CompareTextboxString1.Substring(i, 1) != CompareTextBoxString2.Substring(i, 1))
                {
                    //ResultCompare.BackColor = Color.Red;
                    ResultCompare.Text = ResultCompare.Text + CompareTextboxString1.Substring(i, 1);
                }           
            }
            */
        }

    }
}