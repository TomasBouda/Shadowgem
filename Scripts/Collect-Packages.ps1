param(
	[Parameter(Mandatory = $true)]
	[string]$Version
)

Remove-Item "$PSScriptRoot\..\Packages" -Recurse -Force
New-Item "$PSScriptRoot\..\Packages" -ItemType Directory | Out-Null

Get-ChildItem "$PSScriptRoot\..\*" -Include "*.$Version.nupkg", "*.$Version.snupkg" -Recurse | ForEach-Object { Copy-Item $_.FullName -Destination "$PSScriptRoot\..\Packages" -Force }