#!/usr/bin/python
import time
import sys

process = sys.argv[1]

print("[{0}] DAG node {1} sleep...".format(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()), process))
time.sleep(40)
print("[{0}] DAG node {1} awake...".format(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()),process))