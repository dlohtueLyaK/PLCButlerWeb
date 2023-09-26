using Microsoft.Ajax.Utilities;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW;
using Siemens.Engineering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PLCButlerWeb.function
{
    //*********************
    //BLOCK EXPORTIEREN
    //*********************
    public partial class CallExport
    {
        public void ExportBlocks(PlcSoftware plcSoftware, string XMLPath, string ExportName, string InfoBox)
        {
            if (string.IsNullOrEmpty(XMLPath) == false)
            {
                try
                {
                    //Überprüfen ob XMLPath.Text leer ist
                    PlcBlock plcBlocks = plcSoftware.BlockGroup.Blocks.Find(ExportName);
                    plcBlocks.Export(new FileInfo(string.Format(@XMLPath, plcBlocks.Name)), ExportOptions.WithDefaults);
                }

                catch (Exception ex)
                {
                    //Fehlerausgabe
                    InfoBox = "Error while adding block" + ex.Message;
                }
            }
        }
    }
}

