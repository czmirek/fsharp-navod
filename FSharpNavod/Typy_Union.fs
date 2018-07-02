module Typy_Union

//Unionový typ
type UnionovýTypDvouČísel = 
    | PrvníČíslo of int    
    | DruhéČíslo of int

    // první svislítko "|" lze vynechat, tzn. validní zápis je i "type UnionovýTypDvouČísel = PrvníČíslo of int | DruhéČíslo of int"

(*
    U tuplu jako např "int * int" říkáme, že tento typ v sobě všechny kombinace dvou intů.
    
    U unionu "UnionovýTypDvouČísel" říkáme, že máme "PrvníČíslo" --- a také --- "DruhéČíslo".
    Tzn. máme k dispozici množinu všech intů z "PrvníČíslo" a zároveň množinu všech intů z "DruhéČíslo"
    Nevytváříme žádnou kombinaci, je to jako kdybychom tyto množiny sečetli takže rozsah hodnot,
    které "UnionovýTypDvouČísel" v sobě může držet, je int + int neboli 2^32 + 2^32
*)

//Přiřazení unionových typů
let u1 = PrvníČíslo 1
let u2 = DruhéČíslo 2
(*
    Unionové typy v C# vůbec nejsou.

    p1 je vlastně číslo (int) ale je to číslo unionového typu "PrvníČíslo".
    POZOR! p1 NENÍ int!! p1 je typu UnionovýTypDvouČísel!

    Tudíž pokud by to byla proměnná, nelze do ní přiřadit číslo.

    let mutable ukazka = PrvníČíslo 1
    ukazka <- 5            //KOMPILER ZDE VYHODÍ CHYBU!!
    ukazka <- PrvníČíslo 5 //ok
    
    Toto lze využít např. pro různé typy ID v businessových objektech. Zatímco v normálním
    C# se toto dělá hrozně kostrbatě, v F# lze definovat něco jako UživatelID a díky tomu
    se nemůže stát, že na UživatelID v kódu bude přiřazeno jakékoliv jiné číslo, které není
    tohoto "pod-typu".
*)

//další možnost zápisu
let u3 = UnionovýTypDvouČísel.DruhéČíslo 5

//Unionový typ může obsahovat podtypy, jejichž podtypy 
type UnionovýTyp2 = TypA | TypB | TypC //tyto podtypy nedrží žádnou hodnotu

//Tyto podtypy lze následovně libovolně přiřazovat.
let u4 = TypA               //není nutné zapisovat UnionovýTyp2
let u5 = UnionovýTyp2.TypA  //totéž

//Union nad generickým typem (uvádí se s jednoduchým apostrofem před názvem)
type GenerickýTyp<'a> = 
    | ``První subtyp`` of 'a
    | ``Druhý subtyp`` of 'a * 'a