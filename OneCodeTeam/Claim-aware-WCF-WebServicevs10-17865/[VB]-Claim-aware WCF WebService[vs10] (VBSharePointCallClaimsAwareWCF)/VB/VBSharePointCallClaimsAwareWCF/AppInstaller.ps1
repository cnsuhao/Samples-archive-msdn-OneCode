function LoadSharePointPowerShellEnvironment
{
	write-host 
	write-host "Setting up PowerShell environment for SharePoint" -foregroundcolor Yellow
	write-host 

	# unload & load the sharepoint powershell snapin
	$snapin = Get-PSSnapin | where-object { $_.Name -eq 'Microsoft.SharePoint.PowerShell' }
	if ($snapin -ne $null){
		write-host "Unloading SharePoint PowerShell Snapin..." -foregroundcolor Gray
		remove-pssnapin "Microsoft.SharePoint.PowerShell"
		write-host "SharePoint PowerShell Snapin unloaded." -foregroundcolor Green
	}
	$snapin = Get-PSSnapin | where-object { $_.Name -eq 'Microsoft.SharePoint.PowerShell' }
	if ($snapin -eq $null){
		write-host "Loading SharePoint PowerShell Snapin..." -foregroundcolor Gray
		add-pssnapin "Microsoft.SharePoint.PowerShell"
		write-host "SharePoint PowerShell Snapin loaded." -foregroundcolor Green
	}
}
#
# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
# Install & create service app... create proxy & add to default proxy group... then start up an instance of the app
# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
#

write-host 

LoadSharePointPowerShellEnvironment


# [[[[[[[[STEP]]]]]]]]


write-host 
write-host "[[STEP]] Installing custom service" -foregroundcolor Yellow
write-host 

write-host "Installing the custom service..." -foregroundcolor Gray
Install-CustomService
write-host "Custom service installed." -foregroundcolor Green


# [[[[[[[[STEP]]]]]]]]


write-host 
write-host "[[STEP]] Creating custom service application." -foregroundcolor Yellow
write-host 

write-host "Ensure custom service application not already created..." -foregroundcolor Gray
$serviceApp = Get-SPServiceApplication | where { $_.GetType().FullName -eq "CustomService.CustomService.CustomServiceApplication" -and $_.Name -eq "CustomServiceApp1" }
if ($serviceApp -eq $null){
	write-host "Creating custom service application..." -foregroundcolor Gray
	$serviceApp = New-CustomServiceApplication -Name "CustomServiceApp1" -ApplicationPool "SharePoint Web Services System" -DatabaseName "CustomServiceApplication"
	write-host "Custom service application created." -foregroundcolor Green
}


# [[[[[[[[STEP]]]]]]]]


write-host 
write-host "[[STEP]] Configuring permissions on custom service application." -foregroundcolor Yellow
write-host 

write-host "Configure permissions on the custom service app..." -foregroundcolor Gray
$user = $env:userdomain + '\' + $env:username

write-host "  Creating new claim for $user..." -foregroundcolor Gray
$userClaim = New-SPClaimsPrincipal -Identity $user -IdentityType WindowsSamAccountName
$security = Get-SPServiceApplicationSecurity $serviceApp

write-host "  Granting $user 'FULL CONTROL' to custom service application..." -foregroundcolor Gray
Grant-SPObjectSecurity $security $userClaim -Rights "Full Control"
Set-SPServiceApplicationSecurity $sampleApp $security

write-host "Custom service application permissions set." -foregroundcolor Green


# [[[[[[[[STEP]]]]]]]]


write-host 
write-host "[[STEP]] Installing custom service proxy." -foregroundcolor Yellow
write-host 

write-host "Installing custom service application proxy..." -foregroundcolor Gray
Install-CustomServiceProxy
write-host "Custom service application proxy installed." -foregroundcolor Green


# [[[[[[[[STEP]]]]]]]]


write-host 
write-host "[[STEP]] Creating custom service application proxy." -foregroundcolor Yellow
write-host 

write-host "Ensure custom service application proxy not already created..." -foregroundcolor Gray
$serviceAppProxy = Get-SPServiceApplicationProxy | where { $_.GetType().FullName -eq "CustomService.CustomService.CustomServiceApplicationProxy" -and $_.Name -eq "CustomServiceAppProxy1" }
if ($serviceAppProxy -eq $null)
{
	write-host "Creating custom service application proxy..." -foregroundcolor Gray
	$serviceAppProxy = New-CustomServiceApplicationProxy -Name "CustomServiceAppProxy1" -ServiceApplication $serviceApp
	write-host "Custom service application proxy created." -foregroundcolor Green

	write-host 

	write-host "Adding custom service application proxy to default group..." -foregroundcolor Gray
	Get-SPServiceApplicationProxyGroup -Default | Add-SPServiceApplicationProxyGroupMember -Member $serviceAppProxy
	write-host "Custom service application proxy added to default group." -foregroundcolor Green
}

# [[[[[[[[STEP]]]]]]]]

write-host 
write-host "[[STEP]] Starting custom service application instance on local server." -foregroundcolor Yellow
write-host 

write-host "Ensure custom service instance is running on server $env:computername..." -foregroundcolor Gray
$localServiceInstance = Get-SPServiceInstance -Server $env:computername | where { $_.GetType().FullName -eq "CustomService.CustomService.CustomServiceInstance" -and $_.Name -eq "" }
if ($localServiceInstance.Status -ne 'Online'){
	write-host "Starting custom service instance on server $env:computername..." -foregroundcolor Gray
	Start-SPServiceInstance $localServiceInstance
	write-host "Custom service instance started." -foregroundcolor Green
}



write-host "[[[[ Custom service application components setup. ]]]]" -foregroundcolor Green

write-host
read-host 