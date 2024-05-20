#r "nuget: SimpleExec, 12.0.0"
open System
open SimpleExec

let wchartDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "WCharT.Net")

//Create binary for Linux / Mac
Command.Run(
    name = "dotnet",
    args = "build --runtime unix --configuration Release",
    workingDirectory = wchartDir
)

//Create binary for Windows
Command.Run(
    name = "dotnet",
    args = "build --runtime windows --configuration Release",
    workingDirectory = wchartDir
)

//Create reference assembly for AnyCPU
Command.Run(
    name = "dotnet",
    args = "build --configuration Release",
    workingDirectory = wchartDir
)