# Star Files

## Overview
Star Files is an application that writes a file on disk for each star you are creating.

There are two types of stars:

- Simple Stars
- Binary Stars.

The Binary Stars in astronomy are systems of two stars orbiting one around the other, therefore two files on disk.

All the stars are added into a Universe.

## The Problem
The owner of this application discovered that the generated files cannot be accessed while the application is running. We discovered there is a problem of memory leak. The file handlers are not released when they should be.

## Win API calls

We must tell you that, in this application, there are calls to low level Win API functions to open the files. These calls use pointers (unmanaged resources) and are, indeed, harder to manage than high level functions from the .NET framework, but we do not want to change that right now. We need only to ensure that the resources, both unmanaged and managed, are correctly released (as soon as they are not needed anymore).

## Requirement

Your job is to ensure that the resources are released correctly. Probably Disposable Pattern can help here.

## Hints
There are two projects in the solution:
- `StarFiles.WinApi`
  - Contains the signatures for the Win API functions.
  - No need to change this project.
- `StarFiles`
  - Here are the classes that fail to release the resources.
  - Take a look into `WinApiFile`, `SimpleStar`, `BinaryStar`, `Universe` classes. You need to implement the `IDisposable` interface. But, can you do it correctly?
