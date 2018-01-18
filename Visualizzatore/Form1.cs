/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace Visualizzatore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var url = "";
            var arg = Environment.GetCommandLineArgs();

            foreach (var a in arg)
                url = a;

            var p = System.Reflection.Assembly.GetExecutingAssembly().Location;
            p = System.IO.Path.GetDirectoryName(p);
            p = System.IO.Path.Combine(p, "graphviz");
            p = System.IO.Path.Combine(p, url);

            this.Text = "Visualizzatore grafo - " + p;

            webBrowser1.Navigate(new Uri(p));
        }


    }
}