using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace AddElementToHeadTag.Features.MainSite {

  [Guid("96a66fa8-478f-4b3f-bc3d-4cb94f2ce6e0")]
  public class MainSiteEventReceiver : SPFeatureReceiver {

    public override void FeatureInstalled(SPFeatureReceiverProperties properties) {
      SPFarm.Local.Services.GetValue<SPWebService>().ApplyApplicationContentToLocalServer();
    }

  }
}
