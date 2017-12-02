(*
Names: Hunter Manhart & Stirling Carter
Emails: Hunter.M.Manhart@vanderbilt.edu 
VUnetIDs: manharhm & cartersh1
Class: Programming Languages
Date: 12/1/2017
Honor Statement: We have neither given nor received unauthorized aid on this assignment
*)


module sudoku

//We need to specify environment for Console, Stream
open System
open System.IO
open System.Collections


//ask for user input

(*    Global Variabls   *)  
let boxSize = 3
let boardSize = 9



Console.Write("Enter the name of your file: ")

//Receive user input
let testFile = Console.ReadLine()

//create a stream to read an input file
let sr = new StreamReader(testFile)

//we will want to edit this in the future, hence mutable
let mutable puzzle = []
//read in from stream
for i in 1 .. boardSize do
    let mutable row = []
    for n in 1 .. boardSize do
        row <- (sr.ReadLine()) :: row
    puzzle <- row :: puzzle
    ()


puzzle <- puzzle |> List.map List.rev

let board = array2D [| 
  [|0; 4; 3; 0; 8; 0; 2; 5; 0|];
  [|6; 0; 0; 0; 0; 0; 0; 0; 0|];
  [|0; 0; 0; 0; 0; 1; 0; 9; 4|];
  [|9; 0; 0; 0; 0; 4; 0; 7; 0|];
  [|0; 0; 0; 6; 0; 8; 0; 0; 0|];
  [|0; 1; 0; 2; 0; 0; 0; 0; 3|];
  [|8; 2; 0; 5; 0; 0; 0; 0; 0|];
  [|0; 0; 0; 0; 0; 0; 0; 0; 5|];
  [|0; 3; 4; 0; 9; 0; 7; 1; 0|]
  |]

(*    Get Available Options at a Square   *)
let canPlace (r: int) (c: int) (board: int[,]) =
  // list of options
  let options = [| 1..boardSize |]
  
  // mark taken 
  let markTaken (i: int) =
    if i > 0 && i <= boardSize then
      options.[i-1] <- 0
  
  // check row
  board.[r, *] |> Array.map markTaken |> ignore
  
  // check col
  //board |> Array.map (fun row -> row.[c])
  board.[*, c] |> Array.map markTaken |> ignore
  
  // check box
  let rStart = r - (r % boxSize)
  let cStart = c - (c % boxSize)
  board.[rStart..(rStart + boxSize - 1), cStart..(cStart + boxSize - 1)] 
    |> Array2D.map markTaken |> ignore
  
  options |> Array.filter (fun i -> i <> 0)
  
(*    Attempt to Place Option at Square   *)
let rec place (r: int) (c: int) (board: int[,]) =
  // Past row limit, so new column
  if r >= boardSize then
    place 0 (c + 1) board

  // Out of columns and all's good, so solved
  elif c >= boardSize then 
    true

  // Already a number here, move on
  elif board.[r,c] <> 0 then 
    place (r + 1) c board
  
  // Get options and try them
  else
    // Get options, via canPlace, and ormap it, via fold
    (canPlace r c board) |> Array.fold 
      (fun acc elm -> 
        // true means we solved it, so pop up
        if acc then
          true
        
        // else keep trying
        else
          board.[r, c] <- elm
          // try to recurse to next box
          if (place (r + 1) c board) then
            true
          else
            // had to do an if-else to reset to 0 on false
            board.[r, c] <- 0
            false
      ) false
      // Returns true if solved, false if ran out of options


(*    Solve through Recursive Backtracking    *)
let solve (board: int[,]) =
  if (place 0 0 board)
    then printfn "%A" board
    else printfn "Board is infeasible"


// Call solve on board
solve board
