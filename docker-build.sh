docker build --rm -t local/hosted-blazor-app .
docker system prune -f
docker images 'local/hosted-blazor-app'