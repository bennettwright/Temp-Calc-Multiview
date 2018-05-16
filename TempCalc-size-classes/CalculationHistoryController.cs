using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace TempCalcsizeclasses
{
    public partial class CalculationHistoryController : UITableViewController
    {
        public CalculationHistoryController (IntPtr handle) : base (handle)
		{ }

		const int DEFAULT_SIZE = 100;
		private static string[] dataArray = new string[DEFAULT_SIZE];
		private static int count = 0, size = DEFAULT_SIZE;
        
		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			HistoryTable.Source = new TableSource(dataArray);
        }
        
		public static void AddData(string data)
		{
			//check for resize first
            if(count >= size)
				Resize();
           
			dataArray[count++] = data;
		}

        /* Doubles the size of the array */
		private static void Resize()
		{
			string[] temp = new string[size * 2];
			dataArray.CopyTo(temp, 0);
			dataArray = temp;
			size *= 2;
		}
    }


	/* Class taken from xamarin example: 
	 * https://docs.microsoft.com/en-us/xamarin/ios/user-interface/controls/tables/populating-a-table-with-data
     */
	public class TableSource : UITableViewSource
    {

        string[] TableItems;
        string CellIdentifier = "TableCell";

        public TableSource(string[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }
    }
}