﻿using System;
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
            ExecuteButton.Enabled = false;
            var psobj = await CallPowerShellAsync();
            ExecuteButton.Enabled = true;
            FillListViewWithPSObjects(psobj);
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
            if (psobjs.Count != 0)
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
                        listApp.Items.Add(lvi);
                    }
                }
            }
        }

        private void listApp_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            Cursor.Current = Cursors.No;
            e.Cancel = true;
            e.NewWidth = listApp.Columns[e.ColumnIndex].Width;
        }
    }
}