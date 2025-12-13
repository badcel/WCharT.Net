#r "nuget: SimpleExec, 12.0.0"
open SimpleExec

let wchartDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "WCharT.Net")

let configuration = "Release"

let buildVariant (target: string) =    
    Command.Run(
        name = "dotnet",
        args = $"build -c {configuration} -p:WChartTarget={target} --artifacts-path ../artifacts/bin/{target}/",
        workingDirectory = wchartDir
    )

//Create reference assembly for AnyCPU
Command.Run(
    name = "dotnet",
    args = $"build -c {configuration} --artifacts-path ../artifacts/ref/",
    workingDirectory = wchartDir
)

//Create platform-specific binaries
buildVariant "unix"
buildVariant "win"