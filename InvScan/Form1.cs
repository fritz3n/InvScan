using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace InvScan
{



    public partial class Form1 : Form
    {
        private string Code = "";


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
                Code = Code
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
                    CheckInBox.Checked = true;
                    break;

                case "CheckOut":
                    CheckOutBox.Checked = true;
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
                    CheckInBox.Checked = false;
                    break;

                case "CheckOut":
                    CheckOutBox.Checked = false;
                    break;
            }
        }

        private void UpdateExplorer()
        {
            exploreView.Items.Clear();

            List<Item> list = DbWrap.GetList();

            foreach(Item itm in list)
            {
                string Available = (itm.Available ? "Yes" : "No");

                string[] row = {itm.Name, itm.Name, Available, itm.Code};
                var listViewItem = new ListViewItem(row);

                listViewItem.Tag = itm;
                listViewItem.ToolTipText = itm.Description;


                exploreView.Items.Add(listViewItem);
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
    }
}
