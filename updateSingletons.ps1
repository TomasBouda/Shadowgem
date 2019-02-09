
$mainProjectPath = "$PSScriptRoot\TomLabs.Shadowgem"
$directories = Get-ChildItem $mainProjectPath -Directory -Exclude 'bin', 'obj'
$projTemplate = [IO.File]::ReadAllText("$PSScriptRoot\ProjTemplate.xml", [Text.Encoding]::UTF8)
# <Compile Include="..\TomLabs.Shadowgem\Helpers\Cmd.cs" Link="Cmd.cs" />
$linkTemplate = '<Compile Include="{0}" Link="{1}" />'

foreach($dir in $directories){
	$links = ""
	$projName = $(Split-Path $dir -Leaf)
	$projFullName = "TomLabs.Shadowgem.$projName"
	$classes = Get-ChildItem $dir -Recurse | Where-Object { !$_.PSIsContainer }

	foreach($class in $classes)
	{
		$include = $class.FullName.Replace($PSScriptRoot, '..')
		$link = $class.FullName.Replace("$mainProjectPath\$projName\", '')

		$links += ($linkTemplate -f $include, $link) + "`n"	
	}

	New-Item -ItemType Directory -Force -Path "$PSScriptRoot\$projFullName"

	$projFile = $projTemplate -f $projFullName, $links
	$projFile | Out-File "$PSScriptRoot\$projFullName\$projFullName.csproj" -Encoding utf8 -Force
}

