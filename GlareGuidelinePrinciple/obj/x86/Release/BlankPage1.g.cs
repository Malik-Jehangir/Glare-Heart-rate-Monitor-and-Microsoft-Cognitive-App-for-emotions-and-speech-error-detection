﻿#pragma checksum "C:\Users\MALIKJEHANGIRAHMED\Documents\Visual Studio 2017\Projects\GlareGuidelinePrinciple\GlareGuidelinePrinciple\BlankPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D8F2E97DF5D8D57A096570BD03E35BD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlareGuidelinePrinciple
{
    partial class BlankPage1 : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.g0 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.StatusMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.stop_Copy = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4:
                {
                    this.media = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 5:
                {
                    this.Main = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.heartRateDisplayText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.guideline = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.halltextBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 54 "..\..\..\BlankPage1.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.halltextBox).SelectionChanged += this.halltextBox_SelectionChangedAsync;
                    #line default
                }
                break;
            case 9:
                {
                    this.ColChart = (global::WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart)(target);
                }
                break;
            case 10:
                {
                    this.heartRateDisplay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 12:
                {
                    global::Windows.UI.Xaml.Controls.Button element12 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\BlankPage1.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element12).Click += this.Button_Click;
                    #line default
                }
                break;
            case 13:
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 30 "..\..\..\BlankPage1.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 31 "..\..\..\BlankPage1.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.Button_Click_2;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

