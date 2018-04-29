# Updates all packages in solution with PackageMetadata.xml

$TEMPLATE_PATH = "$PWD\PackageMetadata.xml"
$EXCLUDED_CSPROJS = "TomLabs.Shadowgem.Tests.csproj"

$TEMPLATEXML = New-Object XML
$TEMPLATEXML.Load($TEMPLATE_PATH)

function Update-CsProj($csprojPath){
    Write-Host "Updating $csprojPath" -ForegroundColor Green

    $xml = New-Object XML
    $xml.Load($csprojPath)

    foreach($templateNode in $TEMPLATEXML.PropertyGroup.ChildNodes){
        $targetNode = $xml.SelectSingleNode("//$($templateNode.Name)")     
        if(!$targetNode){
            Write-Host "Creating node: $($templateNode.Name)"
            $targetNode = $xml.CreateElement($templateNode.Name)
            $xml.Project.PropertyGroup.AppendChild($targetNode)
        }
        $targetNode.InnerText = $templateNode.InnerText
    }
    
    $xml.Save($csprojPath)
}

$csProjs = Get-ChildItem $PWD -Recurse -Include *.csproj -Exclude $EXCLUDED_CSPROJS

foreach($csproj in $csProjs){
    Update-CsProj($csproj)
}

Write-Host "Updating PackageInfos done." -ForegroundColor Green