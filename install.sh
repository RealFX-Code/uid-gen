#!/usr/bin/bash

installPath=/usr/local/bin/uid

echo -e "!! THIS SCRIPT WILL ASK FOR SUDO PERMISSIONS, GIVE IT OR THE SCRIPT WILL ERROR OUT."


if [[ -L "$installPath" ]]; then
    echo "You've installed UID with a symlink, Do you want me to remove it? (y/N)"
    read yesOrNo1
    if [ -z $yesOrNo1 ];
    then
        echo -e "No input given, You've succesfully bailed out!"
        exit 1
    fi
    if [[ "$yesOrNo1" == "n" ]]; then
        echo -e "You'v'e chose not to. You've succesfully bailed out."
        exit 1
    fi
    if [[ "$yesOrNo1" == "y" ]]; then
        echo -e "OK. Removing UID..."
        sudo unlink "$installPath"
    fi
fi


if [ -f "$FILE" ]; then
    echo -e "UID already exists! Want me to remove UID and install UID again? (y/N)"
    read yesOrNo
    if [ -z $yesOrNo ];
    then
        echo -e "No input given, You've succesfully bailed out!"
        exit 1
    fi
    if [[ "$yesOrNo" == "n" ]]; then
        echo -e "You'v'e chose not to. You've succesfully bailed out."
        exit 1
    fi
    if [[ "$yesOrNo" == "y" ]]; then
        echo -e "OK. Removing UID..."
        sudo rm "$installPath"
    fi
fi

echo -e "Building UID..."
source ./publish.sh

echo -e "installing linux-x64 binary to path..."
sudo cp "./publish/linux-x64/uid" "/usr/local/bin/uid"

echo -e "UID installed!"