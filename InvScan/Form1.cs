using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Threading;

namespace InvScan
{

    

    public partial class Form1 : Form
    {
        private BrightIdeasSoftware.TreeListView treeListView;
        private List<Item> data;

        private string Code = "";

        bool ctrlDown = false;
        bool captureScan = false;
        bool HideAvailable = false;

        public Form1()
        {
            InitializeComponent();

            initExplore();

        }

        private void initExplore()
        {

            treeListView = new BrightIdeasSoftware.TreeListView();
            treeListView.Dock = DockStyle.Fill;

            //tabControl1.TabPages[4].Controls.Add(treeListView);

            splitContainer1.Panel1.Controls.Add(treeListView);

            //tabpage5 Controls.Add(treeListView);

            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView.CanExpandGetter = x => (x as Item).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView.ChildrenGetter = x => (x as Item).Children;

            // create the tree columns and set the delegates to print the desired object proerty
            var nameCol = new OLVColumn("Name", "Name");
            nameCol.AspectGetter = x => (x as Item).Name;

            var col1 = new OLVColumn("Place", "Place");
            col1.AspectGetter = x => (x as Item).Place;

            var col2 = new OLVColumn("Available", "Available");
            col2.AspectGetter = x => (x as Item).Available;

            var col3 = new OLVColumn("Code", "Code");
            col3.AspectGetter = x => (x as Item).Code;

            // add the columns to the tree
            this.treeListView.Columns.Add(nameCol);
            this.treeListView.Columns.Add(col1);
            this.treeListView.Columns.Add(col2);
            this.treeListView.Columns.Add(col3);

            // set the tree roots
            this.treeListView.Roots = data;

            treeListView.SelectedIndexChanged += TreeListView_SelectedIndexChanged;
            treeListView.PreviewKeyDown += TreeListView_PreviewKeyDown;
            treeListView.KeyPress += TreeListView_KeyPress;

           // treeListView.

            treeListView.FullRowSelect = true;
            treeListView.HideSelection = false;

            UpdateExplorer();
        }

        private void TreeListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (captureScan && !ctrlDown)
            {
                CodeBox.Text += e.KeyChar.ToString().ToUpper();

                e.Handled = true;
            }
        }

        private void TreeListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrlDown = true;

                //Console.WriteLine("control");

            }

            if (ctrlDown && e.KeyCode == Keys.B)
            {
                captureScan = true;

                //Console.WriteLine("capturin");

                CodeBox.Text = "";

                e.IsInputKey = false;

                //e.Handled = true;
                //e.SuppressKeyPress = true;
            }


            if (ctrlDown && e.KeyCode == Keys.C)
            {
                captureScan = false;

                //Console.WriteLine("not capturin");

                HandleCode();

                e.IsInputKey = false;

                //e.Handled = true;
                //e.SuppressKeyPress = true;

            }
        }

        private void TreeListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                //Console.WriteLine("not control");

                ctrlDown = false;

            }
        }



        private void TreeListView_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (treeListView.SelectedObjects.Count == 1)
            {
                Item itm = (Item)treeListView.SelectedObjects[0];

                ExpNameBox.Text = itm.Name;
                ExpPlaceBox.Text = itm.Place;
                ExpDescBox.Text = itm.Description;

                DeleteButt.Enabled = true;
                UpdateButt.Enabled = true;

            }
            else
            {
                UpdateButt.Enabled = false;

                if (treeListView.SelectedObjects.Count > 1)
                {
                    DeleteButt.Enabled = true;
                }
                else
                {
                    DeleteButt.Enabled = false;
                }

                ExpNameBox.Text = "";
                ExpPlaceBox.Text = "";
                ExpDescBox.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HandleCode();
        }

        private void HandleCode()
        {
            Code = CodeBox.Text.ToUpper();
            CodeLabel.Text = Code;
            CodeBox.Text = "";

            Console.WriteLine("Got:" + Code);

            if (CheckInBox.Checked)
            {
                Console.WriteLine("CheckIn:" + Code);

                List<Item> list = DbWrap.GetList(Code);

                foreach (Item itm in list)
                {
                    itm.SetAvailable(true);
                    Console.WriteLine("In:" + itm.Id);
                    DbWrap.Update(itm);
                }
            }
            else if (CheckOutBox.Checked)
            {
                Console.WriteLine("CheckOut:" + Code);

                List<Item> list = DbWrap.GetList(Code);

                foreach (Item itm in list)
                {
                    itm.SetAvailable(false);
                    Console.WriteLine("Out:" + itm.Id);
                    DbWrap.Update(itm);
                }
            }

            UpdateExplorer();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddButt_Click(object sender, EventArgs e)
        {
            
            Item itm = new Item()
            {
                Name = NameBox.Text,
                Place = PlaceBox.Text,
                Description = DescBox.Text,
                Code = Code
            };

            itm.SetAvailable(true);

            if (ParentBox.Text != "")
            {
                List<Item> list = DbWrap.GetList(ParentBox.Text);
                if (list.Count > 0)
                {
                    list.First().AddChild(itm);
                    DbWrap.Update(list.First());
                    
                }
                else
                {
                    DbWrap.Insert(itm);
                }
            }
            else
            {
                DbWrap.Insert(itm);
            }

            NameBox.Text = "";
            PlaceBox.Text = "";
            DescBox.Text = "";
            
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string name = tabControl1.SelectedTab.Text;

            //MessageBox.Show(name);

            switch (name)
            {
                case "Explore":
                    UpdateExplorer();
                    Console.WriteLine("Explore");
                    break;

                case "CheckIn":
                    //CheckInBox.Checked = true;
                    break;

                case "CheckOut":
                    //CheckOutBox.Checked = true;
                    break;
            }


        }

        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            string name = e.TabPage.Text;

            //MessageBox.Show(name);

            switch (name)
            {
                case "CheckIn":
                    //CheckInBox.Checked = false;
                    break;

                case "CheckOut":
                    //CheckOutBox.Checked = false;
                    break;
            }
        }

        private void UpdateExplorer()
        {
            Thread.Sleep(100);
            
            List<Item> list = DbWrap.GetList();

            data = list;

            this.treeListView.Roots = data;

            treeListView.RebuildAll(true);

            //treeListView.Refresh();

            
        }

        private void CodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void CodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCode();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CheckInButt_Click(object sender, EventArgs e)
        {
            List<Item> list = DbWrap.GetList(Code);

            foreach (Item itm in list)
            {
                itm.SetAvailable(true);
                Console.WriteLine(itm.Id);
                DbWrap.Update(itm);
            }
        }

        private void CheckOutButt_Click(object sender, EventArgs e)
        {
            List<Item> list = DbWrap.GetList(Code);

            foreach (Item itm in list)
            {
                itm.SetAvailable(false);
                DbWrap.Update(itm);
            }
        }

        private void exploreView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        


        private void DeleteButt_Click(object sender, EventArgs e)
        {
            foreach(Item itm in treeListView.SelectedObjects)
            {
                DbWrap.Delete(itm);
            }

            UpdateExplorer();
            
        }

        private void UpdateButt_Click(object sender, EventArgs e)
        {
            Item itm = (Item)treeListView.SelectedObjects[0];

            itm.Name = ExpNameBox.Text;
            itm.Place = ExpPlaceBox.Text;
            itm.Description = ExpDescBox.Text;

            DbWrap.Update(itm);

            UpdateExplorer();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrlDown = true;

                //Console.WriteLine("control");

            }

            if(ctrlDown && e.KeyCode == Keys.B)
            {
                captureScan = true;

                //Console.WriteLine("capturin");

                CodeBox.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            

            if (ctrlDown && e.KeyCode == Keys.C)
            {
                captureScan = false;

                //Console.WriteLine("not capturin");

                HandleCode();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.ControlKey)
            {
                //Console.WriteLine("not control");

                ctrlDown = false;

            }
        }

        private void CheckInBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckInBox.Checked)
            {
                CheckOutBox.Checked = false;

                behaviorLabel.ForeColor = Color.Red;

                behaviorLabel.Text = "Auto CheckIn";

            }
            else
            {
                behaviorLabel.ForeColor = Color.Black;

                behaviorLabel.Text = "Default";
            }

        }

        private void CheckOutBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckOutBox.Checked)
            {
                CheckInBox.Checked = false;

                behaviorLabel.ForeColor = Color.Red;

                behaviorLabel.Text = "Auto CheckOut";

            }
            else
            {
                behaviorLabel.ForeColor = Color.Black;

                behaviorLabel.Text = "Default";
            }
        }

        private void behaviorLabel_Click(object sender, EventArgs e)
        {
            CheckInBox.Checked = false;
            CheckOutBox.Checked = false;
        }

        public ListViewItem SearchInBox(string text)
        {
            string[] words = text.Split(' ');

            string regex = "";

            foreach (string s in words)
            {
                if (s != "")
                {
                    regex += Regex.Escape(s.ToLower()) + ".*?";
                }
            }


            Console.WriteLine(regex);

            for(int i = 0; i < treeListView.GetItemCount();i++)
            {
                ListViewItem Item = treeListView.GetItem(i);
                //Console.WriteLine(Item.SubItems[0].Text);
                if (Regex.IsMatch(Item.SubItems[0].Text.ToLower(), regex))
                {
                    Console.WriteLine(Item.SubItems[0].Text);
                    return Item;

                }
            }


            return null;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            ListViewItem foundItem = SearchInBox(searchBox.Text);
            if (foundItem != null)
            {
                treeListView.TopItem = foundItem;

                for (int i = 0; i < treeListView.GetItemCount(); i++)
                {
                    ListViewItem Item = treeListView.GetItem(i);
                    Item.Selected = false;
                }

                    foundItem.Selected = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (captureScan && !ctrlDown)
            {
                

                CodeBox.Text += e.KeyChar.ToString().ToUpper();

                e.Handled = true;
            }
        }

        private void ParentPasteButt_Click(object sender, EventArgs e)
        {
            ParentBox.Text = Code;
        }
    }
}
