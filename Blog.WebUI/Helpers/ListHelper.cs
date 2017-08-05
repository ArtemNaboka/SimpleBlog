using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.WebUI.Helpers
{
    public static class ListHelper
    {
        private static readonly Dictionary<ListType, string> ListDictionary = new Dictionary<ListType, string>
        {
            [ListType.Ul] = "ul",
            [ListType.Ol] = "ol"
        };


        public static MvcHtmlString CreateList(
            this HtmlHelper html, ListType listType, IEnumerable<string> list, object htmlAttributes = null)
        {
            var ul = new TagBuilder(ListDictionary[listType]);

            foreach (var item in list)
            {
                var li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }

            ul.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return new MvcHtmlString(ul.ToString());
        }

        public enum ListType
        {
            Ul,
            Ol
        }
    }
}