task . CopyNuget

task CopyNuget {
    Copy-Item source\JsonLogger\bin\Release\*.nupkg ~\localnuget
}
