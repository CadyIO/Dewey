param(
    $a
)

$src = dir .\src

function clean {
    foreach ($dir in $src) {
        Set-Location .\src\$dir

        if(Test-Path -Path .\bin) {
            Remove-Item .\bin -Force -Recurse
            "$dir\bin deleted."
        } else {
            "$dir\bin not found."
        }

        Set-Location ..\..\
    }
}

function build {
    foreach ($dir in $src) {
        Set-Location .\src\$dir
        dotnet build
        Set-Location ..\..\
    }
}

function pack {
    foreach ($dir in $src) {
        Set-Location .\src\$dir
        dotnet pack
        Set-Location ..\..\
    }
}

function restore {
    foreach ($dir in $src) {
        Set-Location .\src\$dir
        dotnet restore
        Set-Location ..\..\
    }
}

function publish {
    foreach ($dir in $src) {
        Set-Location .\src\$dir\bin\debug

        $packages = Get-ChildItem -Filter *.nupkg | Where-Object { $_.Extension -eq '.nupkg' }

        foreach($package in $packages) {
            nuget push $package -Source https://www.nuget.org/api/v2/package
        }

        Set-Location ..\..\..\..\
    }
}

function love {
    "Awww, we love you too!"
}

switch($a) {
    "clean" {
        clean
    }
    "restore" {
        restore
    }
    "build" {
        build
    }
    "pack" {
        pack
    }
    "publish" {
        publish
    }
    "love" {
        love
    }
    default {
        clean
        restore
        build
        pack
        ""
        "---------------------------------------"
        ""
        "NOTE: You must run `publish` manually."
        ""
        "---------------------------------------"
        ""
    }
}