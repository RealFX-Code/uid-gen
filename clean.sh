#!/usr/bin/bash

echo -e "Warning! This script will clean all binary files from this project!"

echo -e "Are you sure you want to continut? (y/n)"
read yesOrNo

if [ -z $yesOrNo ];
then
    echo -e "No input given, You've succesfully bailed out!"
    exit 1
fi

if [[ "$yesOrNo" == "y" ]]
then
    echo -e "You've chose to clean build files..."
    rm -R .vs
    rm -R UniqueIdentifier-gen/bin
    rm -R UniqueIdentifier-gen/obj
    exit 0
fi

if [[ "$yesOrNo" == "n" ]]; then
    echo -e "You'v'e chose not to. You've succesfully bailed out."
    exit 1
fi

echo -e "Invalid answer."