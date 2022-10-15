//***********************************************************************************************
//Programmer: Toton Liantoro
//Date: 8 Sepetember 2022
//Software: Microsoft Visual Studio 2022 Community Edition
//Platform: Microsoft Windows 11 64-bit
//Purpose: To complete the assignment 1 Subject: Apply Advance Object-Oriented Language Skills
//***********************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAssessment
{
    public partial class FrmMain : Form
    {
        private StreamReader fileReader;

        public FrmMain()
        {
            InitializeComponent();
        }

       
        string fileName;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //Set filter for open File dialog 
            dlgOpen.Filter = "Text Files | *.txt";
            if (dlgOpen.ShowDialog() != DialogResult.Cancel)
                fileName = dlgOpen.FileName;

            //Open file for read access
            FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            fileReader = new StreamReader(input);
            btnOpen.Enabled = false;
        }

        private void btnNextRecord_Click(object sender, EventArgs e)
        {
            lstFile.Items.Clear();
            string myNumbers;
            StreamReader file = new StreamReader(fileName);
            List<int> list = new List<int>();
            while ((myNumbers = file.ReadLine()) != null)
            {
                list.Add(int.Parse(myNumbers));
            }

            int[] arr = list.ToArray();
            foreach (int item in arr)
            {
                lstFile.Items.Add(item);
            }
            lblStatus.Text = "Unsorted Data";
            lblStatus.BackColor = System.Drawing.Color.Cyan;
            lstFile.BackColor = System.Drawing.Color.Orange;
        }


        private void btnSort_Click(object sender, EventArgs e)
        {
            lstFile.Items.Clear();
            string myNumbers;
            StreamReader file = new StreamReader(fileName);
            List<int> list = new List<int>();
            while ((myNumbers = file.ReadLine()) != null)
            {
                list.Add(int.Parse(myNumbers));
            }

            int[] arr = list.ToArray();
            Array.Sort(arr);
            foreach (int item in arr)
            {
                lstFile.Items.Add(item);
            }
            lblStatus.Text = "Sorted Data";
            lblStatus.BackColor = System.Drawing.Color.Cornsilk;
            // Change backcolor of listbox to green (sorted)
            lstFile.BackColor = System.Drawing.Color.LightGreen;

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            int [] data = lstFile.Items.OfType<int>().ToArray();
            int top = 0;
            int mid = 99;
            int bottom = lstFile.Items.Count - 1;
            int key;
            bool result = false;
            key = Convert.ToInt32(txtFind.Text);
            while (bottom >= top)
            {
                mid = (top + bottom) / 2;
                if (key == data[mid])
                {
                    result = true;
                    break;
                }
                else
                    if (key < data[mid])
                        bottom = mid - 1;
                    else 
                        top = mid + 1;
            }

            if (result)
                lblTheResult.Text = "Item found as index " + Convert.ToString(mid);

            else
                lblTheResult.Text = "Item not found";

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
            btnSearch.BackColor = System.Drawing.Color.Cyan;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            fileReader.Close();
            Application.Exit();
        }

      
    }
}
