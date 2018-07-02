module Typy_Enum

//Enum
type Barvy = Červená = 1 | Zelená = 2
//Rozdíl mezi unionem a enumem v F# je, že u enumu je nutné všude přiřadit hodnoty.

//Při přiřazení do enumu je nutné uvést i název enumu "Barvy"
let e1 = Barvy.Červená
//let e2 = Červená      //toto nefunguje