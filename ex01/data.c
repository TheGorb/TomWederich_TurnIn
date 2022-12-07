#include "data.h"

// Takes in pointer to data and an amount of bytes that are in the data. It creates Data *d and allocates d->arr to the size of bytes and then copies the data from dat into d→arr.
Data *makeData(void *dat, int bytes)
{
    Data *newData = malloc(sizeof(Data));

    newData->arr = malloc(sizeof(bytes));
    memcpy(newData->arr, dat, bytes);
    newData->byteSize = bytes;
    return newData;
}

// Allocates a buffer with the exact size of the Data and then copies the data being pointed to by the Data struct into the buffer along with the size of the buffer. Returns a pointer to the buffer.
void *writeData(Data *d)
{
    void *buffer = malloc(sizeof(d->byteSize));
    memcpy(buffer, d->arr, d->byteSize);
    return buffer;
}

// Declares a Data struct. Reads from buffer created with the writeData function. First it reads size from the buffer (and copies it into the Data struct’s bytes field) so that it knows how much data is in the buffer. Then it reads that much data from the buffer and copies it into the Data struct’s arr field.
Data *readData(void *buffer)
{
    Data *newData = malloc(sizeof(Data));
    newData->byteSize = sizeof(buffer);
    newData->arr = malloc(sizeof(buffer));
    memcpy(newData->arr, buffer, newData->byteSize);
    return newData;
}

// Free the allocated array in d and also d itself.
void freeData(Data *d)
{
    free(d->arr);
    free(d);
}
