CommandLine and Mediatr Reference App
==============================

Just a simple app to demonstrate using Mediatr to wire up the options returned 
by CommandLineParser. Just write your verbs as usual, but apply the IRequest
interface to them. Create a class that implements RequestHandler<YourVerb> and
mediatr will take care of the rest. 