# Volcano Sample
This is a simple sample of [Volcano](https://volcano.sh/en/docs/). 

## Installation
To install Volcano, you need to first have an Kubernetes cluster with CRD (CustomResourceDefinition) supported. Then you need to install Volcano on the Kubernetes cluster.

### AKS Cluster Deployment
Deploy an AKS cluster on Azure with a Linux node pool.

### ACR to Store Docker Images
Create an ACR on Azure to store docker images.

### Install Volcano
Run the following command on AKS cluster to indtall Volcano.

```
kubectl apply -f https://raw.githubusercontent.com/volcano-sh/volcano/master/installer/volcano-development.yaml
```

## Build Docker Image
Run the following command to build and push docker image:

```
// build image
docker build -t <image_name> -f Dockerfile .
```
```
//push image to ACR
docker push <image_name>
```
Now you have the image in ACR that can be pulled.

## Create a Volcano Queue
Run the following command to create a Volcano queue named `test`.
```
kubectl apply -f queue.yaml
```

Check queue status:
```
kubectl get queue test -oyaml
```

## Create a Volcano Job
Run the following command to create a Volcano job named `job-1`. It has 1 task replica named `volcano-test-task` and a container named `volcano-test-container` in it. It only requires at least one task available.
```
kubectl apply -f job.yaml
```
To get concise job status:
```
kubectl get vcjob
```

Check full job status in yaml format:
```
kubectl get vcjob job-1 -oyaml
```

When creating a job without podgroup specified, Volcano will create a podgroud with the same name as job. To check podgroup status:
```
kubectl get podgroup job-1 -oyaml
```

## Others
You can also use Kubernetes command to check pod status and get logs.

To check pod status:
```
kubectl get pods
```

To get the last ten logs of the pod:
```
kubectl logs <full_pod_name> --tail=10
```