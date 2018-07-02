module Funkce_lambda

//normální funkce
let normalFce x = x + 1

//anonymní funkce
let anonymFce   = fun x -> x + 1
(*
    anonymFce dělá naprosto totéž, co normalFce
*)

let hodnota1 = normalFce 1 //výsledek = 2
let hodnota2 = anonymFce 1 //výsledek = 2

let ``Přičti 1 k výsledku funkce na vstupu`` fx x = fx(x) + 1

//není žádný rozdíl mezi signature normální a anon fcí, obojí je "int -> int"
//a s obojím lze stejně nakládat
let výsledek1 = ``Přičti 1 k výsledku funkce na vstupu`` normalFce 1         //výsledek = 3
let výsledek2 = ``Přičti 1 k výsledku funkce na vstupu`` anonymFce 1         //výsledek = 3
let výsledek3 = ``Přičti 1 k výsledku funkce na vstupu`` (fun x -> x + 2) 1  //výsledek = 4
                                                        //anon funkci je tady nutné
                                                        //dát jako parametr do 
                                                        //kulatých 1závorek

