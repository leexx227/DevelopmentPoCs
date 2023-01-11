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
When logging in to slurm scheduler node, you're at `/shard/home/<user>` which is the shared foler. Seems you must run `sbatch` command here and the job will run correctly. If you run the command under other path, the job can't run as expected and the output files are lost.

First save the batch.slurm at `/shared/home/<user>` and run:
```
sbatch -n3 /shared/home/batch.slurm
```

The output file will not be automatically saved at the **current** directory. As it's shared folder, you can just view the output on scheduler node. 
```
ls
```
The output is like
```
batch.slurm stderr-13.txt
```

To check the output file on the compute node:
```
srun -n3 -l ls
```
The output is like:
```
0: batch.slurm
0: stderr-13.txt
```

To get the content:
```
srun -n1 -w "hpc-pg0-1" cat stderr-13.txt
```

## To run job in an interactive way
```
salloc -N3 bash
srun -l cat /shared/home/result.txt
exit
```