#!/bin/bash
# parameter: $1=jobname
start=$(grep begin slurm-$1* | awk '{print $3}' | sort -n | head -n1)
end=$(grep end slurm-$1* | awk '{print $3}' | sort -n -r | head -n1)
echo "start: $start"
echo "end: $end"
duration=$((($end - $start)/1000000))
echo "duration: $duration ms"
throughput=$(printf "%.5f" `echo "scale=5;1000/$duration*1000"|bc`)
echo "throughput: $throughput msg/s"