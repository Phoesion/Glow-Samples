# System Tests

These samples demonstrate how to perform system test on a service.

System test will initialize and run the service in reactor, as if it was run with visual studio or deployed to a glow cloud.
Each service will **run in a separate process**, as they normally would in production. If debugger is available the processes will be attached to visual studio debugger.
This mean everything the service does or needs, eg. filesystem, databases, brokers, etc. must be available and **will be used/modified by service during the testing.**
If you what to use *mocks and fakes* to test a single action without any other components/dependencies, then have a look in the **UnitTest** directory.





