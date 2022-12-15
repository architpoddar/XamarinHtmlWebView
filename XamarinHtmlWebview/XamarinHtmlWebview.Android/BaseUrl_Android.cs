using System;
using Xamarin.Forms;
using XamarinHtmlWebview.Droid;

[assembly: Dependency(typeof(BaseUrl_Android))]
namespace XamarinHtmlWebview.Droid
{
	public class BaseUrl_Android : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset";
        }
    }
}

