# QuickREST

Simple C#.NET code for integrating consumption of RESTful services.

Reference QuickRESTbase.dll and QuickRESTdata.dll in your project to use.  You'll need to create a bridge library to tie the base stuff into your project.  Example code of this is seen in the QuickRESTexamplelib project.  The QuickRESTexample project is a Winforms demonstration using a public REST service to show you how it works.  You will need to use the Newtonsoft JSON Nuget package in Visual Studio.

I wrote this bit to make things a little simpler for implementing many different RESTful services at once.  They can all be called using easy to remember and descriptive text.  Using the lambda expressions to dynamically assign arguments and polymorphism makes it pretty versatile.

**Here are some instructions for you to follow.**

1. First, create a class that inherits APIData, and override and define the root_api_url string inherted from APIData

2. You'll need to create a constructor for this class that takes a string as an argument, and assigns it to the _APIuri class member variable.  Here is an example of what it looks like:
   
       public ExampleAPIData(string uri)
       {            
           _APIuri = uri;
           _APIResult = null;
       }
3. Next, you'll want to override JObject makeRESTrequest from APIData to contain the code that actually sends the request and receives the response.  I suggest returning the JObject even if you only want a small part as it'll make things consistent across multiple URIs.
4. Then, in another class that inherits from the RESTfulClientBase, define a newChildObject delegate to use the new inherited APIData's constructor that passes the string in as an argument.
5. You'll also want to override initializeAPIdict to add to the dictionary of APIData.  The Keys of this dictionary are how the APIs are accessed.  You'll never need to mess with the URI again once they are added in here.  Place them in such a way that they can be modified with String.Format.  You'll need to pass your newChildObject delegate in as an argument.  Dictionary is allowed to be speficied in case you wished to have multiple APIData dictionaries for some reason, otherwise, this should probably just use the inherited apiInformation dictionary passed in from the Constructor.
6. You're almost done, all you have to do is create a new object of your RESTfulClientBase child, put together a uriArgs delegate function to format the URLs using String.Format, and call obtainAPIresults.  This will return a bool letting you know if it worked or not.
7. If it worked, simply access the appropriate APIData (use the Key) APIResult property to get your JSON response, parse it however you'd like.
8. Many RESTful services require you to authenticate with them.  You will have to get instructions on how to get passed their security from them if you wish to use them.
