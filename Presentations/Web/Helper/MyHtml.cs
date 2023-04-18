using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class MyHtml
    {
        /// <summary>
        /// 生成包含图片的超链接
        /// <remarks>注：若actionName为空，则超链接的地址为当前App的Home页；
        /// 若actionName不为空，controllerName为空，则超链接地址为当前App的Home页对应的Action
        /// </remarks>
        /// </summary>
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName = "", string controllerName = "", object routeValue = null)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string linkUrl = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder linkTagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            linkTagBuilder.MergeAttribute("href", linkUrl);

            return new MvcHtmlString(linkTagBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName = "", string controllerName = "", object routeValue = null, string imgAttribute = null)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            IDictionary<string, object> imgAttributes = new Dictionary<string, object>();
            imgAttributes.Add("src", imgUrl);
            //imgAttributes.Add("style", imgCssStyle);// 图片默认无边框
            imgTagBuilder.MergeAttributes(imgAttributes);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string linkUrl = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder linkTagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            linkTagBuilder.MergeAttribute("href", linkUrl);
            if (imgAttribute != null)
            {
                linkTagBuilder.MergeAttribute("target", imgAttribute);
            }

            return new MvcHtmlString(linkTagBuilder.ToString(TagRenderMode.Normal));
        }

    }
}