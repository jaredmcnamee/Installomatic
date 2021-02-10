//Project : Intsall-o-Matic
//Nov 03 2019
//by Jared McNamee
//
//Main form
// ///////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab02
{
    public partial class Form1 : Form
    {
        enum Algorithm { eRawList, eLibraryList, eSortedList };//enum to represent the chosen algorithm mainly for readability
        Algorithm selectedAnalyze = new Algorithm(); 
        List<Package> loaded = new List<Package>(); //list of the package class that has been loaded
        List<Package> installable = new List<Package>(); //list of the package class that is ready for install
        List<Package> unInstall = new List<Package>();//list of the package class that either has dependencies yet to be installed or cannot be installed
        public Stopwatch sw = new Stopwatch(); //stop watch for measuring the time it takes to analyze the file

        bool displayFlag = false;



        public Form1()
        {
            InitializeComponent();

            //initalizing the items in the algorithm drop down
            UI_tsCBox_Algorithm.Items.Add("Raw List Access");
            UI_tsCBox_Algorithm.Items.Add("Library Helpers");
            UI_tsCBox_Algorithm.Items.Add("Binary Search");
            //initializing the items in the selected items drop down
            UI_tsCBx_selView.Items.Add("All Packages");
            UI_tsCBx_selView.Items.Add("Loadable Packages");
            UI_tsCBx_selView.Items.Add("Unloadable Packages");

            //setting the attaching the binding source as the data source of the data grid view
            UI_DGV_Display.DataSource = UI_BS_Data;
            
            //initializing and binding all the event functions
            UI_tsBtn_Load.Click += UI_tsBtn_Load_Click;
            UI_tsBtn_Analyze.Click += UI_tsBtn_Analyze_Click;
            UI_tsCBx_selView.SelectedIndexChanged += UI_tsCBx_selView_SelectedIndexChanged;
            UI_DGV_Display.ColumnHeaderMouseClick += UI_DGV_Display_ColumnHeaderMouseClick;
            UI_tsCBox_Algorithm.SelectedIndexChanged += UI_tsCBox_Algorithm_SelectedIndexChanged;
            
        }


        /// <summary>
        /// when the index changes in the algorithm drop down setting the algorithm to the selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_tsCBox_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(UI_tsCBox_Algorithm.SelectedIndex)
            {
                case 0:
                    selectedAnalyze = Algorithm.eRawList;
                    break;
                case 1:
                    selectedAnalyze = Algorithm.eLibraryList;
                    break;
                case 2:
                    selectedAnalyze = Algorithm.eSortedList;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// When the header of the columns are clicked applying a sort based on the column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_DGV_Display_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Applying an alphabetical name sort when the name column is clicked
            if(e.ColumnIndex == 0)
            {
                loaded.Sort(Package.CompareDwName);
                installable.Sort(Package.CompareDwName);
                unInstall.Sort(Package.CompareDwName);
            }

            //applying a numerical sort based on the count when the count column is clicked
            if(e.ColumnIndex == 1)
            {
                loaded.Sort((left, right) => left.Count.CompareTo(right.Count));
                installable.Sort((left, right) => left.Count.CompareTo(right.Count));
                unInstall.Sort((left, right) => left.Count.CompareTo(right.Count));
            }

            //applying a name within count sort when the dependency column is clicked 
            if(e.ColumnIndex == 2)
            {
                loaded.Sort(Package.CompareNwDepdency);
                installable.Sort(Package.CompareNwDepdency);
                unInstall.Sort(Package.CompareNwDepdency);
            }
            //displaying the results to the user
            ShowSelectedLoad();
        }

        /// <summary>
        /// showing the correct list when the index is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_tsCBx_selView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedLoad();
        }
        
        /// <summary>
        /// When the analyze button is pressed applying the select algorithm 
        /// to increment through the loaded list and install the packages that can be installed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_tsBtn_Analyze_Click(object sender, EventArgs e)
        {
            //starting or restarting the stopwatch before the install starts
            sw.Restart();

            //disallowing an empty list to be worked on
            if (loaded != null)
            {
                //copying the loaded list to the uninstalled list
                unInstall = new List<Package>(loaded);
                //clearing the installed list
                installable.Clear();

                //Raw algorithm 
                if (selectedAnalyze == Algorithm.eRawList)
                {
                    //boolean for deciding if the install is complete
                    bool valid = false;
                    //iterating atleast once through the list
                    do
                    {
                        //setting complete flag to false
                        valid = false;
                        //creating a temporary list for package removal
                        List<Package> tempPkg = new List<Package>(unInstall);
                        //interating through the uninstalled packages looking for packages to install
                        for (int i = 0; i < unInstall.Count; i++)
                        {
                            //setting a flag for whether a package may be installed to false
                            bool installFlag = false;
                            //getting a temporay list of the dependencies of the current item in the list
                            List<string> temp = new List<string>(unInstall[i].GetDepends());
                            //if that item has no dependencies flagging for install
                            if (unInstall[i].Count < 1)
                            {
                                installFlag = true;
                            }
                            //otherwise looking to see if the dependencies have been installed
                            for (int j = 0; j < temp.Count(); j++)
                            {
                                for (int k = 0; k < installable.Count; k++)
                                {
                                    //if every member of the temp list is in the installed list flagging for install
                                    if(temp[j].Equals(installable[k].Name))
                                    {
                                        installFlag = true;
                                        break;
                                    }
                                    //otherwise not installing
                                    installFlag = false;
                                }
                                //if not flaged for install breaking out of the for loop
                                if (!installFlag)
                                    break;
                            }
                            //if flagged adding to the installed list
                            if (installFlag)
                            {
                                installable.Add(unInstall[i]);
                                //flagging to end if we are at the end of the list
                                valid = true;
                            }
                            //iterating through the installed items and removing from the temporary list
                            for (int j = 0; j < installable.Count; j++)
                            {
                                if (unInstall[i].Equals(installable[j])) tempPkg.Remove(unInstall[i]);
                            }
                        }
                        //removing the appropriate items from the uninstallable list
                        unInstall = tempPkg;
                    } while (valid);
                }
                //library functions
                if(selectedAnalyze == Algorithm.eLibraryList)
                {
                    //boolean for deciding if the install is complete
                    bool valid = false;
                    //iterating atleast once through the list
                    do
                    {
                        //setting complete flag to false
                        valid = false;
                        //creating a temporary list for package removal
                        List<Package> tempPkg = new List<Package>(unInstall);
                        //iterating throught the uninstallables and checking to see if there are any packages to install
                        foreach (Package pkg in unInstall)
                        {
                            //getting a temporay list of the dependencies of the current item in the list
                            List<string> temp = new List<string>(pkg.GetDepends());
                            //if the package has no dependencies or the package contains only packages that have been installed 
                            //adding to installed list
                            if ( pkg.Count == 0 || temp.TrueForAll(x => installable.Contains(new Package(x))))
                            {
                                installable.Add(pkg);
                                //flagging to complete  the install if this is the last item
                                valid = true;
                            }
                            //removing the installed items from the temp list
                            if (installable.Contains(pkg)) tempPkg.Remove(pkg);
                        }
                        //copying the temp to the uninstallable list
                        unInstall = tempPkg;
                    } while (valid);
                }
                //the Binary search algorithm
                if(selectedAnalyze == Algorithm.eSortedList)
                {
                    //boolean for deciding if the install is complete
                    bool valid = false;
                    //iterating atleast once through the list
                    do
                    {
                        //setting complete flag to false
                        valid = false;
                        //creating a temporary list for package removal
                        List<Package> tempPkg = new List<Package>(unInstall);
                        //iterating throught the uninstallables and checking to see if there are any packages to install
                        foreach (Package pkg in unInstall)
                        {
                            //getting a temporay list of the dependencies of the current item in the list
                            List<string> temp = new List<string>(pkg.GetDepends());

                            //if the package has no dependencies or the package contains only packages that have been installed 
                            //adding to installed list
                            if (pkg.Count == 0 || temp.TrueForAll(x => installable.BinarySearch(new Package(x)) >= 0))
                            {
                                //inserting the new package at the position that is its binary compliment in the index
                                installable.Insert(~installable.BinarySearch(pkg),pkg);
                                //flagging to complete  the install if this is the last item
                                valid = true;
                            }
                            //removing the installed items from the temp list
                            if (installable.Contains(pkg)) tempPkg.Remove(pkg);
                        }
                        //copying the temp to the uninstallable list
                        unInstall = tempPkg;
                    } while (valid);
                }
            }
            //stopping the stop watch 
            sw.Stop();
            //displaying the time to analyze to the user
            Ui_tsLBL_time.Text = $"Analyze time: <{sw.ElapsedMilliseconds}> ";

            UI_tsCBx_selView.SelectedIndex = 1;
            //displaying the selected list to the user
            ShowSelectedLoad();
        }

        /// <summary>
        /// when the load button is clicked attempting to load a file to be installed into the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_tsBtn_Load_Click(object sender, EventArgs e)
        {
            //clearing the lists
            loaded.Clear();
            installable.Clear();
            unInstall.Clear();

            //clearing the data grid view
            UI_DGV_Display.Rows.Clear();
            UI_DGV_Display.Refresh();

            

            //setting the indexes of the drop downs back to the defaults
            UI_tsCBox_Algorithm.SelectedIndex = 0;
            UI_tsCBx_selView.SelectedIndex = 0;

            //updating the labels of the app
            Ui_tsLbl_Loaded.Text = loaded.Count + " Packages Loaded";
            UI_tsLbl_Installable.Text = installable.Count + " Packages Installable";
            Ui_tsLbl_Uninstallable.Text = unInstall.Count + " Packages Uninstallable";

            //creating a open file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            //setting the intial directory to the base directory of the project file
            ofd.InitialDirectory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\PackageTestFiles");
            //filtering for only text files and all files
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 1;

            //if the dialog has its ok button pressed
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                //reading all lines to a temporary string
                string[] temp = File.ReadAllLines(ofd.FileName);
                //foreach string in the temp file
                foreach (string s in temp)
                {
                    //trimming any whitespace from the end
                    string removeNull = s.TrimEnd();
                    //creating a new package at every space
                    Package p = new Package(removeNull.Split(' '));
                    //if the loaded does not contain the package adding it to the list
                    if (!loaded.Contains(p))
                        loaded.Add(p);
                    //otherwise merging it with the package that is in the list
                    else
                    {
                        p.MergePackage(loaded[loaded.IndexOf(p)]);
                    }
                }
                //setting the seleced index to the default
                UI_tsCBx_selView.SelectedIndex = 0;
                //and displaying tot he user

                if (loaded.Max(x => x.Count) > 10)
                    displayFlag = true;
                ShowSelectedLoad();
                
            }
        }
        /// <summary>
        /// this function will display the selected list
        /// </summary>
        public void ShowSelectedLoad()
        {
            //setting the binding sources data to null
            UI_BS_Data.DataSource = null;
            //swapping the data source to the selected index of the list drop down
            if(UI_tsCBx_selView.SelectedIndex == 0)
            {
                UI_BS_Data.DataSource = loaded;
            }
            if(UI_tsCBx_selView.SelectedIndex == 1)
            {
                UI_BS_Data.DataSource = installable;
            }
            if(UI_tsCBx_selView.SelectedIndex == 2)
            {
                UI_BS_Data.DataSource = unInstall;
            }

            //sizing the data grid view to the displayed cells
            UI_DGV_Display.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //filling the rest of the view with the last cell
            UI_DGV_Display.Columns[UI_DGV_Display.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (displayFlag)
                UI_DGV_Display.Columns[UI_DGV_Display.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //freezing the first two columns
            UI_DGV_Display.Columns[0].Frozen = UI_DGV_Display.Columns[1].Frozen = true;
           
            //updating the display lists for the user
            Ui_tsLbl_Loaded.Text = loaded.Count + " Packages Loaded";
            UI_tsLbl_Installable.Text = installable.Count + " Packages Installable";
            Ui_tsLbl_Uninstallable.Text = unInstall.Count + " Packages Uninstallable";
        }
    }
}
