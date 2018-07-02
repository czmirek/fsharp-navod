module Typy_Tuple

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