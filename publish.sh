#!/usr/bin/bash

cd UniqueIdentifier-gen
./publish.sh
cd ..
cp -R ./UniqueIdentifier-gen/publish ./
rm -R ./UniqueIdentifier-gen/publish
