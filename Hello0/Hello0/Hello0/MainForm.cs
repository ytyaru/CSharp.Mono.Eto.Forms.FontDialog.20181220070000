using System;
using Eto.Forms;
using Eto.Drawing;

namespace Hello0
{
    public partial class MainForm : Form
    {
        private RichTextArea textarea1;
        private WebView webView1;
		private FontDialog fontDialog1;
        public MainForm()
        {
            Title = "Splitter";
            ClientSize = new Size(800, 600);
            CreateUi();
        }
        private void CreateUi()
        {
            //textarea1 = new RichTextArea() { Width=this.Width/2, Height=this.Height, Text="何かしらの文字列。" };
            textarea1 = new RichTextArea() { Width=1, Height=1, Text="何かしらの文字列。" };
            textarea1.Focus();
            textarea1.KeyDown += Textarea1_KeyDown;
            webView1 = new WebView() { Width=1, Height=1, Url=new Uri("https://www.google.co.jp") } ;
            //webView1 = new WebView() { Width=this.Width/2, Height=this.Height, Url=new Uri("https://www.google.co.jp") } ;
            var splitter= new Eto.Forms.Splitter();
            splitter.Panel1 = textarea1;
            splitter.Panel2 = webView1;
            //splitter.Panel1.Width = this.Width / 2;
            fontDialog1 = new FontDialog();
            fontDialog1.FontChanged += Dialog_FontChanged;
            Content = new TableLayout() {
                Padding = 0,
                Spacing = new Size(0, 0),
                Rows = {
                    new TableRow(splitter),
                }
            };
        }
        void Textarea1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Keys.Escape) { fontDialog1.ShowDialog(textarea1); }
        }
        void Dialog_FontChanged(object sender, EventArgs e)
        {
			textarea1.Font = fontDialog1.Font;
        }
    }
}
