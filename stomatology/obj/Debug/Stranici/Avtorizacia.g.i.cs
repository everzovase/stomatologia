﻿#pragma checksum "..\..\..\Stranici\Avtorizacia.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "56688DD012A3FAEBA241E3670AB382867CC36A9E76D20F3269EB10CFAF6C3860"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using stomatology.Stranici;


namespace stomatology.Stranici {
    
    
    /// <summary>
    /// Avtorizacia
    /// </summary>
    public partial class Avtorizacia : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Stranici\Avtorizacia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PoleLogin;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Stranici\Avtorizacia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PoleParol;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Stranici\Avtorizacia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KnopkaLogin;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Stranici\Avtorizacia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KnopkaReg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/stomatology;component/stranici/avtorizacia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Stranici\Avtorizacia.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PoleLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PoleParol = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.KnopkaLogin = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Stranici\Avtorizacia.xaml"
            this.KnopkaLogin.Click += new System.Windows.RoutedEventHandler(this.KnopkaLogin_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.KnopkaReg = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Stranici\Avtorizacia.xaml"
            this.KnopkaReg.Click += new System.Windows.RoutedEventHandler(this.KnopkaReg_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

