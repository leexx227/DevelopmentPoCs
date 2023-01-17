# Benchmark End-to-end Slurm Performance
## Slurm configuration
In order to avoid creating large scale of nodes, we can use Slurm [OverSubscribe](https://slurm.schedmd.com/slurm.conf.html#OPT_OverSubscribe) feature to execute multiple jobs at a time on one node. Go to `/sched` and edit the `slurm.conf` file as follow:
```
#Include cyclecloud.conf
PartitionName=hpc OverSubscribe=FORCE:100 Nodes=hpc-pg0-[1-10] Default=YES DefMemPerCPU=1 MaxTime=INFINITE State=UP
Nodename=hpc-pg0-[1-10] Feature=cloud STATE=CLOUD CPUs=2 ThreadsPerCore=2 RealMemory=15360
```
1. Comment out `Include cyclecloud.conf`.
2. Copy the partition and node configuration from `cyclecloud.conf`, which means we need to maintain the partition and nodes by ourselves. Cyclecloud will still update `cyclecloud.conf` but that makes no effect.
3. Add `OverSubscribe=FORCE:100` to allow 100 jobs running at a time and change `DefMemPerCPU` to `DefMemPerCPU=1` for safety.
4. Run following commands to make changes taking affect.
```
hpcadmin@ip-0A020006:/sched$ sudo -i
root@ip-0A020006:~# cd ..
root@ip-0A020006:~# cd /opt/cycle/slurm
root@ip-0A020006:/opt/cycle/slurm#
root@ip-0A020006:/opt/cycle/slurm# ./cyclecloud_slurm.sh remove_nodes
root@ip-0A020006:/opt/cycle/slurm# ./cyclecloud_slurm.sh scale
root@ip-0A020006:/opt/cycle/slurm# scontrol reconfigure
```

## Run benchmark script
Submit job array from `/shared/home/<user>` which will submit 500 jobs with 2 tasks in one job (1000 tasks in total).
```
sbatch batch.slurm
```
To calculate the result, run
```
bash calculate.sh <job_name>
```
where you can get the `<job_name>` when you submitting job array.