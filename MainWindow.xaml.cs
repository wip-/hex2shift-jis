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
        }

        private void TextBoxHex_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void ComboBoxEncoding_DropDownClosed(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            if (TextBoxShiftJis == null)
                return;

            try
            {
                String str = TextBoxHex.Text;
                int length = str.Length / 2;
                byte[] raw = new byte[length];
                for (int i = 0; i < length; ++i)
                {
                    raw[i] = Convert.ToByte(str.Substring(2 * i, 2), 16);
                }

                String str2 = Encoding.GetEncoding(ComboBoxEncoding.Text).GetString(raw);
                TextBoxShiftJis.Text = str2;
            }
            catch (System.Exception /*ex*/)
            {
                TextBoxShiftJis.Text = "Input corrupted";
            }
        }
    }
}
