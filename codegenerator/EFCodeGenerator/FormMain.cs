using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace EFCodeGenerator
{
    public partial class FormMain : Form
    {
        private List<Type> _listTable;

        public FormMain()
        {
            InitializeComponent();
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Common.InitializeNamespaceAndClass();

                _listTable = new List<Type>();

                Assembly assembly = Type.GetType(Common._contextClassFullName + "," + Common._defaultNamespace).Assembly;
                listBoxSource.Items.Clear();
                listBoxDestination.Items.Clear();

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.Namespace == Common._modelsNamespace &&
                        !type.Name.EndsWith("Extensions"))
                    {
                        if (!type.FullName.StartsWith(Common._contextClassFullName))
                        {
                            if ((type.Name != "MigrationHistory" &&
                                type.Name != "UserLogins" &&
                                type.Name != "UserClaims"))
                            {
                                listBoxSource.Items.Add(type.Name);
                                _listTable.Add(type);
                            }
                        }
                    }
                }

                SetButtonsEditable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                this.Close();
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxDestination.Items)
            {
                foreach (var type in _listTable)
                {
                    if (type.Name == item.ToString())
                    {
                        var cg = new CodeGenerator(textBoxProjectFile.Text, Common._defaultNamespace, type.Name, type, Common._contextClassName);
                        cg.CreateFiles();

                        break;
                    }
                }   
            }

            buttonGenerate.Enabled = false;                      

            MessageBox.Show("DAL codes successfully generated.");

            LoadData();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBoxSource, listBoxDestination);
        }

        private void buttonMoveRightAll_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBoxSource, listBoxDestination);
        }

        private void buttonMoveLeftAll_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBoxDestination, listBoxSource);
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBoxDestination, listBoxSource);
        }

        private void MoveAllItems(ListBox listFrom, ListBox listTo)
        {
            listTo.Items.AddRange(listFrom.Items);
            listFrom.Items.Clear();
            SetButtonsEditable();
        }

        private void MoveSelectedItems(ListBox listFrom, ListBox listTo)
        {
            while (listFrom.SelectedItems.Count > 0)
            {
                string item = (string)listFrom.SelectedItems[0];
                listTo.Items.Add(item);
                listFrom.Items.Remove(item);
            }
            SetButtonsEditable();
        }

        private void SetButtonsEditable()
        {
            buttonMoveRight.Enabled = (listBoxSource.SelectedItems.Count > 0);
            buttonMoveRightAll.Enabled = (listBoxSource.Items.Count > 0);
            buttonMoveLeft.Enabled = (listBoxDestination.SelectedItems.Count > 0);
            buttonMoveLeftAll.Enabled = (listBoxDestination.Items.Count > 0);

            buttonGenerate.Enabled = false;
            if (listBoxDestination.Items.Count > 0 &&
                !string.IsNullOrEmpty(textBoxProjectFile.Text))
            {
                buttonGenerate.Enabled = true;
            }
        }

        private void listBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void listBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void buttonBrowseProjectFile_Click(object sender, EventArgs e)
        {
            openFileDialogBrowse.FileName = string.Empty;

            if (openFileDialogBrowse.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialogBrowse.FileName.Contains(".csproj"))
                {
                    textBoxProjectFile.Text = openFileDialogBrowse.FileName;
                }
                else
                {
                    textBoxProjectFile.Text = string.Empty;
                }
            }

            SetButtonsEditable();
        }

        private void listBoxSource_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(listBoxSource, listBoxDestination);
        }

        private void listBoxDestination_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(listBoxDestination, listBoxSource);
        }
    }
}
