param([Parameter(Mandatory=$true)][string]$intDir,[Parameter(Mandatory=$true)][string]$crproj)

$ErrorActionPreference = "Stop"

#$intDir = 'obj\ObsfucatedRelease\Assemblies\'
#$crproj = "ManualApk.crproj"

$xml=New-Object XML

$xml.Load($crproj)
$xml.ParentNode

$xml.FirstChild.Attributes["baseDir"].InnerText=$intDir

$xml.Save($crproj)

& 'C:\Development\ConfuserEx\Confuser.CLI.exe' $crproj -n
Copy-Item $intDir\Confused\* $intDir -verbose

Remove-Item $intDir\Confused -Recurse