using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace File_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int BufferSize = 32768;

        private string _FilePath = "C:\file";
        private string _FileSizeAmount = "1";
        private string _FileSizeUnit = "GB";
        private bool   _FileRandom = false;

        private bool   OpenedMemes = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateFile()
        {
            decimal fileSize;

            try
            {
                fileSize = Decimal.Parse(_FileSizeAmount);

                switch (_FileSizeUnit)
                {
                    case "KB":
                        fileSize *= 1024;
                        break;

                    case "MB":
                        fileSize *= 1048576;
                        break;

                    case "GB":
                        fileSize *= 1073741824;
                        break;
                }
            }
            catch { throw new Exception("Error parsing dummy file size."); }

            if (_FileRandom)
            {
                using (FileStream DummyFile = new FileStream(_FilePath, FileMode.Create))
                {
                    Random rand = new Random();

                    if (_FileSizeUnit == "Byte(s)")
                        BufferSize = (int)fileSize;

                    byte[] buffer = new byte[BufferSize];

                    for (long pos = 0; pos < (long)fileSize; pos += BufferSize)
                    {
                        rand.NextBytes(buffer);
                        DummyFile.Write(buffer, 0, BufferSize);
                    }
                }
            }
            else
            {
                using (FileStream DummyFile = new FileStream(_FilePath, FileMode.Create))
                {
                    DummyFile.SetLength((long)fileSize);
                }
            }
            

            MessageBox.Show("File of size: " + _FileSizeAmount + _FileSizeUnit + " successfully created!", "TTT File Creator", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "file";
            
            if (dlg.ShowDialog() == true)
            {
                _FilePath = dlg.FileName;
                FilePathLabel.Text = _FilePath;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _FileSizeAmount = fileSizeAmount.Text;
            _FileSizeUnit = fileSizeUnit.Text;

            CreateFile();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _FileRandom = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _FileRandom = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!OpenedMemes)
            {
                MessageBoxResult result = MessageBox.Show("Quickest memes I could find.\r\nView at your own risk!\r\nThere are 9 memes, can u find them all?", "TTT Meme provider", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                OpenedMemes = true;

                if (result == MessageBoxResult.Cancel)
                    return;
            }

            MemeWindow meme = new MemeWindow();
            meme.Show();
        }
    }
}
