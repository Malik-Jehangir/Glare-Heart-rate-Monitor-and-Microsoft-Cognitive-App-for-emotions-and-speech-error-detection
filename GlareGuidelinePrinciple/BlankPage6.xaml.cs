using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI;
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
    public sealed partial class BlankPage6 : Page
    {
        private DispatcherTimer timer;
        private int countdown;
        int score2;
        List<string> items2;

        private IMobileServiceTable<usertable> userTable = App.MobileService.GetTable<usertable>();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string user_email = e.Parameter.ToString();
            username.Text = user_email;
        }

        public BlankPage6()
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


            para.Text = "Like an oyster, Bahrain has a rough exterior that takes some prising open. Nowadays the country has its own Formula 1 grand prix, a growing art and foodie scene frequented by Manama's sizeable expat population, and all the hallmarks of wealth, modern Arabian style, have it all to yourself.";

            this.Loaded += OnLoaded;

            //ring starts
            

            // Clearly, this complex dictionary would be better wrapped into an
            // object model - I'm being lazy.
            this.actions = new Dictionary<string, Dictionary<string, Action>>()
            {
                [SIZE_RULE] = new Dictionary<string, Action>()
                {


                    [ALL_TO_YOURSELF_OPTION] = OnAlltoyourself

                    
                }
            };

        }

        private void OnAlltoyourself()
        {
           res.Text = lblCountdown.Text;
            int a;
            int.TryParse(lblCountdown.Text, out a); //Now a contains seconds consumed, it can be used for pace
            timer.Stop();
            /*btnCountdown.IsEnabled = false;*/

            if (a == 0)
            {
                pace.Text = "Time up!!\nVery slow";
                score2 = 0;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score2.ToString() + " / 20";
            }
            else if (a > 0 && a < 10)
            {
               
                pace.Text = "Normal";
                score2 = 20;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score2.ToString() + " / 20";


            }
            else if (a >= 10 && a < 15)
            {
                //speed is Medium, yellow

               
                pace.Text = "Acceptable";
                score2 = 12;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score2.ToString() + " / 20";



            }
            else if (a >= 15 && a <20  )
            {
               
                pace.Text = "High";
                score2 = 7;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score2.ToString() + " / 20";

            }
        
            else if (a >= 20)
            {
                
                pace.Text = "Very high";
                score2 = 5;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score2.ToString() + " / 20";

            }
        }

        private void btnCountdown_Click(object sender, RoutedEventArgs e)
        {
            countdown = 30;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
            timer.Start();

        }

        private void timer_tick(object sender, object e)
        {
            countdown--;
            lblCountdown.Text = countdown.ToString();
            btnCountdown.Content= countdown.ToString();
            if (countdown <= 0)
            {
                MediaTool.Play();
                lblCountdown.Text = "Time up !!!!";
                timer.Stop();
            }
        }

        async void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.speechRecognizer = new SpeechRecognizer();
            this.speechRecognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(0);
            this.speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(0);
            this.speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(0);

            var grammarFile = await StorageFile.GetFileFromApplicationUriAsync(
              new Uri("ms-appx:///grammar2.xml"));

            this.speechRecognizer.Constraints.Add(
              new SpeechRecognitionGrammarFileConstraint(grammarFile));

            var result = await speechRecognizer.CompileConstraintsAsync();

            if (result.Status == SpeechRecognitionResultStatus.Success)
            {
                while (true)
                {
                    var speechResult = await speechRecognizer.RecognizeAsync();

                    if ((speechResult.Confidence == SpeechRecognitionConfidence.Medium) ||
                      (speechResult.Confidence == SpeechRecognitionConfidence.High))
                    {
                        string spokenCommand = string.Empty;

                        var lastRulePath = speechResult.RulePath.Last();
                        IReadOnlyList<string> values = null;

                        if (speechResult?.SemanticInterpretation?.Properties.TryGetValue(
                          ACTION_IDENTIFIER, out values) == (bool)true)
                        {
                            var action = values.FirstOrDefault();

                            // Ok, we have a rule and an action. Need to execute on it.
                            this.actions[lastRulePath]?[action]?.Invoke();
                        }
                    }
                }
            }
        }
        SpeechRecognizer speechRecognizer;
        Dictionary<string, Dictionary<string, Action>> actions;
        static readonly string SIZE_RULE = "sizetype";

        static readonly string ALL_TO_YOURSELF_OPTION = "all to yourself";

     

        static readonly string ACTION_IDENTIFIER = "action";

        IMobileServiceTable<usertable> userTableObj = App.MobileService.GetTable<usertable>();
        private async void save_Click(object sender, RoutedEventArgs e)
        {
            items2 = await userTable
           .Where(userTable => userTable.User_Email == username.Text)
           .Select(userTable => userTable.id).ToListAsync();
            string userID = (string)items2[0]; //Ive got the id here
            JObject jo = new JObject();
            jo.Add("id", userID); //used as "where id== "....
          
            jo.Add("level2", score2);
            var inserted = await userTableObj.UpdateAsync(jo);
            Frame.Navigate(typeof(BlankPage5), username.Text);
        }

      
    }
}
