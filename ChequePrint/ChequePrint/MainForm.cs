using NumberToText;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ChequePrint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

           
            
            NumberToTextLabel.Parent = ChImage;
            NumberToTextLabel.BackColor = Color.Transparent;
            NumberToTextLabel.Location = new Point(53, 104);

            DateNumberLabel.Parent = ChImage;
            DateNumberLabel.BackColor = Color.Transparent;
            DateNumberLabel.Location = new Point(370, 64);

            ShenaaseLabel.Parent = ChImage;
            ShenaaseLabel.BackColor = Color.Transparent;
            ShenaaseLabel.Location = new Point(142, 144);

            HavaaleLabel.Parent = ChImage;
            HavaaleLabel.BackColor = Color.Transparent;
            HavaaleLabel.Location = new Point(30, 144);

            PersoanNameLabel.Parent = ChImage;
            PersoanNameLabel.BackColor = Color.Transparent;
            PersoanNameLabel.Location = new Point(363, 144);


            DescriptionLabel.Parent = ChImage;
            DescriptionLabel.BackColor = Color.Transparent;
            DescriptionLabel.Location = new Point(144, 10);


            SecondNumberLabel.Parent = ChImage;
            SecondNumberLabel.BackColor = Color.DimGray;
            SecondNumberLabel.Location = new Point(200, 210);
           

            for( int i =1;i <=15;i++)
            {
               
                Control ctn = this.tabControl1.TabPages[0].Controls["l" + i.ToString()];
                ctn.Parent = ChImage;
                ctn.BackColor = Color.Transparent;
                int X = (int)(33 + i * 1.41 * ctn.Width);
                ctn.Location = new Point(X, 210);

            }

            for (int i = 1; i <= 8; i++)
            {

                Control ctn = this.tabControl1.TabPages[0].Controls["b" + i.ToString()];
                ctn.Parent = ChImage;
                ctn.BackColor = Color.Transparent;
                int X = (int)(408 + i * 1.28 * ctn.Width);
                ctn.Location = new Point(X, 40);

            }


            foreach (Control c in ChImage.Controls)
            {
                if (c is Label)
                {
                    Label L = (Label)c;
                    LoadSettings(L.Name);
                }
            }

            try
            {
                
                txtLeft.Text = Properties.Settings.Default.XValue.ToString();
                txtTop.Text = Properties.Settings.Default.YValue.ToString();
            }
            catch { }


        }

        private void Form1_Load(object sender, EventArgs e)
        {


            int yearnumber = (int)numericYear.Value;

            string date = udYear.Value.ToString() + "/" + udMonth.Value.ToString().PadLeft(2, '0') + "/" + udDay.Value.ToString().PadLeft(2, '0');
            if (date.Length == 10)
                DateNumberLabel.Text = NumberToText.NumberToTextLibrary.DateToText(date,yearnumber);

            DescriptionLabel.Text = txtDescription.Text;

            for (int i = 1; i <= 8; i++)
            {
                Control ctn = this.ChImage.Controls["b" + (i).ToString()];
                ctn.Text = "*";
            }


            date = date.Replace("/", "");
            for (int i = 1; i <= 8; i++)
            {
                Control ctn = this.ChImage.Controls["b" + (9 - i).ToString()];
                ctn.Text = date[8 - i].ToString();
            }

        }

        private void txtNumberInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string value = txtNumberInput.Text.Replace(",", "");
                if (value.Length > 15)
                    return;
                ulong ul;
                if (ulong.TryParse(value, out ul))
                {
                    txtNumberInput.TextChanged -= txtNumberInput_TextChanged;
                    txtNumberInput.Text = string.Format("{0:#,#}", ul);
                    txtNumberInput.SelectionStart = txtNumberInput.Text.Length;
                    txtNumberInput.TextChanged += txtNumberInput_TextChanged;
                    NumberToTextLabel.Text = NumberToText.NumberToTextLibrary.NumberToText(value, false) + " " + Properties.Resources.PersianText;

                    if ( chSecondNumber.Checked)
                        SecondNumberLabel.Text = txtNumberInput.Text + " RLS";
                    if (chCloseNumber.Checked)
                        NumberToTextLabel.Text += "//" + " ";


                    NumberToTextLabel.Font =
                        new Font(NumberToTextLabel.Font.FontFamily.Name, 10.75F, FontStyle.Bold);

                    if (chAutoSize.Checked)
                    {
                        Size size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                        int with = (size.Width);

                        while (with > NumberToTextLabel.Width)
                        {
                            NumberToTextLabel.Font =
                                new Font(
                                    NumberToTextLabel.Font.FontFamily.Name,
                                    NumberToTextLabel.Font.Size - 0.01F,
                                    FontStyle.Bold);

                            size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                            with = (size.Width);
                        }
                    }

                    if (chFillText.Checked)
                    {

                        if (chFillText.Checked)
                        {
                            Size size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                            int with = (size.Width);

                            while (with < NumberToTextLabel.Width-10)
                            {

                                NumberToTextLabel.Text += "*";
                                size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                                with = (size.Width);
                            }
                        }
                    }


                    for (int i = 1; i <= 15; i++)
                    {
                        Control ctn = this.ChImage.Controls["l" + (i).ToString()];
                        ctn.Text = "*";
                    }


                    int ci = value.Length;
                    for (int i = 1; i <= ci; i++)
                    {
                        Control ctn = this.ChImage.Controls["l" + (16 - i).ToString()];
                        ctn.Text = value[ci - i].ToString();
                    }

                }

                else
                {
                    for (int i = 1; i <= 15; i++)
                    {
                        Control ctn = this.ChImage.Controls["l" + (i).ToString()];
                        ctn.Text = "*";
                    }
                    NumberToTextLabel.Text = "";

                    NumberToTextLabel.Font =
                                new Font(
                                    NumberToTextLabel.Font.FontFamily.Name,
                                    9.75F,
                                    FontStyle.Bold);

                }

            }
            catch { }
        }

        private void txtNumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }


            }
            catch { }
        }

        private void domainUpDown1_TextChanged(object sender, EventArgs e)
        {

            int yearnumber = (int)numericYear.Value;
            string date = udYear.Text + "/" + udMonth.Text + "/" + udDay.Text;
            if ( date.Length == 10)
                DateNumberLabel.Text = NumberToText.NumberToTextLibrary.DateToText(date,yearnumber);
        }

        private void udDay_SelectedItemChanged(object sender, EventArgs e)
        {
            int yearnumber = (int)numericYear.Value;
            string date = udYear.Text + "/" + udMonth.Text + "/" + udDay.Text;
            if (date.Length == 10)
                DateNumberLabel.Text = NumberToText.NumberToTextLibrary.DateToText(date,yearnumber);
        }

        private void chCloseNumber_CheckedChanged(object sender, EventArgs e)
        {


            if (chCloseNumber.Checked)
                NumberToTextLabel.Text += "//";
            else
                NumberToTextLabel.Text = NumberToTextLabel.Text.Replace("//", "");


        }

        private void DateNumberLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void DateNumberLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DateNumberLabel.Left = e.X + DateNumberLabel.Left - MouseDownLocation.X;
                DateNumberLabel.Top = e.Y + DateNumberLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = DateNumberLabel.Left.ToString() + "," + DateNumberLabel.Top.ToString();
            }
        }

        private Point MouseDownLocation;
        private void NumberToTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void NumberToTextLabel_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                NumberToTextLabel.Left = e.X + NumberToTextLabel.Left - MouseDownLocation.X;
                NumberToTextLabel.Top = e.Y + NumberToTextLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = NumberToTextLabel.Left.ToString() + "," + NumberToTextLabel.Top.ToString();
            }

        }

        private void ShenaaseLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void ShenaaseLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShenaaseLabel.Left = e.X + ShenaaseLabel.Left - MouseDownLocation.X;
                ShenaaseLabel.Top = e.Y + ShenaaseLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = ShenaaseLabel.Left.ToString() + "," + ShenaaseLabel.Top.ToString();
            }
        }

        private void HavaaleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void HavaaleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                HavaaleLabel.Left = e.X + HavaaleLabel.Left - MouseDownLocation.X;
                HavaaleLabel.Top = e.Y + HavaaleLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = HavaaleLabel.Left.ToString() + "," + HavaaleLabel.Top.ToString();
            }
        }

        private void chHavaale_CheckedChanged(object sender, EventArgs e)
        {
            if (chHavaale.Checked)
                HavaaleLabel.Text = "/////////////////";
            else
                HavaaleLabel.Text = "";
        }

        private void chShenaase_CheckedChanged(object sender, EventArgs e)
        {
            if (chShenaase.Checked)
                ShenaaseLabel.Text = "******************";
            else
                ShenaaseLabel.Text = "";

        }

        private void PersoanNameLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void PersoanNameLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PersoanNameLabel.Left = e.X + PersoanNameLabel.Left - MouseDownLocation.X;
                PersoanNameLabel.Top = e.Y + PersoanNameLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = PersoanNameLabel.Left.ToString() + "," + PersoanNameLabel.Top.ToString();
            }
        }

        private void txtPersonName_TextChanged(object sender, EventArgs e)
        {
            PersoanNameLabel.Text = "//"  + " " + txtPersonName.Text + " " +  "//";
        }

        private void DescriptionLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DescriptionLabel.Left = e.X + DescriptionLabel.Left - MouseDownLocation.X;
                DescriptionLabel.Top = e.Y + DescriptionLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = DescriptionLabel.Left.ToString() + "," + DescriptionLabel.Top.ToString();
            }
        }

        private void DescriptionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            DescriptionLabel.Text = txtDescription.Text;
        }

        private void FontAutoCurrect_Click(object sender, EventArgs e)
        {



            NumberToTextLabel.Font =
                             new Font(
                                 NumberToTextLabel.Font.FontFamily.Name,
                                 9.75F,
                                 FontStyle.Bold);

            
            {


                Size size = System.Windows.Forms.TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);

                int with = (size.Width);
                while (with > NumberToTextLabel.Width)
                {
                    NumberToTextLabel.Font =
                        new Font(
                            NumberToTextLabel.Font.FontFamily.Name,
                            NumberToTextLabel.Font.Size - 0.01F,
                            FontStyle.Bold);
                    size = System.Windows.Forms.TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                    with = (size.Width);
                }
            }
        }

        private void chAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chAutoSize.Checked)
            {
                NumberToTextLabel.Font =
                          new Font(NumberToTextLabel.Font.FontFamily.Name, 10.75F, FontStyle.Bold);

                if (chAutoSize.Checked)
                {
                    Size size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                    int with = (size.Width);

                    while (with > NumberToTextLabel.Width)
                    {
                        NumberToTextLabel.Font =
                            new Font(
                                NumberToTextLabel.Font.FontFamily.Name,
                                NumberToTextLabel.Font.Size - 0.01F,
                                FontStyle.Bold);

                        size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                        with = (size.Width);
                    }
                }
            }
        }

        private void chFillText_CheckedChanged(object sender, EventArgs e)
        {
            if (chFillText.Checked)
            {

                if (chFillText.Checked)
                {
                    Size size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                    int with = (size.Width);

                    while (with < NumberToTextLabel.Width-10)
                    {

                        NumberToTextLabel.Text += "*";
                        size = TextRenderer.MeasureText(NumberToTextLabel.Text, NumberToTextLabel.Font);
                        with = (size.Width);
                    }
                }
            }
            else
            {
                NumberToTextLabel.Text = NumberToTextLabel.Text.Replace("*", "");
            }
        }

        private void udMonth_ValueChanged(object sender, EventArgs e)
        {
            int yearnumber = (int)numericYear.Value;
            string date = udYear.Value.ToString() + "/" + udMonth.Value.ToString().PadLeft(2,'0') + "/" + udDay.Value.ToString().PadLeft(2, '0');
            if (date.Length == 10)
                DateNumberLabel.Text = NumberToText.NumberToTextLibrary.DateToText(date,yearnumber);

            for (int i = 1; i <= 8; i++)
            {
                Control ctn = this.ChImage.Controls["b" + (i).ToString()];
                ctn.Text = "*";
            }


            date = date.Replace("/", "");
            for (int i = 1; i <= 8; i++)
            {
                Control ctn = this.ChImage.Controls["b" + (9 - i).ToString()];
                ctn.Text = date[8 - i].ToString();
            }
        }

        private void udDay_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void SecondNumberLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void SecondNumberLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                SecondNumberLabel.Left = e.X + SecondNumberLabel.Left - MouseDownLocation.X;
                SecondNumberLabel.Top = e.Y + SecondNumberLabel.Top - MouseDownLocation.Y;
                ControlLocation.Text = SecondNumberLabel.Left.ToString() + "," + SecondNumberLabel.Top.ToString();
            }
        }

        private void chSecondNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chSecondNumber.Checked)
            {
                SecondNumberLabel.Visible = true;
                SecondNumberLabel.Text = txtNumberInput.Text + " RLS";
            }
            else
                SecondNumberLabel.Visible = false;
        }

        private void b1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void b1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                b1.Left = e.X + b1.Left - MouseDownLocation.X;
                b1.Top = e.Y + b1.Top - MouseDownLocation.Y;
                ControlLocation.Text = b1.Left.ToString() + "," + b1.Top.ToString();

                for (int i = 2; i <= 8; i++)
                {

                    Control ctn = ChImage.Controls["b" + i.ToString()];
                    ctn.BackColor = Color.Transparent;
                    int X = (int)(b1.Left + (i-1) * 1.28 * ctn.Width);
                    ctn.Location = new Point(X, b1.Top);

                }
            }
        }

        private void l1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void l1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                l1.Left = e.X + l1.Left - MouseDownLocation.X;
                l1.Top = e.Y + l1.Top - MouseDownLocation.Y;
                ControlLocation.Text = l1.Left.ToString() + "," + l1.Top.ToString();

                for (int i = 2; i <= 15; i++)
                {

                    Control ctn = ChImage.Controls["l" + i.ToString()];
                    ctn.BackColor = Color.Transparent;
                    int X = (int)(l1.Left + (i - 1) * 1.41 * ctn.Width);
                    ctn.Location = new Point(X, l1.Top);

                }
            }
          
        }

        public  void SaveSettings(string x, string y, Control ctrl)
        {
            if (!Directory.Exists(Application.StartupPath + "\\ControlSettings"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\ControlSettings");
            }

            XmlDocument xmlDocument = new XmlDocument();
            string xml = string.Format(@"<?xml version='1.0' " +
                "encoding='utf-8'?><Control><x>{0}</x><y>{1}</y><name>{2}</name><fontName>{3}</fontName><fontSize>{4}</fontSize><fontBold>{5}</fontBold></Control>",
                x, y, ctrl.Name,ctrl.Font.FontFamily.Name, ctrl.Font.Size, ctrl.Font.Bold);
            xmlDocument.LoadXml(xml);
            xmlDocument.Save(Application.StartupPath + "\\ControlSettings\\" + ctrl.Name + ".xml");
        }

        public void LoadSettings(string ControlName)
        {

            if (!File.Exists(Application.StartupPath + "\\ControlSettings\\" + ControlName + ".xml"))
            {
                return;
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.StartupPath + "\\ControlSettings\\" + ControlName + ".xml");

            XmlNode button = xmlDocument.GetElementsByTagName("Control").Item(0);

            XmlNode nameNode = button.SelectSingleNode("name");
            XmlNode xNode = button.SelectSingleNode("x");
            XmlNode yNode = button.SelectSingleNode("y");
            XmlNode fontName = button.SelectSingleNode("fontName");
            XmlNode fontSize = button.SelectSingleNode("fontSize");
            XmlNode fontBold = button.SelectSingleNode("fontBold");

            Control ctn = ChImage.Controls[ControlName];
            int X = Convert.ToInt32(xNode.InnerText);
            int Y = Convert.ToInt32(yNode.InnerText);
            ctn.Location = new Point(X,Y);
            float size = 10;
            float.TryParse(fontSize.InnerText, out size);

            if (fontBold.InnerText == "True")
                ctn.Font = new Font(fontName.InnerText, size, FontStyle.Bold);
            else
                ctn.Font = new Font(fontName.InnerText, size, FontStyle.Regular);


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Control c in ChImage.Controls)
            {
                if ( c is Label)
                {
                    Label L = (Label)c;
                    SaveSettings(L.Location.X.ToString(), L.Location.Y.ToString(), L);
                }
            }

            try
            {
                float y = 1.3f;
                float.TryParse(txtTop.Text, out y);
                float x = 1.3f;
                float.TryParse(txtLeft.Text, out x);
                Properties.Settings.Default.YValue = y;
                Properties.Settings.Default.XValue = x;
                Properties.Settings.Default.Save();
            }
            catch { }

        }

        private Font _SystemFont;
        private void btnFontSelect_Click(object sender, EventArgs e)
        {
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                _SystemFont = fontDlg.Font;
             
            }

        }

        private void fontSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    fontDlg.Font = sourceControl.Font;
                    if (fontDlg.ShowDialog() != DialogResult.Cancel)
                    {
                        Control ctn = ChImage.Controls[sourceControl.Name];
                        ctn.Font = fontDlg.Font;
                        if ( ctn.Name == "l1")
                        {
                            for (int i = 2; i <= 15; i++)
                            {

                                ctn = ChImage.Controls["l" + i.ToString()];
                                ctn.Font = fontDlg.Font;

                            }
                        }
                        if (ctn.Name == "b1")
                        {
                            for (int i = 2; i <= 8; i++)
                            {

                                ctn = ChImage.Controls["b" + i.ToString()];
                                ctn.Font = fontDlg.Font;

                            }
                        }

                    }
                }
            }


           

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private Image _ChBitmap;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                float x, y;
                float.TryParse(txtTop.Text, out y);
                float.TryParse(txtLeft.Text, out x);
                e.Graphics.DrawImage(_ChBitmap, x* 3.7795275591F, y* 3.7795275591F, (int)_ChBitmap.Width, (int)_ChBitmap.Height);
            }
            catch { }
        }


        public static Bitmap RotateImage(Image inputImage, float angleDegrees, bool upsizeOk,
                                    bool clipOk, Color backgroundColor)
        {
           
            if (angleDegrees == 0f)
                return (Bitmap)inputImage.Clone();

           
            int oldWidth = inputImage.Width;
            int oldHeight = inputImage.Height;
            int newWidth = oldWidth;
            int newHeight = oldHeight;
            float scaleFactor = 1f;


            if (upsizeOk || !clipOk)
            {
                double angleRadians = angleDegrees * Math.PI / 180d;

                double cos = Math.Abs(Math.Cos(angleRadians));
                double sin = Math.Abs(Math.Sin(angleRadians));
                newWidth = (int)Math.Round(oldWidth * cos + oldHeight * sin);
                newHeight = (int)Math.Round(oldWidth * sin + oldHeight * cos);
            }

            
            if (!upsizeOk && !clipOk)
            {
                scaleFactor = Math.Min((float)oldWidth / newWidth, (float)oldHeight / newHeight);
                newWidth = oldWidth;
                newHeight = oldHeight;
            }


            Bitmap newBitmap = new Bitmap(newWidth, newHeight, backgroundColor == Color.Transparent ?
                                             PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
            newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);

            using (Graphics graphicsObject = Graphics.FromImage(newBitmap))
            {
                graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphicsObject.SmoothingMode = SmoothingMode.HighQuality;

    
                if (backgroundColor != Color.Transparent)
                    graphicsObject.Clear(backgroundColor);


                graphicsObject.TranslateTransform(newWidth / 2f, newHeight / 2f);

                if (scaleFactor != 1f)
                    graphicsObject.ScaleTransform(scaleFactor, scaleFactor);

                graphicsObject.RotateTransform(angleDegrees);
                graphicsObject.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);

                graphicsObject.DrawImage(inputImage, 0, 0);
            }

            return newBitmap;
        }

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

   
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void printSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();

        }

        private void printToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (var bmp = new Bitmap(ChImage.Width, ChImage.Height))
            {

                ChImage.Image = null;
                ChImage.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                _ChBitmap = RotateImage(bmp, 270, true, true, Color.White);
                _ChBitmap.Save(@"c:\screenshot.png", ImageFormat.Png);
                ChImage.Image = Properties.Resources.chequeTemplate;
                printDocument1.Print();


            }
        }

        private void udDay_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void numericYear_ValueChanged(object sender, EventArgs e)
        {
            int yearnumber = (int)numericYear.Value;
            string date = udYear.Value.ToString() + "/" + udMonth.Value.ToString().PadLeft(2, '0') + "/" + udDay.Value.ToString().PadLeft(2, '0');
            if (date.Length == 10)
                DateNumberLabel.Text = NumberToText.NumberToTextLibrary.DateToText(date, yearnumber);

            for (int i = 1; i <= 8; i++)
            {
                Control ctn = this.ChImage.Controls["b" + (i).ToString()];
                ctn.Text = "*";
            }


            date = date.Replace("/", "");
            for (int i = 1; i <= 8; i++)
            {
                Control ctn = this.ChImage.Controls["b" + (9 - i).ToString()];
                ctn.Text = date[8 - i].ToString();
            }
        }
    }
}
