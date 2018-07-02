module Funkce_partialApplication

//Opakování z Funkce1.fs
let sečtiČísla sčítanec1 sčítanec2 = sčítanec1 + sčítanec2

//Nyní pozor!
let sečtiČíslaBezDruhéhoSčítance sčítanec1 = sečtiČísla sčítanec1
(* 
    Kód výše znamená: vytvoř mi funkci "sečtiČíslaBezDruhéhoSčítance" která na vstupu
    bere jen "sčítanec1" a na výstupu vrací "sečtiČísla" ale s uvedením pouze
    jednoho parametru.

    Co to znamená? Jak je to možné, když "sečtiČísla" má na vstupu dva parametry?

    Tohle souvisí s tím, že VŠECHNY funkce v F# mají jen JEDEN vstup a JEDEN výstup.
    Kompiler pro funkce s více parametry pouze vytváří další vnitřní funkce.

    Funkce "sečtiČíslaBezSčítance" je tudíž reprezentace té první, "vnější" zkompilované
    funkce, která má na vstupu pouze čitatel.
*)

let sečtiČíslaSPrvnímSčítancem = sečtiČíslaBezDruhéhoSčítance 5
(*
    Výraz "sečtiČíslaBezDruhéhoSčítance 5" vrátí funkci, která přijímá druhý parametr, 
    výše pojmenovaný jako "sčítanec2"!
*)

let výsledek = sečtiČíslaSPrvnímSčítancem 9 //výsledek je 14
