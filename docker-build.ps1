#docker rmi -f $(docker images 'local/hosted-blazor-app' -q) 2>&1 | Out-Null
docker build --rm -t local/hosted-blazor-app .
docker system prune -f
docker images 'local/hosted-blazor-app'