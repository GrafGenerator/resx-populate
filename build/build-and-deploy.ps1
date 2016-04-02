Set-StrictMode -Version Latest

Import-Module -Name "$PSScriptRoot\Invoke-MsBuild.psm1" -DisableNameChecking

$moduleName = 'GrafGenerator.ResxPopulate'
$docsFolder = [Environment]::GetFolderPath('MyDocuments')
$installFolder = "$docsFolder\WindowsPowerShell\Modules\$moduleName"

$rootFolder = "$PSScriptRoot\.."
$artifactsFolder = "$rootFolder\artifacts"
$solutionPath = "$rootFolder\src\ResxPopulate.sln"



# build

$buildSucceeded = Invoke-MsBuild -Path $solutionPath -MsBuildParameters "/target:Clean;Build /property:Configuration=Release;OutDir=$artifactsFolder"

if ($buildSucceeded)
{ Write-Host "Build completed successfully." }
else
{ Write-Host "Build failed. Check the build log file for errors." }


#install

Write-Host "Install module."

#Copy-Item

Write-Host $installFolder
