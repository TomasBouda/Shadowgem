using System.Data;
using System.Text;

namespace TomLabs.Shadowgem.Misc
{
	/// <summary>
	/// <see cref="DataTable"/> related extension methods
	/// </summary>
	public static class DataTableExtensions
	{
		/// <summary>
		/// Converts <see cref="DataTable"/> to string
		/// </summary>
		/// <param name="dataTable"></param>
		/// <returns></returns>
		public static string ToStringSingle(this DataTable dataTable)
		{
			var output = new StringBuilder();
			foreach (DataRow row in dataTable.Rows)
			{
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					output.AppendLine(row[i].ToString());
				}
			}
			return output.ToString();
		}

		/// <summary>
		/// Converts <see cref="DataTable"/> to formated string
		/// </summary>
		/// <param name="dataTable"></param>
		/// <returns></returns>
		public static string ToFormatedString(this DataTable dataTable)
		{
			var output = new StringBuilder();

			var columnsWidths = new int[dataTable.Columns.Count];

			// Get column widths
			foreach (DataRow row in dataTable.Rows)
			{
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					var length = row[i].ToString().Length;
					if (columnsWidths[i] < length)
					{
						columnsWidths[i] = length;
					}
				}
			}

			// Get Column Titles
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				var length = dataTable.Columns[i].ColumnName.Length;
				if (columnsWidths[i] < length)
				{
					columnsWidths[i] = length;
				}
			}

			// Write Column titles
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				var text = dataTable.Columns[i].ColumnName;
				output.Append("|" + PadCenter(text, columnsWidths[i] + 2));
			}
			output.Append("|\n" + new string('=', output.Length) + "\n");

			// Write Rows
			foreach (DataRow row in dataTable.Rows)
			{
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					var text = row[i].ToString();
					output.Append("|" + PadCenter(text, columnsWidths[i] + 2));
				}
				output.Append("|\n");
			}
			return output.ToString();
		}

		private static string PadCenter(string text, int maxLength)
		{
			int diff = maxLength - text.Length;
			return new string(' ', diff / 2) + text + new string(' ', (int)(diff / 2.0 + 0.5));
		}
	}
}