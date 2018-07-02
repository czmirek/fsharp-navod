module Typy1

//Definice typu.
type Číslo = int
(*
    Názvy typů mohou obsahovat diakritiku. Kód normálně píšu anglicky ale teď se mi
    chce psát všechno česky, když se to takhle učím s českým komentářem.

    V F# lze definovat, že daný typ je vlastně pouze aliasem pro existující typ
    což se ale prej nedoporučuje.
*)

//Definice konstantní hodnoty
let konstantníHodnota = 5;
(* 
    
   Platí následující

   1) hodnota1 už nelze měnit. V F# se defaultně nepracuje s proměnnými ale s konstantami,
      proto F# defaultně pracuje s konstantními hodnotami a pro vytvoření proměnné je nutné
      zadat další klíčové slovo "mutable".

      Začátečníkům se nedoporučuje vůbec proměnné vytvářet, v F# má význam s proměnnými 
      pracovat pouze při komunikaci s dalšími knihovnami a podobně.
      Měnitelná hodnota bude vysvětlena níže.

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
    Uvedení typu není pro F# kompiler nic jiného, než jen nahrazení řetězce!
    V tomto případě není vůbec žádný rozdíl, mezi konstanta:int a konstanta:Číslo.
    Pokud by to byla proměnná, stále do ní můžeme přiřadit obyčejný int.
    V tomto případě to funguje pouze jako alias.
*)


//Složitější název typu obalený v ``
type ``Název typu obsahující diakritiku, mezery a různý znaky -?:!§`` = int


//Dvoj-číslo (Tuple)
type IntTuple = int * int
(*
    Toto je totéž, jako v C# Tuple<int, int> pojmenované ve vlastním typu.
*)

//Tuple<int, string, bool>
type IntAndStringAndBool = int * string * bool
(*
   Proč zrovna znak "*"? Protože:

      "int"     reprezentuje "všechny integery" tedy všechna čísla, která jsou int.
      "string"  reprezentuje "všechny stringy" které kdy mohou v typu "string" existovat.
                to se pochopitelně nedá spočítat
      "bool"    reprenzetuje "všechny booly" které mohou existovat - ty jsou jenom dva, true a false

   V C# když napíšeš "int x = 5" pak to vlastně znamená něco jako 
        - "udělej mi v paměti adresovatelný 32bitový prostor" 
        - "do tohoto prostoru v paměti ulož hodnotu 5"
   
   ...a zpravidla nás víc nezajímá, u C# přistupujeme ke kódu jako kdybychom zadávali
   počítači instrukce, jenom pro to používáme různě složité způsoby zápisu (jako třeba OOP)
   které potom kompiler převádí do IL a posléze do strojového kódu.

   V F# když napíšeš "let x = 5" pak je nutné se na to dívat trochu jinak. Samozřejmě ve výsledku
   se taky někde musí v paměti vyhradí 32bitový prostor kam se uloží daná hodnota, ale u typů v F#
   se za "int" spíš považuje "množina všech intů".

   "string" se považuje za množinu všech stringů a "bool" za množinu všech boolů.

   potom "int * string * bool" vlastně znamená "všechny kombinace všech intů, všech stringů a všech boolů".
   Proto "*" protože to opravdu znamená násobení. Pokud chceme int zkombinovat se stringem, pak vlastně
   vznikne kombinace všech intů a všech stringů tím, že vynásobíme všechny inty všemi stringy.
*)

//Možné zápisy hodnoty do tuplu
let x1 = 5, "Nějaký řetězec", true                      //x1 je typu int * string * bool
let x2:IntAndStringAndBool = 5, "Nějaký řetězec", true  //x2 je typu IntAndStringAndBool...který kompiler jednoduše přepíše na int * string * bool
let x3 = (10, "asdf", true)                             //stejně jako x1 ale se závorkama

//Unionový typ
type UnionovýTypDvouČísel = 
    | PrvníČíslo of int    
    | DruhéČíslo of int

    // první znak | lze vynechat, tzn. validní zápis je i "type UnionovýTypDvouČísel = PrvníČíslo of int | DruhéČíslo of int"

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
let u4 = TypA                       //není nutné zapisovat UnionovýTypBezPodtypů
let u5 = UnionovýTypBezPodtypů.TypA //

//Enum
type Barvy = Červená = 1 | Zelená = 2
//Rozdíl mezi unionem a enumem v F# je, že u enumu je nutné všude přiřadit hodnoty.

//Při přiřazení do enumu je nutné uvést i název enumu "Barvy"
let e1 = Barvy.Červená



//recordový typ
type Záznam = {Email: string; EmailPotvrzen: bool}

//
type GenerickýTyp<'a> = 
    | ``První subtyp`` of 'a
    | ``Druhý subtyp`` of 'a * 'a

type User = {
    UserName: Option<string>;
    Email: string;    
}

//let, use, do

//use = using v c#
