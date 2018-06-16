using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EBSWebsiteAutomation
{
    public class Navigation
    {
        public WebBrowser WebBrowser { get; }
        public string Url { get; }
        public Delegate Operation { get; }

        public Navigation(WebBrowser webbrowser, string url, Delegate operation)
        {
            WebBrowser = webbrowser ?? new WebBrowser();
            Url = url;
            Operation = operation;

            StartNavigation();
        }
        public Navigation(string url, Delegate operation) : this(null, url, operation)
        {

        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Operation.DynamicInvoke();
        }

        public void StartNavigation()
        {
            WebBrowser.ScriptErrorsSuppressed = true;
            WebBrowser.DocumentCompleted += WebBrowser1_DocumentCompleted;

            if (Url != null) WebBrowser.Navigate(Url);
        }

        public bool SingleElementClickNodes(string firstChildId, int[] childLevels)
        {
            int arrayMaxPosition = childLevels.Length - 1;

            HtmlElement[] elemArray = new HtmlElement[childLevels.Length];

            if (WebBrowser.Document == null)
                return false;

            HtmlElement element = WebBrowser.Document.GetElementById(firstChildId);

            if (element == null)
                return false;

            for (int i = 0; i < childLevels.Length; i++)
            {
                if (i == 0)
                    elemArray[i] = element.Children[childLevels[i]];
                else
                    elemArray[i] = elemArray[i - 1].Children[childLevels[i]];
            }

            HtmlElement hiperLink = elemArray[arrayMaxPosition];
            if (hiperLink != null)
            {
                hiperLink.SetAttribute("target", "_self");
                hiperLink.InvokeMember("click");
            }

            return true;
        }

        public bool SetValueManyElements(Dictionary<string, string> fields)
        {
            foreach (var item in fields)
            {
                if (WebBrowser.Document == null)
                    return false;

                HtmlElement element = WebBrowser.Document.GetElementById(item.Key);

                if (element == null)
                    return false;

                element.SetAttribute("value", item.Value);
            }

            return true;
        }

        public bool SingleElementClick(string elementName)
        {
            if (WebBrowser.Document == null)
                return false;

            HtmlElement element = WebBrowser.Document.GetElementById(elementName);

            if (element == null)
                return false;

            element.InvokeMember("click");
            return true;
        }
    }
}
