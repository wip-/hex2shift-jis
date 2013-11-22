using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace hex2shift_jis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //BatchHack();
        }

        private String EncodeHex(String hexValues, String encoding)
        {
            try
            {
                String str = TextBoxHex.Text;
                int length = hexValues.Length / 2;
                byte[] raw = new byte[length];
                for (int i = 0; i < length; ++i)
                {
                    raw[i] = Convert.ToByte(hexValues.Substring(2 * i, 2), 16);
                }

                String str2 = Encoding.GetEncoding(encoding).GetString(raw);
                return str2;
            }
            catch (System.Exception /*ex*/)
            {
                return "Input corrupted";
            }
        }

        private void BatchHack()
        {
            string[] array = Directory.GetFiles(@"C:\", "*.txt");

            foreach (string fileName in array)
            {
                String str = EncodeHex(System.IO.Path.GetFileNameWithoutExtension(fileName), "EUC-JP");
                Console.WriteLine(str);
            }
        }

        private void Update()
        {
            if (TextBoxShiftJis == null)
                return;

            TextBoxShiftJis.Text = EncodeHex(TextBoxHex.Text, ComboBoxEncoding.Text);
        }

        private void TextBoxHex_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void ComboBoxEncoding_DropDownClosed(object sender, EventArgs e)
        {
            Update();
        }

    }
}
