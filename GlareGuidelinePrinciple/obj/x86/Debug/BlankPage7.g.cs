﻿#pragma checksum "C:\Users\MALIKJEHANGIRAHMED\Documents\Visual Studio 2017\Projects\GlareGuidelinePrinciple\GlareGuidelinePrinciple\BlankPage7.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A53EE0085138E970D1324AFBDBD2DCED"
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
    partial class BlankPage7 : 
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
                    this.username = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.lblCountdown = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.btnCountdown = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 136 "..\..\..\BlankPage7.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCountdown).Click += this.btnCountdown_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.MediaTool = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 5:
                {
                    this.pace = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.res = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.score_leve2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.save = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 145 "..\..\..\BlankPage7.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.save).Click += this.save_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.result = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.resu = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

