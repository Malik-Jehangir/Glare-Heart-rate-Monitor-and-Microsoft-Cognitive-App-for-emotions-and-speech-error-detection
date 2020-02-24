using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlareGuidelinePrinciple
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage4 : Page
    {
        List<string> items;
        private IMobileServiceTable<usertable> userTable = App.MobileService.GetTable<usertable>();

        public BlankPage4()
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
        }
        IMobileServiceTable<usertable> userTableObj = App.MobileService.GetTable<usertable>();
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                usertable obj = new usertable();
              
                obj.User_Email = Uemail.Text;
                obj.Password = password.Password;
                obj.event_date = DateTime.Now;
                obj.level1 = 0;
                obj.level2 = 0;
                obj.level3 = 0;
                obj.level4 = 0;
                obj.level5 = 0;
                obj.total = 0;

                await userTableObj.InsertAsync(obj);
                MessageDialog msgDialog = new MessageDialog("Signed up successfully!!!");
                await msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                await msgDialogError.ShowAsync();
            }
        }

        private async void Button_Click_1Async(object sender, RoutedEventArgs e)
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems.
                 items = await userTable
     .Where(userTable => userTable.User_Email == Uemail.Text && userTable.Password == password.Password)
      .Select(userTable => userTable.id).ToListAsync();
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
                if (items.Count == 1)
                {
                    Frame.Navigate(typeof(BlankPage5), Uemail.Text);
                }
                else
                {
                    
                    MessageDialog msgDialog = new MessageDialog("Email or password is incorrect !!");
                    await msgDialog.ShowAsync();
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
