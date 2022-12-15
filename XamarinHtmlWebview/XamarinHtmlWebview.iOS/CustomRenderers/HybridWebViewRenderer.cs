using System;
using System.ComponentModel;
using System.IO;
using Foundation;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinHtmlWebview.Controls;
using XamarinHtmlWebview.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace XamarinHtmlWebview.iOS.CustomRenderers
{
    public class HybridWebViewRenderer : WkWebViewRenderer
    {
        public HybridWebViewRenderer() : this(new WKWebViewConfiguration())
        {
        }

        public HybridWebViewRenderer(WKWebViewConfiguration config) : base(config)
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                HybridWebView hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }

            if (e.NewElement != null)
            {
                var htmlText = ((HybridWebView)Element).HtmlText;

                var baseUrl = DependencyService.Get<IBaseUrl>().Get();
                LoadHtmlString(htmlText, new NSUrl(baseUrl, false));
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

