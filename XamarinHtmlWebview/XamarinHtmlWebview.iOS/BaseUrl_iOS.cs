using System;
using Foundation;
using Xamarin.Forms;
using XamarinHtmlWebview.iOS;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace XamarinHtmlWebview.iOS
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}

