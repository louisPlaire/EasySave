# EasySave
Easy Save is a C# library initially made for the Unity Engine, it can be used for other purposes like in desktop applications.


## How to use it ?
There is the visual studio documentation explaining what each function and method do but here is 
an exemple to make it easier to understand:

```
  // variable declaration
  int integer = 15;
  int newInteger = 0;
  
  DataBase myDataBase = new DataBase("dataBaseName", "C:\PATH"); // create a new database which name is 
                                                                 // "dataBaseName" and which has a path
  
  // saving data
  myDataBase.Save("variableName", integer); // save the variable integer in the database 
                                            // with a name which is the key to find 
                                            // the value of it in de DataBase
  
  // loading data
  newInteger = myDataBase.LoadAsInt("variableName"); // In a database a variable is stored as a string,
                                                     // so in order to load an int you have to call the function 
                                                     // LoadAsInt() with the name you gave to 
                                                     // your variable in the database
```
