using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SfDataGridDemo
{
    public class HeaderConverter : IValueConverter
    {
        //To find whether style is applied for previous HeaderCell.
        bool isStyleApplied = false;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gridColumn = value as GridColumn;

            var dataGrid = Application.Current.MainWindow.FindName("sfdatagrid") as SfDataGrid;
            if (gridColumn == dataGrid.Columns.FirstOrDefault())
                isStyleApplied = false;
            foreach (var row in dataGrid.StackedHeaderRows)
            {
                var stackedColumns = row.StackedColumns;
                foreach (var column in stackedColumns)
                {
                    string[] childcolumns = column.ChildColumns.Split(',');
                    //If there is only one child column, need to apply border for both left and right unless right border for previous cell is not applied.
                    if (gridColumn != null && childcolumns.Count() == 1 && gridColumn.MappingName == childcolumns.FirstOrDefault() && !isStyleApplied)
                    {
                        isStyleApplied = true;
                        return new Thickness(3, 0, 3, 1);
                    }
                    else if (gridColumn != null && gridColumn.MappingName == childcolumns.LastOrDefault())
                    {
                        isStyleApplied = true;
                        return new Thickness(0, 0, 3, 1);
                    }
                    //if the cell if first child column, need to check right border of previous cell's right border.
                    else if (gridColumn != null && gridColumn.MappingName == childcolumns.FirstOrDefault() && !isStyleApplied)
                    {
                        isStyleApplied = true;
                        return new Thickness(3, 0, 1, 1);
                    }
                }
            }
            isStyleApplied = false;
            return new Thickness(0, 0, 1, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StackedHeaderConverter : IValueConverter
    {
        int previousChildColumnIndex = -1;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stackedColumn = value as StackedColumn;
            var dataGrid = Application.Current.MainWindow.FindName("sfdatagrid") as SfDataGrid;
            string[] childcolumns = stackedColumn.ChildColumns.Split(',');
            string firstChildColumn = childcolumns.FirstOrDefault();
            var column = dataGrid.Columns[firstChildColumn];
            var colindex = dataGrid.Columns.IndexOf(column);
            //If style is applied for previous stackedheader cell, no need to apply left border for currentcell.
            if (colindex != 0 && previousChildColumnIndex == colindex - 1)
                return new Thickness(0, 0, 3, 1);
            var previousLastColumn = childcolumns.LastOrDefault();
            previousChildColumnIndex = dataGrid.Columns.IndexOf(dataGrid.Columns[previousLastColumn]);
            return new Thickness(3, 0, 3, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
