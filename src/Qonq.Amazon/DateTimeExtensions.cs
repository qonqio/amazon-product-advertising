using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qonq.Amazon
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert to Amazon Date String
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToAmzDateStr(this DateTime date) => date.ToString("yyyyMMddTHHmmssZ");

    }
}