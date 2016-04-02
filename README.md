# ResxPopulate
## Description
Small Powershell cmdlet for RESX file populating for many cultures.
Cmdlet named Copy-Resx.

## Call syntax
`Copy-Resx "path-to-resx" @("ru", "en", "cn")`

or

`Copy-Resx "path-to-resx"`

In second case cultures list is omitted, and default list used (ar-AE, cs-CZ, el-GR, es-Cl, kk-KZ, ky-KG, ru-RU, uk-UA).

## Installation

1. Download or clone sources.
2. Open `build` folder
3. Run Powershell here
4. Run build-and-deploy.ps1. It will install module into your modules folder (under Documents\WindowsPowerShell\Modules).
5. Now if run new Powershell console, module should be loaded and Copy-Resx command should be available.

#License
MIT license
