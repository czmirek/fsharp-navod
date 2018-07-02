module Funkce3

(*
    
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/
    https://fsharpforfunandprofit.com/posts/expressions-vs-statements/

    V C# je několik typů zápisů.    
    
    int x = 5;      <--- toto je tvrzení, v angličtině "statement". 
                         Tvrzení je něco, co se má stát.

    int y = x * 10; <--- x * 10 je výraz, v angličtině "expression"
                         Výraz má návratovou hodnotu.

    
    V F# je VŠE VÝRAZ! Tzn. úplně vše má nějakou návratovou hodnotu.
    
    Funkce mají v F# tento zápis:
        vstup -> výstup
*)

// toto je hodnota typu string
let hodnota          = "Nějaký řetězec";

// toto je funkce, která na vstupu obsahuje "unit" a na výstupu vrací string 
// neboli "unit -> string"
// unit = "ekvivalent" k void v C# - jedná se o "nic" hodnotu a zapisuje se jako ()
let hodnotaZFunkce() = "Nějaký řetězec z funkce"; 

// hodnota 2 je hodnota typu string a obsahuje "Nějaký řetězec"
let hodnota2 = hodnota

// hodnota 3 je funkce stejného typu, jako hodnotaZFunkce (unit -> string)
let hodnota3 = hodnotaZFunkce

// hodnota 4 je řetězec "Nějaký řetězec z funkce", jako první parametr mu byl předán unit, který
// se v F# zapisuje takto: ()
let hodnota4 = hodnota3 ()

// Toto je funkce, která na vstupu bere 4x unit a vrací string!
let podivnáFunkce () () () () = "blabla"
(*

podivnáFunkce je typu "unit -> unit -> unit -> unit -> string" protože

    Funkce              Vstup   Výstup
    --------------------------------------
    podivnáFunkce       unit    unit
    vnitřníFunkce1      unit    unit
    vnitřníFunkce2      unit    unit
    vnitřníFunkce3      unit    string
*)

//vstupem "výsledekPodivnéFunkce" nebo jakékoliv funkce bez parametru je ve skutečnosti vždy unit --> () 
//ale ten se nezapisuje, F# kompiler ho automaticky doplňuje sám (F# funkce mají vždy jeden vstup a jeden výstup)
//výstupem je řetězec "blabla"
let výsledekPodivnéFunkce = podivnáFunkce () ()
let blablaStrnig = výsledekPodivnéFunkce()

//vstupem další prapodivné funkce je řetězec, výstupem je unit
let dalšíPrapodivnáFunkce string = ()
let unitHodnota = dalšíPrapodivnáFunkce "řetězec"