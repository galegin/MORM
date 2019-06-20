using System;
using System.Collections.Generic;

public static class AbstractIocResolver
{
    static Dictionary<Type, object> _registeredTypes = new Dictionary<Type, object>();
 
    public static void Register<T>(T toRegister)
    {
        _registeredTypes.Add(typeof(T), toRegister);
    }
 
    public static T Resolve<T>()
    {
        return (T)_registeredTypes[typeof(T)];
    }
}

/*
C# Reflection - Getting Constructors

C# reflection Type class provides two methods for getting the constructors in any Type.

GetConstructors() //Returns all the constructors
GetConstructor() //Returns only the specific constructor with match your given criteria.
By default, all the above methods returns public constructors of a Type. To get the private, protected, and static constructors you have to use other overloaded methods of GetConstructors() and GetConstructor() method in which we have to specify the BindingFlags and parameter types.

GetConstructors() Method
GetConstructors method have two overload methods:

GetConstructors(): Search only for public constructors.
GetConstructors(BindingFlags flags): //Search using the criteria in the BindingFlags. 
Example of GetConstructors() method

public class Program
{
    public Program()
    {
 
    }
 
    public Program(string str)
    {
 
    }
 
    private Program(int i)
    {
 
    }
 
    static Program()
    {
 
    }
 
    static void Main(string[] args)
    {
        Type type = typeof(Program);
 
        //get the public construcotrs
        foreach (ConstructorInfo item in type.GetConstructors())
        {
            Console.WriteLine("Name: " + item.Name + ", IsPublic: " + item.IsPublic + ", IsPrivate: " + item.IsPrivate + ", IsStatic: " + item.IsStatic);
        }
 
        //get the private constructors
        foreach (ConstructorInfo item in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            Console.WriteLine("Name: " + item.Name + ", IsPublic: " + item.IsPublic + ", IsPrivate: " + item.IsPrivate + ", IsStatic: " + item.IsStatic);
        }
 
        //get the static constructors
        foreach (ConstructorInfo item in type.GetConstructors(BindingFlags.Static | BindingFlags.NonPublic))
        {
            Console.WriteLine("Name: " + item.Name + ", IsPublic: " + item.IsPublic + ", IsPrivate: " + item.IsPrivate + ", IsStatic: " + item.IsStatic);
        }
        Console.ReadLine();
    }
}
 
//OUTPUT
//Name: .ctor, IsPublic: True, IsPrivate: False, IsStatic: False
//Name: .ctor, IsPublic: True, IsPrivate: False, IsStatic: False
//Name: .ctor, IsPublic: False, IsPrivate: True, IsStatic: False
//Name: .ctor, IsPublic: False, IsPrivate: True, IsStatic: True

We have used different BindingFlags for getting different constructors in GetConstructors() method of Type class.

Public Constructors
No Binding Flags needed
Private Constructors
BindingFlags.Instance | BindingFlags.NonPublic
Static Constructors
BindingFlags.Static | BindingFlags.NonPublic
GetConstructor() Method
C# reflection provides two main overloads of GetConstructor methods.

GetConstructor(Type[] types): Search for public constructor which match the types as parameters. Specify Type.EmptyTypes for no parameters in the constructor.
GetConstructor(BindingFlags flags, Binder binder, Type[] types, ParamModifier[] modifiers): Search for public, private, protected, and static constructors.
Examples of GetConstructor() method in C# reflection.

public class Program
{
    public Program()
    {
 
    }
 
    public Program(string str)
    {
 
    }
 
    private Program(int i)
    {
 
    }
 
    static Program()
    {
 
    }
 
    static void Main(string[] args)
    {
        Type type = typeof(Program);
 
        //get private constructor
        ConstructorInfo privateConstructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
            null, new[] { typeof(int) }, null);
        Console.WriteLine(privateConstructor.IsPrivate); //return true
 
        //get public constructor
        ConstructorInfo publicConstructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public,
            null, new[] { typeof(string) }, null);
        Console.WriteLine(publicConstructor.IsPublic); //return true
 
        //get default constructor
        ConstructorInfo publicDefaultConstructor = type.GetConstructor(Type.EmptyTypes);
        Console.WriteLine(publicDefaultConstructor.IsPublic); //return true
 
        //get static constructor
        ConstructorInfo staticConstructor = type.GetConstructor(BindingFlags.Static | BindingFlags.NonPublic,
            null, new Type[] { }, null);
        Console.WriteLine(staticConstructor.IsStatic); //return true
 
        Console.ReadLine();
    }
}
 
//OUTPUT:
//True
//True
//True
//True

In the above example, we have created four constructors in the Program class. Two public constructors are overloaded, one is private and last one is static constructor.

In the Main method, we have first get type Type class from the typeof(Program) statement and use the different overloaded methods for getting all the constructors of a Program class.

In the above example, I have used different BindingFlags for getting different types of constructors:

Private Constructor
 

Flags: BindingFlags.Instance | BindingFlags.NonPublic
Type array: new[] { typeof(int) }
Public Constructor with Parameters
 

Flags: BindingFlags.Instance | BindingFlags.Public
Type array: new[] { typeof(string) } 
Public Constructor with No Parameters
 

Flags: None
Type array: Type.EmptyTypes //Returns an empty array
Static Constructor?
 

Flags: BindingFlags.Static | BindingFlags.NonPublic
Type array:  new Type[] { }    //Another way to write blank array
ConstructorInfo Class
Both GetConstructors() and GetConstructor() returns an instance of ConstructorInfo class.

ConstructorInfo has only two important methods listed below:

Invoke which is used for invoking constructors when creating a new instance. We'll understand instance creation later in the next sessions.
GetParameters() which we can use for knowing the parameters of the constructor.
GetParameters() returns all the parameters of a constructor. It returns the array of ParameterInfo class.

Some important properties of ParameterInfo class are listed below:

Name	Description
DefaultValue	Get default value of the optional parameter
HasDefaultValue	Whether this parameter has default value
IsOptional	Is optional parameter
IsOut	Is output parameter
Name	Name of the parameter
ParameterType	Type of the parameter
Position	Position of the parameter
Below is an full example of ConstructorInfo properties.

public class Program
{
    public Program(int i, out string str, double d = 1.00)
    {
        str = "str value";
    }
 
    static void Main(string[] args)
    {
        Type type = typeof(Program);
        var outStringType = Type.GetType("System.String&");
 
        ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public,
            null, new Type[] { typeof(int), outStringType, typeof(double) }, null);
 
        foreach (var parameter in constructor.GetParameters())
        {
            Console.Write("Name: " + parameter.Name + ", ");
            Console.Write("Parameter Type: " + parameter.ParameterType.Name + ", ");
            Console.Write("Position: " + parameter.Position + ", ");
 
            Console.Write("IsOutput: " + parameter.IsOut + ", ");
            Console.Write("IsOptional: " + parameter.IsOptional + ", ");
 
            if (parameter.HasDefaultValue)
            {
                Console.Write("Default Value: " + parameter.DefaultValue);
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
//OUTPUT
//Name: i, Prameter Type: Int32, Position: 0, IsOutput: False, IsOptional: False,
//Name: str, Prameter Type: String&, Position: 1, IsOutput: True, IsOptional: False,
//Name: d, Prameter Type: Double, Position: 2, IsOutput: False, IsOptional: True, Default Value: 1
*/