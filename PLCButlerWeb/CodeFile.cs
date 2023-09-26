using PLCButlerWeb;
using System;
using System.IO;

namespace FileOperationFunction
{
    public class FileOperation
    {
        public static string ReadTextOfFile;
        //****************************************************************************
        //HOW TO CALL:
        //using FileFunction;
        //InfoBox.Text = FileOperation.FileOperation_ReadFile("C:\\temp\\Sample.txt");
        //****************************************************************************
        public static string FileOperation_ReadFile(string pathfile)
        {
            String line;
            try
            {
                ReadTextOfFile = "";
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(pathfile);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    ReadTextOfFile = ReadTextOfFile + line;
                    //Read the next line
                    line = sr.ReadLine();
                    ReadTextOfFile = ReadTextOfFile + "\n";
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                return "FileOperation_ReadFile Error \n" + e.Message;
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
            return ReadTextOfFile;
        }

        //****************************************************************************
        //HOW TO CALL:
        //using FileFunction;
        //InfoBox.Text = FileOperation.FileOperation_WriteFile("C:\\temp\\Sample.txt", "Hello World!");
        //****************************************************************************
        public static string FileOperation_WriteFile(string pathfile, string TextOfFile)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(pathfile);
                //Write a line of text
                sw.WriteLine(TextOfFile);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                return ("FileOperation_WriteFile Error \n" + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block."); 
            }
            return ("Executing finally block.");
        }
    }
}