using CompareEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ComparatorTool
{
    public partial class Main : Form
    {       
        private string _oldText;
        private string _newText;

        private DiffEngineLevel _level;

        public Main()
        {
            InitializeComponent();
            _oldText = textBoxOld.Text;
            _newText = textBoxNew.Text;

            _level = DiffEngineLevel.FastImperfect;
            CreateColumns();
        }

        private void CreateColumns()
        {
            var line1 = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Line",
                Name = "OldLineNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };


            var text1 = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Text",
                Name = "OldText",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            var line2 = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Line",
                Name = "NewLineNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            var text2 = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Text",
                Name = "NewText",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            oldGridView.Columns.Add(line1);
            oldGridView.Columns.Add(text1);

            newGridView.Columns.Add(line2);
            newGridView.Columns.Add(text2);
        }

        private void CompareFiles(DiffList_TextFile source, DiffList_TextFile destination, ArrayList DiffLines, double seconds)
        {
            int cnt = 1;
            int i;

            DataGridViewRow oldrow;
            DataGridViewRow newrow;

            foreach (DiffResultSpan drs in DiffLines)
            {
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.DeleteSource:
                        for (i = 0; i < drs.Length; i++)
                        {
                            oldrow = (DataGridViewRow) oldGridView.Rows[0].Clone();
                            oldrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            oldrow.Cells[1].Value = ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line;
                            oldrow.Cells[1].Style.BackColor = Color.Red;

                            newrow = (DataGridViewRow)newGridView.Rows[0].Clone();
                            newrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            newrow.Cells[1].Value = "";
                            newrow.Cells[1].Style.BackColor = Color.LightGray;


                            oldGridView.Rows.Add(oldrow);
                            newGridView.Rows.Add(newrow);

                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.NoChange:
                        for (i = 0; i < drs.Length; i++)
                        {
                            oldrow = (DataGridViewRow)oldGridView.Rows[0].Clone();
                            oldrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            oldrow.Cells[1].Value = ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line;
                            oldrow.Cells[1].Style.BackColor = Color.White;

                            newrow = (DataGridViewRow)newGridView.Rows[0].Clone();
                            newrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            newrow.Cells[1].Value = ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line;
                            newrow.Cells[1].Style.BackColor = Color.White;


                            oldGridView.Rows.Add(oldrow);
                            newGridView.Rows.Add(newrow);

                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.AddDestination:
                        for (i = 0; i < drs.Length; i++)
                        {
                            oldrow = (DataGridViewRow)oldGridView.Rows[0].Clone();
                            oldrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            oldrow.Cells[1].Value = "";
                            oldrow.Cells[1].Style.BackColor = Color.LightGray;

                            newrow = (DataGridViewRow)newGridView.Rows[0].Clone();
                            newrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            newrow.Cells[1].Value = ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line;
                            newrow.Cells[1].Style.BackColor = Color.LightGreen;

                            oldGridView.Rows.Add(oldrow);
                            newGridView.Rows.Add(newrow);
                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.Replace:
                        for (i = 0; i < drs.Length; i++)
                        {
                            oldrow = (DataGridViewRow)oldGridView.Rows[0].Clone();
                            oldrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            oldrow.Cells[1].Value = ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line;
                            oldrow.Cells[1].Style.BackColor = Color.Red;

                            newrow = (DataGridViewRow)newGridView.Rows[0].Clone();
                            newrow.Cells[0].Value = cnt.ToString("00000");
                            oldrow.Cells[0].Style.BackColor = Color.LightSlateGray;
                            newrow.Cells[1].Value = ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line;
                            newrow.Cells[1].Style.BackColor = Color.LightGreen;


                            oldGridView.Rows.Add(oldrow);
                            newGridView.Rows.Add(newrow);
                            cnt++;
                        }

                        break;
                }
            }
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            if(checkBoxEdit.Checked || checkBoxEdit.Checked)
            {
                MessageBox.Show(this, "Cannot Compare Documents in Edit Mode: Please Uncheck Edit Mode and try again");
                return;
            }

            if (radioButtonfast.Checked)
            {
                _level = DiffEngineLevel.FastImperfect;
            }
            else
            {
                if (radioButtonMedium.Checked)
                {
                    _level = DiffEngineLevel.Medium;
                }
                else
                {
                    _level = DiffEngineLevel.SlowPerfect;
                }
            }

            ResetView(oldGridView);
            ResetView(newGridView);

            #region todelete

            #endregion

            TextDiff(_oldText, _newText);   
        }

        private string getViewString(ListView view)
        {
            StringBuilder builder = new StringBuilder();
            foreach (ListViewItem itemRow in view.Items)
            {
                builder.AppendLine(itemRow.SubItems[1].Text);
            }

            try
            {
                XDocument xml = XDocument.Parse(builder.ToString());
                return xml.ToString();
            }
            catch
            {
                return builder.ToString();
            }
        }


    private void TextDiff(string oldText, string newText)
        {
            this.Cursor = Cursors.WaitCursor;

            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try
            {
                sLF = new DiffList_TextFile(oldText);
                dLF = new DiffList_TextFile(newText);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, _level);

                ArrayList rep = de.DiffReport();
                CompareFiles(sLF, dLF, rep, time);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
            this.Cursor = Cursors.Default;
        }

        private void CaptureEntry(List<string> text, String entry, DataGridView grid)
        {
            try
            {
                using (StringReader sr = new StringReader(entry))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        text.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            PoulateView(text, grid);
        }

        private void PoulateView(List<string> items, DataGridView grid)
        {
            ResetView(grid);

            int cnt = 1;
            int i;

            DataGridViewRow row;

            for (i = 0; i < items.Count; i++)
            {
                row = (DataGridViewRow)oldGridView.Rows[0].Clone();
                row.Cells[0].Value = cnt.ToString("00000");
                row.Cells[1].Value = items[i];

                grid.Rows.Add(row);
                cnt++;
            }
        }

        private void ResetView(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Refresh();
        }

        private void checkBoxEditOld_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEdit.Checked)
            {
                oldGridView.Visible = false;
                textBoxOld.Visible = true;
                newGridView.Visible = false;
                textBoxNew.Visible = true;
            }
            else
            {
                oldGridView.Visible = true;
                textBoxOld.Visible = false;
                newGridView.Visible = true;
                textBoxNew.Visible = false;
                CaptureEntry(new List<string>(), _oldText, oldGridView);
                CaptureEntry(new List<string>(), _newText, newGridView);
            }
        }

        private void textBoxOld_TextChanged(object sender, EventArgs e)
        {
            _oldText = textBoxOld.Text;
        }

        private void textBoxNew_TextChanged(object sender, EventArgs e)
        {
            _newText = textBoxNew.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CaptureEntry(new List<string>(), _oldText, oldGridView);
            CaptureEntry(new List<string>(), _newText, newGridView);
        }
    }
}
