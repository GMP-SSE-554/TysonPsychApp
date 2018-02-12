using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SSE554Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Slideshow slideshow;

        public MainWindow()
        {
            string inputFile;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                inputFile = openFileDialog.FileName;
                InitializeComponent();
                slideshow = new Slideshow(inputFile, this);
                Update();
                TextBox.Focus();
            } else
            {
                Close();
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (TextBox.Text == "")
            {
                slideshow.GetCurrentSlide().BeginTyping();
            }

            slideshow.SetAnswer(TextBox.Text);

            if (e.Key == Key.Return)
            {
                slideshow.AdvanceSlide();
                Update();
            }
        }

        public void Update()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (slideshow.IsFinished())
                {
                    Close();
                } else {
                    TextBlock.Text = slideshow.GetCurrentSlide().GetText();
                    TextBox.Text = "";
                    if (slideshow.GetCurrentSlide().IsEnabled())
                    {
                        TextBox.IsEnabled = true;
                        TextBox.Focus();
                    } else {
                        TextBox.IsEnabled = false;
                    }
                }
            });
        }
    }
}
