//Authors: Stirling Carter and Hunter Manhart
//Date: 12/1/2017

module sudoku

open System
open System.IO
open System.Collections

Console.Write("Enter the name of your file: ")

// Read user input
let testFile = Console.ReadLine()

let sr = new StreamReader(testFile)

let mutable puzzle = []
for i in 1 .. 9 do
    let mutable row = []
    for n in 1 .. 9 do
        row <- (sr.ReadLine()) :: row
    puzzle <- row :: puzzle
    ()


puzzle <- puzzle |> List.map List.rev

