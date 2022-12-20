using System;
using System.Reflection;
using Xamarin.Forms;

namespace XamarinHtmlWebview.Helpers
{
	public static class StringHelper
	{
        public static string CustomizeHtmlData(string htmlString, string fontName = "SourceSansPro-Regular.ttf")
        {

            var heading = htmlString.Split(new string[] { "</strong></p>" }, StringSplitOptions.None);

            var title = heading[0];
            var body = heading[1];

            title = "<h2>" + title + "</strong></p></h2>";

            var finalHtml = title + body;

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
                {finalHtml}
                </body>
            </html>";

            return html;
        }


        public static string FontFaceRules()
        {
            string fontFaceRules =
                "@font-face {" +
                "    font-family: 'SourceSansPro';" +
                "    src: url('fonts/SourceSansPro-Regular.ttf');" +
                "}" +
                "@font-face {" +
                "    font-family: 'SourceSansPro';" +
                "    font-weight: bold;" +
                "    src: url('fonts/SourceSansPro-Bold.ttf');" +
                "}" +
                "@font-face {" +
                "    font-family: 'SourceSansPro';" +
                "    font-style: italic;" +
                "    src: url('fonts/SourceSansPro-Italic.ttf');" +
                "}" +
                "@font-face {" +
                "    font-family: 'SourceSansPro';" +
                "    font-weight: bold;" +
                "    font-style: italic;" +
                "    src: url('fonts/SourceSansPro-BoldItalic.ttf');" +
                "}";



            return fontFaceRules;
        }

        public static string WrapInHtmlWithBodyEvent(string htmlSnipet, string bodyEvent = "", string fontSize = "16", int noOfTitleParagraphs = 1)
        {
            //var heading = htmlSnipet.Split(new string[] { "</strong></p>" }, StringSplitOptions.None);

            //var title = heading[0];
            //var body = heading[1];

            //title = @"<div class=""titleLabel"">" + title + "</strong></p></div>";

            //htmlSnipet = title + body;

            string paraTitleStyle = "";

            var css = "{ font-size: 30pt; color: #FF0000; }";

            if (noOfTitleParagraphs == 1)
            {
                paraTitleStyle = @"p:first-child" + css;
            }
            else if(noOfTitleParagraphs > 1)
            {
                paraTitleStyle = "p:first-child";

                string additionalParaStyle = "p:first-child";

                for (int i = 2; i <= noOfTitleParagraphs; i++)
                {
                    additionalParaStyle = $"{additionalParaStyle}+p";
                    paraTitleStyle = paraTitleStyle + "," + additionalParaStyle;
                }

                paraTitleStyle = paraTitleStyle + css;
            }

            string fontFaceRules = FontFaceRules();
            if (!string.IsNullOrEmpty(bodyEvent))
                bodyEvent = $" {bodyEvent}";

            string html =
                "<!DOCTYPE html>" +
                "<html>" +
                "<head>" +
                "    <meta charset='utf-8'>" +
                "    <style>" +
               $"        {fontFaceRules}" +
                "        html { -webkit-text-size-adjust: none; }" +
                "        body, table, h1, h2, h3, h4, h5 {" +
                "            font-family: 'SourceSansPro';" +
                "        }" +
                "        body {" +
               $"            font-size: {fontSize}pt;" +
                "            margin: 0px;" +
                "            padding: 0px;" +
                "            -webkit-text-size-adjust: none;" +
                "            color: #584F75;" +
                "        }" +
                "        .titleLabel {" +
                $"            font-size: 18pt;" +
                "            color: #00FF00;" +
                "        }" +
                $"{paraTitleStyle}"+
                //"        p:first-child {" +
                //$"            font-size: 30pt;" +
                //"            color: #FF0000;" +
                //"        }" +
                //"        p:first-child + p + p {" +
                //$"            font-size: 30pt;" +
                //"            color: #FF0000;" +
                //"        }" +
                "    </style>" +
                "</head>" +
               $"<body{bodyEvent}>" +
               $"    {htmlSnipet}" +
                "</body>" +
                "</html>";

            return html;
        }
    }
}

