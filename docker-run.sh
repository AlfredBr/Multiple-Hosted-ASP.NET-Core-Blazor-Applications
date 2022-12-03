docker kill `docker ps -f name="blazor-host" -q` > /dev/null 2>&1
docker run \
	--rm \
	-d \
	--name "blazor-host" \
	-p 7000:7000 \
	-p 7001:7001 \
	-p 7002:7002 \
	-p 7003:7003 \
	-p 7004:7004 \
	-e ASPNETCORE_ENVIRONMENT="Development" \
	-e ASPNETCORE_HOSTNAME="funkyhost" \
	-e ASPNETCORE_URLS="http://*:7000;http://*:7001;http://*:7002;http://*:7003;http://*:7004" \
	local/hosted-blazor-app
