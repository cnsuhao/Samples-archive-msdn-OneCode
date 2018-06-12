# Traverse TreeView in Windows Forms (CSWinFormTreeViewTraversal)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Controls
* TreeView
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:14:59
## Description

<h1><span style="font-family:������">WINDOWS FORMS APPLICATION</span> (<span style="font-family:������">CSWinFormTreeViewTraversal</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This example demonstrates how to perform TreeView nodes traverse and find a node by its Text member rather than Name, which is provided by default in the Nodes.Find() method.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53731/1/image.png" alt="" width="462" height="475" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">You can click ��Traversal�� button, and you may notice that all the nodes of this treeview will be listed in the Listbox.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53732/1/image.png" alt="" width="462" height="475" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">You can also type some words in the textbox, then
<span class="GramE">click ��</span>Find Next�� button. With the ��<span class="SpellE">MatchWholeWord��checkbox</span> checked, you will match every letter in the Node��s Text.
<span class="GramE">additionally</span>, case sensitive. If the checkbox isn��t checked, you fill find the node whose text contains your condition.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53733/1/image.png" alt="" width="462" height="475" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a method called FindNodeByText which will travel through all nodes
<span style="">&nbsp;</span>and find a special one <span style="">by its Text. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private List&lt;TreeNode&gt; FindNodeByText(TreeView treeView, string nodeText, bool matchWholeWord)
       {
           // Store the found node
           List&lt;TreeNode&gt; lstFoundNode = new List&lt;TreeNode&gt;();


           // Travel stack
           Stack&lt;TreeNode&gt; nodeStack = new Stack&lt;TreeNode&gt;();
           for (int i = 0; i &lt; treeView.Nodes.Count; i&#43;&#43;)
           {
               nodeStack.Push(treeView.Nodes[i]);
           }


           while (nodeStack.Count != 0)
           {
               TreeNode treeNode = nodeStack.Pop();
               if (matchWholeWord)
               {
                   if (treeNode.Text == nodeText)
                   {
                       lstFoundNode.Add(treeNode);
                   }
               }
               else
               {
                   if (treeNode.Text.Contains(nodeText))
                   {
                       lstFoundNode.Add(treeNode);
                   }
               }


               for (int i = 0; i &lt; treeNode.Nodes.Count; i&#43;&#43;)
               {
                   nodeStack.Push(treeNode.Nodes[i]);
               }
           }
           return lstFoundNode;
       }

</pre>
<pre id="codePreview" class="csharp">
private List&lt;TreeNode&gt; FindNodeByText(TreeView treeView, string nodeText, bool matchWholeWord)
       {
           // Store the found node
           List&lt;TreeNode&gt; lstFoundNode = new List&lt;TreeNode&gt;();


           // Travel stack
           Stack&lt;TreeNode&gt; nodeStack = new Stack&lt;TreeNode&gt;();
           for (int i = 0; i &lt; treeView.Nodes.Count; i&#43;&#43;)
           {
               nodeStack.Push(treeView.Nodes[i]);
           }


           while (nodeStack.Count != 0)
           {
               TreeNode treeNode = nodeStack.Pop();
               if (matchWholeWord)
               {
                   if (treeNode.Text == nodeText)
                   {
                       lstFoundNode.Add(treeNode);
                   }
               }
               else
               {
                   if (treeNode.Text.Contains(nodeText))
                   {
                       lstFoundNode.Add(treeNode);
                   }
               }


               for (int i = 0; i &lt; treeNode.Nodes.Count; i&#43;&#43;)
               {
                   nodeStack.Push(treeNode.Nodes[i]);
               }
           }
           return lstFoundNode;
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoNormal">2. When call the FindNodeByText method, pass TreeView that is going to be looped through.<span style="">
</span>Pass the text of the TreeNode which you are going to find. Pass the MathWholdWord option indicate whether you are going to match the whol<span style="">e</span> word.<span style="">&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">3. When you pass empty string as second parameter and false as the third, it list all nodes<span style="">
</span>of the TreeView control<span style="">&nbsp;&nbsp; </span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
    private void btnTravel_Click(object sender, EventArgs e)
      {
          // List all nodes of TreeView
          this.listBox1.Items.Clear();
          List&lt;TreeNode&gt; allNodes = new List&lt;TreeNode&gt;();
          allNodes = FindNodeByText(this.treeView1, &quot;&quot;, false);
          foreach (TreeNode tn in allNodes)
          {
              listBox1.Items.Add(tn.Text);
          }
      }

</pre>
<pre id="codePreview" class="csharp">
    private void btnTravel_Click(object sender, EventArgs e)
      {
          // List all nodes of TreeView
          this.listBox1.Items.Clear();
          List&lt;TreeNode&gt; allNodes = new List&lt;TreeNode&gt;();
          allNodes = FindNodeByText(this.treeView1, &quot;&quot;, false);
          foreach (TreeNode tn in allNodes)
          {
              listBox1.Items.Add(tn.Text);
          }
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. After you get the result TreeNode List, you can update the UI with these data.</p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">Windows Forms General FAQ.</a>
<span style="">&nbsp;&nbsp;&nbsp;</span> </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ch6etkw4.aspx">Windows Forms TreeView control</a><span style="">&nbsp;&nbsp;
</span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
