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
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using Windows.UI.Xaml.Navigation;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlareGuidelinePrinciple
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public class GraphHR2
        {
            public string Emotion { get; set; }
            public double Values { get; set; }
        }

        CameraCaptureUI captureUI = new CameraCaptureUI();
        StorageFile photo;
        IRandomAccessStream imageStream;
        string emotion_u;
        int ar=0;
        List<string> items2;
        private IMobileServiceTable<usertable> userTable = App.MobileService.GetTable<usertable>();

        const string APIKEY = "0353ebb6cfe84b97991270ac883f7a08";
        EmotionServiceClient emotionServiceClient = new EmotionServiceClient(APIKEY);
        Emotion[] emotionResult;
        SpeechSynthesizer speechSynthesizer;

        public string StatusInformation { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string user_email = e.Parameter.ToString();
            username.Text = user_email;
        }

        public BlankPage2()
        {
            this.InitializeComponent();
            speechSynthesizer = new SpeechSynthesizer();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Windows.Foundation.Size(366, 414);

            //PC customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    /*titleBar.ButtonBackgroundColor = Colors.DarkBlue;
                    titleBar.ButtonForegroundColor = Colors.White;*/
                    titleBar.BackgroundColor = Colors.Black;
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

        private async void tkphoto_Click(object sender, RoutedEventArgs e)
        {
            generate.IsEnabled = true;


            try
            {

                photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);


                if (photo == null)
                {
                    //user cancelled photo
                    return;
                }
                else
                {
                    imageStream = await photo.OpenAsync(FileAccessMode.Read);
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(imageStream);
                    SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                    SoftwareBitmap softwareBitmapBGRB = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                    SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
                    await bitmapSource.SetBitmapAsync(softwareBitmapBGRB);
                    image3.Source = bitmapSource;

                }
            }
            catch
            {
                confidencecheck.Text = "Error taking photo";
            }
        }

        private async void generate_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                emotionResult = await emotionServiceClient.RecognizeAsync(imageStream.AsStream());
                if (emotionResult != null)
                {






                    string[] emo = {
                    "Happy",
                     "Sad",
                    "Surprise",
                     "Anger",
                    "Fear",
                    "Contemp",
                    "Disgust",
                   "Neutral" };






                    double[] anArray = { emotionResult[0].Scores.Happiness, emotionResult[0].Scores.Sadness, emotionResult[0].Scores.Surprise, emotionResult[0].Scores.Fear, emotionResult[0].Scores.Anger, emotionResult[0].Scores.Contempt, emotionResult[0].Scores.Disgust, emotionResult[0].Scores.Neutral };
                    // Finding max

                    double large = anArray.Max();

                    int p = Array.IndexOf(anArray, large);


                    confidencecheck.Text = "Highest : " + emo[p];
                    string myemo = emo[p];

                    
                    if(myemo==emotion_u)
                    {
                        ar += 20;
                        myscore.Text = ar.ToString();
                    }


                    /*List<GraphHR2> lst2 = new List<GraphHR2>();
                    //fix this, shift heart rate and stop watch time
                    lst2.Add(new GraphHR2 { Emotion = "Happiness", Values = (emotionResult[0].Scores.Happiness) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Sadness", Values = (emotionResult[0].Scores.Sadness) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Surprise", Values = (emotionResult[0].Scores.Surprise) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Fear", Values = (emotionResult[0].Scores.Fear) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Anger", Values = (emotionResult[0].Scores.Anger) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Contempt", Values = (emotionResult[0].Scores.Contempt) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Disgust", Values = (emotionResult[0].Scores.Disgust) * 100 });
                    lst2.Add(new GraphHR2 { Emotion = "Neutral", Values = (emotionResult[0].Scores.Neutral) * 100 });
                    (ColumnChart.Series[0] as ColumnSeries).ItemsSource = lst2;
                    (PieChart2.Series[0] as PieSeries).ItemsSource = lst2;




                    if (emo[p] == "Neutral")
                    {
                        steps.Visibility = Visibility.Collapsed;

                        confidencecheck.Text = "These type of people are hard to deal with.\n Try to deal with them in a funny way.\nPass a joke and give it a try.";
                        Talk(confidencecheck.Text);
                    }
                    else if (emo[p] == "Surprise")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }
                    else if (emo[p] == "Happiness")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }
                    else if (emo[p] == "Fear")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }
                    else if (emo[p] == "Angry")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }
                    else if (emo[p] == "Sadness")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }
                    else if (emo[p] == "Contempt")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }
                    else if (emo[p] == "Disgust")
                    {
                        steps.Visibility = Visibility.Visible;
                        image3.Visibility = Visibility.Collapsed;
                        steps.Text = "";
                        Talk(steps.Text);
                    }*/
                }

            }
            catch
            {
                confidencecheck.Text = "Error returning the emotion";
            }
        }

        private void halltextBox_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            emotion_u = item.Content.ToString();
        }

        IMobileServiceTable<usertable> userTableObj = App.MobileService.GetTable<usertable>();
        private async void save_Click(object sender, RoutedEventArgs e)
        {
            items2 = await userTable
           .Where(userTable => userTable.User_Email == username.Text)
           .Select(userTable => userTable.id).ToListAsync();
            string userID = (string)items2[0]; //Ive got the id here
            JObject jo = new JObject();
            jo.Add("id", userID); //used as "where id== "....
           
            jo.Add("level4", ar);
            var inserted = await userTableObj.UpdateAsync(jo);
            Frame.Navigate(typeof(BlankPage5), username.Text);
        }
        /*private async void Talk(string message)
{



var stream = await speechSynthesizer.SynthesizeTextToStreamAsync(message);
media.SetSource(stream, stream.ContentType);
media.Play();



}*/

    }
}
