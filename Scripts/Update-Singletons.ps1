# Updates singleton libraries from main library

$rootDir = Get-Item "$PSScriptRoot\.."
$mainProjectPath = "$rootDir\TomLabs.Shadowgem"
$directories = Get-ChildItem $mainProjectPath -Directory -Exclude 'bin', 'obj'

foreach($dir in $directories){
	$projName = $(Split-Path $dir -Leaf)
	$projFullName = "TomLabs.Shadowgem.$projName"
	$csprojPath = "$rootDir\$projFullName\$projFullName.csproj"
	$classes = Get-ChildItem $dir -Recurse | Where-Object { !$_.PSIsContainer }

	$xml = New-Object XML
	$xml.Load($csprojPath)

	$compileNodes = $xml.Project.ItemGroup.ChildNodes

	foreach($class in $classes)
	{
		$include = $class.FullName.Replace($rootDir.FullName, '..')
		$link = $class.FullName.Replace("$mainProjectPath\$projName\", '')

		if($null -eq ($compileNodes | Where-Object { $_.GetAttribute('Include') -eq $include })){
			$newCompileNode = $xml.CreateElement('Compile')
			$newCompileNode.SetAttribute('Include', $include)
			$newCompileNode.SetAttribute('Link', $link)
			$xml.Project.ItemGroup.AppendChild($newCompileNode)
		}
	}

	$xml.Save($csprojPath)
}

