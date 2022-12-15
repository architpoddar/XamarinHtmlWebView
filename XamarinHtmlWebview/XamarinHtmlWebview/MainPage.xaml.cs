using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinHtmlWebview.Helpers;

namespace XamarinHtmlWebview
{
    public partial class MainPage : ContentPage
    {
        public string HtmlString { get; set; }

        public MainPage()
        {
            InitializeComponent();

            //var html = @"<html><head><style type=text/css> body{background-color: #636363;color: blue;font-size: 80px;}p{color: yellow;font-size: 60px;}</style></head><body><p><strong>This is a sample title</strong><p><p> This is a sample paragraph text.</body></html>";
            var html = "<p><strong>This is a sample title</strong><p><p> This is a sample paragraph text.";

            HtmlString = StringHelper.CustomizeHtmlData(html);

            BindingContext = this;
        }
    }
}

