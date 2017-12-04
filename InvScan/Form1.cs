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

namespace InvScan
{



    public partial class Form1 : Form
    {
        private string Code = "";

        bool ctrlDown = false;
        bool captureScan = false;
        bool HideAvailable = false;

        public Form1()
        {
            InitializeComponent();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HandleCode();
        }

        private void HandleCode()
        {
            Code = CodeBox.Text;
            CodeLabel.Text = Code;
            CodeBox.Text = "";


            if (CheckInBox.Checked)
            {
                List<Item> list = DbWrap.GetList(Code);

                foreach (Item itm in list)
                {
                    itm.Available = true;
                    Console.WriteLine(itm.Id);
                    DbWrap.Update(itm);
                }
            }
            else if (CheckOutBox.Checked)
            {
                List<Item> list = DbWrap.GetList(Code);

                foreach (Item itm in list)
                {
                    itm.Available = false;
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
            Item itm = new Item {
                Name = NameBox.Text,
                Place = PlaceBox.Text,
                Description = DescBox.Text,
                Code = Code,
                Available = true
            };

            DbWrap.Insert(itm);


            NameBox.Text = "";
            PlaceBox.Text = "";
            DescBox.Text = "";

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbWrap.Debug();
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
            exploreView.Items.Clear();

            List<Item> list = DbWrap.GetList();

            foreach(Item itm in list)
            {

                if (!(HideAvailable && itm.Available))
                {

                    string Available = (itm.Available ? "Yes" : "No");

                    string[] row = { itm.Name, itm.Name, Available, itm.Code };
                    var listViewItem = new ListViewItem(row);

                    listViewItem.Tag = itm;
                    listViewItem.ToolTipText = itm.Description;

                    if (!itm.Available)
                    {
                        listViewItem.BackColor = Color.LightPink;
                    }

                    exploreView.Items.Add(listViewItem);
                }
            }
        }

        private void CodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                itm.Available = true;
                Console.WriteLine(itm.Id);
                DbWrap.Update(itm);
            }
        }

        private void CheckOutButt_Click(object sender, EventArgs e)
        {
            List<Item> list = DbWrap.GetList(Code);

            foreach (Item itm in list)
            {
                itm.Available = false;
                DbWrap.Update(itm);
            }
        }

        private void exploreView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(exploreView.SelectedItems.Count == 1)
            {
                Item itm = (Item)exploreView.SelectedItems[0].Tag;

                ExpNameBox.Text = itm.Name;
                ExpPlaceBox.Text = itm.Place;
                ExpDescBox.Text = itm.Description;

                DeleteButt.Enabled = true;
                UpdateButt.Enabled = true;

            }
            else
            {
                UpdateButt.Enabled = false;

                if(exploreView.SelectedItems.Count > 1)
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
        


        private void DeleteButt_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem listItem in exploreView.SelectedItems)
            {
                Item itm = (Item)listItem.Tag;

                DbWrap.Delete(itm);
            }

            UpdateExplorer();
            
        }

        private void UpdateButt_Click(object sender, EventArgs e)
        {
            Item itm = (Item)exploreView.SelectedItems[0].Tag;

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

                Console.WriteLine("control");

            }

            if(ctrlDown && e.KeyCode == Keys.B)
            {
                captureScan = true;

                Console.WriteLine("capturin");

                CodeBox.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            

            if (ctrlDown && e.KeyCode == Keys.C)
            {
                captureScan = false;

                Console.WriteLine("not capturin");

                HandleCode();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
            else if (captureScan & (e.KeyCode > Keys.D0 && e.KeyCode < Keys.D9))
            {
                KeysConverter kc = new KeysConverter();
                string keyChar = kc.ConvertToString(e.KeyCode);

                CodeBox.Text += keyChar;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control)
            {
                ctrlDown = false;

                Console.WriteLine("not control");

            }
        }

        private void exploreView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(e.Column == 2)
            {
                HideAvailable = !HideAvailable;
                
                if (HideAvailable)
                {
                    //exploreView

                    foreach (ListViewItem listItem in exploreView.Items)
                    {
                        if (((Item)listItem.Tag).Available)
                        {
                            listItem.Remove();
                        }
                    }
                }
                else
                {
                    UpdateExplorer();
                }
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

            foreach (ListViewItem Item in exploreView.Items)
            {
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
                exploreView.TopItem = foundItem;

                foreach (ListViewItem listItem in exploreView.Items)
                {
                    listItem.Selected = false;
                }
                
                foundItem.Selected = true;
            }
        }
    }
}
