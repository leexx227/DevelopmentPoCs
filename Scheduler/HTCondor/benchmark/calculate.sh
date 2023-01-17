#!/bin/bash
# parameter: $1=clustername

start=$(condor_history -userlog condor-$1.log --long | grep JobCurrentStartDate | awk '{print $3}' | sort -n | head -n1)end=$(condor_history -userlog condor-$1.log --long | grep CompletionDate| awk '{print $3}' | sort -n -r | head -n1)
echo "start: $start"
echo "end: $end"
duration=$(($end - $start))
echo "duration: $duration s"
throughput=$(printf "%.5f" `echo "scale=5;1024/$duration"|bc`)
echo "throughput: $throughput msg/s"