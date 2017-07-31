using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(
            this HtmlHelper html, ListType listType, IEnumerable<string> list, object htmlAttributes = null)
        {
            var ul = new TagBuilder(listType.ToString().ToLower());

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