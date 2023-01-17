# Benchmark End-to-end HTCondor Performance
# HTCondor configuration
1. Disable autoscale
2. Install cyclecloud CLI and run
```
cyclecloud add_node <HTCondor_cluster_name> -t execute -c 32
```
to create 32 compute nodes.

# Run benchmark script
Submit job frorm `/mnt/exports/shared/home/<user>` (which is the default path when ssh to scheduler node), which will queue 1024 jobs (tasks in Batch concept).
```
condor_submit job.sub
```
This will get output files for each job and a log file `condor-$(Cluster).log` for the cluster. This log file stores the start time and completion time for each single job, which will help to calculate the benchmark result. To get the performance result, run:
```
bash calculate.sh <cluster_name>
```
where you can get the `<cluster_name>` when submitting job script to HTCondor.