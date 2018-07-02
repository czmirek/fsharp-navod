module Funkce_zaklad

//definice funkce
let přičtiJedničku číslo = číslo + 1
let čísloŠest = přičtiJedničku 5
(* 
    Parametry funkce na vstupu se udávají oddělené MEZEROU!

    Většinu času není vůbec nutné uvádět typy, F# je zjistí sám.
    Jednou zjištěný typ ale nelze přeměnit tzn. jakmile kompiler zjistí,
    že daná hodnota by měla být int, potom úplně všude počítá s tím,
    že daná hodnota je int a pokud se s tím někde pracuje nějak jinak,
    vyhodí to chybu kompilace.

    F# v tomto ohledu nefunguje jako PHP nebo Javascript, kde lze jedné proměnné
    házet hodnoty různých typů sem tam a je to úplně jedno.
*)

let sečtiČísla sčítanec1 sčítanec2 = sčítanec1 + sčítanec2
(* 
    sečtiČísla má na vstupu dva parametry: sčitatel a sčítanec a vrací to jednu hodnotu.
    
    POZOR 1: kód "let sečtiČísla sčítanec1,sčítanec2" znamená v F# něco ÚPLNĚ JINÉHO!!
                                         /
                                        /
                                   čárka

    POZOR 2: --- NÁSLEDUJÍCÍ INFORMACE JE EXTRÉMNĚ DŮLEŽITÁ! 

    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    !!!! V F# mají VŠECHNY funkce JEDEN vstup a JEDEN výstup !!!!
    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    Funkce sečtiČísla totiž kompiler přeloží takto 
    
    V pseudo-kódu:
    --------------------

        funkce sečtiČísla(int sčítanec1) 
        {
            var fce2 = vnitříFunkce(int sčítanec2) 
            {
                return sčítanec1 + sčítanec2;
            }
            return fce2();
        }

    V F# kódu 
    --------------------

        let sečtiČísla čitatel = 
            let vnitřníFunkce sčítanec = čitatel + sčítanec
            sečtiČísla1

    Co to znamená? Kompiler vytvořil funkci sečtiČísla, která na vstupu bere 
    první parametr. V kontextu této funkce vytvořil další vnitřní funkci, která
    na vstupu bere druhý parametr. V těle této dvě funkce teprve sečte hodnotu
    čitatel a sčítanec, protože to je všechno v kontextu funkce "sečtiČísla".
*)