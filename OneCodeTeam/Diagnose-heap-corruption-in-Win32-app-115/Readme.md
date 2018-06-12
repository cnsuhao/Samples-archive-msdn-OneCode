# Diagnose heap corruption in Win32 app (CppHeapCorrupt​ion)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Diagnostics
## Topics
* Heap Corruption
## IsPublished
* True
## ModifiedDate
* 2012-05-10 07:50:26
## Description

<h1><span style="">Diagnose heap corruption in Win32 app (CppHeapCorruption)</span><span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">CppHeapCorruption is designed to show heap corruption and its consequences.It demonstrates four typical situations of heap corruption:
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Using Uninitialied State</span><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Heap Overrun and Underrun</span><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">C.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Heap Handle Mismatch</span><span style=""> </span>
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">D.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Heap Reuse After Deletion</span><span style="">
</span></p>
<h2><span style="">Symptoms </span></h2>
<p class="MsoNormal"><span style="">The biggest problem with heap corruption is that the faulting code is not easily trapped at the point of corruption; rather, the corruption typically shows up later on in the execution. This behavior alone makes it really
 hard to track down the source of heap corruption.</span><span style=""> </span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Crash (generally with an Access Violation error).</span><span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Unpredictable behavior of the application.</span><span style="">
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2><span style="">Causes</span><span style=""> </span></h2>
<p class="MsoNormal"><span style="">Using <span class="SpellE">uninitialied</span> state and heap overrun are the two typical causes (situations) of the Heap Corruption problems:
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Using <span class="SpellE">Uninitialied</span> State
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">According to the book 'Advanced Windows Debugging', uninitialized state is a common programming mistake that can lead to numerous hours of debugging to track down. Fundamentally, uninitialized state refers
 to a block of memory that has been successfully allocated but not yet initialized to a state in which it is considered valid for use. The memory block can range from simple native data types, such as integers, to complex data blobs.
<span class="GramE">Using an uninitialized memory block results in unpredictable behavior or crash with access violation.</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Heap Overrun </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Heap overruns, like static buffer overruns, can lead to memory and stack corruption. Because heap overruns occur in heap memory rather than on the stack, some people consider them to be less able to cause
 serious problems; nevertheless, heap overruns require real programming care and are just as able to allow system risks as static buffer overruns.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">C.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Heap Handle Mismatch </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">The heap manager keeps a list of active heaps in a process. The heaps are considered separate entities in the sense that the internal per-heap state is only valid within the context of that particular heap.
 Developers working with the heap manager must take great care to respect this separation by ensuring that the correct heaps are used when allocating and freeing heap memory. The separation is exposed to the developer by using heap handles in the heap API calls.
 Each heap handle uniquely represents a particular heap in the list of heaps for the process. If the uniqueness is broken, heap corruption will ensue.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">D.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Heap Reuse After Deletion </span></p>
<p class="MsoListParagraphCxSpLast"><span style="">Next to heap overruns, heap reuse after deletion is the second most common source of heap corruptions. After a heap block has been freed, it is put on the free lists (or look aside list) by the heap manager.
 From there on, it is considered invalid for use by the application. If an application uses the free block in any way, e.g. free the block again, the state of the block on the free list will most likely be corrupted.
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2><span style="">Debugging</span><span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Debug the use of Uninitialied State </span></p>
<p class="MsoListParagraphCxSpLast"><span style="">Start the example of using uninitialied state and attach a debugger, e.g. windbg, at the startup. (Please note that do NOT use a debugger to start the example). Resume the execution of the process and watch
 how the debugger breaks.</span><span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; g
(1aa4.2d0): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=00000002 ebx=001e0000 ecx=00000004 edx=001e00c4 esi=00100000 edi=001e0148
eip=77d08bc0 esp=0013f178 ebp=0013f250 iopl=0         nv up ei pl nz na pe nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00010206
ntdll!RtlpAllocateHeap&#43;0x493:
77d08bc0 8b00            mov     eax,dword ptr [eax]  ds:0023:00000002=????????

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; g
(1aa4.2d0): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=00000002 ebx=001e0000 ecx=00000004 edx=001e00c4 esi=00100000 edi=001e0148
eip=77d08bc0 esp=0013f178 ebp=0013f250 iopl=0         nv up ei pl nz na pe nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00010206
ntdll!RtlpAllocateHeap&#43;0x493:
77d08bc0 8b00            mov     eax,dword ptr [eax]  ds:0023:00000002=????????

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Dump the call-stack:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; k
ChildEBP RetAddr  
0013f250 77d08752 ntdll!RtlpAllocateHeap&#43;0x493
0013f2c8 77cd99f1 ntdll!RtlAllocateHeap&#43;0x1e3
0013f33c 77ce5488 ntdll!LdrGetDllHandleEx&#43;0x1ba
0013f358 76b1bb05 ntdll!LdrGetDllHandle&#43;0x18
0013f3a8 76b1ba2d kernel32!GetModuleHandleForUnicodeString&#43;0x22
0013f820 76b1b93d kernel32!BasepGetModuleHandleExW&#43;0x179
0013f838 5196bed3 kernel32!GetModuleHandleW&#43;0x29
0013f84c 5196bf1e MSVCR90D!__crtCorExitProcess&#43;0x13
0013f858 5196bdb1 MSVCR90D!__crtExitProcess&#43;0xe
0013f8a8 5196b9e2 MSVCR90D!doexit&#43;0x1d1
0013f8bc 00f51eb5 MSVCR90D!exit&#43;0x12
0013f904 00f51cdf CppHeapCorruption!__tmainCRTStartup&#43;0x1c5
0013f90c 76b14911 CppHeapCorruption!wmainCRTStartup&#43;0xf
0013f918 77cde4b6 kernel32!BaseThreadInitThunk&#43;0xe
0013f958 77cde489 ntdll!__RtlUserThreadStart&#43;0x23
0013f970 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; k
ChildEBP RetAddr  
0013f250 77d08752 ntdll!RtlpAllocateHeap&#43;0x493
0013f2c8 77cd99f1 ntdll!RtlAllocateHeap&#43;0x1e3
0013f33c 77ce5488 ntdll!LdrGetDllHandleEx&#43;0x1ba
0013f358 76b1bb05 ntdll!LdrGetDllHandle&#43;0x18
0013f3a8 76b1ba2d kernel32!GetModuleHandleForUnicodeString&#43;0x22
0013f820 76b1b93d kernel32!BasepGetModuleHandleExW&#43;0x179
0013f838 5196bed3 kernel32!GetModuleHandleW&#43;0x29
0013f84c 5196bf1e MSVCR90D!__crtCorExitProcess&#43;0x13
0013f858 5196bdb1 MSVCR90D!__crtExitProcess&#43;0xe
0013f8a8 5196b9e2 MSVCR90D!doexit&#43;0x1d1
0013f8bc 00f51eb5 MSVCR90D!exit&#43;0x12
0013f904 00f51cdf CppHeapCorruption!__tmainCRTStartup&#43;0x1c5
0013f90c 76b14911 CppHeapCorruption!wmainCRTStartup&#43;0xf
0013f918 77cde4b6 kernel32!BaseThreadInitThunk&#43;0xe
0013f958 77cde489 ntdll!__RtlUserThreadStart&#43;0x23
0013f970 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">From the stack, it looks like tha application was in the process of shutting down when the access violation occurred. Our code is nowhere on the stack! Let's do some preliminary investigation
 of the heap and see if we can find some clues as to some potential culprits. Without knowing which part of the heap is corrupted, a good starting point is to see if the segments are intact.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !heap -s
LFH Key                   : 0x7c07dda9
Termination on corruption : DISABLED
Affinity manager status:
   - Virtual affinity limit 4
   - Current entries in use -1
   - Statistics:  Swaps=0, Resets=0, Allocs=0


  Heap     Flags   Reserv  Commit  Virt   Free  List   UCR  Virt  Lock  Fast 
                    (k)     (k)    (k)     (k) length      blocks cont. heap 
-----------------------------------------------------------------------------
001e0000 00000002    1024    148   1024     13     2     1    0      0   LFH
00010000 00008000      64     12     64     10     1     1    0      0      
00a80000 00000002    1088    136   1088     22     4     2    0      0   LFH
00bc0000 00001002      64     20     64      7     2     1    0      0      
00720000 00001002      64     44     64     13     3     1    0      0      
00db0000 00001002      64     20     64      6     2     1    0      0      
00020000 00001002      64     32     64     30     1     1    0      0      
00ba0000 00001002      64      4     64      2     1     1    0      0      
-----------------------------------------------------------------------------

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !heap -s
LFH Key                   : 0x7c07dda9
Termination on corruption : DISABLED
Affinity manager status:
   - Virtual affinity limit 4
   - Current entries in use -1
   - Statistics:  Swaps=0, Resets=0, Allocs=0


  Heap     Flags   Reserv  Commit  Virt   Free  List   UCR  Virt  Lock  Fast 
                    (k)     (k)    (k)     (k) length      blocks cont. heap 
-----------------------------------------------------------------------------
001e0000 00000002    1024    148   1024     13     2     1    0      0   LFH
00010000 00008000      64     12     64     10     1     1    0      0      
00a80000 00000002    1088    136   1088     22     4     2    0      0   LFH
00bc0000 00001002      64     20     64      7     2     1    0      0      
00720000 00001002      64     44     64     13     3     1    0      0      
00db0000 00001002      64     20     64      6     2     1    0      0      
00020000 00001002      64     32     64     30     1     1    0      0      
00ba0000 00001002      64      4     64      2     1     1    0      0      
-----------------------------------------------------------------------------

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Get all information of the process heap:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !heap -a 001e0000 
Index   Address  Name      Debugging options enabled
  1:   001e0000 
    Segment at 001e0000 to 002e0000 (00025000 bytes committed)
    Flags:                00000002
    ForceFlags:           00000000
    Granularity:          8 bytes
    Segment Reserve:      00100000
    Segment Commit:       00002000
    DeCommit Block Thres: 00000800
    DeCommit Total Thres: 00002000
    Total Free Size:      00000690
    Max. Allocation Size: 7ffdefff
    Lock Variable at:     001e0130
    Next TagIndex:        0000
    Maximum TagIndex:     0000
    Tag Entries:          00000000
    PsuedoTag Entries:    00000000
    Virtual Alloc List:   001e00a0
    Uncommitted ranges:   001e0090
            00205000: 000db000  (897024 bytes)
    FreeList[ 00 ] at 001e00c4: 00201b80 . 0000000a  
    Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002


    Segment00 at 001e0000:
        Flags:           00000000
        Base:            001e0000
        First Entry:     001e0580
        Last Entry:      002e0000
        Total Pages:     00000100
        Total UnCommit:  000000db
        Largest UnCommit:00000000
        UnCommitted Ranges: (1)


    Heap entries for Segment00 in Heap 001e0000
        001e0000: 00000 . 00580 [101] - busy (57f)
        001e0580: 00580 . 00240 [101] - busy (23f)
        001e07c0: 00240 . 00020 [101] - busy (18)
        ......

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !heap -a 001e0000 
Index   Address  Name      Debugging options enabled
  1:   001e0000 
    Segment at 001e0000 to 002e0000 (00025000 bytes committed)
    Flags:                00000002
    ForceFlags:           00000000
    Granularity:          8 bytes
    Segment Reserve:      00100000
    Segment Commit:       00002000
    DeCommit Block Thres: 00000800
    DeCommit Total Thres: 00002000
    Total Free Size:      00000690
    Max. Allocation Size: 7ffdefff
    Lock Variable at:     001e0130
    Next TagIndex:        0000
    Maximum TagIndex:     0000
    Tag Entries:          00000000
    PsuedoTag Entries:    00000000
    Virtual Alloc List:   001e00a0
    Uncommitted ranges:   001e0090
            00205000: 000db000  (897024 bytes)
    FreeList[ 00 ] at 001e00c4: 00201b80 . 0000000a  
    Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002


    Segment00 at 001e0000:
        Flags:           00000000
        Base:            001e0000
        First Entry:     001e0580
        Last Entry:      002e0000
        Total Pages:     00000100
        Total UnCommit:  000000db
        Largest UnCommit:00000000
        UnCommitted Ranges: (1)


    Heap entries for Segment00 in Heap 001e0000
        001e0000: 00000 . 00580 [101] - busy (57f)
        001e0580: 00580 . 00240 [101] - busy (23f)
        001e07c0: 00240 . 00020 [101] - busy (18)
        ......

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">The lines shows that the free list of the heap is corrupted because BLink (0000000a) does not point to the heap body, instead, it points to an invalid memory.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
FreeList[ 00 ] at 001e00c4: 00201b80 . 0000000a  
Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002

</pre>
<pre id="codePreview" class="cplusplus">
FreeList[ 00 ] at 001e00c4: 00201b80 . 0000000a  
Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Now that we know the heap is corrupted, we need to enable page heap and recapture a dump of crash.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Debug Heap Overrun </span></p>
<p class="MsoListParagraphCxSpLast"><span style="">Start the heap overrun example and attach a debugger, e.g. windbg, at the startup. Resume the execution of the process and watch how the debugger breaks with an access violation.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; g
(1838.2280): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=00100000 ebx=00c10000 ecx=00000000 edx=0000007f esi=00bccb50 edi=00c107d8
eip=77d0814c esp=0016fb30 ebp=0016fb58 iopl=0         nv up ei pl zr ac pe nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00010256
ntdll!RtlpCoalesceFreeBlocks&#43;0x35:
77d0814c 324e02          xor     cl,byte ptr [esi&#43;2]        ds:0023:00bccb52=??

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; g
(1838.2280): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=00100000 ebx=00c10000 ecx=00000000 edx=0000007f esi=00bccb50 edi=00c107d8
eip=77d0814c esp=0016fb30 ebp=0016fb58 iopl=0         nv up ei pl zr ac pe nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00010256
ntdll!RtlpCoalesceFreeBlocks&#43;0x35:
77d0814c 324e02          xor     cl,byte ptr [esi&#43;2]        ds:0023:00bccb52=??

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Dump the call-stack:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; kvn
 # ChildEBP RetAddr  Args to Child              
00 0016fb58 77d08417 00c10000 00c107d8 0016fc00 ntdll!RtlpCoalesceFreeBlocks&#43;0x35
01 0016fc50 77d08652 00c107d8 00c107e0 0016fc94 ntdll!RtlpFreeHeap&#43;0x1e2
02 0016fc6c 76b1c56f 00c10000 00000000 00c107d8 ntdll!RtlFreeHeap&#43;0x14e
03 0016fc80 00b816da 00c10000 00000000 00c107e0 kernel32!HeapFree&#43;0x14
04 0016fd9c 00b818b4 00000000 00000000 7ffdd000 CppHeapCorruption!HeapOverrun&#43;0x1da
05 0016fe70 00b81e98 00000001 00821a88 00821b40 CppHeapCorruption!wmain&#43;0x24
06 0016fec0 00b81cdf 0016fed4 76b14911 7ffdd000 CppHeapCorruption!__tmainCRTStartup&#43;0x1a8
07 0016fec8 76b14911 7ffdd000 0016ff14 77cde4b6 CppHeapCorruption!wmainCRTStartup&#43;0xf
08 0016fed4 77cde4b6 7ffdd000 77f16616 00000000 kernel32!BaseThreadInitThunk&#43;0xe
09 0016ff14 77cde489 00b81087 7ffdd000 00000000 ntdll!__RtlUserThreadStart&#43;0x23
0a 0016ff2c 00000000 00b81087 7ffdd000 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; kvn
 # ChildEBP RetAddr  Args to Child              
00 0016fb58 77d08417 00c10000 00c107d8 0016fc00 ntdll!RtlpCoalesceFreeBlocks&#43;0x35
01 0016fc50 77d08652 00c107d8 00c107e0 0016fc94 ntdll!RtlpFreeHeap&#43;0x1e2
02 0016fc6c 76b1c56f 00c10000 00000000 00c107d8 ntdll!RtlFreeHeap&#43;0x14e
03 0016fc80 00b816da 00c10000 00000000 00c107e0 kernel32!HeapFree&#43;0x14
04 0016fd9c 00b818b4 00000000 00000000 7ffdd000 CppHeapCorruption!HeapOverrun&#43;0x1da
05 0016fe70 00b81e98 00000001 00821a88 00821b40 CppHeapCorruption!wmain&#43;0x24
06 0016fec0 00b81cdf 0016fed4 76b14911 7ffdd000 CppHeapCorruption!__tmainCRTStartup&#43;0x1a8
07 0016fec8 76b14911 7ffdd000 0016ff14 77cde4b6 CppHeapCorruption!wmainCRTStartup&#43;0xf
08 0016fed4 77cde4b6 7ffdd000 77f16616 00000000 kernel32!BaseThreadInitThunk&#43;0xe
09 0016ff14 77cde489 00b81087 7ffdd000 00000000 ntdll!__RtlUserThreadStart&#43;0x23
0a 0016ff2c 00000000 00b81087 7ffdd000 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Looking at the stack, it appears that the application was in the process of freeing a heap block at 00c107e0 in the heap 00c10000 when the access violation occurred.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Get all information for the specified heap:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !heap -a 00c10000
Index   Address  Name      Debugging options enabled
  9:   00c10000 
    Segment at 00c10000 to 00c50000 (00001000 bytes committed)
    Flags:                00001002
    ForceFlags:           00000000
    Granularity:          8 bytes
    Segment Reserve:      00100000
    Segment Commit:       00002000
    DeCommit Block Thres: 00000200
    DeCommit Total Thres: 00002000
    Total Free Size:      00000100
    Max. Allocation Size: 7ffdefff
    Lock Variable at:     00c10130
    Next TagIndex:        0000
    Maximum TagIndex:     0000
    Tag Entries:          00000000
    PsuedoTag Entries:    00000000
    Virtual Alloc List:   00c100a0
    Uncommitted ranges:   00c10090
            00c11000: 0003f000  (258048 bytes)
    FreeList[ 00 ] at 00c100c4: 00c10800 . 00c107c8  
        00c107c0: 00240 . 00018 [100] - free
        00c107f8: 00020 . 007e8 [100] - free


    Segment00 at 00c10000:
        Flags:           00000000
        Base:            00c10000
        First Entry:     00c10580
        Last Entry:      00c50000
        Total Pages:     00000040
        Total UnCommit:  0000003f
        Largest UnCommit:00000000
        UnCommitted Ranges: (1)


    Heap entries for Segment00 in Heap 00c10000
        00c10000: 00000 . 00580 [101] - busy (57f)
        00c10580: 00580 . 00240 [101] - busy (23f)
        00c107c0: 00240 . 00018 [100]
        00c107d8: 43c88 . 24238 [41] - busy (24238), user flags (2)
            unable to read heap entry at 00c34a10

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !heap -a 00c10000
Index   Address  Name      Debugging options enabled
  9:   00c10000 
    Segment at 00c10000 to 00c50000 (00001000 bytes committed)
    Flags:                00001002
    ForceFlags:           00000000
    Granularity:          8 bytes
    Segment Reserve:      00100000
    Segment Commit:       00002000
    DeCommit Block Thres: 00000200
    DeCommit Total Thres: 00002000
    Total Free Size:      00000100
    Max. Allocation Size: 7ffdefff
    Lock Variable at:     00c10130
    Next TagIndex:        0000
    Maximum TagIndex:     0000
    Tag Entries:          00000000
    PsuedoTag Entries:    00000000
    Virtual Alloc List:   00c100a0
    Uncommitted ranges:   00c10090
            00c11000: 0003f000  (258048 bytes)
    FreeList[ 00 ] at 00c100c4: 00c10800 . 00c107c8  
        00c107c0: 00240 . 00018 [100] - free
        00c107f8: 00020 . 007e8 [100] - free


    Segment00 at 00c10000:
        Flags:           00000000
        Base:            00c10000
        First Entry:     00c10580
        Last Entry:      00c50000
        Total Pages:     00000040
        Total UnCommit:  0000003f
        Largest UnCommit:00000000
        UnCommitted Ranges: (1)


    Heap entries for Segment00 in Heap 00c10000
        00c10000: 00000 . 00580 [101] - busy (57f)
        00c10580: 00580 . 00240 [101] - busy (23f)
        00c107c0: 00240 . 00018 [100]
        00c107d8: 43c88 . 24238 [41] - busy (24238), user flags (2)
            unable to read heap entry at 00c34a10

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">From the info, we see that there are two free blocks starting (including block header) at 00c107c0(sized 0x18) and 00c107f8(sized 0x7e8) respectively.Busy blocks are the heap are at 00c10000(sized
 0x580), 00c10580(sized 0x240), 00c107d8(sized 0x24238). The last entry whose address 00c107d8( = 00c107e0 - 8 bytes of block header ) is exactly the block the thread is freeing. Its current size (24238) is abnormal and its previous block size (43c88) and cannot
 match the previous block (00c107c0)'s size (00018). The block seems corrupted. Let's dump the memory at 00c107d8:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; dd 00c107d8
00c107d8  3b414847 4e4d4c4b 5251504f 56555453
00c107e8  5a595857 00000000 00000000 00000000
00c107f8  c7fabdfd 0000cbde 00c100c4 00c107c8
00c10808  00000000 00000000 00000000 00000000
00c10818  00000000 00000000 00000000 00000000
0:000&gt; da 00c107d8
00c107d8  &quot;GHA;KLMNOPQRSTUVWXYZ&quot;

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; dd 00c107d8
00c107d8  3b414847 4e4d4c4b 5251504f 56555453
00c107e8  5a595857 00000000 00000000 00000000
00c107f8  c7fabdfd 0000cbde 00c100c4 00c107c8
00c10808  00000000 00000000 00000000 00000000
00c10818  00000000 00000000 00000000 00000000
0:000&gt; da 00c107d8
00c107d8  &quot;GHA;KLMNOPQRSTUVWXYZ&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">The memory contains ASCII characters, which appears to be caused by the overrun of string copy.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Debug Heap Handle Mismatch </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Start the example of heap handle mismatch and attach a debugger, e.g. windbg, at the startup. Resume the execution of the process and watch how the<span style="">&nbsp;
</span>debugger breaks.</span><span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; g
HEAP[CppHeapCorruption.exe]: Invalid address specified to RtlValidateHeap
( 00970000, 0047E260 )
(1c60.2198): Break instruction exception - code 80000003 (first chance)
eax=0047e258 ebx=0047e258 ecx=77cc385a edx=002df66d esi=00970000 edi=77d0151e
eip=77ce7dfe esp=002df8b0 ebp=002df8b4 iopl=0         nv up ei pl nz na po nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00000202
ntdll!DbgBreakPoint:
77ce7dfe cc              int     3


0:000&gt; kvn
 # ChildEBP RetAddr  Args to Child              
00 002df8ac 77d51c93 002df8d0 77d22b26 0047e258 ntdll!DbgBreakPoint
01 002df8b4 77d22b26 0047e258 00970000 00000001 ntdll!RtlpBreakPointHeap&#43;0x28
02 002df8d0 77cb226e 00970000 0047e258 77d0151e ntdll!RtlpValidateHeapEntry&#43;0x16d
03 002df93c 76adfcb4 00970000 00000000 0047e260 ntdll!RtlValidateHeap&#43;0x8d
04 002df950 51831ac9 00970000 00000000 0047e260 kernel32!HeapValidate&#43;0x14
05 002df974 51830b3a 0047e280 0047e280 002df9bc MSVCR90D!_CrtIsValidHeapPointer&#43;0xf9
06 002df984 518309e0 0047e280 00000001 d19c468d MSVCR90D!_free_dbg_nolock&#43;0x11a
07 002df9bc 51838990 0047e280 00000001 002dfab0 MSVCR90D!_free_dbg&#43;0x50
08 002df9cc 010c1796 0047e280 002dfb84 00000000 MSVCR90D!free&#43;0x10
09 002dfab0 010c18b4 00000000 00000000 7ffdc000 CppHeapCorruption!HeapHandleMismatch&#43;0x86
0a 002dfb84 010c1e98 00000001 00971a88 00971b40 CppHeapCorruption!wmain&#43;0x24
0b 002dfbd4 010c1cdf 002dfbe8 76b14911 7ffdc000 CppHeapCorruption!__tmainCRTStartup&#43;0x1a8
0c 002dfbdc 76b14911 7ffdc000 002dfc28 77cde4b6 CppHeapCorruption!wmainCRTStartup&#43;0xf
0d 002dfbe8 77cde4b6 7ffdc000 7764e30c 00000000 kernel32!BaseThreadInitThunk&#43;0xe
0e 002dfc28 77cde489 010c1087 7ffdc000 00000000 ntdll!__RtlUserThreadStart&#43;0x23
0f 002dfc40 00000000 010c1087 7ffdc000 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; g
HEAP[CppHeapCorruption.exe]: Invalid address specified to RtlValidateHeap
( 00970000, 0047E260 )
(1c60.2198): Break instruction exception - code 80000003 (first chance)
eax=0047e258 ebx=0047e258 ecx=77cc385a edx=002df66d esi=00970000 edi=77d0151e
eip=77ce7dfe esp=002df8b0 ebp=002df8b4 iopl=0         nv up ei pl nz na po nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00000202
ntdll!DbgBreakPoint:
77ce7dfe cc              int     3


0:000&gt; kvn
 # ChildEBP RetAddr  Args to Child              
00 002df8ac 77d51c93 002df8d0 77d22b26 0047e258 ntdll!DbgBreakPoint
01 002df8b4 77d22b26 0047e258 00970000 00000001 ntdll!RtlpBreakPointHeap&#43;0x28
02 002df8d0 77cb226e 00970000 0047e258 77d0151e ntdll!RtlpValidateHeapEntry&#43;0x16d
03 002df93c 76adfcb4 00970000 00000000 0047e260 ntdll!RtlValidateHeap&#43;0x8d
04 002df950 51831ac9 00970000 00000000 0047e260 kernel32!HeapValidate&#43;0x14
05 002df974 51830b3a 0047e280 0047e280 002df9bc MSVCR90D!_CrtIsValidHeapPointer&#43;0xf9
06 002df984 518309e0 0047e280 00000001 d19c468d MSVCR90D!_free_dbg_nolock&#43;0x11a
07 002df9bc 51838990 0047e280 00000001 002dfab0 MSVCR90D!_free_dbg&#43;0x50
08 002df9cc 010c1796 0047e280 002dfb84 00000000 MSVCR90D!free&#43;0x10
09 002dfab0 010c18b4 00000000 00000000 7ffdc000 CppHeapCorruption!HeapHandleMismatch&#43;0x86
0a 002dfb84 010c1e98 00000001 00971a88 00971b40 CppHeapCorruption!wmain&#43;0x24
0b 002dfbd4 010c1cdf 002dfbe8 76b14911 7ffdc000 CppHeapCorruption!__tmainCRTStartup&#43;0x1a8
0c 002dfbdc 76b14911 7ffdc000 002dfc28 77cde4b6 CppHeapCorruption!wmainCRTStartup&#43;0xf
0d 002dfbe8 77cde4b6 7ffdc000 7764e30c 00000000 kernel32!BaseThreadInitThunk&#43;0xe
0e 002dfc28 77cde489 010c1087 7ffdc000 00000000 ntdll!__RtlUserThreadStart&#43;0x23
0f 002dfc40 00000000 010c1087 7ffdc000 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">The process is trying to free the memory 0047e280 on the CRT heap. From the frame:
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
04 002df950 51831ac9 00970000 00000000 0047e260 kernel32!HeapValidate&#43;0x14

</pre>
<pre id="codePreview" class="cplusplus">
04 002df950 51831ac9 00970000 00000000 0047e260 kernel32!HeapValidate&#43;0x14

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">we see that the CRT heap is at 00970000.
<a href="http://msdn.microsoft.com/en-us/library/aa366708.aspx"><span style="font-size:9.0pt; line-height:115%; font-family:&quot;Courier New&quot;">http://msdn.microsoft.com/en-us/library/aa366708.aspx</span></a></span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Get the segements of the heap:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !heap -m 00970000 
Index   Address  Name      Debugging options enabled
  5:   00970000 
    Segment at 00970000 to 00980000 (0000b000 bytes committed)
    ......

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !heap -m 00970000 
Index   Address  Name      Debugging options enabled
  5:   00970000 
    Segment at 00970000 to 00980000 (0000b000 bytes committed)
    ......

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">The heap currently has only one segment that ranges from 00970000 to 00980000. The memory that is being freed (0047e280) is not in the range. In other words, the memory does not belong to the
 heap. To find its belonging heap, use the !address command:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !address 0047e280
 ProcessParametrs 00463828 in range 00460000 00485000
 Environment 004607e8 in range 00460000 00485000
    00460000 : 00460000 - 00025000
                    Type     00020000 MEM_PRIVATE
                    Protect  00000004 PAGE_READWRITE
                    State    00001000 MEM_COMMIT
                    Usage    RegionUsageHeap
                    Handle   00460000

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !address 0047e280
 ProcessParametrs 00463828 in range 00460000 00485000
 Environment 004607e8 in range 00460000 00485000
    00460000 : 00460000 - 00025000
                    Type     00020000 MEM_PRIVATE
                    Protect  00000004 PAGE_READWRITE
                    State    00001000 MEM_COMMIT
                    Usage    RegionUsageHeap
                    Handle   00460000

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">From the output, we see that the memory belongs to the heap 00460000, which is the process heap:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !heap -s
LFH Key                   : 0x28cc5a6e
Termination on corruption : DISABLED
Affinity manager status:
   - Virtual affinity limit 4
   - Current entries in use -1
   - Statistics:  Swaps=0, Resets=0, Allocs=0


  Heap     Flags   Reserv  Commit  Virt   Free  List   UCR  Virt  Lock  Fast 
                    (k)     (k)    (k)     (k) length      blocks cont. heap 
-----------------------------------------------------------------------------
00460000 00000002    1024    148   1024     13     2     1    0      0   LFH
00010000 00008000      64     12     64     10     1     1    0      0      
00140000 00000002    1088    136   1088     22     4     2    0      0   LFH
00db0000 00001002      64     20     64      7     2     1    0      0      
00970000 00001002      64     44     64      9     3     1    0      0      
00bd0000 00001002      64     20     64      6     2     1    0      0      
00da0000 00001002      64     32     64     30     1     1    0      0      
00d50000 00001002      64      4     64      2     1     1    0      0      
-----------------------------------------------------------------------------

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !heap -s
LFH Key                   : 0x28cc5a6e
Termination on corruption : DISABLED
Affinity manager status:
   - Virtual affinity limit 4
   - Current entries in use -1
   - Statistics:  Swaps=0, Resets=0, Allocs=0


  Heap     Flags   Reserv  Commit  Virt   Free  List   UCR  Virt  Lock  Fast 
                    (k)     (k)    (k)     (k) length      blocks cont. heap 
-----------------------------------------------------------------------------
00460000 00000002    1024    148   1024     13     2     1    0      0   LFH
00010000 00008000      64     12     64     10     1     1    0      0      
00140000 00000002    1088    136   1088     22     4     2    0      0   LFH
00db0000 00001002      64     20     64      7     2     1    0      0      
00970000 00001002      64     44     64      9     3     1    0      0      
00bd0000 00001002      64     20     64      6     2     1    0      0      
00da0000 00001002      64     32     64     30     1     1    0      0      
00d50000 00001002      64      4     64      2     1     1    0      0      
-----------------------------------------------------------------------------

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Debug Heap Reuse After Deletion </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Start the example of heap reuse after deletion and attach a debugger, e.g. windbg, at the startup. Resume the execution of the process and watch how the<span style="">&nbsp;
</span>debugger breaks with Access Violoation.</span><span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; g
(1b38.18dc): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=01bf07c8 ebx=01bf0000 ecx=0000000b edx=01bf0808 esi=01bf0800 edi=00000000
eip=77d08516 esp=001ef84c ebp=001ef92c iopl=0         nv up ei pl zr na pe nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00010246
ntdll!RtlpFreeHeap&#43;0x4bf:
77d08516 8b39            mov     edi,dword ptr [ecx]  ds:0023:0000000b=????????


The crash was caused by the access of invalid memory 0000000b.

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; g
(1b38.18dc): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=01bf07c8 ebx=01bf0000 ecx=0000000b edx=01bf0808 esi=01bf0800 edi=00000000
eip=77d08516 esp=001ef84c ebp=001ef92c iopl=0         nv up ei pl zr na pe nc
cs=001b  ss=0023  ds=0023  es=0023  fs=003b  gs=0000             efl=00010246
ntdll!RtlpFreeHeap&#43;0x4bf:
77d08516 8b39            mov     edi,dword ptr [ecx]  ds:0023:0000000b=????????


The crash was caused by the access of invalid memory 0000000b.

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Dump the call-stack:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; kvn
 # ChildEBP RetAddr  Args to Child              
00 001ef92c 77d08652 01bf0800 01bf0808 001ef970 ntdll!RtlpFreeHeap&#43;0x4bf
01 001ef948 76b1c56f 01bf0000 00000000 01bf0800 ntdll!RtlFreeHeap&#43;0x14e
02 001ef95c 00851a38 01bf0000 00000000 01bf0808 kernel32!HeapFree&#43;0x14
03 001efa6c 00851b64 00000000 00000000 7ffda000 CppHeapCorruption!HeapReuseAfterDeletion&#43;0x198
04 001efb40 00852138 00000001 009f1a88 009f1b40 CppHeapCorruption!wmain&#43;0x24
05 001efb90 00851f7f 001efba4 76b14911 7ffda000 CppHeapCorruption!__tmainCRTStartup&#43;0x1a8
06 001efb98 76b14911 7ffda000 001efbe4 77cde4b6 CppHeapCorruption!wmainCRTStartup&#43;0xf
07 001efba4 77cde4b6 7ffda000 76cd15c7 00000000 kernel32!BaseThreadInitThunk&#43;0xe
08 001efbe4 77cde489 00851087 7ffda000 00000000 ntdll!__RtlUserThreadStart&#43;0x23
09 001efbfc 00000000 00851087 7ffda000 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; kvn
 # ChildEBP RetAddr  Args to Child              
00 001ef92c 77d08652 01bf0800 01bf0808 001ef970 ntdll!RtlpFreeHeap&#43;0x4bf
01 001ef948 76b1c56f 01bf0000 00000000 01bf0800 ntdll!RtlFreeHeap&#43;0x14e
02 001ef95c 00851a38 01bf0000 00000000 01bf0808 kernel32!HeapFree&#43;0x14
03 001efa6c 00851b64 00000000 00000000 7ffda000 CppHeapCorruption!HeapReuseAfterDeletion&#43;0x198
04 001efb40 00852138 00000001 009f1a88 009f1b40 CppHeapCorruption!wmain&#43;0x24
05 001efb90 00851f7f 001efba4 76b14911 7ffda000 CppHeapCorruption!__tmainCRTStartup&#43;0x1a8
06 001efb98 76b14911 7ffda000 001efbe4 77cde4b6 CppHeapCorruption!wmainCRTStartup&#43;0xf
07 001efba4 77cde4b6 7ffda000 76cd15c7 00000000 kernel32!BaseThreadInitThunk&#43;0xe
08 001efbe4 77cde489 00851087 7ffda000 00000000 ntdll!__RtlUserThreadStart&#43;0x23
09 001efbfc 00000000 00851087 7ffda000 00000000 ntdll!_RtlUserThreadStart&#43;0x1b

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">The crash happened when the application is freeing the memory 01bf0808 in the heap 01bf0000. Let's dump the detailed information of the heap:</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; !heap -a 01bf0000 
Index   Address  Name      Debugging options enabled
  9:   01bf0000 
    Segment at 01bf0000 to 01c30000 (00001000 bytes committed)
    Flags:                00001002
    ForceFlags:           00000000
    Granularity:          8 bytes
    Segment Reserve:      00100000
    Segment Commit:       00002000
    DeCommit Block Thres: 00000200
    DeCommit Total Thres: 00002000
    Total Free Size:      000000fc
    Max. Allocation Size: 7ffdefff
    Lock Variable at:     01bf0130
    Next TagIndex:        0000
    Maximum TagIndex:     0000
    Tag Entries:          00000000
    PsuedoTag Entries:    00000000
    Virtual Alloc List:   01bf00a0
    Uncommitted ranges:   01bf0090
            01bf1000: 0003f000  (258048 bytes)
    FreeList[ 00 ] at 01bf00c4: 01bf0828 . 01bf07c8  
        01bf07c0: 00240 . 00020 [100] - free
    Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002


    Segment00 at 01bf0000:
        Flags:           00000000
        Base:            01bf0000
        First Entry:     01bf0580
        Last Entry:      01c30000
        Total Pages:     00000040
        Total UnCommit:  0000003f
        Largest UnCommit:00000000
        UnCommitted Ranges: (1)


    Heap entries for Segment00 in Heap 01bf0000
        01bf0000: 00000 . 00580 [101] - busy (57f)
        01bf0580: 00580 . 00240 [101] - busy (23f)
        01bf07c0: 00240 . 00020 [100]
        01bf07e0: 00020 . 00020 [101] - busy (18)
        01bf0800: 00020 . 00020 [00]
        01bf0820: 00020 . 007c0 [00]
        01bf0fe0: 007c0 . 00020 [111] - busy (1d)
        01bf1000:      0003f000      - uncommitted bytes.

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; !heap -a 01bf0000 
Index   Address  Name      Debugging options enabled
  9:   01bf0000 
    Segment at 01bf0000 to 01c30000 (00001000 bytes committed)
    Flags:                00001002
    ForceFlags:           00000000
    Granularity:          8 bytes
    Segment Reserve:      00100000
    Segment Commit:       00002000
    DeCommit Block Thres: 00000200
    DeCommit Total Thres: 00002000
    Total Free Size:      000000fc
    Max. Allocation Size: 7ffdefff
    Lock Variable at:     01bf0130
    Next TagIndex:        0000
    Maximum TagIndex:     0000
    Tag Entries:          00000000
    PsuedoTag Entries:    00000000
    Virtual Alloc List:   01bf00a0
    Uncommitted ranges:   01bf0090
            01bf1000: 0003f000  (258048 bytes)
    FreeList[ 00 ] at 01bf00c4: 01bf0828 . 01bf07c8  
        01bf07c0: 00240 . 00020 [100] - free
    Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002


    Segment00 at 01bf0000:
        Flags:           00000000
        Base:            01bf0000
        First Entry:     01bf0580
        Last Entry:      01c30000
        Total Pages:     00000040
        Total UnCommit:  0000003f
        Largest UnCommit:00000000
        UnCommitted Ranges: (1)


    Heap entries for Segment00 in Heap 01bf0000
        01bf0000: 00000 . 00580 [101] - busy (57f)
        01bf0580: 00580 . 00240 [101] - busy (23f)
        01bf07c0: 00240 . 00020 [100]
        01bf07e0: 00020 . 00020 [101] - busy (18)
        01bf0800: 00020 . 00020 [00]
        01bf0820: 00020 . 007c0 [00]
        01bf0fe0: 007c0 . 00020 [111] - busy (1d)
        01bf1000:      0003f000      - uncommitted bytes.

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">The heap entries for Segment00 look fine. However, the free list cannot be interpreted by the debugger.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
FreeList[ 00 ] at 01bf00c4: 01bf0828 . 01bf07c8  
        01bf07c0: 00240 . 00020 [100] - free
    Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002

</pre>
<pre id="codePreview" class="cplusplus">
FreeList[ 00 ] at 01bf00c4: 01bf0828 . 01bf07c8  
        01bf07c0: 00240 . 00020 [100] - free
    Unable to read nt!_HEAP_FREE_ENTRY structure at 00000002

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Let's walk the free list manually. First, get the FLINK 01bf0828. 01bf0828 points to the body of a free block. Its first two DWORDs should be the FLINK and BLINK of adjacent free blocks.
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; dd 01bf0828 L2
01bf0828  01bf00c4 01bf07c8

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; dd 01bf0828 L2
01bf0828  01bf00c4 01bf07c8

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Going forward (take the FLINK 01bf00c4):</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; dd 01bf00c4 L2
01bf00c4  01bf07c8 01bf0828

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; dd 01bf00c4 L2
01bf00c4  01bf07c8 01bf0828

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Continue going forward (take the FLINK 01bf07c8)</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
0:000&gt; dd 01bf07c8 L2
01bf07c8  0000000a 0000000b

</pre>
<pre id="codePreview" class="cplusplus">
0:000&gt; dd 01bf07c8 L2
01bf07c8  0000000a 0000000b

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">We can confirm that 01bf07c8 points to a free block:</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">However, its FLINK (0000000a) and BLINK (0000000b) appear corrupted. The faulting instruction reminds us that the BLINK (0000000b) is exactly the address that caused the crash.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
mov     edi,dword ptr [ecx]  ds:0023:0000000b=????????

</pre>
<pre id="codePreview" class="cplusplus">
mov     edi,dword ptr [ecx]  ds:0023:0000000b=????????

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">One possible reason for this symptom is that, the block at 01bf07c8 was reused (be filled in the values 0000000a and 0000000b) after it was freed.
</span></p>
<h2><span style="">Detections </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Detect the use of uninitialized state at run-time.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Start the process directly under a debugger, instead of attaching a debugger to the process after it is started.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Whenever you start a process under the debugger, the heap manager automatically initializes all memory with a fill pattern. The specifics of the fill pattern depend on the status of the heap block. When
 a heap block is first returned to the caller, the heap manager fills the user-accessible part of the heap block with a fill pattern consisting of the values baadf00d. This indicates that the heap block is allocated but has not yet been initialized. Should
 an application (such as <span class="SpellE">UseUninitializedMemory</span>) dereference this memory block without initializing it first, it will fail with the access violation because the memory pointed by baadf00d is definitely inaccessible to user-mode
 codes. On the other hand, if the application properly initializes the memory block, execution continues. After the heap block is freed, the heap manager once again initializes the user-accessible part of the heap block, this time with the values
<span class="SpellE">feeefeee</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">When the application is not started under the debugger but rather attached to the process, the allocated memory differs in that no longer is the memory initialized to pointer values that cause an immediate
 access violation (baadf00d) when dereferenced. <span class="GramE">The dereference</span> may succeed this time. The incorrect usage of the pointer value might end up causing serious problems somewhere else in the application in paths that rely on the state
 of that memory to be intact. This makes it very difficult to track down the source of the problem.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Detect heap overrun and the reuse of heap after deletion at run-time.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">The <span class="SpellE">
pageheap</span> facility can be used to track down the heap overrun problem and the reuse of heap after deletion.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span class="SpellE"><span style="">Pageheap</span></span><span style=""> is a special debugging heap manager that has even more checking features than the internal debug heap manager used when a process is started
 under a user-mode debugger. <span class="SpellE">Pageheap</span> options are applied at process startup so changes require a process termination and restart.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">There are two forms of <span class="SpellE">
pageheap</span> �C light and full. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Full <span class="SpellE">
pageheap</span> is used to debug heap corruptions. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Guard pages at the beginning and end of a block with NO_ACCESS (0xC0)
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Access to guard pages cause Access Violation </span>
</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Virtual memory usage is much larger and application runs much slower.
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span class="GramE"><span style="">If a user is having timing issues and has already run a scenario under &quot;Full&quot; Page Heap, setting it to &quot;Light&quot; will likely address these issues.</span></span><span style="">
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">Light <span class="SpellE">
pageheap</span> is a lower overhead mechanism to debug heap corruptions. </span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Places fill patterns (0xE0) at the beginning and end of an allocation
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Examines the patterns when a heap block is freed for potential overruns.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">This does not catch corruption as it��s happening but can catch it
<span class="GramE">fairly<span style="">&nbsp; </span>close</span>. </span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style="">To enable page heap, we can use the tool pageheap.exe or Application Verifier, or
<span class="SpellE">gflag</span>. Please read the following articles for details.
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""><a href="http://support.microsoft.com/kb/264471">http://support.microsoft.com/kb/264471</a>
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""><span style="">&nbsp;</span><a href="http://support.microsoft.com/kb/286470">http://support.microsoft.com/kb/286470</a>
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""><a href="http://support.microsoft.com/kb/286568">http://support.microsoft.com/kb/286568</a>
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/cc265902.aspx">http://msdn.microsoft.com/en-us/library/cc265902.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt"><span style=""></span></p>
<h2>Fixes<span style=""> </span></h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Make sure to initialize the memory after the allocation on the heap.
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">It is recommended to replace all occurences of the unsafe buffer-copy APIs such as strcat, strcpy, or wcscpy with the secure ones like StringCchCopy, strcpy_s, and wcscpy_s, _mbscpy_s. The secure APIs allow you to specify
 the size of the destination string to ensure that no more than the specified number of characters are ever copied to the destination. We can use PREfast to find all unsafe uses of buffer-copy APIs, and replace them one by one.
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Be careful that the allocation and deallocation of memory on the heap should be paired and should target the same heap. The most common pairs are:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
New               -    delete
malloc            -    free
GlobalAlloc       -    GlobalFree
LocalAlloc        -    LocalFree
CoTaskMemAlloc    -    CoTaskMemFree 
SysAllocString    -    SysFreeString

</pre>
<pre id="codePreview" class="cplusplus">
New               -    delete
malloc            -    free
GlobalAlloc       -    GlobalFree
LocalAlloc        -    LocalFree
CoTaskMemAlloc    -    CoTaskMemFree 
SysAllocString    -    SysFreeString

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Be careful not to use or double free heap block after deletion.</span><span style="">
</span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span class="GramE"><span style="">Mario <span class="SpellE">
Hewardt</span> &amp; Daniel <span class="SpellE">Pravat</span>, Advanced Windows Debugging Ch. 5 (2007), at
<a href="http://advancedwindowsdebugging.com/">http://advancedwindowsdebugging.com/</a> .</span></span><span style=""><span style="">&nbsp;
</span>Copyright 2008 by Pearson <span class="SpellE">Education<span class="GramE">,Inc</span></span>. This material may be distributed only subject to the terms and conditions set forth in the Open Publication License, v1.0 or later (the latest version
 is presently available at <a href="http://www.opencontent.org/openpub">http://www.opencontent.org/openpub</a> /).
<span class="GramE">Excerpted by <span class="SpellE">Jialiang</span> <span class="SpellE">
Ge</span>, 2009.</span> </span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:0cm"><a href="http://msdn.microsoft.com/en-us/library/ms717795.aspx">Avoiding Buffer Overruns</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:0cm"><a href="http://www.codeproject.com/KB/debug/cdbntsd3.aspx">Debug Tutorial Part 3: The Heap</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
