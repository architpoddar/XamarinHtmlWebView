using System;
using Xamarin.Forms;

namespace XamarinHtmlWebview.Helpers
{
	public static class StringHelper
	{
        public static string CustomizeHtmlData(string htmlString, string fontName = "SourceSansPro-Regular.ttf")
        {
            var fontPath = DependencyService.Get<IBaseUrl>().Get() + $"/Fonts/{fontName}";

            var html = $@"
            <html>
                <head>
                    <style type=text/css>
                        @font-face {{
                        font-family: 'Source Sans Pro';
                        src: url('{fontPath}')
                        }}
                        body {{
                            font-family: 'Source Sans Pro';
                            color: #0000ff;
                        }}
                    </style>
                </head>
                <body>
                {htmlString}
                </body>
            </html>";

            return html;
        }
    }
}

