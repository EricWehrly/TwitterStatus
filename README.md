﻿# Twitter Server Status Tool

## Building and Debugging

### Option 1: Visual Studio
Install [Visual Studio](https://visualstudio.microsoft.com/downloads/) (Community will work) and use File -> Open to open the solution.

With the project open, press "Start" in the standard toolbar to run it in debug mode.

Or use the "Build" option from the main menu to build the solution, which will produce the executable and required dlls into the "bin/Debug" folder.

TODO: Add instructions for building with Docker / CI tool.

---
Assumptions are documented in line in the application, except for the following:

Assume app is meant to ship with an initial server.txt.
Assume the client will populate server.txt with all intended hostnames.
