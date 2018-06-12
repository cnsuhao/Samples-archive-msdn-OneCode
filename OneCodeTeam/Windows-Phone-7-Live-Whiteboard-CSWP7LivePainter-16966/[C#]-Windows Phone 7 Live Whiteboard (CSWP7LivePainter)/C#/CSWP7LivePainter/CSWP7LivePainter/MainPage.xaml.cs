/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cs
* Project:		CSWP7LivePainter
* Copyright (c) Microsoft Corporation.
* 
* When app start, Windows Phone will send a http request to tell server this is 
* an online phone. When drawing is done (lose mouse focus event). Windows Phone 
* will send the points info to server. At the same time, when any points info 
* comes from server (notification push). Lines will be drawn in Inkpresenter control.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;
using System.IO;
using System.Windows.Ink;
using System.Text;

namespace CSWP7LivePainter
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpNotificationChannel pushChannel;
        string channelName = "LivePainterChannel";
        Guid id = new Guid();
        string serverHost = "";
        public MainPage()
        {
            InitializeComponent();
            id = Guid.NewGuid();
        }

        /// <summary>
        /// This method will get the Notification Channel URI.
        /// </summary>
        /// <returns></returns>
        private HttpNotificationChannel GetPushChannel()
        {
            HttpNotificationChannel pushChannel = HttpNotificationChannel.Find(channelName);
            // If the channel was not found, then create a new connection to the push service.
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName);

                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated +=
                    new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred +=
                    new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);
                pushChannel.HttpNotificationReceived +=
                    new EventHandler<HttpNotificationEventArgs>(PushChannel_HttpNotificationReceived);

                pushChannel.Open();
            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated +=
                    new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred +=
                    new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);
                pushChannel.HttpNotificationReceived +=
                    new EventHandler<HttpNotificationEventArgs>(PushChannel_HttpNotificationReceived);

                // Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                System.Diagnostics.Debug.WriteLine(pushChannel.ChannelUri.ToString());

                MessageBox.Show(String.Format("Channel Uri remains {0}",
                                pushChannel.ChannelUri.ToString()));
            }

            return pushChannel;
        }

        /// <summary>
        /// Send http request to tell server that I am online and register 
        /// this device to server. 
        /// </summary>
        /// <param name="id">Device id</param>
        /// <param name="uri">Notification channel URI</param>
        void RegisterDevice(Guid id, Uri uri)
        {
            string serviceURL = serverHost+"AddPhone.srv";
            string postData = "id=" + id.ToString() + "&channelUri=" + uri.ToString();
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/x-www-form-urlencoded";
            webClient.UploadStringAsync(new Uri(serviceURL), "POST", postData);
            webClient.UploadStringCompleted +=
                new UploadStringCompletedEventHandler(webClient_UploadStringCompleted);
        }

        void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(() => MessageBox.Show("upload device info done"));
        }

        /// <summary>
        /// Tell server that this app is closed and unregister from server. 
        /// </summary>
        /// <param name="id">Device id.</param>
        void UnRegisterPhone(Guid id)
        {
            string serviceURL = serverHost + "RemovePhone.srv";
            string postData = "id=" + id.ToString();
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/x-www-form-urlencoded";
            webClient.UploadStringAsync(new Uri(serviceURL), "POST", postData);
        }

        /// <summary>
        /// This event will raise when channel uri is updated. 
        /// </summary>
        void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                RegisterDevice(id, e.ChannelUri);
                MessageBox.Show(String.Format("Channel Uri updated {0}", e.ChannelUri.ToString()));
            });
        }

        /// <summary>
        /// Event handler for push notification errors.
        /// </summary>
        void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            // Error handling logic for your particular application would be here.
            Dispatcher.BeginInvoke(() =>
                MessageBox.Show(String.Format("A push notification {0} error occurred.  {1} ({2}) {3}",
                                              e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData)));
        }

        /// <summary>
        /// Event handler for when a raw notification arrives.  For this sample, the raw 
        /// data is simply displayed in a MessageBox.
        /// </summary>
        void PushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                Stream bodyStream = e.Notification.Body;
                Stroke stroke = GetStroke(bodyStream);
                this.MyIPtest.Strokes.Add(stroke);
            });
        }

        /// <summary>
        /// This method will deal with the raw stroke info from server. 
        /// First read bytes from a UTF8 stream. then extract the points array
        /// from bytes array. and final turns to be a Stroke object that 
        /// can be showed in InkPresenter. 
        /// </summary>
        private Stroke GetStroke(Stream strokeStream)
        {
            BinaryReader br = new BinaryReader(strokeStream);
            System.Text.UTF8Encoding encoder = new UTF8Encoding();
            byte[] strokeBytes = br.ReadBytes((int)strokeStream.Length);
            string strokeString = encoder.GetString(strokeBytes, 0, strokeBytes.Length);

            double[] strokeArray = StringToDoubleArray(strokeString);
            int arrayLength = strokeArray.Length;
            Stroke stroke = new Stroke();
            StylusPoint sp;
            for (int i = 0; i < arrayLength; i = i + 2)
            {
                sp = new StylusPoint();
                sp.X = strokeArray[i];
                sp.Y = strokeArray[i + 1];
                stroke.StylusPoints.Add(sp);
            }
            return stroke;
        }

        Stroke newStroke;
        /// <summary>
        /// When mouse capture lost, call the SendPointsInfo to server. 
        /// </summary>
        public void MyIP_LostMouseCapture(object sender, MouseEventArgs e)
        {
            this.MyIP.ReleaseMouseCapture();
            if (newStroke == null)
            {
                return;
            }

            SendPointsInfo();
            newStroke = null;
        }

        /// <summary>
        /// The method will do the real send jobs. first, get the points info
        /// and construct these position as a array.We can also serialize
        /// these info as xml string. but passing Array around will save space 
        /// and time. 
        /// </summary>
        private void SendPointsInfo()
        {
            var points = newStroke.StylusPoints;
            double[] strokArray = new double[points.Count * 2];
            int i = 0;
            foreach (var point in points)
            {
                strokArray[i] = point.X;
                i++;
                strokArray[i] = point.Y;
                i++;
            }

            string strokeString = DoubleArrayToString(strokArray);

            string serviceURL = serverHost + "Relay.srv";
            string postData = "id=" + id.ToString() + "&strokeString=" + strokeString;
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/x-www-form-urlencoded";
            webClient.UploadStringAsync(new Uri(serviceURL), "POST", postData);
        }

        /// <summary>
        /// Change the points array to a string, a points string separated by
        /// comma. for example:[10,11,12,13] will be transferred to 
        /// "10,11,12,13,"
        /// </summary>
        private string DoubleArrayToString(double[] doubleArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < doubleArray.Length; i++)
            {
                sb.Append(doubleArray[i].ToString());
                sb.Append(",");
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method function extract points array from a points string. 
        /// please do a compare with DoubleArrayToString method. 
        /// </summary>
        private double[] StringToDoubleArray(string strokeString)
        {
            string[] stringArray = strokeString.Split(',');
            double[] strokeArray = new double[stringArray.Length - 1];
            for (int i = 0; i < strokeArray.Length; i++)
            {
                strokeArray[i] = Double.Parse(stringArray[i]);
            }
            return strokeArray;
        }

        /// <summary>
        /// This method capture mouse down event and initialize related objects. 
        /// </summary>
        private void MyIP_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyIP.CaptureMouse();
            StylusPointCollection myStylusPointCollection = new StylusPointCollection();
            myStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(MyIP));
            newStroke = new Stroke(myStylusPointCollection);
            newStroke.DrawingAttributes.Color = Colors.Blue;
            MyIP.Strokes.Add(newStroke);
        }

        /// <summary>
        /// Add stroke info into shared stroke object(newStroke).
        /// </summary>
        private void MyIP_MouseMove(object sender, MouseEventArgs e)
        {
            if (newStroke != null)
            {
                newStroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(MyIP));
            }
        }

        /// <summary>
        /// Unregister the device when user turn away from this page. 
        /// </summary>
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // delete device info from server
            UnRegisterPhone(id);
        }

        private void btn_ServerOk_Click(object sender, RoutedEventArgs e)
        {
            serverHost = txtBox_ServerAddress.Text;
            pushChannel = this.GetPushChannel();
        }
    }
}