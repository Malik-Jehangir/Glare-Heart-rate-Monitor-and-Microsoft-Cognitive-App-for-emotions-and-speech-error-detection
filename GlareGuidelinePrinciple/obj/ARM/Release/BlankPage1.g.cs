﻿#pragma checksum "C:\Users\MALIKJEHANGIRAHMED\Documents\Visual Studio 2017\Projects\GlareGuidelinePrinciple\GlareGuidelinePrinciple\BlankPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4DB52AC311D356B1EFC90A1E8630632A"
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
                    this.StatusMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.media = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 3:
                {
                    this.heartRateDisplayText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.halltextBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 19 "..\..\..\BlankPage1.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.halltextBox).SelectionChanged += this.halltextBox_SelectionChangedAsync;
                    #line default
                }
                break;
            case 5:
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\BlankPage1.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Button_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.heartRateDisplay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.guideline = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

