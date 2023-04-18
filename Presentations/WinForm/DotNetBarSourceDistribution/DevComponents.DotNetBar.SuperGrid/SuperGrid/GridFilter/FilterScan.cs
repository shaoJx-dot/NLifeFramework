using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DevComponents.DotNetBar.SuperGrid
{
    ///<summary>
    /// FilterScan
    ///</summary>
    public class FilterScan
    {
        #region Events

        ///<summary>
        /// ScanComplete
        ///</summary>
        public event EventHandler ScanComplete;

        private delegate void ScanListDelegate(List<object> items);

        #endregion

        #region Private variables

        private GridColumn _GridColumn;

        private bool _Scanning;
        private Thread _ScanThread;
        private EventHandler _OnScanComplete;
        private ScanListDelegate _ScanListDelegate;
        private List<object> _ScanItems;

        #endregion

        #region Public properties

        ///<summary>
        /// ScanItems
        ///</summary>
        public List<object> ScanItems
        {
            get { return (GetScanItems()); }
        }

        #endregion

        ///<summary>
        /// FilterScan
        ///</summary>
        ///<param name="gridColumn"></param>
        public FilterScan(GridColumn gridColumn)
        {
            _GridColumn = gridColumn;

            _OnScanComplete = new EventHandler(OnScanComplete);
            _ScanListDelegate = new ScanListDelegate(AddScanItems);
        }

        #region BeginScan

        ///<summary>
        /// BeginScan
        ///</summary>
        public void BeginScan()
        {
            if (_Scanning == false)
            {
                _Scanning = true;
                _ScanItems = null;

                _ScanThread = new Thread(ScanThread);
                _ScanThread.Start();
            }
        }

        #endregion

        #region EndScan

        ///<summary>
        /// BeginScan
        ///</summary>
        public void EndScan()
        {
            if (_Scanning == true)
            {
                if (_ScanThread.IsAlive)
                {
                    _ScanThread.Abort();
                    _ScanThread.Join();
                }

                _ScanThread = null;
                _ScanItems = null;

                _Scanning = false;
            }
        }

        #endregion

        #region ScanThread

        private void ScanThread()
        {
            GridColumn gridColumn = _GridColumn;
            GridPanel panel = gridColumn.GridPanel;

            List<object> scanItems = new List<object>();

            try
            {
                if (panel != null)
                {
                    ScanColumn(panel.Rows, gridColumn, scanItems);

                    RemoveDuplicates(scanItems);
                }
            }
            catch (Exception exp)
            {
            }
            finally
            {
                _Scanning = false;

                gridColumn.SuperGrid.BeginInvoke(
                    _ScanListDelegate, new object[] { scanItems });

                gridColumn.SuperGrid.BeginInvoke(
                    _OnScanComplete, new object[] { this, EventArgs.Empty });
            }
        }

        #region ScanColumn

        private void ScanColumn(
            GridItemsCollection rows, GridColumn gridColumn, List<object> scanItems)
        {
            if (rows != null && rows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    GridContainer cont = rows[i] as GridContainer;

                    if (cont != null)
                    {
                        GridRow row = cont as GridRow;

                        if (row != null)
                        {
                            GridCell cell = row.GetCell(gridColumn.ColumnIndex);

                            if (cell != null)
                            {
                                object value = cell.ValueEx;

                                if (value != null && value != DBNull.Value)
                                {
                                    if (value is DateTime)
                                        value = ((DateTime)value).Date;

                                    scanItems.Add(value);
                                }
                            }
                        }

                        if (gridColumn.GridPanel.FilterLevel != FilterLevel.Root && cont is GridPanel == false)
                            ScanColumn(cont.Rows, gridColumn, scanItems);
                    }
                }
            }
        }

        #endregion

        #region RemoveDuplicates

        private void RemoveDuplicates(List<object> scanItems)
        {
            GridColumn gridColumn = _GridColumn;

            if (gridColumn.DataType != null)
            {
                for (int i = scanItems.Count - 1; i >= 0; --i)
                {
                    if (scanItems[i].GetType() != gridColumn.DataType)
                        scanItems.RemoveAt(i);
                }
            }

            scanItems.Sort(new ScanComparer());

            object o = null;

            for (int i = scanItems.Count - 1; i >= 0; --i)
            {
                if (scanItems[i].Equals(o) == true)
                    scanItems.RemoveAt(i);
                else
                    o = scanItems[i];
            }
        }

        private class ScanComparer : IComparer<object>
        {
            public int Compare(object val1, object val2)
            {
                return (CompareVal.CompareTo(val1, val2));
            }
        }

        #endregion

        #endregion

        #region AddScanItems

        private void AddScanItems(List<object> items)
        {
            _ScanItems = items;
        }

        #endregion

        #region OnScanComplete

        private void OnScanComplete(object sender, EventArgs e)
        {
            if (ScanComplete != null)
                ScanComplete(sender, e);
        }

        #endregion

        #region GetScanItems

        internal List<object> GetScanItems()
        {
            List<object> list = null;

            if (_GridColumn.NeedsFilterScan == true)
            {
                _GridColumn.SuperGrid.Cursor = Cursors.AppStarting;

                _GridColumn.NeedsFilterScan = false;
                _GridColumn.FilterScan.BeginScan();

                for (int i = 0; i < 500; i++)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(20);

                    list = _ScanItems;

                    if (list != null)
                        break;
                }

                _GridColumn.SuperGrid.Cursor = Cursors.Default;
            }
            else
            {
                list = _ScanItems;
            }

            return (list);
        }

        #endregion
    }
}