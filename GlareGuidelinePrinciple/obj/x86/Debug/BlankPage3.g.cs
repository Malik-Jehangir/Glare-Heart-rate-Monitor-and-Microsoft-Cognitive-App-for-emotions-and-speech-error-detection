﻿#pragma checksum "C:\Users\MALIKJEHANGIRAHMED\Documents\Visual Studio 2017\Projects\GlareGuidelinePrinciple\GlareGuidelinePrinciple\BlankPage3.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1FDCE07049D0F8CECCF82A5BC1CF412B"
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
    partial class BlankPage3 : 
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
                    this.result = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.dd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 134 "..\..\..\BlankPage3.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.dd).Click += this.Button_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.level1_final = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 136 "..\..\..\BlankPage3.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 5:
                {
                    this.username = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.level1_final_text = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

