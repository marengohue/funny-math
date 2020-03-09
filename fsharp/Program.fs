module FunnyMath

open System

let isPerfectSquare x =
    (x |> float |> sqrt) % 1.0 = 0.0

let solve (combs: int seq) = 
    Seq.indexed combs
        |> Seq.filter (fun (idx, _) -> isPerfectSquare (idx + 1))
        |> Seq.map (fun (_, sum) -> sum / 2)

[<EntryPoint>]
let main _ =
    Console.ReadLine()
        |> int
        |> fun x -> x * x
        |> StreamingStdin.yieldNums
        |> solve
        |> Seq.iter Console.WriteLine

    0
