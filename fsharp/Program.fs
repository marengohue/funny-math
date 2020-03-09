module FunnyMath

open System
open System.IO

let isPerfectSquare x =
    (x |> float |> sqrt) % 1.0 = 0.0

let solve (combs: int seq) = 
    Seq.indexed combs
        |> Seq.filter (fun (idx, _) -> isPerfectSquare (idx + 1))
        |> Seq.map (fun (_, sum) -> sum / 2)

[<EntryPoint>]
let main _ =
    Console.ReadLine() |> int |> ignore // We don't even need N

    let stdInChars = seq {
        for nextChar in Seq.initInfinite ( fun _ -> Console.Read()) do
            if nextChar <> 10 && nextChar <> 13 && nextChar <> int ' ' then
                yield nextChar
    }

    let stdInNumbers = seq {
        for digits in stdInChars do
            yield String.Join("", digits) |> int
    }

    for result in (solve stdInNumbers) do
        Console.WriteLine(result)
    
    0
