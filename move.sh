#!/bin/bash

START_TIME=$(date +%s%3N)
mv ./non-nfs-mount/testfile ./nfs-mount/testfile
END_TIME=$(date +%s%3N)
ELAPSED_TIME=$(($END_TIME - $START_TIME))

echo "From local to NFS: $ELAPSED_TIME"

START_TIME=$(date +%s%3N)
mv ./nfs-mount/testfile ./non-nfs-mount/testfile
END_TIME=$(date +%s%3N)
ELAPSED_TIME=$(($END_TIME - $START_TIME))

echo "From NFS to local: $ELAPSED_TIME";
