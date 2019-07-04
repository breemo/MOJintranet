using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SP.Common
{
    public sealed partial class Helper
    {
        /// <summary>
        /// Get Anchor tag
        /// </summary>
        /// <param name="content">Title and Content are same</param>
        /// <param name="url">Url</param>
        /// <returns>Anchor information</returns>
        public static string GetA(string content, string url)
        {
            string returnString = string.Empty;
            returnString = "<a href=\"" + url + "\">" + content + "</a>";
            return returnString;
        }

        /// <summary>
        /// Get Anchor tag
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="url">Url</param>
        /// <param name="title">Title</param>
        /// <param name="cssClass">Css Class</param>
        /// <returns>Anchor information</returns>
        public static string GetA(string content, string url, string cssClass)
        {
            string returnString = string.Empty;
            returnString = "<a href=\"" + url + "\" title=\"" + content + "\" class=\"" + cssClass + "\">" + content + "</a>";
            return returnString;
        }

        /// <summary>
        /// Get Anchor tag
        /// </summary>
        /// <param name="content"></param>
        /// <param name="url"></param>
        /// <param name="cssClass"></param>
        /// <param name="rel"></param>
        /// <returns></returns>
        public static string GetA(string content, string url, string cssClass, string rel)
        {
            string returnString = string.Empty;
            returnString = "<a Class=\"" + cssClass + "\" rel=\"" + rel + "\" href=\"" + url + "\">" + content + "</a>";
            return returnString;
        }

        /// <summary>
        /// Get Ancor tag.
        /// </summary>
        /// <param name="content">which you want to anchor</param>
        /// <param name="url">anchor url</param>
        /// <param name="cssClass">css class for anchor tag</param>
        /// <param name="title">title of anchot tag</param>
        /// <param name="fontSize">font size in anchor tag</param>
        /// <returns></returns>
        public static string GetA(string content, string url, string cssClass, string title, int fontSize)
        {
            string returnString = string.Empty;
            returnString = "<a Class=\"" + cssClass + "\" href=\"" + url + "\" title=\"" + title + "\" style=\"font-size:" + fontSize + "pt;\">" + content + "</a>";
            return returnString;
        }

        public static string GetA(string content, string url, string cssClass, string title, string empty)
        {
            string returnString = string.Empty;
            returnString = "<a target=\"_blank\" href=\"" + url + "\" title=\"" + title + "\" class=\"" + cssClass + "\">" + content + "</a>";
            //returnString = "<a href=\"javascript:openModalDialog('" + url + "')\" title=\"" + title + "\" class=\"" + cssClass + "\">" + content + "</a>";
            return returnString;
        }
        /// <summary>
        /// Get Anchor tag
        /// </summary>
        /// <param name="content">Title and Content are same</param>
        /// <param name="url">Url</param>
        /// <param name="target">Target</param>
        /// <returns>Anchor information</returns>
        public static string GetAWithTarget(string content, string url, string target)
        {
            string returnString = string.Empty;
            returnString = "<a href=\"" + url + "\" target=\"" + target + "\" >" + content + "</a>";
            return returnString;
        }

        /// <summary>
        /// Get Anchor tag
        /// </summary>
        /// <param name="content">Which you want to anchor</param>
        /// <param name="url">anchor url</param>
        /// <param name="target">target for open link. like _blank menas open in new window</param>
        /// <param name="cssClass">css class for anchor tag</param>
        /// <returns>HTML Ancor tag as string</returns>
        public static string GetAWithTarget(string content, string url, string target, string cssClass)
        {
            string returnString = string.Empty;
            returnString = "<a href=\"" + url + "\" target=\"" + target + "\" >" + content + "</a>";
            return returnString;
        }

        /// <summary>
        /// Get div content
        /// </summary>
        /// <param name="content">Source</param>
        /// <param name="cssClass">CssClass</param>
        /// <returns>div information</returns>
        public static string GetDiv(string content, string cssClass)
        {
            string returnString = string.Format("<div class=\"{0}\">{1}</div>", cssClass, content);
            return returnString;
        }

        /// <summary>
        /// Get div content
        /// </summary>
        /// <param name="content">Source</param>
        /// <param name="Id">Div Id</param>
        /// <returns>div teg </returns>
        public static string GetDivWithId(string content, string Id)
        {
            string returnString = string.Format("<div id=\"{0}\">{1}</div>", Id, content);
            return returnString;
        }

        /// <summary>
        /// Get div content
        /// </summary>
        /// <param name="content">Source</param>
        /// <param name="cssClass">CssClass</param>
        /// <returns>div information</returns>
        public static string GetDiv(string content, string cssClass, string width)
        {
            string returnString = string.Format("<div class=\"{0}\" style=\"width: {1}px;\" > {2} </div>", cssClass, width, content);
            return returnString;
        }

        /// <summary>
        /// Get Image tag
        /// </summary>
        /// <param name="src">Image Sources</param>
        /// <param name="alternatingText">Image alternatingText</param>
        /// <returns>Image tag data</returns>
        public static string GetImg(string src, string alternatingText)
        {
            string returnString = string.Empty;
            returnString = "<img src=\"" + src + "\" AlternatingText=\"" + alternatingText + "\" />";
            return returnString;
        }

        /// <summary>
        /// Get Image tag
        /// </summary>
        /// <param name="src">Image Sources</param>
        /// <param name="alternatingText">Image alternatingText</param>
        /// <param name="cssClass">Css Class</param>
        /// <returns>Image tag data</returns>
        public static string GetImg(string src, string alternatingText, string cssClass)
        {
            string returnString = string.Empty;
            returnString = "<img src=\"" + src + "\" AlternatingText=\"" + alternatingText + "\" class=\"" + cssClass + "\" />";
            return returnString;
        }

        /// <summary>
        /// Get Image tag
        /// </summary>
        /// <param name="src">Image Sources</param>
        /// <param name="alternatingText">Image alternatingText</param>
        /// <param name="align">Css align Property</param>
        /// <returns>Image tag data</returns>
        public static string GetImgWithAlign(string src, string alternatingText, string align)
        {
            string returnString = string.Empty;
            returnString = "<img src=\"" + src + "\" AlternatingText=\"" + alternatingText + "\" align=\"" + align + "\" />";
            return returnString;
        }

        /// <summary>
        /// Get heading tag.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="waight"></param>
        /// <returns>Heading tag</returns>
        public static string GetH(string content, string weight)
        {
            string returnString = string.Empty;
            returnString = "<h" + weight + ">" + content + "</h" + weight + ">";
            return returnString;
        }

        /// <summary>
        /// Get heading tag.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="waight"></param>
        /// <param name="cssClass"></param>
        /// <returns>Heading tag</returns>
        public static string GetH(string content, string weight, string cssClass)
        {
            string returnString = string.Empty;
            returnString = "<h" + weight + " class=\"" + cssClass + "\">" + content + "</h" + weight + ">";
            return returnString;
        }

        /// <summary>
        /// Get Paragraph Tag
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetP(string content)
        {
            string returnString = string.Empty;
            returnString = "<p>" + content + "</p>";
            return returnString;
        }

        /// <summary>
        /// Get Paragraph Tag
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static string GetP(string content, string cssClass)
        {
            string returnString = string.Empty;
            returnString = "<p class=\"" + cssClass + "\">" + content + "</p>";
            return returnString;
        }

        /// <summary>
        /// Get break teg.
        /// </summary>
        /// <returns>Break html teg</returns>
        public static string GetBr()
        {
            string returnString = string.Empty;
            returnString = "</br>";
            return returnString;
        }

        /// <summary>
        /// Get User list tag.
        /// </summary>
        /// <param name="content"></param>
        /// <returns>User list tag</returns>
        public static string GetUl(string content)
        {
            string returnString = string.Empty;
            returnString = "<ul>" + content + "</ul>";
            return returnString;
        }

        /// <summary>
        ///  Get User list tag.
        /// </summary>
        /// <param name="content">content of user list</param>
        /// <param name="cssClass">css class of user list</param>
        /// <returns>user list teg</returns>
        public static string GetUl(string content, string cssClass)
        {
            string returnString = string.Empty;
            returnString = "<ul class=\"" + cssClass + "\">" + content + "</ul>";
            return returnString;
        }

        /// <summary>
        /// Get list item tag.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="waight"></param>
        /// <returns>List item tag</returns>
        public static string GetLi(string content)
        {
            string returnString = string.Empty;
            returnString = "<li>" + content + "</li>";
            return returnString;
        }

        /// <summary>
        /// Get span tag.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="waight"></param>
        /// <returns>Span item tag</returns>
        public static string GetSpan(string content)
        {
            string returnString = string.Empty;
            returnString = "<span>" + content + "</span>";
            return returnString;
        }

        /// <summary>
        /// Get Center
        /// </summary>
        /// <param name="content">content</param>
        /// <returns>Center html teg</returns>
        public static string GetCenter(string content)
        {
            string returnString = string.Empty;
            returnString = "<center>" + content + "</center>";
            return returnString;
        }

        /// <summary>
        /// Get Td html tag.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetTd(string content)
        {
            string returnString = string.Empty;
            returnString = " <td>" + content + "</td>";
            return returnString;
        }

        /// <summary>
        /// Get Tr html tag.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetTr(string content)
        {
            string returnString = string.Empty;
            returnString = "<tr>" + content + "</tr>";
            return returnString;
        }
    }
}
