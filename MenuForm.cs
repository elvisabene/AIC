using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppInformer
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            ListApp.Items.Clear();
            ExecuteButton.Enabled = false;
            var psobj = await RegistryConnection.GetAppsAsync(compNamesComboBox.Text);
            ExecuteButton.Enabled = true;
            FillListViewWithApps(psobj);
        }

        private async Task<Collection<PSObject>> CallPowerShellAsync()
        {
            return await Task.Run(() =>
            {
                using (Runspace runspace = RunspaceFactory.CreateRunspace())
                {
                    runspace.Open();
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript(PSScriptStorage.GetCommand(null));
                    var PSObjects = pipeline.Invoke();
                    return PSObjects;
                }
            });
        }

        private async void ExportInCsvAsync(Collection<PSObject> psobjs)
        {
            await Task.Run(() =>
            {
                using (Runspace runspace = RunspaceFactory.CreateRunspace())
                {
                    runspace.Open();
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript(PSScriptStorage.GetCommand(null));
                    pipeline.Commands.Add(PSScriptStorage.GetCommand("Export"));
                    pipeline.Invoke();
                }
            });
        }

        private void FillListViewWithPSObjects(Collection<PSObject> psobjs)
        {
            for (int i = 0; i < psobjs.Count; i++)
            {
                var lvi = new ListViewItem();
                bool notNull = true;
                foreach (PSPropertyInfo prop in psobjs[i].Properties)
                {
                    switch (prop.Name)
                    {
                        case "DisplayName":
                            {
                                if (prop.Value == null)
                                {
                                    notNull = false;
                                }
                                lvi.Text = prop.Value?.ToString();
                                break;
                            }
                        case "DisplayVersion":
                            {
                                lvi.SubItems.Add(prop.Value?.ToString());
                                break;
                            }
                    }
                }
                if (notNull)
                {
                    ListApp.Items.Add(lvi);
                }
            }
        }

        private void FillListViewWithApps(Hashtable[] apps)
        {
            if (apps is null)
            {
                return;
            }
            foreach(Hashtable app in apps)
            {
                var lvi = new ListViewItem();
                bool notNull = true;
                foreach (var key in app.Keys)
                {
                    if ((string)key == "DisplayName")
                    {
                        if (app[key] == null)
                        {
                            notNull = false;
                        }
                        lvi.Text = app[key].ToString();
                    }
                    else if ((string)key == "DisplayVersion")
                    {
                        lvi.SubItems.Add(app[key].ToString());
                    }
                }
                if (notNull)
                {
                    ListApp.Items.Add(lvi);
                }
            }
        }

        private void ListApp_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            Cursor.Current = Cursors.No;
            e.Cancel = true;
            e.NewWidth = ListApp.Columns[e.ColumnIndex].Width;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            updateComboBox_button.PerformClick();
        }

        private async void updateComboBox_button_Click(object sender, EventArgs e)
        {
            updateComboBox_button.Enabled = false;
            compNamesComboBox.Items.Clear();
            var items = await NetworkHelper.GetLocalNamesAsync();
            compNamesComboBox.Items.AddRange(items);
            updateComboBox_button.Enabled = true;
        }
    }
}
