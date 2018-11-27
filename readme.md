# API

Due to the lack of time, do not implemented the real function of sending email in the api part.
Just created an abstraction and 2 fake implementations.

For failover, a simple switch function is implemented in the provider factory, if the main provider cannot work properly, the backup can start to work for at least 1 mins.

# UI
The UI is implemented by Angular and NgRx.

# Test
There are some unit tests in both of UI and Backend to make sure the key feature is working well.