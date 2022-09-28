#!/usr/bin/bash

echo -e "Building for linux..."
dotnet publish -r linux-x64 -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true --self-contained true

echo -e "building for windows..."
dotnet publish -r win-x64 -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true --self-contained true

echo -e "fixing publish directory..."
echo -e "Creating directory publish"
mkdir publish
echo -e "Creating directory publish/win-x64"
mkdir publish/win-x64
echo -e "Creating directory publish/linux-x64"
mkdir publish/linux-x64
echo -e "Copying linux binary..."
cp "./bin/Debug/net6.0/linux-x64/publish/UniqueIdentifier-gen" "./publish/linux-x64/uid"
echo -e "Copying windows binary..."
cp "./bin/Debug/net6.0/win-x64/publish/UniqueIdentifier-gen.exe" "./publish/win-x64/uid.exe"
echo -e "Copying linux debug symbols..."
cp "./bin/Debug/net6.0/linux-x64/publish/UniqueIdentifier-gen.pdb" "./publish/linux-x64/uid.pdb"
echo -e "Copying windows debug symbols..."
cp "./bin/Debug/net6.0/win-x64/publish/UniqueIdentifier-gen.pdb" "./publish/win-x64/uid.pdb"

echo -e "\n\tPublished UID!"
exit 0
