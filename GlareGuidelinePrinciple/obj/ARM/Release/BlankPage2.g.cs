﻿#pragma checksum "C:\Users\MALIKJEHANGIRAHMED\Documents\Visual Studio 2017\Projects\GlareGuidelinePrinciple\GlareGuidelinePrinciple\BlankPage2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4C644F57BC9A9CA1914F2F44E2547390"
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
    partial class BlankPage2 : 
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
                    this.tkphoto = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 16 "..\..\..\BlankPage2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.tkphoto).Click += this.tkphoto_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.generate = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\BlankPage2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.generate).Click += this.generate_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.steps = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.confidencecheck = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.image3 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 6:
                {
                    this.halltextBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 21 "..\..\..\BlankPage2.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.halltextBox).SelectionChanged += this.halltextBox_SelectionChangedAsync;
                    #line default
                }
                break;
            case 7:
                {
                    this.myscore = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.save = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 33 "..\..\..\BlankPage2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.save).Click += this.save_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.username = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

