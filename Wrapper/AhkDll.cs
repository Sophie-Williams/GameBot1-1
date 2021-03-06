﻿using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace AhkWrapper
{
    public partial class AutoHotkey
    {        
        /// <summary>
        /// Start a new thread with text from a file loaded
        /// </summary>
        /// <param name="FilePath">The absolute or relative path of the file 
        /// containing AutoHotkey compatible code</param>
        public static void ThreadFromFile(string FilePath) {
            AhkDllFlat.ahkdll( FilePath, null, null );
        }

        /// <summary>
        /// Start a new AutoHotkey thread.  This (or ThreadFromFile) must be
        /// called before other member functions can be called.
        /// </summary>
        /// <param name="Code">This plain-text code will be launched with the 
        /// new thread.  Leave it blank to use the defaults (#Persistent and 
        /// #NoTrayIcon).</param>
        public static void ThreadFromText(string Code) {
            AhkDllFlat.ahktextdll( Code, "", "" );
        }

        public static Thread ThreadFromText(string Code, bool UseDebug) {
            if (UseDebug)
            {
                return AhkDllFlat.ahktextdll(Code, "/Debug", "");
            }

            else
            {
                return AhkDllFlat.ahktextdll(Code, "", "");
            }
        }

        /// <summary>
        /// Run some code instantly.  The thread will be paused until the code
        /// has finished executing.
        /// </summary>
        /// <param name="Code">The AutoHotkey code to be run</param>
        /// <returns>The output of the code</returns>
        public static string Exec(string Code) {
            // prefix is inserted before each executed line.  The variable
            // name was choosen because it's generally bad practice to use
            // variable names starting with "A_" due to their use as built-
            // in-variables.  The user may also refer to A_LASTRETURN in 
            // following lines of code.
            const string prefix = "A_LASTRETURN := ";
            AhkDllFlat.ahkExec( prefix + Code );
            return AutoHotkey.Var["A_LASTRETURN"];
        }

        /// <summary>
        /// Execute code instantly discarding the result.
        /// </summary>
        /// <param name="Code">The AutoHotkey code to be run</param>
        /// <returns>true for sucess, otherwise false</returns>
        public static bool ExecSimple(string Code) {
            return AhkDllFlat.ahkExec( Code );
        }

        /// <summary>
        /// Get the string representation of a variable as reported by AutoHotkey
        /// </summary>
        /// <param name="VarName">The name of the variable to ask for</param>
        /// <returns>The variable's value, or a blank string if unset</returns>
        public static string GetVar(string VarName) {
            // Get a pointer to the variable
            IntPtr p = AhkDllFlat.ahkgetvar( VarName, false );
            return Marshal.PtrToStringAuto( p );
        }

        /// <summary>
        /// Assign a new value to a variable
        /// </summary>
        /// <param name="VarName">The name of the variable to set</param>
        /// <param name="NewValue">The new value of the variable</param>
        public static void SetVar(string VarName, string NewValue) {
            AhkDllFlat.ahkassign( VarName, NewValue );
        }

        /// <summary>
        /// Allows getting and setting AutoHotkey variables with an indexer.
        /// This is equivilent to calling GetVar or SetVar
        /// </summary>
        static DllVariableIndexer _configurationManager = new DllVariableIndexer();

        /// <summary>
        /// Allows getting and setting AutoHotkey variables with an indexer.
        /// This is equivilent to calling GetVar or SetVar
        /// </summary>
        public static DllVariableIndexer Var {
            get {
                return _configurationManager;
            }
        }
    }
}
