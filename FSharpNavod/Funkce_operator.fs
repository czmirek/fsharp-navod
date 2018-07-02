module Funkce_operator

//tato funkce má na vstupu int, na výstupu int->int
//tzn. na vstupu vezme jedno číslo, na výstupu vrátí
//funkci, která má vstup int, výstup int
let sečtiČísla číslo = (+) číslo

(*
    Operátory jsou v F# funkce. Zápis "a+b" je v F# sugar syntax,
    ve skutečnosti se volá funkce, která má název (+) a má na 
    vstupu "a" a "b". A protože všechny funkce v F# mají jen
    jeden vstup a jeden výstup, tak i funkce pro operátor "+"
    má ve skutečnosti jeden vstup a když této funkci předáme
    jen první parametr, tak to vrátí vnitřní funkci int->int,
    která dostane druhý parametr.
*)

let výsledek1 = sečtiČísla 11   //vrátí funkci int->int
let výsledek2 = výsledek1 5     //vrátí 16