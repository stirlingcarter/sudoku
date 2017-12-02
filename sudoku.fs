//Authors: Stirling Carter and Hunter Manhart
//Date: 12/1/2017

module sudoku

//We need to specify environment for Console, Stream
open System
open System.IO
open System.Collections

//ask for user input
Console.Write("Enter the name of your file: ")

//Receive user input
let testFile = Console.ReadLine()

//create a stream to read an input file
let sr = new StreamReader(testFile)

//we will want to edit this in the future, hence mutable
let mutable puzzle = []
//read in from stream
for i in 1 .. 9 do
    let mutable row = []
    for n in 1 .. 9 do
        row <- (sr.ReadLine()) :: row
    puzzle <- row :: puzzle
    ()


puzzle <- puzzle |> List.map List.rev

