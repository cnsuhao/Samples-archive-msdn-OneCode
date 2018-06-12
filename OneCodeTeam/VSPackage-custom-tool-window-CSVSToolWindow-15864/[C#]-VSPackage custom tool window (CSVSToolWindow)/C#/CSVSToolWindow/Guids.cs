// Guids.cs
// MUST match guids.h
using System;

namespace Microsoft.CSVSToolWindow
{
    static class GuidList
    {
        public const string guidCSVSToolWindowPkgString = "52189dda-5aa7-4207-a7b2-c330fb171a09";
        public const string guidCSVSToolWindowCmdSetString = "da778ffe-d832-4965-a108-e3104503b670";
        public const string guidToolWindowPersistanceString = "9e2c6336-e461-43fb-ab62-47a266a46a4e";

        public static readonly Guid guidCSVSToolWindowCmdSet = new Guid(guidCSVSToolWindowCmdSetString);
    };
}