using System;
using Xamarin.Forms;

namespace XamarinHtmlWebview.Controls
{
    public class HybridWebView : WebView
    {
        Action<string> action;

        public static readonly BindableProperty HtmlTextProperty = BindableProperty.Create(
            propertyName: "HtmlText",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string HtmlText
        {
            get { return (string)GetValue(HtmlTextProperty); }
            set { SetValue(HtmlTextProperty, value); }
        }

        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }

        public void Cleanup()
        {
            action = null;
        }

        public void InvokeAction(string data)
        {
            if (action == null || data == null)
            {
                return;
            }
            action.Invoke(data);
        }
    }
}

