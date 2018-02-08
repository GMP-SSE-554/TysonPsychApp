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
            InitializeComponent();
            slideshow = new Slideshow(@"C:\Users\Tyson\Desktop\TestFile.xlsx", this);
            Update();
            TextBox.Focus();
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
