using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using SteamToolkit.Community;

namespace SteamToolkit
{
    public class HapHelper
    {

        public static string GetNodeAttributeValue(HtmlNode node, string attributeName)
        {
            HtmlAttribute attribute = node.Attributes.AttributesWithName(attributeName).FirstOrDefault();
            return attribute?.Value;
        }

        public static List<HtmlNode> FindNodesByAttribute(HtmlNode node, string attribute, string attributeValue)
        {
            return
                node.Descendants("div")
                    .Where(d => d.Attributes.Contains(attribute))
                    .Where(d => d.Attributes[attribute].Value.ToUpper().Contains(attributeValue.ToUpper()))
                    .ToList();
        }

        /// <summary>
        /// Finds all nodes in a specified node with the specified attribute name and vallue
        /// </summary>
        /// <param name="start">Starting node</param>
        /// <param name="name">Attribute name to search for</param>
        /// <param name="value">Attribute value to search for</param>
        /// <returns>A list of all located attributes</returns>
        public static List<HtmlNode> FindAllNodesByAttribute(HtmlNode start, string name, string value)
        {
            List<HtmlNode> matchingNodes = new List<HtmlNode>();
            foreach (HtmlNode node in start.ChildNodes)
            {
                if (!node.HasChildNodes) continue;
                if (node.HasAttributes)
                {
                    matchingNodes.AddRange(from attribute in node.Attributes
                        where
                        attribute.Name.ToUpper().Contains(name.ToUpper()) &&
                        attribute.Value.ToUpper().Contains(value.ToUpper())
                        select node);
                }
                matchingNodes.AddRange(FindAllNodesByAttribute(node, name, value));
            }
            return matchingNodes;
        }

        public static HtmlNode FindChildByClass(HtmlNode node, string classValue)
        {
            return (from x in node.ChildNodes
                let attribute = x.Attributes.AttributesWithName("class").FirstOrDefault()
                where
                attribute != null &&
                string.Equals(attribute.Value.TrimEnd(' '), classValue, StringComparison.CurrentCultureIgnoreCase)
                select x).FirstOrDefault();
        }

        public static HtmlDocument LoadDocumentFromUrl(Web.Web web, string url, CookieContainer authContainer = null)
        {
            int retryCount = 0;
            string result = null;
            while (result == null)
            {
                try
                {
                    result = web.Fetch(url, "GET", null, authContainer)?.ReadStream();
                }
                catch (Exception)
                {
                    if (retryCount > 3) return null;
                    retryCount++;
                    //consume exception
                }
            }

            using (
                var reader = new StringReader(result)
                )
            {
                var document = new HtmlDocument();
                document.Load(reader);
                return document;
            }
        }

        public static HtmlDocument LoadDocument(GetTopicsHtmlResult result)
        {
            using (
                var reader = new StringReader(result.TopicsHtml)
                )
            {
                var document = new HtmlDocument();
                document.Load(reader);
                return document;
            }
        }
    }
}
