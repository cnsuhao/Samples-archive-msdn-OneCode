/**************************** Module Header ******************************\
' Module Name:  Default.aspx.cs
' Project:      CSD2DServerSideRendering
' Copyright (c) Microsoft Corporation.
' 
' This code demonstrates how to use Direct2D to render 2D objects and text to
' an image file on disk.  You will need to grant permission to the "Network Service" 
' user account for the folder on the server that you wish to save the image file to.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/



using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAPICodePack.DirectX;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.WindowsImagingComponent;
using Microsoft.WindowsAPICodePack.DirectX.DirectWrite;


namespace CSD2DServerSideRendering
{
    public partial class _Default : System.Web.UI.Page
    {

        D2DFactory d2dFactory;
        ImagingFactory wicFactory;
        DWriteFactory dwriteFactory;
        D2DBitmap d2dBitmapBarcode;
        RenderTarget wicRenderTarget;


        RenderTargetProperties renderProps = new RenderTargetProperties
        {
            PixelFormat = new PixelFormat(
                Microsoft.WindowsAPICodePack.DirectX.Graphics.Format.B8G8R8A8UNorm,
                AlphaMode.Ignore),
            Usage = RenderTargetUsages.None,
            RenderTargetType = RenderTargetType.Software 
        };


        // Demonstrates how to create a Direct2D bitmap based on image data in memory
        private void CreateBitmap()
        {
            // We have a 32 bpp Bitmap.  This is one example.  The width and height are:  69 x 23
            var size = new SizeU((uint)69, (uint)23);

            BitmapProperties bmpProp = new BitmapProperties(
                new PixelFormat(Microsoft.WindowsAPICodePack.DirectX.Graphics.Format.B8G8R8A8UNorm, AlphaMode.Ignore), 
                wicRenderTarget.Dpi.X, wicRenderTarget.Dpi.Y);

            d2dBitmapBarcode = wicRenderTarget.CreateBitmap(size, bmpProp);

            int nWidth = (int)size.Width;
            int nHeight = (int)size.Height;

            byte[] testData = new byte[nWidth * nHeight * 4];
            byte TestByte = 1;
            int nCurrentDest = 0;

            for (int y = 0; y < nHeight; y++)
            {
                for (int x = 0; x < nWidth; x++)
                {
                    byte CurrByte = (byte)TestByte++;

                    testData.SetValue(CurrByte, nCurrentDest);   // blue
                    testData.SetValue(CurrByte, nCurrentDest + 1);  // green
                    testData.SetValue(CurrByte, nCurrentDest + 2);  // red
                    nCurrentDest += 4;
                }
            }
            d2dBitmapBarcode.CopyFromMemory(testData, ((uint)nWidth) * 4 );
        } 


        protected void btnCreateImage_Click(object sender, EventArgs e)
        {
            // Create Factories.
            d2dFactory = D2DFactory.CreateFactory(D2DFactoryType.Multithreaded);
            wicFactory = ImagingFactory.Create();
            dwriteFactory = DWriteFactory.CreateFactory();

            float ShippingLabelWidth = 500.0f;
            float ShippingLabelHeight = 500.0f;

            SizeU size = new SizeU((uint)ShippingLabelWidth, (uint)ShippingLabelHeight);

            ImagingBitmap wicBitmap = wicFactory.CreateImagingBitmap(
                size.Width,
                size.Height,
                PixelFormats.Bgr32Bpp,
                BitmapCreateCacheOption.CacheOnLoad);

            wicRenderTarget =
                d2dFactory.CreateWicBitmapRenderTarget(wicBitmap, renderProps);

            // Create a sample Bitmap
            CreateBitmap();

            wicRenderTarget.BeginDraw();

            wicRenderTarget.Clear(new ColorF(0, 1, 0, 1));  // clear the background to white

            SolidColorBrush blackSolidColorBrush;

            blackSolidColorBrush = wicRenderTarget.CreateSolidColorBrush(new ColorF(0, 0, 0, 1));

            // Render an Ellipse
            Ellipse ellipse = new Ellipse();
            ellipse.Point = new Point2F(300.0f, 300.0f);
            ellipse.RadiusX = 100.0f;
            ellipse.RadiusY = 150.0f;

            wicRenderTarget.DrawEllipse(ellipse, blackSolidColorBrush, 10.0f);

            // Render a Rectangle
            RectF rect;
            rect = new RectF(130, 30, 200, 100);
            wicRenderTarget.DrawRectangle(rect, blackSolidColorBrush, 10.0f);

            // Render text rotated
            TextFormat textFormat_Value;

            textFormat_Value = dwriteFactory.CreateTextFormat("Arial", 17, Microsoft.WindowsAPICodePack.DirectX.DirectWrite.FontWeight.Bold, 
                Microsoft.WindowsAPICodePack.DirectX.DirectWrite.FontStyle.Normal, Microsoft.WindowsAPICodePack.DirectX.DirectWrite.FontStretch.Normal);

            RectF renderText_Value;

            renderText_Value = new RectF(10, 150, 180, 250);

            wicRenderTarget.Transform = Matrix3x2F.Rotation(90, new Point2F(100, 95));
            wicRenderTarget.DrawText("This is a test", textFormat_Value, renderText_Value, blackSolidColorBrush);
            wicRenderTarget.Transform = Matrix3x2F.Translation(0, 0);

            RectF DrawBitmap_Rect;
            DrawBitmap_Rect = new RectF(10, 275, 180, 350);
            wicRenderTarget.DrawBitmap(d2dBitmapBarcode, 1.0f, BitmapInterpolationMode.NearestNeighbor, DrawBitmap_Rect);

            wicRenderTarget.EndDraw();

            try
            {
                // This code will need write permissions to the folder on the server that you wish to save the image file to.
                // You will need to grant permission to the "Network Service" user account.
                wicBitmap.SaveToFile(wicFactory, ContainerFormats.Png, "c:\\SampleFiles\\Images\\test.png");
            }
            catch (Exception ex)
            {
                // Catch the exception that is unhandled in TryCast.

                Type ExceptionType = ex.GetType();

                // Check for System.UnauthorizedAccessException here.  You will need to grant permission 
                //   to the "Network Service" user account for the folder on the server that you wish to 
                //   save the image file to.

                // Restore the original unhandled exception. 
                throw;
            }
            finally
            {
                // Clean up
                d2dFactory.Dispose();
                wicFactory.Dispose();
                dwriteFactory.Dispose();
            }
        }
    }
}
