function CreateFolder($path) {
    
    if (!(Test-Path $path)) {
    
        New-Item -ItemType Directory -Force -Path $path
    
    }
}

function DeleteFile($path){
    
  if (Test-Path $path) { 
    
    try {
    
        Write-Host "Deleting $path.." -foreground "magenta" 
            Remove-Item -Path "$path" -Force -ErrorAction SilentlyContinue
            Write-Host " "
        
            return $true
        }
        catch {
    
            $_
            return $false
        }	
    }
    else {
        return $true
    }
}

function DeleteDirectory($path) {
    
    if (Test-Path $path) { 
    
        try {
    
            Write-Host "Deleting $path.." -foreground "magenta" 
            Remove-Item -Path "$path" -Force -Recurse -ErrorAction SilentlyContinue
            Write-Host " "
    
            return $true
        }
        catch {
    
            $_
            return $false
        }	
    }
    else {
    
        return $true
    }
}


function CreateSearchService($path) {
    
    $dest = "$path\src\app\shared\services"
    
    CreateFolder $dest
    Set-Location $dest
    
    ng g service Search
    
    Set-Location $path
    Write-Host 
}

function CreateSearchResponse($path) {
    
    $dest = "$path\src\app\shared\responses"
    
    CreateFolder $dest
    Set-Location $dest
    
    ng g class SearchResponse --spec=false
    
    Set-Location $path
    Write-Host 
}

function CreateAssetFolders($path) {
    
    $img = "$path\src\assets\img"
    
    CreateFolder $img
}

function CreateBusyIndicatorComponent($path) {
    
    $dest = "$path\src\app\shared"
    
    CreateFolder $dest
    Set-Location $dest
    
    ng g component BusyIndicator --spec=false
    
    Set-Location $path
    Write-Host 
}

function CreateEmlCheckBoxComponent($path) {
    
    $dest = "$path\src\app\shared"
    
    CreateFolder $dest
    Set-Location $dest
    
    ng g component EmlCheckbox
    
    Set-Location $path
    Write-Host 
}

function CreateDebuggerPipe($path) {
    
    $dest = "$path\src\app\shared"
    
    CreateFolder $dest
    Set-Location $dest
    
    ng g pipe Debugger --spec=false
    
    Set-Location $path
    Write-Host 
}

function CreateAngular($path, $angularAppName) {
  
    Clear-Host
    Write-Host 
    Write-Host $angularAppName": $path" -foreground Cyan
    Write-Host 

    $forceDeleteSuccess = DeleteFile "$path\angular.json"
    $forceDeleteSuccess = DeleteFile "$path\.editorconfig"
    $forceDeleteSuccess = DeleteFile "$path\.gitignore"
    $forceDeleteSuccess = DeleteFile "..\package.json"
    $forceDeleteSuccess = DeleteFile "$path\package.json"
    $forceDeleteSuccess = DeleteFile "$path\angular.json"
    $forceDeleteSuccess = DeleteFile "$path\README.md"
    $forceDeleteSuccess = DeleteFile "$path\tsconfig.json"
    $forceDeleteSuccess = DeleteFile "$path\tslint.json"
    $forceDeleteSuccess = DeleteFile "$path\package-lock.json"

    $forceDeleteSuccess = DeleteDirectory "$path\node_modules"
    $forceDeleteSuccess = DeleteDirectory "$path\e2e"
    $forceDeleteSuccess = DeleteDirectory "$path\src"

    Set-Location $path

    ng new $angularAppName --directory=./ --routing --skip-install --skip-git --style=css --interactive=false
    npm i @angular/animations@latest @angular/common@latest @angular/compiler@latest @angular/core@latest @angular/forms@latest @angular/platform-browser@latest @angular/platform-browser-dynamic@latest @angular/router@latest core-js@latest rxjs@latest tslib@latest zone.js@latest --save
    # typescript versions: https://www.npmjs.com/package/typescript
    npm i typescript@3.1.6 @angular-devkit/build-angular@latest @angular/cli@latest @angular/compiler-cli@latest @angular/language-service@latest @types/node@latest @types/jasmine@latest @types/jasminewd2@latest codelyzer@latest jasmine-core@latest jasmine-spec-reporter@latest karma@latest karma-chrome-launcher@latest karma-coverage-istanbul-reporter@latest karma-jasmine@latest karma-jasmine-html-reporter@latest protractor@latest ts-node@latest tslint@latest --save-dev
    npm i jquery popper.js bootstrap animate.css font-awesome roboto-fontface moment primeng primeicons dexie --save
    npm i ts-helpers --save-dev
    # #npm audit fix

    CreateSearchService $path
    CreateSearchResponse $path
    CreateBusyIndicatorComponent $path
    CreateEmlCheckBoxComponent $path
    CreateDebuggerPipe $path
    CreateAssetFolders $path

    #ng g m Dashboard --routing
    #https://baswanders.com/angular-cli-cheatsheet-an-overview-of-the-most-used-commands/
    #https://angular.io/guide/styleguide

    Write-Host 
    Write-Host 
}

$projectPath=(get-item $PSScriptRoot)
    
CreateAngular $projectPath "TechChallengeTmp"
