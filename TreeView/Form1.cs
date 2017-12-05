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
        string currentPath = "Мой компьютер";
        TreeNode mainNode;
        Stack<string> prevPath = new Stack<string>();
        bool showHiddenElements = false;
        bool showFileEx = true;
        public Form1()
        {
            InitializeComponent();
            mainNode = new TreeNode("Мой компьютер");
            mainNode.Name = "";
            mainNode.Nodes.Add("");
            mainNode.ImageIndex = 2;
            mainNode.SelectedImageIndex = 3;
            mainNode.Tag = "comp";
            Tree.Nodes.Add(mainNode);
            Tree.BeforeExpand += Tree_BeforeExpand;
            Tree.BeforeSelect += Tree_BeforeSelect;
            List.DoubleClick += List_DoubleClick;

            foreach (string view in Enum.GetNames(typeof(View)))
                toolStripComboBox1.Items.Add(view);

            toolStripComboBox1.SelectedIndex = 0;


        }

        void SetPath(string path)
        {
            currentPath = path;
            Path.Text = path;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            if (List.SelectedItems.Count == 1)
            {
                try
                {
                    if (Path.Text == "Мой компьютер")
                    {
                        string newPath = List.SelectedItems[0].Text + "\\";
                        var dirs = new DirectoryInfo(newPath).GetDirectories();
                        List.Items.Clear();
                        MoveToDir(newPath);
                    }
                    else
                    {

                        string newPath = Path.Text + List.SelectedItems[0].Text + "\\";

                        var Node = List.SelectedItems[0];
                        List.Items.Clear();
                        MoveToDir(newPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        void Tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            bool isNeedDrop = e.Action != TreeViewAction.ByKeyboard;

            try
            {
                Tree.BeforeSelect -= Tree_BeforeSelect;
                string tag = (string)e.Node.Tag;
                Tree.BeforeSelect += Tree_BeforeSelect;
                if (isNeedDrop)
                {

                    if ((string)e.Node.Tag == "comp")
                    {
                        MoveToDir("Мой компьютер");
                    }
                    else if ((string)e.Node.Tag != "file")
                    {

                        MoveToDir(GetParrentName(e.Node));

                    }
                }
            }
            catch (Exception ex)
            {

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
                        newNode.SelectedImageIndex = 2;
                        newNode.Tag = "hard";
                        e.Node.Nodes.Add(newNode);
                    }
                }
                else if ((string)e.Node.Tag != "file")
                {
                    foreach (var item in new DirectoryInfo(GetParrentName(e.Node)).GetDirectories())
                    {
                        TreeNode newNode = new TreeNode(item.Name);
                        newNode.Nodes.Add("");
                        newNode.ImageIndex = 1;
                        newNode.SelectedImageIndex = 1;
                        newNode.Name = item.Name;
                        newNode.Tag = "dir";
                        e.Node.Nodes.Add(newNode);
                        //Tree.SelectedImageIndex = newNode.ImageIndex;
                    }

                    foreach (var item in new DirectoryInfo(GetParrentName(e.Node)).GetFiles())
                    {
                        TreeNode newNode = new TreeNode(item.Name);
                        newNode.ImageIndex = 0;
                        newNode.SelectedImageIndex = 0;
                        newNode.Name = item.Name;
                        newNode.Tag = "file";
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
                return GetParrentName(node.Parent) + node.Name + "\\";
            else return "";
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string viewName = toolStripComboBox1.SelectedItem.ToString();
            View view = (View)Enum.Parse(typeof(View), viewName);
            List.View = view;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = !toolStripButton1.Checked;
            List.ShowGroups = toolStripButton1.Checked;
        }

    
     
        void MoveToDir(string path, bool needRemember = true)
        {
            try
            {

            
         
            List.Items.Clear();
            if (path == "Мой компьютер")
            {
                foreach (var item in DriveInfo.GetDrives())
                {
                    ListViewItem newNode = new ListViewItem(item.Name);
                    newNode.Tag = "hard";
                    newNode.ImageIndex = 2;
                    newNode.Group = List.Groups[2];
                    List.Items.Add(newNode);
                }
            }
            else 
            {

                foreach (var item in new DirectoryInfo(path).GetDirectories())
                {
                    if (showHiddenElements && (item.Attributes & FileAttributes.Hidden) == 0 || !showHiddenElements)
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        newNode.Tag = "dir";
                        newNode.ImageIndex = 1;
                        newNode.Group = List.Groups[0];
                        newNode.SubItems.Add(item.LastAccessTime.ToShortDateString() + " " + item.LastAccessTime.ToShortTimeString());
                        List.Items.Add(newNode);
                    }
                }

                foreach (var item in new DirectoryInfo(path).GetFiles())
                {
                    if (showHiddenElements && (item.Attributes & FileAttributes.Hidden) == 0 || !showHiddenElements)
                    {
                        ListViewItem newNode = new ListViewItem(item.Name);
                        newNode.Tag = "file";
                        newNode.ImageIndex = 0;
                        newNode.Name = item.Name;
                        newNode.Group = List.Groups[1];
                        newNode.SubItems.Add(item.LastAccessTime.ToShortDateString() + " " + item.LastAccessTime.ToShortTimeString());
                        List.Items.Add(newNode);
                    }
                }
            }

                if (needRemember)
                {
                    prevPath.Push(Path.Text);
                    if (prevPath.Count > 0)
                        button1.Enabled = true;
                }
                SetPath(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MoveToDir(currentPath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MoveToDir(prevPath.Pop(), false);
            if (prevPath.Count == 1)
            {
                button1.Enabled = false;
            }
        }

        private void Path_Validating(object sender, CancelEventArgs e)
        {
            if (Directory.Exists(Path.Text) || Path.Text == "Мой компьютер")
            {
                MoveToDir(Path.Text);
            }
            else
            {
                MessageBox.Show("Неверно указан путь!");
                Path.Text = currentPath;

                e.Cancel = true;
            }
        }

        private void Tree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string pat = GetParrentName(Tree.SelectedNode);
                if(pat == "")
                    MoveToDir("Мой компьютер");
                else
                MoveToDir(pat);
            }
        }

        void update()
        {
        }

        private void viewHidden_Click(object sender, EventArgs e)
        {
            showHiddenElements = !showHiddenElements;
            MoveToDir(Path.Text, false);
        }
    }
}

