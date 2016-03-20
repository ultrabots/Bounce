﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainUi
{
    public class HtmlOutputWrapper : OutputConsole
    {
        private HtmlElement output_div;

        public HtmlOutputWrapper(HtmlDocument _doc)
        {
            output_div = _doc.GetElementById("output_panel");
            if(output_div == null)
            {
                throw new ArgumentException("Unable to find output document", 
                    "_doc");
            }
        }

        public override void Write(string data)
        {
            data = data.Replace("\n", "<br>\n");
            output_div.InnerHtml = String.Concat(output_div.InnerHtml, data);
        }

        public override void WriteLine(string data)
        {
            Write(String.Concat(data, "<br>\n"));
        }
    }
}