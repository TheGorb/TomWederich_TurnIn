#include "server.h"

// Init server struct, clientsSocks init to size of max clients
// timeval can be set to 0
// Socket init with FD from creating socket
int newSocket;
Server *setUpServerConnection()
{
    Server *newServer = malloc(sizeof(Server));

    newServer->maxClients = 10;
    newServer->clientSocks = malloc(sizeof(int) * newServer->maxClients);
    newServer->clientSocks[0] = NULL;
    newServer->tv.tv_sec = 0;
    newServer->tv.tv_usec = 0;
    newServer->sock = socket(AF_INET, SOCK_STREAM, 0);

    if (newServer->sock < 0)
    {
        printf("Socket creation error\n");
        return NULL;
    }
    if (newServer->maxClients < 10)
    {
        printf("Number of max client should be greeter than 10\n");
        return NULL;
    }

    newServer->addr.sin_family = AF_INET;
    newServer->addr.sin_addr.s_addr = htonl(INADDR_ANY);
    newServer->addr.sin_port = htons(8080);

    if (bind(newServer->sock, (struct sockaddr *)&newServer->addr, sizeof(newServer->addr)))
    {
        printf("Bind error\n");
        return NULL;
    }
    if (listen(newServer->sock, newServer->maxClients))
    {
        printf("Listen error\n");
        return NULL;
    }

    int flags = fcntl(newServer->sock, F_GETFL);
    fcntl(newServer->sock, F_SETFL, flags | O_NONBLOCK);
    struct sockaddr_in addr;
    printf("Listening for incoming connection");
    return (newServer);
}

void closeServer(Server *s)
{
    close(s->sock);
    free(s);
}

void serverSendReceive(Server *s, void *buffer, int *gotData)
{

}
