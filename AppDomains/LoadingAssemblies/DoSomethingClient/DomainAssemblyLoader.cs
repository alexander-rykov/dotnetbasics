using System;
using System.Linq;
using System.Reflection;
using MyInterfaces;

namespace DoSomethingClient
{
    public class DomainAssemblyLoader : MarshalByRefObject
    {
        // NOTE Before making this call make sure that MyInterface assembly is signed with mykey.snk file. See Signing tab in MyInterface project properties editor.
        public IDoSomething Load<T>(string assemblyString)
        {
            // TODO Load an assembly using assemblyString and a static method of Assembly class.
            Assembly assembly = null;

            // TODO Get all types that are loaded in the assembly.
            Type[] types = null;

            // TODO Get a type instance of the IDoSomething interface.
            Type interfaceType = null;

            // TODO Get a type instance of the DoSomethingAttribute class.
            Type attributeType = null;

            // Find first type that has DoSomething attribute (use GetCustom... method) and implements IDoSomething (use IsAssignable method).
            Func<Type, bool> implementsInterfaceAndHasAttribute = (Type t) =>
            {
                return
                    // TODO Uncomment the next line and put correct method name there. Remove false.
                    // interfaceType.MethodName(t)
                    false
                    &&
                    // TODO Uncomment the next line and put correct method name there. Remove false.
                    // t.MethodName().Any(t2 => t2.GetType() == attributeType);
                    false;
            };

            // TODO Use appropriate LINQ method on types array with implementsInterfaceAndHasAttribute delegate to find the type that matches all criteria. Only one type is expected, exception should be thrown otherwise.
            Type doSomethingType = null;

            // TODO Create an instance of doSomethingType using static method of Activator class.
            IDoSomething doSomethingService = (IDoSomething)null;

            return doSomethingService;
        }

        // LoadFile() doesn't bind through Fusion at all - the loader just goes ahead and loads exactly what the caller requested.
        // It doesn't use either the Load or the LoadFrom context.
        // LoadFile() has a catch. Since it doesn't use a binding context, its dependencies aren't automatically found in its directory. 

        // Usage:
        // var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MyDomain\MyLibrary.dll");
        // result = loader.Load(path, input);
        public Result LoadFile(string path, Input data)
        {
            // LoadFrom() goes through Fusion and can be redirected to another assembly at a different path
            // but with that same identity if one is already loaded in the LoadFrom context.

            var assembly = Assembly.LoadFile(path);
            var types = assembly.GetTypes();

            Type type = null; // TODO: Find first type that has DoSomething attribute and don't implement IDoSomething.
            // TODO: MethodInfo mi = type.GetMethod("DoSomething");
            Result result = null;
            // TODO: result = mi.Invoke();

            return result;
        }

        // More details: http://stackoverflow.com/questions/1477843/difference-between-loadfile-and-loadfrom-with-net-assemblies
        public Result LoadFrom(string fileName, Input data)
        {
            var assembly = Assembly.LoadFrom(fileName);
            var type = assembly.GetTypes();

            // TODO: Find first type that has DoSomething attribute and implements IDoSomething.
            // TODO: Create an instance of this type.

            IDoSomething doSomethingService = null; // TODO Save instance to variable.
            return doSomethingService.DoSomething(data);
        }
    }
}
