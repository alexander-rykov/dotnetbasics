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

            // Find first type that has DoSomething attribute (use GetCustom... method) and implements IDoSomething (use IsAssignable method).
            Func<Type, bool> implementsInterfaceAndHasAttribute = (Type t) =>
            {
                return
                    // TODO Uncomment the next line and put correct method name there to check that t type can be assigned to interfaceType. Remove false.
                    // interfaceType.MethodName(t)
                    false
                    &&
                    // TODO Use GetCustomAttribute method to check whether a t type has DoSomething attribute. Remove false.
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
        public Result LoadFile<T, V>(string path, string methodName, Input data)
        {
            // TODO Load an assembly using path.
            Assembly assembly = null;

            // TODO Get all types that are loaded in the assembly.
            Type[] types = null;

            // TODO Get a type of an interface.
            Type interfaceType = null;

            // Find first type that has DoSomething attribute and DO NOT implements IDoSomething.
            Func<Type, bool> hasAttributeAndDontImplementsInterface = (Type t) => 
                // TODO Specify condition to met all criteria.
                false;

            // TODO Search for type.
            Type serviceType = null;

            // TODO Create an instance using serviceType.
            object service = null;

            // TODO Get method info from service type using method name.
            MethodInfo methodInfo = null;

            // TODO Call the method with data as a parameter.
            Result result = null; // (Result)methodInfo.Invoke();

            return result;
        }

        // LoadFrom() goes through Fusion and can be redirected to another assembly at a different path
        // but with that same identity if one is already loaded in the LoadFrom context.
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
