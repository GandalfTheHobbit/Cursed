﻿namespace Cursed.Base.Tests
open Cursed.Base

open NUnit.Framework
open Swensen.Unquote

[<TestFixture>]
type MainFormControllerTests() = 
    [<Test>]
    member this.``When progress bar value is an int should return value`` () = 
        let progress = Progress 12
        test <@ MainViewController.GetProgress progress = 12 @>

    [<Test>]
    member this.``When progress is anything else should be 0`` () =
        test <@ MainViewController.GetProgress Indeterminate = 0 @>
        test <@ MainViewController.GetProgress Disabled = 0 @>

    [<Test>]
    member this.``When getting completed mods it should return only completed as obj seq`` () =
        let mods = 
            [ { Link = "FirstMod" 
                Name = "First Mod"
                Completed = false
                ProjectId = 1 }
              { Link = "Second"
                Name = "Second Mod"
                Completed = true
                ProjectId = 2 } ]
        let results = MainViewController.GetCompletedMods mods
        test <@ results |> Seq.length = 1 @>
        test <@ (results |> Seq.head) :?> string = "Second Mod" @>
