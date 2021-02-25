#!/bin/sh

echo "Creating file"
./make_dummy.sh

echo "Testing bash"
./move.sh

echo "Testing python"
python3 move.py

echo "Testing .NET"
cd ./dotnet
dotnet run dotnet
