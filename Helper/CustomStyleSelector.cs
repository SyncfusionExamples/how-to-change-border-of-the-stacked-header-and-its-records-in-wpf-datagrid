using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace SfDataGridDemo
{
    public class CustomStyleSelector : StyleSelector
    {
        //To find whether style is applied for previous GridCell.
        bool isStyleApplied = false;
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var data = item as Model;
            if (data == null)
                return base.SelectStyle(item, container);

            var gridCell = container as GridCell;
            var gridColumn = gridCell.ColumnBase.GridColumn;
            
            var dataGrid = Application.Current.MainWindow.FindName("sfdatagrid") as SfDataGrid;
            //Need to set isStyleApplied false for the new row
            if (gridColumn == dataGrid.Columns.FirstOrDefault())
                isStyleApplied = false;
            foreach (var row in dataGrid.StackedHeaderRows)
            {
                var stackedColumns = row.StackedColumns;
                foreach (var column in stackedColumns)
                {
                    string[] childcolumns = column.ChildColumns.Split(',');
                    //If there is only one child column, need to apply border for both left and right unless right border for previous cell is not applied.
                    if (data != null && childcolumns.Count() == 1 && gridColumn.MappingName == childcolumns.FirstOrDefault() && !isStyleApplied)
                    {
                        isStyleApplied = true;
                        return Application.Current.Resources["gridCellStyle3"] as Style;
                    }
                    else if (data != null && gridColumn.MappingName == childcolumns.LastOrDefault())
                    {
                        isStyleApplied = true;
                        return Application.Current.Resources["gridCellStyle2"] as Style;
                    }
                    //if the cell if first child column, need to check right border of previous cell's right border.
                    else if (data != null && gridColumn.MappingName == childcolumns.FirstOrDefault() && !isStyleApplied)
                    {
                        isStyleApplied = true;
                        return Application.Current.Resources["gridCellStyle1"] as Style;
                    }
                }
            }

            isStyleApplied = false;
            return base.SelectStyle(item, container);
        }
    }
}
