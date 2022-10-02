# Sample Micro-Applications and Micro-Services

## Setup Development Environment

### Prerequisite

1. Docker Desktop
2. k3d
3. Git for Windows
4. <strong>IDE</strong>: Visual Studio Code, Visual Studio Community
5.

### Configure

1. Initialize local Kubternetes cluster using below command

```powershell
k3d cluster create dev --port 8080:80@loadbalancer --port 8443:443@loadbalancer --api-port 6443 --servers 1 --agents 2 --registry-create registry.localhost:0.0.0.0:5000

skaffold config set default-repo registry.local
```

```powershell-interactive
helm dependency update ./k8s
```

## In this What we will get to know

- [x] Swager
- [x] Versioning

  - https://github.com/dotnet/aspnet-api-versioning

- [ ] Model Versioning using oData
  - https://www.bytefish.de/blog/aspnet_core_odata_example.html
  -
- [ ] Caching (Redis)
  - https://duongnt.com/stackexchangeredis
- [x] Logging (Serilog)
- [ ] grpc Services
- [ ] Transactional Sanity and Concurrency
- [ ] Distributed Transactions (MongoDb, CouchDb or Redis)
  - [ ] SAGA (massTransit)

### Frontend:

Basic Angular application that will implement cart system.

### Backend:

1. Security Service (OpenID)
   1. KeyCloak
   1. Okta
1.
1. Transaction Service (Exposed)
   1. Calculator Core Service (<strong>FAAS</strong>)
   1. Transaction Validation Service (<strong>FAAS</strong>)
   1. Transaction Finalize Service (<strong>FAAS</strong>)
      1. Credit Card 3rd Party
1. Product Service (Exposed)
1. Search Service (Exposed)
   1. ElasticSearch
   1. Data Exchange

### Observability

1. Prometheus
1. Grafana
1. Kiali
1. Jaeger/ZipKin

## Service Mesh

Istio
