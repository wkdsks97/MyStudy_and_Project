The Hermes Standard test driver Version 1.0.1.0 implements
The Hermes Standard Version 1.0, revision 1.

It simulates either an upstream or a downstream partner, and since you can run several instances of it, you can in fact simulate both upstream and downstream and even several lanes .
Please note, however, that the simulation is an ongoing development and  not production code. More specifically:
-        It has not been rigorously tested
-        We assume no responsibility whatsoever for any damage it might cause.
-        It is (yet) only capable of a manual mode in which the user selects The Hermes Standard commands she/he wants to send. Responses are only displayed in a message window
-        There is no documentation
 
However, you are still getting something valuable, free of charge, which you may also distribute.
-        Is has the same implementation of The Hermes Standard at its core that we use for our Siplace Machines. 
-        Running your software with our simulation is pretty much similar to running it with our real machine.
-        Usage is straightforward
-        Simple copy deployment
-        The incoming messages are checked for the correct state and syntax
 
So while we cannot promise a speedy reaction on any queries you have or bugs you find, we would still very much appreciate your feedback, which will eventually speed up the integration process between equipments!
By the way, even if your implementation of The Hermes Standard is not yet complete, you can get an initial feeling of our simulation and the potential value it provides by running it against itself, i.e. by starting an upstream and a downstream instance.
 
Quick user guide:
-        Unzip into some directory
-        Run HermesTestDriver.exe
-        Select UpstreamSimuation or DownstreamSimulation
-        Configure (for an initial test on a single PC, the default settings should work well enough)
o   MachineId (as sent in the ServiceDescription message)
o   Port number
o   Host address
o   Level of state check
o   CheckAlive period
-        Run it with the green arrow botton on the top right
-        Wait until connection is established
-        Choose any of the actions and populate the required and the desired optional data fields
-        Execute the action
 
You can observe:
The simulation displaying its state
The incoming and outgoing messages (left and right arrow)
Traces, infos, warnings and errors emitted by our implementation

The settings (position on screen, ports, etc.) will be persisted in the registry at
HKEY_CURRENT_USER\Software\ASM AS\HermesTestDriver.
Delete this entry if you want to reset to default or totally remove the test driver from your system.
 
Feedback to leif.reichert@asmpt.com
 
Enjoy!
