module Debug

(*
    %s = stringy    
    %b = booleany
    %i = inty
    %f = floaty
    %A = tuply, recordy a uniony
    %O = ostatní objekty

*)
type Uživatel = {Jméno:string;Příjmení:string}
let uživatel1 = { Jméno = "Karel"; Příjmení = "Varel"; }

printfn "Ahoj %s" "Karle"
printfn "Je to pravda: %b or %b" true false
printfn "%i stříbrných stříkaček" 333
printfn "Pi = %f" 3.1415
printfn "Tuple: %A" ("Řetězec a číslo", 567)
printfn "Record: %A" uživatel1