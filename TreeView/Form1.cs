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
namespace TreeView
{
    public partial class Form1 : Form
    {
        TreeNode mainNode;
        public Form1()
        {
            InitializeComponent();
            mainNode = new TreeNode("Мой компьютер");
            mainNode.Name = "";
            mainNode.Nodes.Add("");
            mainNode.ImageIndex = 2;
            Tree.Nodes.Add(mainNode);
            Tree.BeforeExpand += Tree_BeforeExpand;
            Tree.BeforeSelect += Tree_BeforeSelect;
            List.DoubleClick += List_DoubleClick;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            if (List.SelectedItems.Count == 1)
            {
                
                if(Path.Text == "Мой компьютер")
                {
                    string newPath = List.SelectedItems[0].Text + "\\";

                    var dirs = new DirectoryInfo(newPath).GetDirectories();
                    List.Items.Clear();
                    foreach (var item in dirs)
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        newNode.ImageIndex = 1;
                        List.Items.Add(newNode);
                    }

                    foreach (var item in new DirectoryInfo(newPath).GetFiles())
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        newNode.Name = item.Name;
                        newNode.ImageIndex = 0;
                        List.Items.Add(newNode);
                    }
                    Path.Text = newPath;
                }
                else
                {

                    string newPath =  Path.Text + List.SelectedItems[0].Text + "\\";
                
                    var Node = List.SelectedItems[0];

                    try
                    {
                        var dirs = new DirectoryInfo(newPath).GetDirectories();
                        List.Items.Clear();
                        foreach (var item in dirs)
                        {
                            ListViewItem newNode = new ListViewItem(item.Name);
                            newNode.ImageIndex = 1;
                            List.Items.Add(newNode);
                        }

                        foreach (var item in new DirectoryInfo(newPath).GetFiles())
                        {
                            ListViewItem newNode = new ListViewItem(item.Name);
                            newNode.Name = item.Name;
                            newNode.ImageIndex = 0;
                            List.Items.Add(newNode);
                        }
                        Path.Text = newPath;

                    }
                    catch (IOException ex)
                    {
                    
                    }
                }

            }
        }

       

        void Tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                List.Items.Clear();
                if (e.Node.FullPath == "Мой компьютер")
                {
                    Path.Text = "Мой компьютер";
                    foreach (var item in DriveInfo.GetDrives())
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        Tree.BeforeSelect -= Tree_BeforeSelect;
                        Tree.SelectedImageIndex = 3;
                        Tree.BeforeSelect += Tree_BeforeSelect;
                        newNode.ImageIndex = 2;
                        List.Items.Add(newNode);
                    }
                }
                else
                {
                   
                    Path.Text = GetParrentName(e.Node);
                    foreach (var item in new DirectoryInfo(GetParrentName(e.Node)).GetDirectories())
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        
                        newNode.ImageIndex = 1;
                        List.Items.Add(newNode);
                    }

                    foreach (var item in new DirectoryInfo(GetParrentName(e.Node)).GetFiles())
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        
                        newNode.ImageIndex = 0;
                        newNode.Name = item.Name;
                        List.Items.Add(newNode);
                    }

                }
            }
            catch (Exception ex)
            {
                Tree.BeforeSelect -= Tree_BeforeSelect;
                Tree.SelectedImageIndex = 2;
                Tree.BeforeSelect += Tree_BeforeSelect;   
                MessageBox.Show(ex.Message);
            }
        }

     

        private void Tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                e.Node.Nodes.Clear();
                if (e.Node.FullPath == "Мой компьютер")
                {
                    e.Node.ImageIndex = 3;
                    foreach (var item in DriveInfo.GetDrives())
                    {
                        TreeNode newNode = new TreeNode(item.Name);
                        newNode.Nodes.Add("");
                        newNode.Name = item.Name;
                        newNode.ImageIndex = 2;
                        e.Node.Nodes.Add(newNode);
                    }
                }
                else
                {
                    //MessageBox.Show(GetParrentName(e.Node));
                    foreach (var item in new DirectoryInfo(GetParrentName(e.Node)).GetDirectories())
                    {
                        TreeNode newNode = new TreeNode(item.Name);
                        newNode.Nodes.Add("");
                        newNode.ImageIndex = 1;
                        newNode.Name = item.Name;
                        e.Node.Nodes.Add(newNode);
                    }

                    foreach (var item in new DirectoryInfo(GetParrentName(e.Node)).GetFiles())
                    {
                        TreeNode newNode = new TreeNode(item.Name);
                        newNode.ImageIndex = 0;
                        newNode.Name = item.Name;
                        e.Node.Nodes.Add(newNode);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


        }

        string GetParrentName(TreeNode node)
        {
            if (node.Parent != null)
                return  GetParrentName(node.Parent) + node.Name + "\\";
            else return "";
        }
    }
}

