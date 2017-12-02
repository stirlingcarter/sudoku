# A sudoku solver written in F#

##### Authors: Stirling Carter, Hunter Manhart 

## Usage Guidelines:

###### Put a .txt file in a working directory with the sudoku.fs. The text file should contain 9 rows of numbers, each row consisting of 9 numbers separated by a space. 

### OSX instructions:

#### install [mono](http://www.mono-project.com):

```
brew install mono
```

#### then compile and run as follows:

```
fsharpc sudoku.fs
mono sudoku.exe
```


### Windows instructions, using VSCode:

See the fsharp [website](http://fsharp.org/use/windows/)

Install via Visual Studio 2017 Build Tools

Add C:\Program Files (x86)\Microsoft SDKs\F#\4.1\Framework\v4.0\ to PATH

#### then compile as follows:

```
fsc ./sudoku.fs
./sudoku.exe
```

