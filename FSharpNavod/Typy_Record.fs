module Typy_Record

//recordový typ
type Uživatel = {Jméno:string;Příjmení:string}
let uživatel1 = { Jméno = "Karel"; Příjmení = "Varel"; }

type User = {
    UserName: Option<string>;
    Email: string;    
}
