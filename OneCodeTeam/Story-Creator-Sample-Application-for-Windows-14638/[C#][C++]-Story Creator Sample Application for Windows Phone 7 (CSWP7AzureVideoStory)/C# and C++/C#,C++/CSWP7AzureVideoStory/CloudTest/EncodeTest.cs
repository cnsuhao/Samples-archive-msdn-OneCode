using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;

namespace CloudTest
{
    [TestClass]
    public class EncodeTest
    {
        [DllImport("NativeVideoEncoder.dll", CharSet = CharSet.Unicode)]
        private static extern int EncoderVideo(string inputFile, string outputFile, string logFile);

        [TestMethod]
        public void Encode()
        {
            int hr = EncoderVideo("test.xml", "test.mp4", "test.log");
            Assert.AreEqual(hr, 0);
        }

        // Use Fiddler to test the following services:
        // POST http://localhost:3229/stories
        // Request body:
/* 
            <Story Name="Test Story" PhotoCount="4">
              <Photo Name="Blue hills.jpg" PhotoDuration="3">
                <Transition Name="Fade Transition" Duration="2" />
              </Photo>
              <Photo Name="Test.jpg" PhotoDuration="5">
                <Transition Direction="Left" Name="Fly In Transition" Duration="3" />
              </Photo>
              <Photo Name="Sunset.jpg" PhotoDuration="4">
                <Transition Direction="Right" Name="Fly In Transition" Duration="1" />
              </Photo>
              <Photo Name="Water lilies.jpg" PhotoDuration="6">
                <Transition Direction="Top" Name="Fly In Transition" Duration="3" />
              </Photo>
                <Photo Name="Winter.jpg" PhotoDuration="4">
                <Transition Direction="Down" Name="Fly In Transition" Duration="2" />
              </Photo>
            </Story>
 */
        // Expected result (ID and Uri may differ):

        //HTTP/1.1 201 Created
        //Content-Type: text/xml; charset=utf-8
        /*
         <Story ID="8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9">
          <Photo Name="Blue hills.jpg" Uri="http://127.0.0.1:10000/devstoreaccount1/videostories/8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9/Blue%20hills.jpg?st=2011-06-30T07%3A56    %   3A26Z&amp;se=2011-06-30T08%3A26%3A26Z&amp;sr=b&amp;sp=w&amp;sig=9i9Lg3q3%2BOu41P%2FEFWICud19bCrHeZZZOD1l2IZmqJI%3D" />
          <Photo Name="Test.jpg" Uri="http://127.0.0.1:10000/devstoreaccount1/videostories/8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9/Test.jpg?st=2011-06-30T07%3A56% 3A26    Z&amp;se=2011-06-30T08%3A26%3A26Z&amp;sr=b&amp;sp=w&amp;sig=s4FVyT4HsVbyZZ8JIoptwz%2FYd8IX5Y7CnXn%2Baw%2FkPrQ%3D" />
          <Photo Name="Sunset.jpg" Uri="http://127.0.0.1:10000/devstoreaccount1/videostories/8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9/Sunset.jpg?st=2011-06-30T07%3A56% 3A26    Z&amp;se=2011-06-30T08%3A26%3A26Z&amp;sr=b&amp;sp=w&amp;sig=tXHuf407NGw%2FTxe61HxQCXr%2BvjoM8Dvdyn2VPQFudwY%3D" />
          <Photo Name="Water lilies.jpg" Uri="http://127.0.0.1:10000/devstoreaccount1/videostories/8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9/Water%20lilies.jpg?st=2 011-06-30T07%    3A56%3A26Z&amp;se=2011-06-30T08%3A26%3A26Z&amp;sr=b&amp;sp=w&amp;sig=OADTsrYM%2B2xpmekf4COYYQ7bkeKjYqZiZIE12qqs8DE%3D" />
         <Photo Name="Winter.jpg" Uri="http://127.0.0.1:10000/devstoreaccount1/videostories/8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9/Winter.jpg?st=2 011-06-30T07%    3A56%3A26Z&amp;se=2011-06-30T08%3A26%3A26Z&amp;sr=b&amp;sp=w&amp;sig=OADTsrYM%2B2xpmekf4COYYQ7bkeKjYqZiZIE12qqs8DE%3D" />
        </Story>
         */


        // Then upload the photos using tools.

        // PUT http://localhost:3229/stories/8bc2b3f3-1d03-44b0-8765-9e6be47e7ce9?commit=true
        // Change the story ID according to the above response.
    }
}
