// Guids.cs
// MUST match guids.h
using System;

namespace Company.CSVSPackage
{
    static class GuidList
    {
        public const string guidCSVSPackagePkgString = "5e8b2fa8-1644-47e8-8f4f-dc602679f2d3";
        public const string guidCSVSPackageCmdSetString = "6737384c-679e-447c-af99-c31719ca4028";

        public static readonly Guid guidCSVSPackageCmdSet = new Guid(guidCSVSPackageCmdSetString);
    };
}