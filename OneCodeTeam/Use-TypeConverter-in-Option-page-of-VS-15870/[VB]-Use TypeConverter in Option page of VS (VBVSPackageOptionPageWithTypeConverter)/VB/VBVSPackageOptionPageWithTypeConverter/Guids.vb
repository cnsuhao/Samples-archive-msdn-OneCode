' Guids.cs
' MUST match guids.h

	Friend NotInheritable Class GuidList
		Public Const guidCSVSPackageOptionPageWithTypeConverterPkgString As String = "3c52e486-60c1-4e82-84d2-84b88bdb2c7d"
		Public Const guidCSVSPackageOptionPageWithTypeConverterCmdSetString As String = "d79922a4-265a-4a54-b5ec-a231d17f115d"

		Public Shared ReadOnly guidCSVSPackageOptionPageWithTypeConverterCmdSet As New Guid(guidCSVSPackageOptionPageWithTypeConverterCmdSetString)
	End Class
