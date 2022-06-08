#!/bin/bash

#SBATCH -e stderr-%j.txt
#SBATCH -o stdout-%j.txt
sbcast test.py /tmp/test.py
srun python /tmp/test.py ${SLURM_JOB_NAME}+"-"+${SLURM_ARRAY_TASK_ID}