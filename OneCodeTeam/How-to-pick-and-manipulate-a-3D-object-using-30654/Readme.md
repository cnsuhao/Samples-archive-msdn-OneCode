# How to pick and manipulate a 3D object using DirectX in Universal apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* DirectX
* Windows
* Direct3D
* Windows Phone
* Windows 8
* Windows Phone 8
* Windows Store app Development
* Windows 8.1
* Windows Phone 8.1
* Graphics and Gaming
* Windows Phone App Development
## Topics
* DirectX
* rotate object
* picking
## IsPublished
* True
## ModifiedDate
* 2015-01-07 12:50:12
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to p</span><span style="font-weight:bold; font-size:14pt">ick and manipulate</span><span style="font-weight:bold; font-size:14pt"> a</span><span style="font-weight:bold; font-size:14pt">
 3D object</span><span style="font-weight:bold; font-size:14pt"> using DirectX in Universal app</span><span style="font-weight:bold; font-size:14pt">s</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample demonstrate</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> how to pick and manipulate
</span><span style="font-size:11pt">a </span><span style="font-size:11pt">3D object, such as rotate, scale and translate. The code also demo</span><span style="font-size:11pt">s</span><a name="_GoBack"></a><span style="font-size:11pt"> intersection test between
 bounding box and bounding frustum.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:medium"><strong>Video</strong></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:medium"><strong><a href="http://channel9.msdn.com/Blogs/OneCode/How-to-pick-and-manipulate-a-3D-object-in-universal-Windows-game-apps/player" target="_blank"><img id="132141" src="https://i1.code.msdn.s-msft.com/how-to-pick-and-manipulate-089639ab/image/file/132141/1/how%20to%20pick%20and%20manipulate%20a%203d%20object%20in%20universal%20windows%20game%20apps%20%20%20channel%209.png" alt="" width="640" height="360" style="border:1px solid black"></a><br>
</strong></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="OLE_LINK3"></a><span>Build the sample in Visual Studio 2013, and then run it.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Check </span><span style="font-size:11pt">the &ldquo;</span><span style="font-size:11pt">Rotate</span><span style="font-size:11pt">&rdquo;</span><span style="font-size:11pt"> button, and the cube will
 rotate with the pointer as we drag the pointer.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/124640/1/image.png" alt="" width="575" height="350" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Check </span><span style="font-size:11pt">the &ldquo;</span><span style="font-size:11pt">Translate</span><span style="font-size:11pt">&rdquo;</span><span style="font-size:11pt"> button, the object will
 transfer some distance as we drag the pointer.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/124641/1/image.png" alt="" width="575" height="350" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Check</span><span style="font-size:11pt"> the</span><span style="font-size:11pt">
</span><span style="font-size:11pt">&ldquo;</span><span style="font-size:11pt">Scale</span><span style="font-size:11pt">&rdquo;</span><span style="font-size:11pt"> button, the cube will b</span><span style="font-size:11pt">e scaled as we drag the pointer</span><span style="font-size:11pt">.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/124642/1/image.png" alt="" width="575" height="350" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:21pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:0pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Firstly, we should transform the 2D screen coordinate to
</span><span style="font-weight:bold">Landscape </span><span style="font-size:11pt">based space, since there are multiple orientations in windows 8 touch device.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">//Transform the current point coordinate to the origin screen space 
Point CubeRenderer::TransformToOrientation(Point point, bool dipsToPixels) 
{ 
Point returnValue; 
 
switch (m_orientation) 
{ 
case DisplayOrientations::Landscape: 
returnValue = point; 
break; 
case DisplayOrientations::Portrait: 
returnValue = Point(point.Y, m_windowBounds.Width - point.X); 
break; 
case DisplayOrientations::PortraitFlipped: 
returnValue = Point(m_windowBounds.Height - point.Y, point.X); 
break; 
case DisplayOrientations::LandscapeFlipped: 
returnValue = Point(m_windowBounds.Width - point.X, m_windowBounds.Height - point.Y); 
break; 
default: 
throw ref new Platform::FailureException(); 
break; 
} 
// Convert DIP to Pixels, or not? 
return dipsToPixels ? Point(ConvertDipsToPixels(returnValue.X), 
ConvertDipsToPixels(returnValue.Y)) 
: returnValue; 
}
</pre>
<pre id="codePreview" class="cplusplus">//Transform the current point coordinate to the origin screen space 
Point CubeRenderer::TransformToOrientation(Point point, bool dipsToPixels) 
{ 
Point returnValue; 
 
switch (m_orientation) 
{ 
case DisplayOrientations::Landscape: 
returnValue = point; 
break; 
case DisplayOrientations::Portrait: 
returnValue = Point(point.Y, m_windowBounds.Width - point.X); 
break; 
case DisplayOrientations::PortraitFlipped: 
returnValue = Point(m_windowBounds.Height - point.Y, point.X); 
break; 
case DisplayOrientations::LandscapeFlipped: 
returnValue = Point(m_windowBounds.Width - point.X, m_windowBounds.Height - point.Y); 
break; 
default: 
throw ref new Platform::FailureException(); 
break; 
} 
// Convert DIP to Pixels, or not? 
return dipsToPixels ? Point(ConvertDipsToPixels(returnValue.X), 
ConvertDipsToPixels(returnValue.Y)) 
: returnValue; 
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:21pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:0pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Then we&rsquo;ll transform the 2D space coordinate of the pointer to
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">view space. Refer to
</span><span style="font-size:11pt">some</span><span style="font-size:11pt"> mathematical knowledge shown below.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void CubeRenderer::ScreenToView( 
_In_ float sx, 
_In_ float sy, 
_Outptr_ float * vx, 
_Outptr_ float * vy 
) 
{ 
*vx = (2.0f * sx / m_d3dRenderTargetSize.Width - 1.0f) / m_cbMVPData.projection._11; 
*vy = (-2.0f * sy / m_d3dRenderTargetSize.Height &#43; 1.0f) / m_cbMVPData.projection._22; 
} 
void CubeRenderer::VectorToLocal( 
_In_ XMVECTOR inVec, 
_Outptr_ XMVECTOR * outVec 
) 
{ 
XMMATRIX viewMx = XMLoadFloat4x4(&amp;m_cbMVPData.view); 
XMMATRIX modelMx = XMLoadFloat4x4(&amp;m_cbMVPData.model); 
XMMATRIX invView = XMMatrixInverse(&amp;XMMatrixDeterminant(viewMx), viewMx); 
XMMATRIX invModel = XMMatrixInverse(&amp;XMMatrixDeterminant(modelMx), modelMx); 
XMMATRIX toLocal = invView * invModel; 
XMFLOAT4 inVecF; 
XMStoreFloat4(&amp;inVecF, inVec); 
if(1.0f == inVecF.w)//point vector 
{ 
*outVec = XMVector3TransformCoord(inVec, toLocal); 
} 
else 
{ 
*outVec = XMVector3TransformNormal(inVec, toLocal); 
*outVec = XMVector3Normalize(*outVec); 
} 
 
}
</pre>
<pre id="codePreview" class="cplusplus">void CubeRenderer::ScreenToView( 
_In_ float sx, 
_In_ float sy, 
_Outptr_ float * vx, 
_Outptr_ float * vy 
) 
{ 
*vx = (2.0f * sx / m_d3dRenderTargetSize.Width - 1.0f) / m_cbMVPData.projection._11; 
*vy = (-2.0f * sy / m_d3dRenderTargetSize.Height &#43; 1.0f) / m_cbMVPData.projection._22; 
} 
void CubeRenderer::VectorToLocal( 
_In_ XMVECTOR inVec, 
_Outptr_ XMVECTOR * outVec 
) 
{ 
XMMATRIX viewMx = XMLoadFloat4x4(&amp;m_cbMVPData.view); 
XMMATRIX modelMx = XMLoadFloat4x4(&amp;m_cbMVPData.model); 
XMMATRIX invView = XMMatrixInverse(&amp;XMMatrixDeterminant(viewMx), viewMx); 
XMMATRIX invModel = XMMatrixInverse(&amp;XMMatrixDeterminant(modelMx), modelMx); 
XMMATRIX toLocal = invView * invModel; 
XMFLOAT4 inVecF; 
XMStoreFloat4(&amp;inVecF, inVec); 
if(1.0f == inVecF.w)//point vector 
{ 
*outVec = XMVector3TransformCoord(inVec, toLocal); 
} 
else 
{ 
*outVec = XMVector3TransformNormal(inVec, toLocal); 
*outVec = XMVector3Normalize(*outVec); 
} 
 
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">But at here, we just make use of a method from DirectXMath,
</span><a href="http://msdn.microsoft.com/en-us/library/microsoft.directx_sdk.transformation.xmvector3unproject(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">XMVector3Unproject</span></a><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We calculate two points from
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">screen space which have same x and y value, but difference z value</span><span style="font-size:11pt">s</span><span style="font-size:11pt">.
</span><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">XMVECTOR vector1 = DirectX::XMVector3Unproject( 
XMVectorSet(sx, sy, 0.0f, 1.0f), 
0.0f, 
0.0f, 
m_d3dRenderTargetSize.Width, 
m_d3dRenderTargetSize.Height, 
0.0f, 
1.0f, 
XMLoadFloat4x4(&amp;m_cbMVPData.projection), 
XMLoadFloat4x4(&amp;m_cbMVPData.view), 
XMLoadFloat4x4(&amp;m_cbMVPData.model) 
); 
XMVECTOR vector2 = DirectX::XMVector3Unproject( 
XMVectorSet(sx, sy, 1.0f, 1.0f), 
0.0f, 
0.0f, 
m_d3dRenderTargetSize.Width, 
m_d3dRenderTargetSize.Height, 
0.0f, 
1.0f, 
XMLoadFloat4x4(&amp;m_cbMVPData.projection), 
XMLoadFloat4x4(&amp;m_cbMVPData.view), 
XMLoadFloat4x4(&amp;m_cbMVPData.model) 
); 
</pre>
<pre id="codePreview" class="cplusplus">XMVECTOR vector1 = DirectX::XMVector3Unproject( 
XMVectorSet(sx, sy, 0.0f, 1.0f), 
0.0f, 
0.0f, 
m_d3dRenderTargetSize.Width, 
m_d3dRenderTargetSize.Height, 
0.0f, 
1.0f, 
XMLoadFloat4x4(&amp;m_cbMVPData.projection), 
XMLoadFloat4x4(&amp;m_cbMVPData.view), 
XMLoadFloat4x4(&amp;m_cbMVPData.model) 
); 
XMVECTOR vector2 = DirectX::XMVector3Unproject( 
XMVectorSet(sx, sy, 1.0f, 1.0f), 
0.0f, 
0.0f, 
m_d3dRenderTargetSize.Width, 
m_d3dRenderTargetSize.Height, 
0.0f, 
1.0f, 
XMLoadFloat4x4(&amp;m_cbMVPData.projection), 
XMLoadFloat4x4(&amp;m_cbMVPData.view), 
XMLoadFloat4x4(&amp;m_cbMVPData.model) 
); 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then we can get the origin point</span><span style="font-size:11pt">
</span><span style="font-size:11pt">(vector1) and direction vector(vector2 &ndash; vector1), which would set to the XMVector3Unproject method. Note to normalize the direction vector.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">Now we can iterate through the 3D object and test if the picking ray intersects it. We use
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/hh855922(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Intersects(&hellip;)</span></a><span style="font-size:11pt"> method which was
 new in DirectXMath.</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt; line-height:27.6pt; text-indent:0pt">After we can test intersecting, we just transform the object by dragging the pointer.</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt; line-height:27.6pt; text-indent:0pt">When we process rotating, we transform the object to an arc ball, so that it can be rotated smoothly.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void CubeRenderer::ScreenToArcBall( 
_In_ float sx,  
_In_ float sy,  
_Outptr_ DirectX::XMFLOAT3 &amp;vec 
) 
{ 
float width = m_windowBounds.Width; 
float height = m_windowBounds.Height; 
float x = ( sx  - width / 2 ) / ( width / 2 ); 
float y = -( sy - height / 2 ) / ( height / 2 ); 
 
float z = 0.0f; 
float mag =  x * x &#43; y * y; 
 
if( mag &gt; 1.0f ) 
{ 
float scale = 1.0f / sqrtf( mag ); 
x *= scale; 
y *= scale; 
} 
else 
z = -(sqrtf( 1.0f - mag )); 
vec = XMFLOAT3(x, y, z); 
} 
</pre>
<pre id="codePreview" class="cplusplus">void CubeRenderer::ScreenToArcBall( 
_In_ float sx,  
_In_ float sy,  
_Outptr_ DirectX::XMFLOAT3 &amp;vec 
) 
{ 
float width = m_windowBounds.Width; 
float height = m_windowBounds.Height; 
float x = ( sx  - width / 2 ) / ( width / 2 ); 
float y = -( sy - height / 2 ) / ( height / 2 ); 
 
float z = 0.0f; 
float mag =  x * x &#43; y * y; 
 
if( mag &gt; 1.0f ) 
{ 
float scale = 1.0f / sqrtf( mag ); 
x *= scale; 
y *= scale; 
} 
else 
z = -(sqrtf( 1.0f - mag )); 
vec = XMFLOAT3(x, y, z); 
} 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:11pt">When </span><span style="font-size:11pt">we
</span><span style="font-size:11pt">execute translating, we just divide the coordinate offset by a constant.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">transform = XMMatrixTranslation((x2 - x1) / 200, (y1 - y2) / 200, 0.0f);
</pre>
<pre id="codePreview" class="cplusplus">transform = XMMatrixTranslation((x2 - x1) / 200, (y1 - y2) / 200, 0.0f);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:11pt">When </span><span style="font-size:11pt">we
</span><span style="font-size:11pt">execute scaling, we also make use of the arc ball to calculate the distance of pointer offset around the ball. Then we set data to
</span><a href="http://msdn.microsoft.com/en-us/library/microsoft.directx_sdk.matrix.xmmatrixscaling(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">XMMatrixScaling(&hellip;)</span></a><span style="font-size:11pt">.</span></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:21pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-21pt">
<span style="font-size:11pt"><span style="font-style:normal; text-decoration:none; font-weight:normal">&bull;&nbsp;</span><a href="http://www.braynzarsoft.net/index.php?p=D3D11PICKING" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Direct3D
 11 Picking</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
