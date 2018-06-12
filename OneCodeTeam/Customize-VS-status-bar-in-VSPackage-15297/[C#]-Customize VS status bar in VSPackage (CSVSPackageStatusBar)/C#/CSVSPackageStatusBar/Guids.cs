// Guids.cs
// MUST match guids.h
using System;

namespace Microsoft.CSVSPackageStatusBar
{
    static class GuidList
    {
        public const string guidCSVSPackageStatusBarPkgString = "579292b7-04d0-4617-98c8-7c8933a270eb";
        public const string guidCSVSPackageStatusBarCmdSetString = "0d10eba7-fc9b-473c-b2d8-bd2853ec55bf";
        public const string guidToolWindowPersistanceString = "d9d49a42-cdc5-4277-be57-6e0b0229ab98";

        public static readonly Guid guidCSVSPackageStatusBarCmdSet = new Guid(guidCSVSPackageStatusBarCmdSetString);
    };
}