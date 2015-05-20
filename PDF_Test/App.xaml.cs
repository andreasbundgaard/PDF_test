﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PDF_Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //ReaderController _RDR;
        private void App_Startup(object sender, StartupEventArgs e)
        {
            string output = "";
            for (int i = 0; i < e.Args.Length; i++)
            {
                if (e.Args[i].Contains(".txt")) {
                    output = e.Args[i];
                }
            }
            MessageBox.Show(output);
        }
    }
}
