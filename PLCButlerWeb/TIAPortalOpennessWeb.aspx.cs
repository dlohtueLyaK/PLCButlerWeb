using System;
using System.Collections.Generic;
using System.IO;

//TIA function from *.dll System.Engineering
//to find in references
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.Tags;

using Siemens.Engineering.SW.Types;
using HmiTarget = Siemens.Engineering.Hmi.HmiTarget;
using Siemens.Engineering.Hmi.Tag;
using Siemens.Engineering.Hmi.Screen;
using Siemens.Engineering.Hmi.RuntimeScripting;

using Library;
using System.Runtime.InteropServices;
using System.Net;
using FileOperationFunction;

namespace PLCButlerWeb
{    
    static class ProjectTyps
    {
        //MyTiaPortal is necessary to run the instance to run TIA Portal
        public static TiaPortal MyTiaPortal;

        //MyProject is necessary to get access to the project in TIA
        //access, open, save, close...
        public static Project MyProject;

        //PlcSoftware is necessary to load in the TIA project
        //objects and get access to global variables
        public static PlcSoftware Software;

        //HmiTarget is necessary to get access to HMI device
        public static HmiTarget Hmitarget;
    }

public partial class TIAPortalOpennessWeb : System.Web.UI.Page
    {
        private TiaPortalProcess _tiaProcess;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //*****************
        //BLOCK IMPORT
        //*****************
        private void ImportBlocks(PlcSoftware plcSoftware)
        {
            //check if XMLPath.Text is empty
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //import FC, FB, OB, DB
                    if (ImportTyp.SelectedIndex == 0 && Group.Text == "")
                    {
                        PlcBlockGroup blockGroup = plcSoftware.BlockGroup;
                        IList<PlcBlock> blocks = blockGroup.Blocks.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import  FC, FB, OB, DB to virtual group
                    if (ImportTyp.SelectedIndex == 0 && Group.Text != "")
                    {
                        PlcBlockGroup blockGroup = plcSoftware.BlockGroup;
                        PlcBlockComposition plcBlocks = blockGroup.Blocks;
                        blockGroup.Groups.Find(Group.Text).Blocks.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import UDT
                    if (ImportTyp.SelectedIndex == 2 && Group.Text == "")
                    {
                        PlcTypeComposition types = plcSoftware.TypeGroup.Types;
                        IList<PlcType> importedTypes = types.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import UDT to virtual group
                    if (ImportTyp.SelectedIndex == 2 && Group.Text != "")
                    {
                        PlcTypeGroup plcTypeGroup = plcSoftware.TypeGroup;
                        PlcTypeComposition types = plcSoftware.TypeGroup.Types;
                        plcTypeGroup.Groups.Find(Group.Text).Types.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import PLC TAG
                    if (ImportTyp.SelectedIndex == 1 && Group.Text == "")
                    {
                        PlcTagTableSystemGroup plcTagTableSystemGroup = plcSoftware.TagTableGroup;
                        PlcTagTableComposition tagTables = plcTagTableSystemGroup.TagTables;
                        tagTables.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import PLC TAG to virtual group
                    if (ImportTyp.SelectedIndex == 1 && Group.Text != "")
                    {
                        PlcTagTableSystemGroup plcTagTableSystemGroup = plcSoftware.TagTableGroup;
                        PlcTagTableComposition tagTables = plcTagTableSystemGroup.TagTables;
                        plcTagTableSystemGroup.Groups.Find(Group.Text).TagTables.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    InfoBox.Text = "Block imported.";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while adding block" + ex.Message;
                }
            }
        }

        //*********************
        //BLOCK EXPORT
        //*********************
        private void ExportBlocks(PlcSoftware plcSoftware)
        {
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //check if XMLPath.Text is empty
                    //export FC, FB, OB, DB
                    if (ImportTyp.SelectedIndex == 0 && Group.Text == "")
                    {
                        PlcBlock plcBlocks = plcSoftware.BlockGroup.Blocks.Find(ExportName.Text);
                        // ExportOptions.WithDefaults = standard values | ExportOptions.WithReadOnly = only readable values
                        plcBlocks.Export(new FileInfo(string.Format(@XMLPath.Text, plcBlocks.Name)), ExportOptions.WithDefaults | ExportOptions.WithReadOnly);
                        InfoBox.Text = "Block exported.";
                    }
                    //export FC, FB, OB, DB to virtual group
                    if (ImportTyp.SelectedIndex == 0 && Group.Text != "")
                    {
                        PlcBlockGroup blockGroup = plcSoftware.BlockGroup.Groups.Find(Group.Text);
                        PlcBlock plcBlocks = blockGroup.Blocks.Find(ExportName.Text);
                        plcBlocks.Export(new FileInfo(string.Format(@XMLPath.Text, plcBlocks.Name)), ExportOptions.WithDefaults | ExportOptions.WithReadOnly);
                        InfoBox.Text = "Block exported from group.";
                    }

                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while adding block" + ex.Message;
                }
            }
        }

        //*********************
        //HMI SCREEN IMPORT
        //*********************
        private void ImportSingleScreenWithFacepalteInstance(HmiTarget Hmitarget)
        {
            //check if XMLPath.Text is empty
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //import HMI screen
                    if (ImportTyp.SelectedIndex == 3 && Group.Text == "")
                    {
                        Hmitarget.ScreenFolder.Screens.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import HMI screen to virtual group
                    if (ImportTyp.SelectedIndex == 3 && Group.Text != "")
                    {
                        ScreenUserFolder folder = Hmitarget.ScreenFolder.Folders.Find(Group.Text);
                        ScreenComposition screens = folder.Screens;
                        folder.Screens.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    InfoBox.Text = "Screen imported.";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while import screen" + ex.Message;
                }
            }
        }

        //*****************************
        //HMI SCREEN-TEMPLATE IMPORT
        //*****************************
        private void ImportScreenTemplatesToHMITarget(HmiTarget Hmitarget)
        {
            //check if XMLPath.Text is empty
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //import HMI-template
                    if (ImportTyp.SelectedIndex == 4 && Group.Text == "")
                    {
                        Hmitarget.ScreenTemplateFolder.ScreenTemplates.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import HMI-template to virtual group
                    if (ImportTyp.SelectedIndex == 4 && Group.Text != "")
                    {
                        ScreenTemplateUserFolder screenTemplatefolder = Hmitarget.ScreenTemplateFolder.Folders.Find(Group.Text);
                        ScreenTemplateComposition screens = screenTemplatefolder.ScreenTemplates;
                        screenTemplatefolder.ScreenTemplates.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    InfoBox.Text = "Template picture imported!";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while import template picture" + ex.Message;
                }
            }
        }

        //**********************
        // HMI-PopUp IMPORT
        //**********************
        private void ImportPopUpScreenToHMITarget(HmiTarget Hmitarget)
        {
            //check if XMLPath.Text is empty
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //import HMI picture
                    if (ImportTyp.SelectedIndex == 5 && Group.Text == "")
                    {
                        Hmitarget.ScreenPopupFolder.ScreenPopups.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import HMI picture to group
                    if (ImportTyp.SelectedIndex == 5 && Group.Text != "")
                    {
                        ScreenPopupUserFolder screenPopUpfolder = Hmitarget.ScreenPopupFolder.Folders.Find(Group.Text);
                        ScreenPopupComposition screens = screenPopUpfolder.ScreenPopups;
                        screenPopUpfolder.ScreenPopups.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    InfoBox.Text = "Screen popup picture imported.";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while import popup picture" + ex.Message;
                }
            }
        }

        //********************************
        //HMI-TAG TABLES IMPORT
        //********************************
        private void ImportSingleHMITagTable(HmiTarget Hmitarget)
        {
            //check if XMLPath.Text is empty
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //import HMI- tag table
                    if (ImportTyp.SelectedIndex == 6 && Group.Text == "")
                    {
                        Hmitarget.TagFolder.TagTables.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    //import HMI- tag table to virtual group
                    if (ImportTyp.SelectedIndex == 6 && Group.Text != "")
                    {
                        TagUserFolder folder = Hmitarget.TagFolder.Folders.Find(Group.Text);
                        TagTableComposition tables = folder.TagTables;
                        folder.TagTables.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                        Hmitarget.TagFolder.Folders.Find(Group.Text).TagTables.Import(new FileInfo(@XMLPath.Text), ImportOptions.Override);
                    }
                    InfoBox.Text = "Picture imported.";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while import picture" + ex.Message;
                }
            }
        }

        //*************************
        //HMI VB-SCRIPT IMPORT
        //*************************
        private void ImportSingleVBScriptToHMITarget(HmiTarget Hmitarget)
        {
            //check if XMLPath.Text empty
            if (string.IsNullOrEmpty(XMLPath.Text) == false)
            {
                try
                {
                    //import HMI VB-Scrip
                    if (ImportTyp.SelectedIndex == 7 && Group.Text == "")
                    {
                        VBScriptSystemFolder vbScriptFolder = Hmitarget.VBScriptFolder;
                        VBScriptComposition vbScripts = vbScriptFolder.VBScripts;
                        if (vbScripts == null) return;
                        {
                            FileInfo info = new FileInfo(@XMLPath.Text);
                            vbScripts.Import(info, ImportOptions.None);
                        }
                    }
                    //import HMI VB-Script to virtual group
                    if (ImportTyp.SelectedIndex == 7 && Group.Text != "")
                    {
                        VBScriptUserFolder vbScriptFolder = Hmitarget.VBScriptFolder.Folders.Find(Group.Text);
                        VBScriptComposition vbScripts = vbScriptFolder.VBScripts;
                        if (vbScripts == null) return;
                        {
                            FileInfo info = new FileInfo(@XMLPath.Text);
                            vbScripts.Import(info, ImportOptions.None);
                        }
                    }
                    InfoBox.Text = "Script imported.";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while import script" + ex.Message;
                }
            }
        }

        //***************************
        //CREATE VIRTUAL GROUP 
        //***************************
        private void CreateBlockGroup(PlcSoftware plcsoftware)
        {
            //check if Group.Text is empty
            if (string.IsNullOrEmpty(Group.Text) == false)
            {
                try
                {
                    //create virutal group for FC, FB, DB, OB
                    if (ImportTyp.SelectedIndex == 0 && Group.Text != "")
                    {
                        PlcBlockSystemGroup systemGroup = plcsoftware.BlockGroup;
                        PlcBlockUserGroupComposition groupComposition = systemGroup.Groups;
                        PlcBlockUserGroup myCreatedGroup = groupComposition.Create(Group.Text);
                    }
                    //create virtual group for UDT
                    if (ImportTyp.SelectedIndex == 2 && Group.Text != "")
                    {
                        PlcTypeSystemGroup systemGroup = plcsoftware.TypeGroup;
                        PlcTypeUserGroupComposition groupComposition = systemGroup.Groups;
                        PlcTypeUserGroup myCreatedGroup = groupComposition.Create(Group.Text);
                    }
                    //create virtual group for tag table
                    if (ImportTyp.SelectedIndex == 1 && Group.Text != "")
                    {
                        PlcTagTableSystemGroup systemGroup = plcsoftware.TagTableGroup;
                        PlcTagTableUserGroupComposition groupComposition = systemGroup.Groups;
                        PlcTagTableUserGroup myCreatedGroup = groupComposition.Create(Group.Text);
                    }
                    //create virtual group for screen
                    if (ImportTyp.SelectedIndex == 3 && Group.Text != "")
                    {
                        ProjectTyps.Hmitarget.ScreenFolder.Folders.Create(Group.Text);
                    }
                    //create group for screen templates
                    if (ImportTyp.SelectedIndex == 4 && Group.Text != "")
                    {
                        ProjectTyps.Hmitarget.ScreenTemplateFolder.Folders.Create(Group.Text);
                    }
                    //create virtual group for HMI tag
                    if (ImportTyp.SelectedIndex == 6 && Group.Text != "")
                    {
                        ProjectTyps.Hmitarget.TagFolder.Folders.Create(Group.Text);
                    }
                    //create virtual group for VB-Script
                    if (ImportTyp.SelectedIndex == 7 && Group.Text != "")
                    {
                        ProjectTyps.Hmitarget.VBScriptFolder.Folders.Create(Group.Text);
                    }
                    InfoBox.Text = "Group created.";
                }
                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while creating group" + ex.Message;
                }
            }
        }

        //***************
        //OPEN PROJECT
        //***************
        private void OpenProject_()
        {
            //check if Group.Text is empty
            if (string.IsNullOrEmpty(ProjectPath.Text) == false)
            {
                try
                {
                    //open project 
                    ProjectTyps.MyProject = ProjectTyps.MyTiaPortal.Projects.Open(new FileInfo(ProjectPath.Text));
                    InfoBox.Text = "Project open.";
                }

                catch (Exception ex)
                {
                    //error output
                    InfoBox.Text = "Error while opening project" + ex.Message;
                }
            }
            else
            {
                InfoBox.Text = "Project path is empty.";
            }
        }

        //***************************
        //START SIEMENS TIA PORTAL
        //***************************
        protected void TIAStart_Click(object sender, EventArgs e)
        {
            //start Siemens TIA Portal WITH interface         
            ProjectTyps.MyTiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);

            //start Siemens TIA Portal WITHOUT Interface
            //MyTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);
            InfoBox.Text = "TIA Protal gestartet!";
        }

        //****************************
        //CONNECT SIEMENS TIA PORTAL
        //****************************
        protected void ConnectToTIA_Click(object sender, EventArgs e)
        {
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            _tiaProcess = processes[0];
            ProjectTyps.MyTiaPortal = _tiaProcess.Attach();
            switch (processes.Count)
            {
                case 1:
                    _tiaProcess = processes[0];
                    ProjectTyps.MyTiaPortal = _tiaProcess.Attach();

                    if (ProjectTyps.MyTiaPortal.Projects.Count <= 0)
                    {
                        InfoBox.Text = "TIA Portal connected!";
                        return;
                    }
                    ProjectTyps.MyProject = ProjectTyps.MyTiaPortal.Projects[0];
                    break;
                //error output
                case 0:
                    InfoBox.Text = "No running instance of TIA Portal was found!";
                    return;
                default:
                    InfoBox.Text = "More than one running instance of TIA Portal was found!";
                    return;
            }
        }

        //**********************************
        //OPEN SIEMENS TIA PORTAL PROJECT
        //**********************************
        protected void OpenProject_Click(object sender, EventArgs e)
        {
            OpenProject_();          
            try
            {
                foreach (Device device in ProjectTyps.MyProject.Devices)
                {
                    DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                    foreach (DeviceItem deviceItem in deviceItemAggregation)
                    {
                        SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                        if (softwareContainer != null)
                        {
                            try
                            {
                                if (softwareContainer.Software is PlcSoftware)
                                {
                                    ProjectTyps.Software = softwareContainer.Software as PlcSoftware;
                                    if (ProjectTyps.Software != null)
                                    {
                                        InfoBox.Text = "PLC found!";
                                    }
                                }
                                if (softwareContainer.Software is HmiTarget)
                                {
                                    ProjectTyps.Hmitarget = softwareContainer.Software as HmiTarget;
                                    if (ProjectTyps.Hmitarget != null)
                                    {
                                        InfoBox.Text = InfoBox.Text + "HMI found!";

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //error output
                                InfoBox.Text = "Error while finding device" + ex.Message;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //error output
                InfoBox.Text = "Error while opening project" + ex.Message;
            }
        }

        //***********************************************
        //CALL FUNCTION FOR EACH CASE OF TYP IMPORT
        //***********************************************
        protected void Import_Click(object sender, EventArgs e)
        {
            if(ImportTyp.SelectedIndex == 0)
            {
                //FC, DB, FB, OB
                ImportBlocks(ProjectTyps.Software);
            }
            if (ImportTyp.SelectedIndex == 1)
            {
                //TAG
                ImportBlocks(ProjectTyps.Software);
            }
            if (ImportTyp.SelectedIndex == 2)
            {
                //UDT
                ImportBlocks(ProjectTyps.Software);
            }
            if (ImportTyp.SelectedIndex == 3)
            {
                //HMI picture
                ImportSingleScreenWithFacepalteInstance(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 4)
            {
                //HMI template
                ImportScreenTemplatesToHMITarget(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 5)
            {
                //HMI popup
                ImportPopUpScreenToHMITarget(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 6)
            {
                //HMI variable
                ImportSingleHMITagTable(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 7)
            {
                //HMI VB-script
                ImportSingleVBScriptToHMITarget(ProjectTyps.Hmitarget);
            }
        }

        //***********************************************
        //CALL FUNCTION FOR EACH CASE OF TYP EXPORT
        //***********************************************
        protected void Export_Click(object sender, EventArgs e)
        {
            if (ImportTyp.SelectedIndex == 0)
            {
                //FC, DB, FB, OB
                ExportBlocks(ProjectTyps.Software);
            }
            if (ImportTyp.SelectedIndex == 1)
            {
                //TAG
                ExportBlocks(ProjectTyps.Software);
            }
            if (ImportTyp.SelectedIndex == 2)
            {
                //UDT
                ExportBlocks(ProjectTyps.Software);
            }
            /*
            if (ImportTyp.SelectedIndex == 3)
            {
            //HMI picture
                ExportSingleScreenWithFacepalteInstance(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 4)
            {
            //HMI template
                ExportScreenTemplatesToHMITarget(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 5)
            {
            //HMI popup
                ExportPopUpScreenToHMITarget(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 6)
            {
            //HMI variable
                ExportSingleHMITagTable(ProjectTyps.Hmitarget);
            }
            if (ImportTyp.SelectedIndex == 7)
            {
            //HMI VB-script
                ExportSingleVBScriptToHMITarget(ProjectTyps.Hmitarget);
            }
            */
        }

        //*******************************************
        //CALL FUNCTION CREATE VIRTUAL GROUP
        //*******************************************
        protected void CreateGroup_Click(object sender, EventArgs e)
        {
            CreateBlockGroup(ProjectTyps.Software);
        }

        //*******************************************
        //CALL FUNCTION SAVE AND DISCONNECT
        //*******************************************
        protected void DisconnectAndSave_Click(object sender, EventArgs e)
        {
            try
            {
                //save project
                ProjectTyps.MyProject.Save();
            }
            catch (Exception ex)
            {
                //error output
                InfoBox.Text = "Error while closing project" + ex.Message;
            }
            finally
            {
                try
                {
                    //close project
                    ProjectTyps.MyProject.Close();
                }
                catch (Exception ex)
                {
                    //output
                    InfoBox.Text = "Error while shutdown" + ex.Message;
                }
            }
            try
            {
                if (ProjectTyps.MyTiaPortal != null)
                {
                    //disconnect Siemens TIA Portal
                    ProjectTyps.MyTiaPortal.Dispose();
                    //output 
                    InfoBox.Text = "Disconnected to Siemens TIA Portal!";
                }
            }
            catch (Exception ex)
            {
                //error output
                InfoBox.Text = "Error while closing project" + ex.Message;
            }
        }
    }  
}
