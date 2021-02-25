import time
import os
import shutil

start_time = time.time()
shutil.move("./non-nfs-mount/testfile", "./nfs-mount/testfile")
end_time = time.time()

elapsed_time = (end_time - start_time) * 1000
print("From local to NFS: ", elapsed_time)

start_time = time.time()
shutil.move("./nfs-mount/testfile", "./non-nfs-mount/testfile")
end_time = time.time()

elapsed_time = (end_time - start_time) * 1000
print("From NFS to local: ", elapsed_time)
