#include "inputThread.h"

// return true if your computer is little endian and false if it is big endian.
bool littleEndian()
{
    unsigned int i = 1;
    char *c = (char *)&i;
    if (*c)
        return (true);
    return (false);
}

// Receives a shared buffer with a pthread_mutex_t stored in it.  Pull the pthread_mutex_t out and store it. Test your code to make sure that this lock is properly connected to the pthread_mutex_t being used in main.
// buffer is shared between this thread and the main thread. In a loop have this function take in user input and stores it in a buffer, when the user hits enter take in the string from the input buffer and copy it into the shared buffer via a Data struct. The main thread should then pick up that there is data in the buffer, and unpack it to display the string the user typed in.
// If the user hits the escape key have the program end. Hint take in the user input charavter at a time, rather than line by line.
void *inputThread(void *buffer)
{
    printf("AGA");
    pthread_mutex_t lock;
    memcpy(&lock, buffer, sizeof(pthread_mutex_t));
    pthread_mutex_lock(&lock);
    return NULL;
}
