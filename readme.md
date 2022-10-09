# uid

This is the repo for my FOSS, Uid!

- [uid](#uid)
  - [What does it do?](#what-does-it-do)
    - [How it works](#how-it-works)
  - [Contributing](#contributing)
    - [Requirements](#requirements)
    - [Building](#building)
  - [Installation](#installation)


## What does it do?

`uid`, is a program I wrote, that generates a random string of hexadecimal characters.
With just running it, You get a 64 character random string, which is the current unix timestamp, encrypted using AES encryption.
If you pass a string as an argument to `uid`, It'll encrypt that string. It's not gauranteed to be 64 characters then.

I also added an alternate method for generating an ID, By passing the `-v2` or `-v2q` argument. It'll encrypt a 16 character long string, containing the letters between A-Z and numbers between 0-9. It'll generate a 64 character long uid, just with a different input.

You may also pass the `-q` or `-v2q` argument to make it only print out the ID and not the input to the encryption.

For more info on arguments, run `uid -help`.

### How it works

It uses AES encryption to encrypt a string.
By default, without any arguments, it uses the current unix timestamp.
If you choose to run `uid` with the `-v2` flag, it'll encrypt a random string of 16 random ASCII characters.

## Contributing

Simply fork the repo and make a pull request. If I can understand the code, and it's an improvement over what's currently in UID, I'll merge it into the master branch.

### Requirements

You need to have `dotnet-sdk 6.0` installed,
and `bash` (bash has to be at `/usr/bin/bash` for the scripts to work without tinkering.) , only if you want to run the scripts to build/clean your local environment.

With `dotnet-sdk 6.0` and `bash` installed, you're ready to build `uid`!

### Building

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
