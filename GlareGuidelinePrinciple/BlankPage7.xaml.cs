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
    public sealed partial class BlankPage7 : Page
    {
        double onsorry = 0, onum = 0, onbasically = 0, onok = 0, onasyousee = 0, onactually = 0, onnow = 0, onsonow = 0, onsoandsofar = 0, onandsoon = 0, onsoon = 0, onyouknow = 0;

        private DispatcherTimer timer;
        private int countdown;
        int score3;
        List<string> items2;

        private IMobileServiceTable<usertable> userTable = App.MobileService.GetTable<usertable>();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string user_email = e.Parameter.ToString();
            username.Text = user_email;
        }

        public BlankPage7()
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


            this.Loaded += OnLoaded;

            //ring starts


            // Clearly, this complex dictionary would be better wrapped into an
            // object model - I'm being lazy.
            this.actions = new Dictionary<string, Dictionary<string, Action>>()
            {
                [SIZE_RULE] = new Dictionary<string, Action>()
                {


                    [THANK_YOU_OPTION] = OnAlltoyourself,
                    [SORRY_OPTION] = OnSorry,
                    [BASICALLY_OPTION] = OnBasically,
                    [OK_OPTION] = OnOk,
                    [AS_YOU_SEE_OPTION] = OnAsYouSee,
                    [ACTUALLY_OPTION] = OnActually,
                    [NOW_OPTION] = OnNow,
                    [SO_NOW_OPTION] = OnSoNow,
                    [SO_AND_SO_FAR_OPTION] = OnSoAndSoFar,
                    [AND_SO_ON_OPTION] = OnAndSoOn,
                    [SO_ON_OPTION] = OnSoOn,
                    [YOU_KNOW_OPTION] = OnYouKnow,
                    [UM_OPTION] = OnUhm


                }
            };

        }

        //FILLER
        private void OnYouKnow()
        {
            onyouknow += 1;
            onyouknow *= 0.5;
        }

        private void OnSoOn()
        {
            onsoon += 1;
            onsoon *= 0.5;
        }

        private void OnAndSoOn()
        {
            onandsoon += 1;
            onandsoon *= 0.5;
        }

        private void OnSoAndSoFar()
        {
            onsoandsofar += 1;
            onsoandsofar *= 0.5;
        }

        private void OnSoNow()
        {
            onsonow += 1;
            onsonow *= 0.5;
        }

        private void OnNow()
        {
            onnow += 1;
            onnow *= 0.5;
        }

        private void OnActually()
        {
            onactually += 1;
            onactually *= 0.5;
        }

        private void OnAsYouSee()
        {
            onasyousee += 1;
            onasyousee *= 0.5;
        }

        private void OnOk()
        {
            onok += 1;
            onok *= 0.5;
        }

        private void OnBasically()
        {
            onbasically += 1;
            onbasically *= 0.5;
        }


        private void OnSorry()
        {
            onsorry += 1;
            onsorry *= 0.5;
        }

        private void OnUhm()
        {
            onum += 1;
            onum *= 0.5;
        }
        //FILLER ENDS

        private void OnAlltoyourself()
        {
            resu.Text = lblCountdown.Text;
            int a;
            int.TryParse(lblCountdown.Text, out a); //Now a contains seconds consumed, it can be used for pace
            timer.Stop();
           /* btnCountdown.IsEnabled = false;*/
            if (a == 0)
            {
                pace.Text = "Time up!!\nVery slow";
                score3 = 0;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score3.ToString() + " / 20";
            }
            else if (a > 0 && a < 10)
            {
                
                pace.Text = "Normal";
                score3 = 20;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score3.ToString() + " / 20";


            }
            else if (a >= 10 && a < 15)
            {
                
                pace.Text = "Acceptable";
                score3 = 12;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score3.ToString() + " / 20";



            }
            else if (a >= 15 && a <20  )
            {
                
                pace.Text = "High";
                score3 = 7;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score3.ToString() + " / 20";

            }
        
            else if (a >= 20)
            {
               
                pace.Text = "Very high";
                score3 = 5;
                score_leve2.Visibility = Visibility.Visible;
                score_leve2.Text = score3.ToString() + " / 20";

            }

            //FOR FILLER
            string res = "";
            if (onum > 0)
            {
                res += "Uhm used " + onum + " %\n";
            }

            if (onsorry > 0)
            {
                res += "Sorry used " + onsorry + " %\n";
            }

            if (onbasically > 0)
            {
                res += "Basically used " + onbasically + " %\n";
            }

            if (onok > 0)
            {
                res += "OK used " + onok + " %\n";
            }

            if (onasyousee > 0)
            {
                res += "As you see used " + onasyousee + " %\n";
            }

            if (onnow > 0)
            {
                res += "Now used " + onnow + " %\n";
            }

            if (onsonow > 0)
            {
                res += "So now used " + onsonow + " %\n";
            }

            if (onsoandsofar > 0)
            {
                res += "So and so far used " + onsoandsofar + " %\n";
            }

            if (onandsoon > 0)
            {
                res += "And so on far used " + onandsoon + " %\n";
            }

            if (onsoon > 0)
            {
                res += "So on used " + onsoon + " %\n";
            }

            if (onyouknow > 0)
            {
                res += "You know used " + onyouknow + " %\n";
            }

            if (onactually > 0)
            {
                res += "Actually used " + onactually + " %\n";
            }

            result.Text = res;
            
            //FOR FILLER

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
            btnCountdown.Content = countdown.ToString();
            if (countdown <= 0)
            {
                MediaTool.Play();
                lblCountdown.Text = "Time up !!!!";
                timer.Stop();
            }
        }

        async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("By the end of your speech, please say 'Thank you'");
            await dialog.ShowAsync();

            this.speechRecognizer = new SpeechRecognizer();
            this.speechRecognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(0);
            this.speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(0);
            this.speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(0);

            var grammarFile = await StorageFile.GetFileFromApplicationUriAsync(
              new Uri("ms-appx:///grammar3.xml"));

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

        static readonly string THANK_YOU_OPTION = "Thank you";
        static readonly string SORRY_OPTION = "sorry";
        static readonly string BASICALLY_OPTION = "basically";
        static readonly string OK_OPTION = "ok";
        static readonly string AS_YOU_SEE_OPTION = "as you see";
        static readonly string ACTUALLY_OPTION = "actually";
        static readonly string NOW_OPTION = "now";
        static readonly string SO_NOW_OPTION = "so now";
        static readonly string SO_AND_SO_FAR_OPTION = "so and so far";
        static readonly string AND_SO_ON_OPTION = "and so on";
        static readonly string SO_ON_OPTION = "so on";
        static readonly string YOU_KNOW_OPTION = "you know";
        static readonly string UM_OPTION = "um";



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

            jo.Add("level3", score3);
            var inserted = await userTableObj.UpdateAsync(jo);
            Frame.Navigate(typeof(BlankPage5), username.Text);
        }
    }
}
