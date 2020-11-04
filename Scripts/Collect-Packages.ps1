param(
	[Parameter(Mandatory = $true)]
	[string]$Version
)

New-Item "$PSScriptRoot\..\Packages" -ItemType Directory

Get-ChildItem "$PSScriptRoot\..\*.$Version.nupkg" -Recurse | ForEach-Object { Copy-Item $_.FullName -Destination "$PSScriptRoot\..\Packages" -Force }