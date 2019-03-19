using System;
using System.Data;

namespace ASP.NET_Web_API_2.DataModel.Utils
{
    public static class DataRowExtension
    {
        public static string GetValue(this DataRow trow, string column)
        {
            return trow.Table.Columns.Contains(column) ? trow[column].ToString() : null;
        }

        public static decimal GetDecimalValue(this DataRow trow, string column)
        {
            var value = decimal.Zero;

            if (!trow.Table.Columns.Contains(column))
            {
                return value;
            }

            try
            {
                value = decimal.Parse(trow.GetValue(column));
            }
            catch (Exception)
            {
                value = decimal.Zero;
            }

            return value;
        }

        public static int GetIntValue(this DataRow trow, string column)
        {
            var value = 0;

            if (!trow.Table.Columns.Contains(column))
            {
                return value;
            }

            try
            {
                value = int.Parse(trow.GetValue(column));
            }
            catch (Exception)
            {
                value = 0;
            }

            return value;
        }

        public static bool GetBooleanValue(this DataRow trow, string column)
        {
            var value = false;

            if (!trow.Table.Columns.Contains(column))
            {
                return false;
            }

            try
            {
                value = bool.Parse(trow.GetValue(column));
            }
            catch (Exception)
            {
                value = false;
            }

            return value;
        }

        public static long? GetMillisecondsValue(this DataRow trow, string column)
        {
            if (!DateTime.TryParse(trow.GetValue(column), out var parsedDate))
            {
                return null;
            }

            var dateTimeOffset = new DateTimeOffset(parsedDate, TimeZone.CurrentTimeZone.GetUtcOffset(parsedDate));
            var milliseconds = dateTimeOffset.ToUniversalTime()
                .Subtract(new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalMilliseconds;
            return (long?)milliseconds;
        }

        public static DateTime? GetDateTimeValue(this DataRow trow, string column)
        {
            var dateTimeValue = trow.GetValue(column);

            if (dateTimeValue == null)
            {
                return null;
            }

            return DateTime.SpecifyKind(DateTime.Parse(dateTimeValue), DateTimeKind.Utc);
        }

        public static bool IsNotNull(this DataRow row, string column)
        {
            return !string.IsNullOrEmpty(row.GetValue(column));
        }

        public static TEnum GetEnum<TEnum>(this DataRow trow, string column)
        {
            var result = default(TEnum);

            if (!trow.Table.Columns.Contains(column))
            {
                return result;
            }

            try
            {
                result = (TEnum)Enum.Parse(typeof(TEnum), trow.GetValue(column));
            }
            catch (Exception)
            {
                result = default(TEnum);
            }

            return result;
        }

        public static string GetBytes(this DataRow trow, string column)
        {
            return trow.Table.Columns.Contains(column) ? Convert.ToBase64String((byte[])trow[column]) : null;
        }
    }
}
