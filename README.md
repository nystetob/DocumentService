# DocumentService

## Getting started
If you wish to run the Microservice, you can use the following commands after installing Docker Desktop:

```bash
docker build -t documentservice .
```

```bash
docker run -dp 3000:80 documentservice
```

Once it has started, you can open your browser to http://localhost:3000/swagger/index.html

## Docker package
Docker image can be pulled from Docker hub with:

```bash
docker pull nystetob/documentservice
```
