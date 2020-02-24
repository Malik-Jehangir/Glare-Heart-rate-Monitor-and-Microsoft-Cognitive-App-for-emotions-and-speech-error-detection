using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlareGuidelinePrinciple
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage8 : Page
    {
        List<DateTime> items;
        List<string> items2;
        List<double> items3;
        List<double> items4;
        List<double> items5;
        List<double> items6;
        List<double> items7;

        string user_email;
        int a;
        double scoreT;
      
        private IMobileServiceTable<usertable> userTable = App.MobileService.GetTable<usertable>();
        public BlankPage8()
        {
            this.InitializeComponent();

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

            Loaded += MainPage_loaded;

          
        }

        private void MainPage_loaded(object sender, RoutedEventArgs e)
        {
          

            UpdateProgress();

        }

        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            user_email = e.Parameter.ToString();
            username.Text = user_email;
        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("A score of level 1 touches 20. \n Points generated will be 100.");
            await dialog.ShowAsync();
        }

        private async void b5_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("A score of level 2 touches 20. \n Points generated will be 100.");
            await dialog.ShowAsync();
        }



        private async void b4_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("A score of level 3 touches 20. \n Points generated will be 100.");
            await dialog.ShowAsync();
        }

        private async void b3_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("A score of level 4 touches 20. \n Points generated will be 100.");
            await dialog.ShowAsync();
        }


        private async void UpdateProgress()
        {
          

            //GET LEVEL 1 SCORE
            items3 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level1).ToListAsync();
            double score1= (double)items3[0];
            if (score1 ==20)
            {
               b1.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/t1.png")), Stretch = Stretch.Fill };
                scoreT += 100;
            }

            //GET LEVEL 2 SCORE
            items4 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level2).ToListAsync();
            double score2 = (double)items4[0];
            if (score2==20)
            {
               
                b5.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/t2.png")), Stretch = Stretch.Fill };
                scoreT += 100;
            }

            //GET LEVEL 3 SCORE
            items5 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level3).ToListAsync();
            double score3 = (double)items5[0];
            if (score3 ==20)
            {
               
                b4.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/t3.png")), Stretch = Stretch.Fill };
                scoreT += 100;
            }

            //GET LEVEL 4 SCORE
            items6 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level4).ToListAsync();
            double score4 = (double)items6[0];
            if (score4 == 20)
            {
               
                b3.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/t4.png")), Stretch = Stretch.Fill };
                scoreT += 100;
            }

            /*//GET  total SCORE
            items7 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.total).ToListAsync();
            double score5 = (double)items7[0];
            myscore.Text = score5.ToString();
            double e;
            double.TryParse(myscore.Text, out e);
            scoreT += e;
            myscore.Text = scoreT.ToString();*/

            



            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems.
                items = await userTable
    .Where(userTable => userTable.User_Email == user_email)
     .Select(userTable => userTable.event_date).ToListAsync();
                //similar to select the ID from usertable where useremail is equal to email textbox text and password is equal to password text box
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                exception = ex;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                //do something
                DateTime eventDate = (DateTime)items[0];
                /*if (eventDate == DateTime.Now)
                {
                    var dialog = new MessageDialog("There are no upcoming events, please select a date !!!!");
                    await dialog.ShowAsync();
                }
                else if(eventDate !=DateTime.Now)
                {*/
               a = eventDate.Subtract(DateTime.Now.Date).Days;
                    if(a<0)
                    {
                        //roll back please
                    }
                    else if(a > 0){
                        /*mydate.Visibility = Visibility.Collapsed;
                        halltextBox.Visibility = Visibility.Collapsed;*/
                    }
                    else if (a == 0)
                    {
                        var dialog = new MessageDialog("Please select an event date and event type !!!!");
                        await dialog.ShowAsync();
                    }
               /*level.Text = a.ToString() + " day(s) remaining until the event starts.";*/
               /* }*/
            }

            prog.IsActive = true;

            await Task.Yield();

            await Task.Delay(5000);
           
            prog.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;

           

        }
        IMobileServiceTable<usertable> userTableObj = App.MobileService.GetTable<usertable>();
        private async void trophies_Click(object sender, RoutedEventArgs e)
        {
            items2 = await userTable
           .Where(userTable => userTable.User_Email == username.Text)
           .Select(userTable => userTable.id).ToListAsync();
            string userID = (string)items2[0];
            JObject jo = new JObject();
            jo.Add("id", userID); //used as "where id== "....
            jo.Add("total", scoreT);
            var inserted = await userTableObj.UpdateAsync(jo);
            Frame.Navigate(typeof(BlankPage5), username.Text);
        }
    }

       /*IMobileServiceTable<usertable> userTableObj = App.MobileService.GetTable<usertable>();

        private async void halltextBox_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            string hall = item.Content.ToString();
            if (hall != "None")
            {


               
                items2 = await userTable
    .Where(userTable => userTable.User_Email == username.Text)
     .Select(userTable => userTable.id).ToListAsync();
                string userID = (string)items2[0];
                JObject jo = new JObject();
                jo.Add("id",userID); //used as "where id== "....
                jo.Add("event_date", mydate.Date); 
                var inserted = await userTableObj.UpdateAsync(jo);

                a = mydate.Date.Subtract(DateTime.Now.Date).Days;
                level.Text = a.ToString() + " day(s) remaining until the event starts.";

                if (a < 0)
                {
                    var dialog = new MessageDialog("Please select an upcoming event !!!!");
                    await dialog.ShowAsync();
                }
                else if (a > 0)
                {
                    mydate.Visibility = Visibility.Collapsed;
                    halltextBox.Visibility = Visibility.Collapsed;
                }
               */

                /*int a = mydate.Date.Subtract(DateTime.Now.Date).Days;
                level.Text = a.ToString() + " days remaining until the event starts.";*/
                /* using (var client = new HttpClient())
                 {
                     var request = new
                     {
                         Inputs = new Dictionary<string, StringTable>() {
                                  {
                                      "Plan_input",
                                      new StringTable()
                                      {
                                          ColumnNames = new string[] {"Remaining Days", "Type"},
                                          Values = new string[,] {  {a.ToString(),hall} }
                                      }
                                  },
                              },
                         GlobalParameters = new Dictionary<string, string>()
                         {
                         }
                     };

                     const string key = "+tTcAEyAzsMCPkA3DeFynJtax55Yg6Dedgs50vkiyyeb+sbiKX6lJgP+huLC8WAzv87EIFkEq2Ao2YGF2DB7AQ==";
                     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);
                     client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/9190c4122e7e43319d3be5a196d998cd/services/515a61cd3b89417fab2633e5ef7b911c/execute?api-version=2.0");

                     HttpResponseMessage response = await client.PostAsJsonAsync("", request).ConfigureAwait(false);

                     // Resumes on background thread, so marshal to the UI thread
                     await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                     {
                         if (response.IsSuccessStatusCode)
                         {
                             // await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));
                             string result = await response.Content.ReadAsStringAsync();
                             Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(result);


                             level.Text = (string.Format("{0}", obj.Results.Plan_data.value.Values[0][0]));

                             if (level.Text == "level 8")
                             {
                                 t1.Visibility = Visibility.Visible;
                                 t2.Visibility = Visibility.Visible;
                                 t3.Visibility = Visibility.Visible;
                                 b1.Visibility = Visibility.Visible;
                                 b1.IsEnabled = true;
                                 b2.Visibility = Visibility.Visible;

                                 b3.Visibility = Visibility.Visible;


                             }



                         }
                         else
                         {
                             var dialog = new MessageDialog(String.Format("The request failed with status code: {0}", response.StatusCode));
                             await dialog.ShowAsync();
                         }
                     });


                 }

            }

           
        }*/

        
    }


