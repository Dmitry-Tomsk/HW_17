using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public static partial class MaxElement
    {
        public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter)
        where T : class
        {
            T value;
            var el = e.GetEnumerator();

            el.MoveNext();
            value = (T)el.Current;

            el.MoveNext();
            T x = (T)el.Current;           

            if (getParameter(x) > getParameter(value))
            {
                value = x;
            }

            while (el.MoveNext())
            {
                x = (T)el.Current;

                if (((decimal)getParameter(x)) > ((decimal)getParameter(value)))
                {
                    value = x;
                }
            }
            return value;
        }
    }
}
