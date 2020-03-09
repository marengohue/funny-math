module StreamingStdin

let isEol c = c = 10 || c = 13
let isWhitespace c = isEol c || (c = int ' ')

let nextLine =
    Seq.initInfinite (fun _ -> System.Console.Read())
        |> Seq.skipWhile isEol
        |> Seq.takeWhile (isEol >> not)

let nextWord =
    let word = nextLine |> Seq.takeWhile (isWhitespace >> not)
    nextLine |> Seq.takeWhile isWhitespace |> ignore
    word |> Seq.map char

let yieldNums n =
    Seq.initInfinite (fun _ -> nextWord)
        |> Seq.take n
        |> Seq.map (Seq.toArray >> System.String >> int)