﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Controls;

namespace CIevlev.ClinicApp.DesktopClient
{
    public partial class WindowContainer : Window
    {
        private readonly Stack<UserControl> _previousContents;
        
        private UserControl _currentContent = null;

        public WindowContainer()
        {
            InitializeComponent();
            
            _previousContents = new Stack<UserControl>();

            ContentContainer.Content = new ControlMainMenu(this);
        }

        public void ChangeContent(UserControl newContent)
        {
            _previousContents.Push((UserControl) ContentContainer.Content);
            ContentContainer.Content = newContent;
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (_previousContents.Count > 0)
            {
                ContentContainer.Content = _previousContents.Pop();
            }
        }
    }
}