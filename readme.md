##uid `--Source`

This is the repo for my FOSS, Uid!

This is written in, and requires `.NET6.0`.
I won't go into detail on how to install dotnet here, since it's not too easy unless you're on windows.

## Contributing

Simply fork the repo and make a pull request. If I can understand the code, and it's an improvement over what's currently in UID, I'll merge it into the main branch.

## Building

I don't use Visual Studio, So I don't know if the `.sln` project file still works, since I've edited the `.csproj` file without using Visual Studio.

Simply run `dotnet build ./UniqueIdentifier-gen.csproj`

Or, To build Release binaries for Linux and Windows, I've written a script (`publish.sh`) that'll build and expose built binaries.

To clean binary files, run the script, `./clean.sh`.

## Installation

I currently don't have a good way to install this.

How I did it:

```
1, Make a script that opens the UID binary placed somewhere accesible.
2, Symlink that script to somewhere in path (E.G. /usr/local/bin)
3, Run `uid -help` to verify.
```

rlfx (c) 2022
