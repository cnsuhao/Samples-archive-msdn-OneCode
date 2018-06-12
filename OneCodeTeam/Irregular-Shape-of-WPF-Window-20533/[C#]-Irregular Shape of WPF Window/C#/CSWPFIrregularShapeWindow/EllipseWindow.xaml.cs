/********************************** Module Header **********************************\
*Module Name:  EllipseWindow.xaml.cs
*Project:      CSWPFIrregularShapeWindow
*Copyright (c) Microsoft Corporation.
*
*The EllipseWindow.xaml.cs file defines a EllipseWindow class is responsible for 
*command binding and relationship between command and menu item or button

*This source is subject to the Microsoft Public License.
*See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
*All other rights reserved.
*
*THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
*EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
*MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/

using System.Windows;
using System.Windows.Input;

namespace CSWPFIrregularShapeWindow
{
    /// <summary>
    /// Interaction logic for EllipseWindow.xaml
    /// </summary>
    public partial class EllipseWindow : Window
    {
        public EllipseWindow()
        {
            InitializeComponent();

            // Insert code required on object creation below this point
            CommandBinding cb = new CommandBinding();
            cb.Command = UICommandBase.CloseCmd;
            cb.Executed += new ExecutedRoutedEventHandler(CloseCmdExecuted);
            cb.CanExecute += new CanExecuteRoutedEventHandler(CloseCmdCanExecute);

            CommandBinding minb = new CommandBinding();
            minb.Command = UICommandBase.MinimizeCmd;
            minb.Executed += new ExecutedRoutedEventHandler(MinimizeCmdExecuted);
            minb.CanExecute += new CanExecuteRoutedEventHandler(MinimizeCmdCanExecute);

            CommandBinding maxb = new CommandBinding();
            maxb.Command = UICommandBase.MaximizeCmd;
            maxb.Executed += new ExecutedRoutedEventHandler(MaximizeCmdExecuted);
            maxb.CanExecute += new CanExecuteRoutedEventHandler(MaximizeCmdCanExecute);

            CommandBinding restoreb = new CommandBinding();
            restoreb.Command = UICommandBase.RestoreCmd;
            restoreb.Executed += new ExecutedRoutedEventHandler(RestoreCmdExecuted);
            restoreb.CanExecute += new CanExecuteRoutedEventHandler(RestoreCmdCanExecute);

            //Will execute the command object added to form the command object set
            this.CommandBindings.Add(cb);
            this.CommandBindings.Add(minb);
            this.CommandBindings.Add(maxb);
            this.CommandBindings.Add(restoreb);

            this.mnuInvokeClose.Command = UICommandBase.CloseCmd;
            this.mnuInvokeClose.CommandTarget = btnInvokeClose;
            this.btnInvokeClose.Command = UICommandBase.CloseCmd;

            this.mnuInvokeMaximize.Command = UICommandBase.MaximizeCmd;
            this.mnuInvokeMaximize.CommandTarget = btnInvokeMaximize;
            this.btnInvokeMaximize.Command = UICommandBase.MaximizeCmd;

            this.mnuInvokeMinimize.Command = UICommandBase.MinimizeCmd;
            this.mnuInvokeMinimize.CommandTarget = btnInvokeMinimize;
            this.btnInvokeMinimize.Command = UICommandBase.MinimizeCmd;

            this.mnuInvokeRestore.Command = UICommandBase.RestoreCmd;
            this.mnuInvokeRestore.CommandTarget = btnInvokeRestore;
            this.btnInvokeRestore.Command = UICommandBase.RestoreCmd;
            
        }

        /// <summary>
        /// Close window behavior
        /// </summary>
        private void CloseCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// CanExecuteRoutedEventHandler for the custom CloseCmd command
        /// </summary>
        private void CloseCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Minimize window behavior
        /// </summary>
        private void MinimizeCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// CanExecuteRoutedEventHandler for the custom MinimizeCmd command
        /// </summary>
        private void MinimizeCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Maximize window behavior
        /// </summary>
        private void MaximizeCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            // If canExcute could be used,then menu item and button which used by Maximize should switch
            bool canExecute = AvalonCommandsHelper.CanExecuteCommandSource(btnInvokeRestore);
            if (canExecute == true)
            {
                this.btnInvokeRestore.Visibility = Visibility.Visible;
                this.btnInvokeMaximize.Visibility = Visibility.Hidden;
                this.mnuInvokeMaximize.IsEnabled = false;
                this.mnuInvokeRestore.IsEnabled = true;
            }
            this.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// CanExecuteRoutedEventHandler for the custom MaximizeCmd command
        /// </summary>
        private void MaximizeCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Restore window behavior
        /// </summary>
        private void RestoreCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            // If canExcute could be used,then menu item and button which used by Restore should switch
            bool canExecute = AvalonCommandsHelper.CanExecuteCommandSource(btnInvokeRestore);
            if (canExecute == true)
            {
                this.btnInvokeRestore.Visibility = Visibility.Hidden;
                this.btnInvokeMaximize.Visibility = Visibility.Visible;
                this.mnuInvokeMaximize.IsEnabled = true;
                this.mnuInvokeRestore.IsEnabled = false;
            }
            this.WindowState = WindowState.Normal;
        }

        /// <summary>
        /// CanExecuteRoutedEventHandler for the custom RestoreCmd command
        /// </summary>
        private void RestoreCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// delegate event for Drag shape window
        /// </summary>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
