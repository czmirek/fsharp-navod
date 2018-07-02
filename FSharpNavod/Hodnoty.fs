module Hodnoty

//Definice typu.
type Číslo = int
(*
    Názvy typů mohou obsahovat diakritiku. Kód normálně píšu anglicky ale teď se mi
    chce psát všechno česky, když se to takhle učím s českým komentářem.

    V F# lze definovat, že daný typ je vlastně pouze aliasem pro existující typ
    což se ale prej nedoporučuje.
*)

//Složitější název typu obalený v ``
type ``Název typu obsahující diakritiku, mezery a různý znaky -?:!§`` = int

//Definice konstantní hodnoty
let konstantníHodnota = 5;
(* 
    
   Platí následující

   1) hodnota1 už nelze měnit. V F# se defaultně nepracuje s proměnnými ale s konstantami,
      proto F# defaultně pracuje s konstantními hodnotami a pro vytvoření proměnné je nutné
      zadat další klíčové slovo "mutable".

      Začátečníkům se nedoporučuje vůbec proměnné vytvářet, v F# má význam s proměnnými 
      pracovat pouze při komunikaci s dalšími knihovnami a podobně.
      
   2) Typová inference = hodnota1 je automaticky int. Toto ale není jako v PHP nebo
      v Javascriptu, kdy lze do jedné proměnné přiřazovat libovolně nejdřív int, pak
      string, pak objekt atd. Jakmile compiler jednou rozhodne o typu, pak je porušení
      tohoto typu chybou kompilace.
*)

//Definice proměnné hodnoty
let mutable proměnná = 5;

//Přiřazení do proměnné hodnoty
proměnná <- 6
(* Operátor <- přímo slouží pro přiřazení hodnoty do proměnné *)

//Definice konstantní hodnoty s uvedeným typem
let konstanta1:Číslo = 5;
(* 
    Kompiler toto přeloží jako konstanta1:int.
    Uvedení typu není pro F# kompiler nic jiného, než jen nahrazení řetězce.
    V tomto případě není vůbec žádný rozdíl, mezi konstanta:int a konstanta:Číslo.
    Pokud by to byla proměnná, stále do ní můžeme přiřadit obyčejný int.
    V tomto případě to funguje pouze jako alias.
*)