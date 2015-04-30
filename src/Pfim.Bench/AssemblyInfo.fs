﻿namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Pfim.Bench")>]
[<assembly: AssemblyProductAttribute("Pfim")>]
[<assembly: AssemblyDescriptionAttribute("Image file format parser")>]
[<assembly: AssemblyVersionAttribute("0.2")>]
[<assembly: AssemblyFileVersionAttribute("0.2")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.2"