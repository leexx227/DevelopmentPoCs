This contains some samples of Slurm:

## To run a simple job

Run 3 jobs on 3 nodes:
```
srun -N3 -l /bin/hostname
```

Run 3 jobs:
```
srun -n3 -l /bin/hostname
```

## To run batch job
First save the batch.slurm at /shared/home, which is the shared folder on the scheduler node.
```
sbatch -n3 /shared/home/batch.slurm
```

The output file will not be automatically sent back to the scheduler node or saved to the shared folder. The output will be stored on the **current** directory first node of the job allocated nodes. 

To check the output file:
```
srun -n3 -l ls
```
The output is like:
```
0: my.stdout
0: stderr-10.txt
0: stderr-13.txt
0: stdout-10.txt
```

To get the content:
```
srun -n1 -w "hpc-pg0-1" cat my.stdout
```

## To run job in an interactive way
```
salloc -N3 bash
srun -l cat /shared/home/result.out
exit
```