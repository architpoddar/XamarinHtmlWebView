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
            var html = @"<p><strong>Terms and conditions for BD™ Diabetes Care App</strong></p><p>Effective date: 4/1/2022</p><p >PLEASE READ THIS AGREEMENT (“AGREEMENT”) CAREFULLY BEFORE USING THE BD DIABETES CARE SOFTWARE APPLICATION (“APP”) OFFERED BY  EMBECTA (REFERRED TO AS “ EMBECTA”, “WE”, “US”, or “OUR” AS APPLICABLE) <strong>FOR USE IN THE USA ONLY</strong>. BY DOWNLOADING THE APP OR USING THE APP IN ANY MANNER, YOU AGREE THAT YOU HAVE READ AND AGREE TO BE BOUND BY AND BE A PARTY TO THE TERMS AND CONDITIONS OF THIS AGREEMENT TO THE EXCLUSION OF ALL OTHER TERMS. IF THE TERMS OF THIS AGREEMENT ARE CONSIDERED AN OFFER, ACCEPTANCE IS EXPRESSLY LIMITED TO SUCH TERMS. IF YOU DO NOT UNCONDITIONALLY AGREE TO ALL THE TERMS AND CONDITIONS OF THE AGREEMENT, YOU HAVE NO RIGHT TO USE THE APP.</p>";

            //HtmlString = html;

            //HtmlString = StringHelper.CustomizeHtmlData(html);
            HtmlString = StringHelper.WrapInHtmlWithBodyEvent(html, noOfTitleParagraphs: 3);

            BindingContext = this;
        }
    }
}

