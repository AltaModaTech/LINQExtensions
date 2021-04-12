param (
    [Parameter(Mandatory=$true)][string]$apiKey
)

$branch = invoke-expression "git branch --show-current"

if ($branch -ne 'master') {
    Write-Error "Publishing only allowed from master branch"
    exit
}

$projPaths = @(
    "."
)

# Ensure everything is built
Write-Verbose "Pack projects"
$projPaths | %{
    write-host ""   # separator
    dotnet pack -c Release $_
}

# Publish to NuGet
Write-Verbose "Publish projects"
$projPaths | %{
    write-host ""   # separator
    $pkg = gci $_/bin/Release *.nupkg
    dotnet nuget push -k $apiKey $pkg.FullName -s https://api.nuget.org/v3/index.json
}
