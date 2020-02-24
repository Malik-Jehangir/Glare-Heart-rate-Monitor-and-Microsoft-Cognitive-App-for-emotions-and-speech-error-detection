using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Newtonsoft.Json;
using Windows.Media.SpeechSynthesis;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using System.Text;
using Windows.ApplicationModel.Core;
using System.Diagnostics;
using System.Linq;
using Windows.Storage.Streams;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;


using Windows.Media.Capture;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Windows.System.Threading;
using Windows.UI.Xaml.Media;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI;




// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlareGuidelinePrinciple
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            bckmp.Play();

            //speed is good, green
            /*ProgressStoryBoard1.Begin();
            ProgressStoryBoard2.Begin();*/

            //PC customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    /*titleBar.ButtonBackgroundColor = Colors.DarkBlue;
                    titleBar.ButtonForegroundColor = Colors.White;*/
                    titleBar.BackgroundColor = Colors.Black ;
                    titleBar.ForegroundColor = Colors.White;
                }
            }

            //Mobile customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {

                var statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 1;
                    statusBar.BackgroundColor = Colors.Black;
                    statusBar.ForegroundColor = Colors.White;
                }
            }
        }











        /// <summary>
        /// ///////////////////////////////////////////////////////////////heart rate//////////////////////////////////////////////////////////
        /// </summary>


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(BlankPage1));



        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage4));


        }



    }
}



