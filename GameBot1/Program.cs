using AhkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using GameBot1.Action;
using GameBot1.Exceptions;
using System.IO;
namespace GameBot1
{
    class Program
    {
        const string logFolder = @"C:\Users\Achu\Documents\log";
        const string logPrefix = "GameBot1_";
        ////TODO
        //@"C:\Users\Achu\Pictures\SiloCloseButton.png"

        static void Main(string[] args)
        {

            AutoHotkey.ThreadFromText("");
            CropCycleConfiguration hdc = new CropCycleConfiguration();
            Action.Action cropCycle = hdc.GenerateSeedHarvestAndSell();
            Action.Action goHome = hdc.GenerateGoHome();
            Action.Action rescureInvalidState = hdc.GetRescueInvalidState();
            Console.WriteLine("How many iterations to execute?");
            int iterations = 99999;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Starting in:" + (i + 1));
                Thread.Sleep(1000);
            }
            StartIterations(cropCycle, goHome, rescureInvalidState, iterations);
            Console.WriteLine("Press key to exit");
            Console.ReadKey();
        }

        private static void StartIterations(Action.Action cropCycle, Action.Action goHome,
            Action.Action rescureInvalidState, int iterations)
        {
            StreamWriter fs = GetFileStream();
            try
            {
                goHome.ExecuteAll(fs);
                for (int i = 0; i < iterations; i++)
                {
                    try
                    {
                        LogToFileAndConsole(fs, Environment.NewLine + "Executing iteration " + (i + 1));

                        cropCycle.ExecuteAll(fs);
                    }
                    catch (InvalidStateException ise)
                    {
                        LogToFileAndConsole(fs, Environment.NewLine + Environment.NewLine + "invalid state Exception: " + Environment.NewLine + ise);
                        rescureInvalidState.ExecuteAll(fs);
                    }
                }
            }
            catch (Exception e)
            {
                LogToFileAndConsole(fs, "Error mitigation failed\n"+ e);
            }
            finally
            {
                fs.Flush();
                fs.Close();
            }
        }

        private static void LogToFileAndConsole(StreamWriter fs, string errorMessage)
        {
            Console.WriteLine(errorMessage);
            fs.WriteLine(errorMessage);
            fs.Flush();
        }

        private static StreamWriter GetFileStream()
        {
            FileStream fs = File.OpenWrite(Path.Combine(logFolder, logPrefix + DateTime.Now.ToString("yyyyMMddHHmmss")+".log"));
            StreamWriter sw = new StreamWriter(fs);
            return sw;
        }
    }
}
//    Thread.Sleep(3000);
            
//                AutoHotkey.SetVar("OutputVarX", "0");
//                AutoHotkey.SetVar("OutputVarY", "0");
//                AutoHotkey.ExecSimple(@"ImageSearch OutputVarX, OutputVarY, 0, 0, 1000, 1000, *25 C:\Users\Achu\Pictures\wheetSample.png");

//                //	ImageSearch, OutputVarX, OutputVarY, X1, Y1, X2, Y2, *25 C:\Users\Achu\Pictures\wheetSample.png
//                Console.WriteLine("OutputVarX:{0}, OutputVarY:{1},  ErrorLevel:{2}",
//                    AutoHotkey.GetVar("OutputVarX"), AutoHotkey.GetVar("OutputVarY"), AutoHotkey.GetVar("ErrorLevel"));