#!/usr/bin/python
import time
import sys

process = sys.argv[1]
print("Process {0} sleep...".format(process))
time.sleep(10)
print("Process {0} awake...".format(process))