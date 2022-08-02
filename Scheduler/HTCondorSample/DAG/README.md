This is a simple of DAG. It's in a diamond shape. Each node in the DAG runs the same job defined in `subjob.sub`.

Usage:
```
condor_submit_dag diamond.dag
```

Monitoring:
```
condor_q -nobatch
```

To check compute node status:
```
condor_status
```

To check log:
```
vim diamond.dag.dagman.out
```