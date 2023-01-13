#!/bin/bash

#SBATCH --nodes=1
#SBATCH --ntasks=2
#SBATCH --array=0-499

begin_time=$(date +%s%N)
echo "begin at $begin_time"
srun /bin/sleep 0
end_time=$(date +%s%N)
echo "end at $end_time"