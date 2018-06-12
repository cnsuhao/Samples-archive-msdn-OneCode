# How to embed video player in Excel 2013 by using Excel Content Pane App
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Viedo Play
* Content pane app
## IsPublished
* True
## ModifiedDate
* 2014-01-07 08:11:40
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to Embed Video Player into Excel Content Pane App (JSO15EmbedVideoPlayInContentPane)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This demonstration shows how to embed video player into Excel content pane app. The apps for Office platform let you create engaging new consumer and enterprise experiences running within supported Office 2013 applications by using the
 power of the web and standard web technologies like HTML5, XML, CSS3, JavaScript, and REST APIs.<span style="color:red">
</span>So we can use video tag of html5 to embed video player into excel.<span> </span>
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal"><span>Install Office 2013 RTM and Install Visual Studio 2012 RTM.
</span></p>
<p class="MsoNormal"><a href="http://www.microsoft.com/web/handlers/WebPI.ashx?command=GetInstallerRedirect&appid=OfficeToolsForVS2012GA"><span style="font-size:11.5pt; line-height:115%; color:#954f72">Download</span></a><span class="apple-converted-space"><span><span style="font-size:11.5pt; line-height:115%; color:black">&nbsp;</span>and
 Install Microsoft Office Developer Tools for Visual Studio 2012.</span></span><span style="font-size:11.5pt; line-height:115%; color:black">
</span><span>&nbsp;</span></p>
<h2>Running the Sample<span> </span></h2>
<p class="MsoNormal"><span>Step1.<span>&nbsp; </span>Open the solution file &quot;JSO15EmbedVideoPlayInContentPane.sln&quot;. Press &quot;F5&quot; on the keyboard to run the project. You will see something like this:
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/106814/1/image.png" alt="" width="576" height="500" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Step2. You can click play button to play the video. You also can click pause button to pause the play.
</span></p>
<p class="MsoNormal">N<span>ote: The Speed function is not supported in the Excel content pane app. But it can be used in Browser.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span>Step1. Create an App for Office 2013 project by using Visual Studio 2012 RTM.
</span></p>
<p class="MsoNormal"><span>Step2. Design the UI of the Task Pane by using the following HTML code snippets:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;body&gt;
    &lt;!-- Page content --&gt;
    &lt;div class=&quot;videoContainer&quot;&gt;
    
    &lt;video id=&quot;myVideo&quot; preload=&quot;auto&quot; poster=&quot;../../Images/poster.jpg&quot; width=&quot;600&quot; height=&quot;350&quot;&gt;
      &lt;source src=&quot;http://content4.catalog.video.msn.com/e2/ds/3ba640f1-9b16-455c-9f9d-0c4aca4dc740.mp4&quot; type=&quot;video/mp4&quot; /&gt;     
      &lt;p&gt;Your browser does not support the video tag.&lt;/p&gt;
    &lt;/video&gt;


    &lt;div class=&quot;caption&quot;&gt;Embed Video Player into Excel Content Pane app&lt;/div&gt;


    &lt;!--Custom Control--&gt;
    &lt;div class=&quot;control&quot;&gt;
        &lt;div class=&quot;topControl&quot;&gt;
            &lt;div class=&quot;progress&quot;&gt;
                &lt;span class=&quot;bufferBar&quot;&gt;&lt;/span&gt;
                &lt;span class=&quot;timeBar&quot;&gt;&lt;/span&gt;
            &lt;/div&gt;
            &lt;div class=&quot;time&quot;&gt;
                &lt;span class=&quot;current&quot;&gt;&lt;/span&gt; / 
                &lt;span class=&quot;duration&quot;&gt;&lt;/span&gt; 
            &lt;/div&gt;
        &lt;/div&gt;
        
        &lt;div class=&quot;btmControl&quot;&gt;
            &lt;div title=&quot;Play/Pause video&quot; class=&quot;btnPlay btn&quot;&gt;&lt;/div&gt;
            &lt;div title=&quot;Stop video&quot; class=&quot;btnStop btn&quot;&gt;&lt;/div&gt;
            &lt;div class=&quot;spdText btn&quot;&gt;Speed: &lt;/div&gt;
            &lt;div title=&quot;Normal speed&quot; class=&quot;btnx1 btn text selected&quot;&gt;x1&lt;/div&gt;
            &lt;div title=&quot;Fast forward x3&quot; class=&quot;btnx3 btn text&quot;&gt;x3&lt;/div&gt;            
            &lt;div title=&quot;Turn on/off light&quot; class=&quot;btnLight lighton btn&quot;&gt;&lt;/div&gt;
            &lt;div title=&quot;Set volume&quot; class=&quot;volume&quot;&gt;
                &lt;span class=&quot;volumeBar&quot;&gt;&lt;/span&gt;
            &lt;/div&gt;
            &lt;div title=&quot;Mute/Unmute sound&quot; class=&quot;sound sound2 btn&quot;&gt;&lt;/div&gt;
        &lt;/div&gt;    
    &lt;/div&gt;


    &lt;div class=&quot;loading&quot;&gt;&lt;/div&gt;
&lt;/div&gt;
&lt;/body&gt;

</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;Page&nbsp;content&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;videoContainer&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;video</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;myVideo&quot;</span>&nbsp;<span class="html__attr_name">preload</span>=<span class="html__attr_value">&quot;auto&quot;</span>&nbsp;<span class="html__attr_name">poster</span>=<span class="html__attr_value">&quot;../../Images/poster.jpg&quot;</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;600&quot;</span>&nbsp;<span class="html__attr_name">height</span>=<span class="html__attr_value">&quot;350&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;source</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;http://content4.catalog.video.msn.com/e2/ds/3ba640f1-9b16-455c-9f9d-0c4aca4dc740.mp4&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;video/mp4&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Your&nbsp;browser&nbsp;does&nbsp;not&nbsp;support&nbsp;the&nbsp;video&nbsp;tag.<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/video&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;caption&quot;</span><span class="html__tag_start">&gt;</span>Embed&nbsp;Video&nbsp;Player&nbsp;into&nbsp;Excel&nbsp;Content&nbsp;Pane&nbsp;app<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--Custom&nbsp;Control--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;control&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;topControl&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;progress&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;bufferBar&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;timeBar&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;time&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;current&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;/&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;duration&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btmControl&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Play/Pause&nbsp;video&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btnPlay&nbsp;btn&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Stop&nbsp;video&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btnStop&nbsp;btn&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;spdText&nbsp;btn&quot;</span><span class="html__tag_start">&gt;</span>Speed:&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Normal&nbsp;speed&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btnx1&nbsp;btn&nbsp;text&nbsp;selected&quot;</span><span class="html__tag_start">&gt;</span>x1<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Fast&nbsp;forward&nbsp;x3&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btnx3&nbsp;btn&nbsp;text&quot;</span><span class="html__tag_start">&gt;</span>x3<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Turn&nbsp;on/off&nbsp;light&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btnLight&nbsp;lighton&nbsp;btn&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Set&nbsp;volume&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;volume&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;volumeBar&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">title</span>=<span class="html__attr_value">&quot;Mute/Unmute&nbsp;sound&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;sound&nbsp;sound2&nbsp;btn&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;loading&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>Step3. Insert the event handle by using the following JavaScript code snippets:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// The initialize function must be run each time a new page is loaded
   Office.initialize = function (reason) {
       
       // INITIALIZE
       var video = $('#myVideo');


       // remove default control when JS is loaded
       video[0].removeAttribute(&quot;controls&quot;);
       $('.control').show().css({ 'bottom': -45 });
       $('.loading').fadeIn(500);
       $('.caption').fadeIn(500);


       // before everything gets started
       video.on('loadedmetadata', function () {
           $('.caption').animate({ 'top': -45 }, 300);


           // set video properties
           $('.current').text(timeFormat(0));
           $('.duration').text(timeFormat(video[0].duration));
           updateVolume(0, 0.7);


           // start to get video buffering data 
           setTimeout(startBuffer, 150);


           // bind video events
           $('.videoContainer')
           .append('<div id="init"></div>')
           .hover(function () {
               $('.control').stop().animate({ 'bottom': 0 }, 500);
               $('.caption').stop().animate({ 'top': 0 }, 500);
           }, function () {
               if (!volumeDrag &amp;&amp; !timeDrag) {
                   $('.control').stop().animate({ 'bottom': -45 }, 500);
                   $('.caption').stop().animate({ 'top': -45 }, 500);
               }
           })
           .on('click', function () {
               $('#init').remove();
               $('.btnPlay').addClass('paused');
               $(this).unbind('click');
               video[0].play();
           });


           $('#init').fadeIn(100);
       });


       // display video buffering bar
       var startBuffer = function () {
           var currentBuffer = video[0].buffered.end(0);
           var maxduration = video[0].duration;
           var perc = 100 * currentBuffer / maxduration;
           $('.bufferBar').css('width', perc &#43; '%');


           if (currentBuffer &lt; maxduration) {
               setTimeout(startBuffer, 500);
           }
       };


       // display current video play time
       video.on('timeupdate', function () {
           var currentPos = video[0].currentTime;
           var maxduration = video[0].duration;
           var perc = 100 * currentPos / maxduration;
           $('.timeBar').css('width', perc &#43; '%');
           $('.current').text(timeFormat(currentPos));
       });


       // controls events
       // video screen and play button clicked
       video.on('click', function () { playpause(); });
       $('.btnPlay').on('click', function () { playpause(); });
       var playpause = function () {
           if (video[0].paused || video[0].ended) {
               $('.btnPlay').addClass('paused');
               video[0].play();
           }
           else {
               $('.btnPlay').removeClass('paused');
               video[0].pause();
           }
       };


       // speed text clicked
       $('.btnx1').on('click', function () { fastfowrd(this, 1); });
       $('.btnx3').on('click', function () { fastfowrd(this, 3); });
       var fastfowrd = function (obj, spd) {
           $('.text').removeClass('selected');
           $(obj).addClass('selected');
           video[0].playbackRate = spd;
           video[0].play();
       };


       // stop button clicked
       $('.btnStop').on('click', function () {
           $('.btnPlay').removeClass('paused');
           updatebar($('.progress').offset().left);
           video[0].pause();
       });


       // light bulb button clicked
       $('.btnLight').click(function () {
           $(this).toggleClass('lighton');


           // if lightoff, create an overlay
           if (!$(this).hasClass('lighton')) {
               $('body').append('<div class="overlay"></div>');
               $('.overlay').css({
                   'position': 'absolute',
                   'width': 100 &#43; '%',
                   'height': $(document).height(),
                   'background': '#000',
                   'opacity': 0.9,
                   'top': 0,
                   'left': 0,
                   'z-index': 999
               });
               $('.videoContainer').css({
                   'z-index': 1000
               });
           }
               //if light on, remove overlay
           else {
               $('.overlay').remove();
           }
       });


       // sound button clicked
       $('.sound').click(function () {
           video[0].muted = !video[0].muted;
           $(this).toggleClass('muted');
           if (video[0].muted) {
               $('.volumeBar').css('width', 0);
           }
           else {
               $('.volumeBar').css('width', video[0].volume * 100 &#43; '%');
           }
       });


       // Video events
       // video canplay event
       video.on('canplay', function () {
           $('.loading').fadeOut(100);
       });


       // video canplaythrough event
       // solve Chrome cache issue
       var completeloaded = false;
       video.on('canplaythrough', function () {
           completeloaded = true;
       });


       // video ended event
       video.on('ended', function () {
           $('.btnPlay').removeClass('paused');
           video[0].pause();
       });


       //video seeking event
       video.on('seeking', function () {
           // if video fully loaded, ignore loading screen
           if (!completeloaded) {
               $('.loading').fadeIn(200);
           }
       });


       // video seeked event
       video.on('seeked', function () { });


       // video waiting for more data event
       video.on('waiting', function () {
           $('.loading').fadeIn(200);
       });


       // VIDEO PROGRESS BAR
       // when video timebar clicked
       var timeDrag = false;    /* check for drag event */
       $('.progress').on('mousedown', function (e) {
           timeDrag = true;
           updatebar(e.pageX);
       });
       $(document).on('mouseup', function (e) {
           if (timeDrag) {
               timeDrag = false;
               updatebar(e.pageX);
           }
       });
       $(document).on('mousemove', function (e) {
           if (timeDrag) {
               updatebar(e.pageX);
           }
       });
       var updatebar = function (x) {
           var progress = $('.progress');


           // calculate drag position
           // and update video currenttime
           // as well as progress bar
           var maxduration = video[0].duration;
           var position = x - progress.offset().left;
           var percentage = 100 * position / progress.width();
           if (percentage &gt; 100) {
               percentage = 100;
           }
           if (percentage &lt; 0) {
               percentage = 0;
           }


           $('.timeBar').css('width', percentage &#43; '%');
           video[0].currentTime = maxduration * percentage / 100;
       };


       // Volume bar
       // volume bar event
       var volumeDrag = false;
       $('.volume').on('mousedown', function (e) {
           volumeDrag = true;
           video[0].muted = false;
           $('.sound').removeClass('muted');
           updateVolume(e.pageX);
       });
       $(document).on('mouseup', function (e) {
           if (volumeDrag) {
               volumeDrag = false;
               updateVolume(e.pageX);
           }
       });
       $(document).on('mousemove', function (e) {
           if (volumeDrag) {
               updateVolume(e.pageX);
           }
       });
       var updateVolume = function (x, vol) {
           var volume = $('.volume');
           var percentage;
           // if only volume has been specified
           // then direct update volume
           if (vol) {
               percentage = vol * 100;
           }
           else {
               var position = x - volume.offset().left;
               percentage = 100 * position / volume.width();
           }


           if (percentage &gt; 100) {
               percentage = 100;
           }
           if (percentage &lt; 0) {
               percentage = 0;
           }


           // update volume bar and video volume
           $('.volumeBar').css('width', percentage &#43; '%');
           video[0].volume = percentage / 100;


           // change sound icon based on volume
           if (video[0].volume == 0) {
               $('.sound').removeClass('sound2').addClass('muted');
           }
           else if (video[0].volume &gt; 0.5) {
               $('.sound').removeClass('muted').addClass('sound2');
           }
           else {
               $('.sound').removeClass('muted').removeClass('sound2');
           }


       };


       // Time format converter - 00:00
       var timeFormat = function (seconds) {
           var m = Math.floor(seconds / 60) &lt; 10 ? &quot;0&quot; &#43; Math.floor(seconds / 60) : Math.floor(seconds / 60);
           var s = Math.floor(seconds - (m * 60)) &lt; 10 ? &quot;0&quot; &#43; Math.floor(seconds - (m * 60)) : Math.floor(seconds - (m * 60));
           return m &#43; &quot;:&quot; &#43; s;
       };
   };

</pre>
<pre class="js" id="codePreview">// The initialize function must be run each time a new page is loaded
   Office.initialize = function (reason) {
       
       // INITIALIZE
       var video = $('#myVideo');


       // remove default control when JS is loaded
       video[0].removeAttribute(&quot;controls&quot;);
       $('.control').show().css({ 'bottom': -45 });
       $('.loading').fadeIn(500);
       $('.caption').fadeIn(500);


       // before everything gets started
       video.on('loadedmetadata', function () {
           $('.caption').animate({ 'top': -45 }, 300);


           // set video properties
           $('.current').text(timeFormat(0));
           $('.duration').text(timeFormat(video[0].duration));
           updateVolume(0, 0.7);


           // start to get video buffering data 
           setTimeout(startBuffer, 150);


           // bind video events
           $('.videoContainer')
           .append('<div id="init"></div>')
           .hover(function () {
               $('.control').stop().animate({ 'bottom': 0 }, 500);
               $('.caption').stop().animate({ 'top': 0 }, 500);
           }, function () {
               if (!volumeDrag &amp;&amp; !timeDrag) {
                   $('.control').stop().animate({ 'bottom': -45 }, 500);
                   $('.caption').stop().animate({ 'top': -45 }, 500);
               }
           })
           .on('click', function () {
               $('#init').remove();
               $('.btnPlay').addClass('paused');
               $(this).unbind('click');
               video[0].play();
           });


           $('#init').fadeIn(100);
       });


       // display video buffering bar
       var startBuffer = function () {
           var currentBuffer = video[0].buffered.end(0);
           var maxduration = video[0].duration;
           var perc = 100 * currentBuffer / maxduration;
           $('.bufferBar').css('width', perc &#43; '%');


           if (currentBuffer &lt; maxduration) {
               setTimeout(startBuffer, 500);
           }
       };


       // display current video play time
       video.on('timeupdate', function () {
           var currentPos = video[0].currentTime;
           var maxduration = video[0].duration;
           var perc = 100 * currentPos / maxduration;
           $('.timeBar').css('width', perc &#43; '%');
           $('.current').text(timeFormat(currentPos));
       });


       // controls events
       // video screen and play button clicked
       video.on('click', function () { playpause(); });
       $('.btnPlay').on('click', function () { playpause(); });
       var playpause = function () {
           if (video[0].paused || video[0].ended) {
               $('.btnPlay').addClass('paused');
               video[0].play();
           }
           else {
               $('.btnPlay').removeClass('paused');
               video[0].pause();
           }
       };


       // speed text clicked
       $('.btnx1').on('click', function () { fastfowrd(this, 1); });
       $('.btnx3').on('click', function () { fastfowrd(this, 3); });
       var fastfowrd = function (obj, spd) {
           $('.text').removeClass('selected');
           $(obj).addClass('selected');
           video[0].playbackRate = spd;
           video[0].play();
       };


       // stop button clicked
       $('.btnStop').on('click', function () {
           $('.btnPlay').removeClass('paused');
           updatebar($('.progress').offset().left);
           video[0].pause();
       });


       // light bulb button clicked
       $('.btnLight').click(function () {
           $(this).toggleClass('lighton');


           // if lightoff, create an overlay
           if (!$(this).hasClass('lighton')) {
               $('body').append('<div class="overlay"></div>');
               $('.overlay').css({
                   'position': 'absolute',
                   'width': 100 &#43; '%',
                   'height': $(document).height(),
                   'background': '#000',
                   'opacity': 0.9,
                   'top': 0,
                   'left': 0,
                   'z-index': 999
               });
               $('.videoContainer').css({
                   'z-index': 1000
               });
           }
               //if light on, remove overlay
           else {
               $('.overlay').remove();
           }
       });


       // sound button clicked
       $('.sound').click(function () {
           video[0].muted = !video[0].muted;
           $(this).toggleClass('muted');
           if (video[0].muted) {
               $('.volumeBar').css('width', 0);
           }
           else {
               $('.volumeBar').css('width', video[0].volume * 100 &#43; '%');
           }
       });


       // Video events
       // video canplay event
       video.on('canplay', function () {
           $('.loading').fadeOut(100);
       });


       // video canplaythrough event
       // solve Chrome cache issue
       var completeloaded = false;
       video.on('canplaythrough', function () {
           completeloaded = true;
       });


       // video ended event
       video.on('ended', function () {
           $('.btnPlay').removeClass('paused');
           video[0].pause();
       });


       //video seeking event
       video.on('seeking', function () {
           // if video fully loaded, ignore loading screen
           if (!completeloaded) {
               $('.loading').fadeIn(200);
           }
       });


       // video seeked event
       video.on('seeked', function () { });


       // video waiting for more data event
       video.on('waiting', function () {
           $('.loading').fadeIn(200);
       });


       // VIDEO PROGRESS BAR
       // when video timebar clicked
       var timeDrag = false;    /* check for drag event */
       $('.progress').on('mousedown', function (e) {
           timeDrag = true;
           updatebar(e.pageX);
       });
       $(document).on('mouseup', function (e) {
           if (timeDrag) {
               timeDrag = false;
               updatebar(e.pageX);
           }
       });
       $(document).on('mousemove', function (e) {
           if (timeDrag) {
               updatebar(e.pageX);
           }
       });
       var updatebar = function (x) {
           var progress = $('.progress');


           // calculate drag position
           // and update video currenttime
           // as well as progress bar
           var maxduration = video[0].duration;
           var position = x - progress.offset().left;
           var percentage = 100 * position / progress.width();
           if (percentage &gt; 100) {
               percentage = 100;
           }
           if (percentage &lt; 0) {
               percentage = 0;
           }


           $('.timeBar').css('width', percentage &#43; '%');
           video[0].currentTime = maxduration * percentage / 100;
       };


       // Volume bar
       // volume bar event
       var volumeDrag = false;
       $('.volume').on('mousedown', function (e) {
           volumeDrag = true;
           video[0].muted = false;
           $('.sound').removeClass('muted');
           updateVolume(e.pageX);
       });
       $(document).on('mouseup', function (e) {
           if (volumeDrag) {
               volumeDrag = false;
               updateVolume(e.pageX);
           }
       });
       $(document).on('mousemove', function (e) {
           if (volumeDrag) {
               updateVolume(e.pageX);
           }
       });
       var updateVolume = function (x, vol) {
           var volume = $('.volume');
           var percentage;
           // if only volume has been specified
           // then direct update volume
           if (vol) {
               percentage = vol * 100;
           }
           else {
               var position = x - volume.offset().left;
               percentage = 100 * position / volume.width();
           }


           if (percentage &gt; 100) {
               percentage = 100;
           }
           if (percentage &lt; 0) {
               percentage = 0;
           }


           // update volume bar and video volume
           $('.volumeBar').css('width', percentage &#43; '%');
           video[0].volume = percentage / 100;


           // change sound icon based on volume
           if (video[0].volume == 0) {
               $('.sound').removeClass('sound2').addClass('muted');
           }
           else if (video[0].volume &gt; 0.5) {
               $('.sound').removeClass('muted').addClass('sound2');
           }
           else {
               $('.sound').removeClass('muted').removeClass('sound2');
           }


       };


       // Time format converter - 00:00
       var timeFormat = function (seconds) {
           var m = Math.floor(seconds / 60) &lt; 10 ? &quot;0&quot; &#43; Math.floor(seconds / 60) : Math.floor(seconds / 60);
           var s = Math.floor(seconds - (m * 60)) &lt; 10 ? &quot;0&quot; &#43; Math.floor(seconds - (m * 60)) : Math.floor(seconds - (m * 60));
           return m &#43; &quot;:&quot; &#43; s;
       };
   };

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span>Build apps for Office: </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/office/jj220060.aspx">http://msdn.microsoft.com/en-us/library/office/jj220060.aspx</a></p>
<p class="MsoNormal">Video object:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ie/ff975073(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/ie/ff975073(v=vs.85).aspx</a>
<span>&nbsp;</span></p>
<p class="MsoNormal"><span>Using JavaScript to control the HTML5 video player: </span>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ie/hh924823(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/ie/hh924823(v=vs.85).aspx</a>
<span>&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
