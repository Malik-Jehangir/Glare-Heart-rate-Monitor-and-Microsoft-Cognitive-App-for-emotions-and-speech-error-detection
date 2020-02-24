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
    public sealed partial class BlankPage5 : Page
    {
        List<DateTime> items;
        List<string> items2;
        List<double> items3;
        List<double> items4;
        List<double> items5;
        List<double> items6;
        string user_email;
        int a;
        private IMobileServiceTable<usertable> userTable = App.MobileService.GetTable<usertable>();
        public BlankPage5()
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
       
        private async void UpdateProgress()
        {
           
            //GET LEVEL 1 SCORE
            items3 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level1).ToListAsync();
            double score1= (double)items3[0];
            b1.Content = score1.ToString();
            if (score1 > 17)
            {
                b5.IsEnabled = true;
            }

            //GET LEVEL 2 SCORE
            items4 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level2).ToListAsync();
            double score2 = (double)items4[0];
            b5.Content = score2.ToString();
            if (score2 >=12)
            {
                b4.IsEnabled = true;
            }

            //GET LEVEL 3 SCORE
            items5 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level3).ToListAsync();
            double score3 = (double)items5[0];
           b4.Content = score3.ToString();
            if (score3 >= 12)
            {
               b3.IsEnabled = true;
            }

            //GET LEVEL 4 SCORE
            items6 = await userTable
            .Where(userTable => userTable.User_Email == username.Text)
            .Select(userTable => userTable.level4).ToListAsync();
            double score4 = (double)items6[0];
            b3.Content= score4.ToString();
           


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
                if (eventDate == DateTime.Now)
                {
                    var dialog = new MessageDialog("There are no upcoming events, please select a date !!!!");
                    await dialog.ShowAsync();
                }
                else if(eventDate !=DateTime.Now)
                {
               a = eventDate.Subtract(DateTime.Now.Date).Days;
                    if(a<=0)
                    {
                        //PROGRESS ROLE BACK EXCEPT THE TOTAL SCORE
                        items2 = await userTable
   .Where(userTable => userTable.User_Email == username.Text)
    .Select(userTable => userTable.id).ToListAsync();
                        string userID = (string)items2[0];
                        JObject jo = new JObject();
                        jo.Add("id", userID); //used as "where id== "....
                        jo.Add("level1", 0);
                        jo.Add("level2", 0);
                        jo.Add("level3", 0);
                        jo.Add("level4", 0);
                        jo.Add("level5", 0);
                        var inserted = await userTableObj.UpdateAsync(jo);

                        var dialog = new MessageDialog("Please select an event date and event type !!!!");
                        await dialog.ShowAsync();
                        //Frame.Navigate(typeof(BlankPage5), username.Text); //Refresh the page

                        //PROGRESS ROLE BACK EXCEPT THE TOTAL SCORE

                    }
                    else if(a > 0){
                        mydate.Visibility = Visibility.Collapsed;
                        halltextBox.Visibility = Visibility.Collapsed;
                      
                    }
                  
               level.Text = a.ToString();

                }
            }

            prog.IsActive = true;

            await Task.Yield();




            //EACH LEVEL'S PROGRESS
            double but1 = score1;
            double but2 = score2;
            double but3 = score3;
            double but4 = score4;

            //for but1
            if (but1 <= 0)
            {
                //display nothing
            }
            else if(but1>0 && but1<= 5)
            {
                /*pr1.Visibility = Visibility.Visible;
                b1.Background = new SolidColorBrush(Colors.Transparent);*/
                b1.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr1.png")), Stretch = Stretch.Fill };

            }
            else if (but1 > 5 && but1 <= 10)
            {
                /*pr2.Visibility = Visibility.Visible;
                b1.Background = new SolidColorBrush(Colors.Transparent);*/
                b1.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr2.png")), Stretch = Stretch.Fill };

            }
            else if (but1 > 10 && but1 <= 15)
            {
                /*pr3.Visibility = Visibility.Visible;
                b1.Background = new SolidColorBrush(Colors.Transparent);*/
                b1.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr3.png")), Stretch = Stretch.Fill };

            }
            else if (but1 > 15 && but1 <= 20)
            {
                /*pr4.Visibility = Visibility.Visible;
                b1.Background = new SolidColorBrush(Colors.Transparent);*/
                b1.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr4.png")), Stretch = Stretch.Fill };

            }




            //for but2
            if (but2 <= 0)
            {
                //display nothing
            }
            else if (but2 > 0 && but2 <= 5)
            {
                /*pra1.Visibility = Visibility.Visible;
                b5.Background = new SolidColorBrush(Colors.Transparent);*/
                b5.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr1.png")), Stretch = Stretch.Fill };

            }
            else if (but2 > 5 && but2 <= 10)
            {
                /*pra2.Visibility = Visibility.Visible;
                b5.Background = new SolidColorBrush(Colors.Transparent);*/
                b5.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr2.png")), Stretch = Stretch.Fill };

            }
            else if (but2 > 10 && but2 <= 15)
            {
                /*pra3.Visibility = Visibility.Visible;
                b5.Background = new SolidColorBrush(Colors.Transparent);*/
                b5.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr3.png")), Stretch = Stretch.Fill };

            }
            else if (but2 > 15 && but2 <= 20)
            {
                /*pra4.Visibility = Visibility.Visible;
                b5.Background = new SolidColorBrush(Colors.Transparent);*/
                b5.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr4.png")), Stretch = Stretch.Fill };

            }



            //for but3
            if (but3 <= 0)
            {
                //display nothing
            }
            else if (but3 > 0 && but3 <= 5)
            {
                /*prb1.Visibility = Visibility.Visible;
                b4.Background = new SolidColorBrush(Colors.Transparent);*/
                b4.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr1.png")), Stretch = Stretch.Fill };

            }
            else if (but3 > 5 && but3 <= 10)
            {
                /*prb2.Visibility = Visibility.Visible;
                b4.Background = new SolidColorBrush(Colors.Transparent);*/
                b4.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr2.png")), Stretch = Stretch.Fill };

            }
            else if (but3 > 10 && but3 <= 15)
            {
                /*prb3.Visibility = Visibility.Visible;
                b4.Background = new SolidColorBrush(Colors.Transparent);*/
                b4.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr3.png")), Stretch = Stretch.Fill };

            }
            else if (but3 > 15 && but3 <= 20)
            {
                /*prb4.Visibility = Visibility.Visible;
                b4.Background = new SolidColorBrush(Colors.Transparent);*/
                b4.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr4.png")), Stretch = Stretch.Fill };

            }



            //for but4
            if (but4 <= 0)
            {
                //display nothing
            }
            else if (but4 > 0 && but4 <= 5)
            {
                /*prc1.Visibility = Visibility.Visible;
                b3.Background = new SolidColorBrush(Colors.Transparent);*/
                b3.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr1.png")), Stretch = Stretch.Fill };

            }
            else if (but4 > 5 && but4 <= 10)
            {
                /*prc2.Visibility = Visibility.Visible;
                b3.Background = new SolidColorBrush(Colors.Transparent);*/
                b3.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr2.png")), Stretch = Stretch.Fill };

            }
            else if (but4 > 10 && but4 <= 15)
            {
                /*prc3.Visibility = Visibility.Visible;
                b3.Background = new SolidColorBrush(Colors.Transparent);*/
                b3.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr3.png")), Stretch = Stretch.Fill };

            }
            else if (but4 > 15 && but4 <= 20)
            {
                /*prc4.Visibility = Visibility.Visible;
                b3.Background = new SolidColorBrush(Colors.Transparent);*/
                b3.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/pr4.png")), Stretch = Stretch.Fill };


            }

            await Task.Delay(5000);
            Main.Visibility = Visibility.Visible;
            prog.Visibility = Visibility.Collapsed;
        }

        IMobileServiceTable<usertable> userTableObj = App.MobileService.GetTable<usertable>();

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
                level.Text = a.ToString();

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


                 }*/

            }

           
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage3), username.Text);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage6), username.Text);
        }

       

        private void b4_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage7), username.Text);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage2), username.Text);
        }

        private void trophies_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage8), username.Text);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage4));
        }
    }
}
