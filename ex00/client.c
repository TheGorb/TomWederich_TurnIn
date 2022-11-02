#include "client.h"

// Init client struct & sock will be FD from AF_INET type SOCK_STREAM,
// timeval set to 0
// sockaddr_in will be ip address type AF_INET
Client *connectAsClient(char *ip)
{
	Client *newClient = malloc(sizeof(Client));
	struct sockaddr_in servAddr = {0};
	char buffer[1024] = {0};
	int valread;

	newClient->sock = socket(AF_INET, SOCK_STREAM, 0);

	if (newClient->sock < 0)
	{
		printf("Socket creation error\n");
		return (NULL);
	}

	servAddr.sin_addr.s_addr = inet_addr(ip);
	servAddr.sin_family = AF_INET;
	servAddr.sin_port = htons(8080);

	newClient->tv.tv_sec = 0;
	newClient->tv.tv_usec = 0;

	if (connect(newClient->sock, (struct sockaddr *)&servAddr, sizeof(servAddr)) < 0)
	{
		printf("Connection Failed");
		return NULL;
	}
	write(newClient->sock, &recv, sizeof(int));

	printf("Sucessfully conected with server\n");
	return (newClient);
}

// Check if there is data to read if so return the size of the data
//-1 if error
int receiveData(Client *c, void *buffer)
{
	int clientSocket = 0;
	clientSocket = accept(c->sock, NULL, NULL);
	if (clientSocket > 0)
	{
		if (recv(c->sock, buffer, 1024, 0))
		{
			printf("RETIRN %d\n", sizeof(buffer));
			return sizeof(buffer);
		}
	}
	return 0;
}