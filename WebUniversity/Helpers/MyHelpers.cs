using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebUniversity.Helpers
{
    public static class MyHelpers
    {
        public static HtmlString Hello(this IHtmlHelper html, string name)
        {
            return new HtmlString($"<h1>Здравствуйте, уважаемый {name}!</h1>");
        }

      
            public static HtmlString Select<T, TVal>(this IHtmlHelper html, IEnumerable<T> xs, string valName, string txtName, TVal selected)
        {
            Type myType = typeof(T);
            var properName = myType.GetProperty(valName);
            var properTxt = myType.GetProperty(txtName);

            string selectnm = "<select name = \"select\">";

            var selectid = properName.GetValue(selected, null);
            foreach (var item in xs)
            {

                var tName = properName.GetValue(item, null);
                var tText = properTxt.GetValue(item, null);
                string selecttmp = selectid.ToString() == tName.ToString() ? "selected" : "";

                string tr = $"<option value=\"{tName}\" {selecttmp}  > {tText} </option>";
                selectnm += tr;
            }
            selectnm += "</select>";

            return new HtmlString(selectnm);

        }

    }
}
