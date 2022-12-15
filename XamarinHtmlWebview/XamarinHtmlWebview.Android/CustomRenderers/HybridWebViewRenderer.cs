using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinHtmlWebview.Droid.CustomRenderers;
using XamarinHtmlWebview.Controls;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace XamarinHtmlWebview.Droid.CustomRenderers
{
    public class HybridWebViewRenderer : WebViewRenderer
    {
        const string JavascriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
        Context _context;

        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                ((Controls.HybridWebView)Element).Cleanup();
            }
            if (e.NewElement != null)
            {
                var baseUrl = DependencyService.Get<IBaseUrl>().Get();
                var htmlText = ((HybridWebView)Element).HtmlText;

                Control.SetWebViewClient(new Android.Webkit.WebViewClient());
                Control.LoadDataWithBaseURL(baseUrl, htmlText, null, "utf-8", null);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((HybridWebView)Element).Cleanup();
            }
            base.Dispose(disposing);
        }
    }
}

