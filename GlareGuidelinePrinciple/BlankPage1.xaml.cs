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
using Windows.Networking;


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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlareGuidelinePrinciple
{
    public class GraphHR
    {
        public string SWtime { get; set; }
        public int HeartValues { get; set; }

    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page {
        int i;


       
    
      




        string hall;
        public int count = 0;
        SpeechSynthesizer speechSynthesizer;
        private DeviceInformation _devicePolar;
        private int combocount;
        Stopwatch myStopWatch = new Stopwatch();
        List<int> hList = new List<int>();
        List<string> tList = new List<string>();

        public string StatusInformation { get; private set; }
    
        public BlankPage1()
        {
            this.InitializeComponent();
            speechSynthesizer = new SpeechSynthesizer();
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
            media.Play();
            begin_process();



        }










  
        /// <summary>
        /// ///////////////////////////////////////////////////////////////heart rate//////////////////////////////////////////////////////////
        /// </summary>
        private async void begin_process()
        {
            var devices = await DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid(GattServiceUuids.HeartRate));
            if (null == devices || devices.Count <= 0) return;
            foreach (var device in devices.Where(device => device.Name == "Polar H7 D9C51918"))
            {
                _devicePolar = device;
                StatusInformation = string.Format("Found {0}", _devicePolar.Name);
                break;
            }
            if (_devicePolar == null) return;
            var service = await GattDeviceService.FromIdAsync(_devicePolar.Id);
            if (null == service) return;

            var characteristics = service.GetAllCharacteristics();
            if (null == characteristics || characteristics.Count <= 0) return;
            foreach (var characteristic in characteristics)
            {
                try
                {
                    characteristic.ValueChanged += GattCharacteristic_ValueChanged;
                    await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                }
                catch (Exception e)
                {
                    //do nothing
                }


            }


        }

        async void GattCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs eventArgs)
        {
            byte[] data = new byte[eventArgs.CharacteristicValue.Length];
            Windows.Storage.Streams.DataReader.FromBuffer(
                eventArgs.CharacteristicValue).ReadBytes(data);
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {

                var bpm = ProcessDataAsync(data);

                heartRateDisplay.Text = bpm.ToString();



            });

        }


        private int ProcessDataAsync(byte[] hrData)
        {
            // Heart Rate profile defined flag values
            const byte heartRateValueFormat = 0x01;

            byte currentOffset = 0;
            byte flags = hrData[currentOffset];
            bool isHeartRateValueSizeLong = ((flags & heartRateValueFormat) != 0);

            currentOffset++;

            ushort heartRateMeasurementValue;

            if (isHeartRateValueSizeLong)
            {
                heartRateMeasurementValue = (ushort)((hrData[currentOffset + 1] << 8) + hrData[currentOffset]);
                currentOffset += 2;
            }
            else
            {
                heartRateMeasurementValue = hrData[currentOffset];
            }

            return heartRateMeasurementValue;
        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////heart rate////////////////////////////////////////////////////////
        /// </summary>

      
        private async void Talk(string message)
        {

            tList.Add(guideline.Text);
      
            var stream = await speechSynthesizer.SynthesizeTextToStreamAsync(message);
            media.SetSource(stream, stream.ContentType);
            media.Play();



        }





        


        private async void OnClear() //this should be changed to "STOP"
        {
            i = (int)myStopWatch.Elapsed.Seconds;


            var dialog = new MessageDialog("Summary: \nTime taken: " + i.ToString() + " seconds" + " \nHeart Rate at end: " + heartRateDisplay.Text + "\nEnding guideline: " + guideline.Text + "\nType of hall: " + hall);
            await dialog.ShowAsync();

            //Ressting things to normal
            guideline.Text = "Guidelines will appear here";
            myStopWatch.Reset();
           
            //set the combo box to none so the whole process stops

        }

        private void halltextBox_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            combocount = 1;

            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            hall = item.Content.ToString();

            if (hall != "Stop" && hall !="None")
            {


                //////stop watch
                myStopWatch.Start();
                /////////stopwatch

                TimeSpan period = TimeSpan.FromSeconds(10);

                ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
                {
                    //
                    // TODO: Work
                    //

                    //
                    // Update the UI thread by using the UI core dispatcher.
                    //
                    await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                        () =>
                        {

                            MachineLearning();

                        });

                }, period);


            }
            else if (hall == "Stop" && combocount > 0)
            {

                OnClear();
            }


        }

        private async void MachineLearning()
        {

            using (var client = new HttpClient())
            {
                var request = new
                {
                    Inputs = new Dictionary<string, StringTable>() {
                                 {
                                     "User_HR_input",
                                     new StringTable()
                                     {
                                         ColumnNames = new string[] {"User_HR", "Hall_Type"},
                                         Values = new string[,] {  {heartRateDisplay.Text.ToString(),hall} }
                                     }
                                 },
                             },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string key = "1l5OeZZhInD6zQREWQCN/EPX+qd6ACzUJBG8hQTtdlnnq3SZ7gB0EjF7vsiTprfWawP8wydf6MTiHFViN69B0Q==";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/9190c4122e7e43319d3be5a196d998cd/services/3eac450e47fc421e8c026cc71039302c/execute?api-version=2.0");

                HttpResponseMessage response = await client.PostAsJsonAsync("", request).ConfigureAwait(false);

                // Resumes on background thread, so marshal to the UI thread
                await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));
                        string result = await response.Content.ReadAsStringAsync();
                        Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(result);


                        guideline.Text = (String.Format("{0}", obj.Results.Guideline_data.value.Values[0][15]));

                        Talk(guideline.Text);
                        hList.Add(Int32.Parse(heartRateDisplay.Text)); //At each call, fills the array list which will be used for graphs


                    }
                    else
                    {
                        var dialog = new MessageDialog(String.Format("The request failed with status code: {0}", response.StatusCode));
                        await dialog.ShowAsync();
                    }
                });


            }
        }










      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            media.Stop();

            this.Frame.Navigate(typeof(MainPage));



        }

       

        
           


       

    }
}


