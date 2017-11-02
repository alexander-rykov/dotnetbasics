using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CustomAttributes
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class MyProxyService : IMyService
    {
        private readonly Type _interfaceType;
        private readonly Type _serviceType;
        private readonly object _service;

        public MyProxyService(object service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            _service = service;
            _interfaceType = typeof(IMyService);
            _serviceType = service.GetType();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [DebuggerHidden]
        public string MyProperty
        {
            get
            {
                // TODO Add new implementation here:
                // If the DefaultValue attribute is applied to the property, return the attribute value; if the DefaultValue attribute is not applied, return default type value.

                throw new NotImplementedException("MyProperty");
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [DebuggerHidden]
        public int AnotherProperty
        {
            get
            {
                // TODO Add new implementation here:
                // If the DefaultValue attribute is applied to the property, return the attribute value; if the DefaultValue attribute is not applied, return default type value.

                throw new NotImplementedException("AnotherProperty");
            }
        }

        [DebuggerHidden]
        public int DoSomething(string stringParameter, int parameter)
        {
            var parameterTypes = new[] { typeof(string), typeof(int) };
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public;

            // TODO Get method from _interfaceType with required name, types and binding flags.
            MethodInfo interfaceMethodInfo = null;

            // TODO Get attributes for interface method and set hasLogMethodCallAttribute to true if LogMethodCall attribute exists in the attribute collection.
            bool hasLogMethodCallAttribute = false;

            // TODO Get a required method from _serviceType with required name, types and binding flags.
            MethodInfo serviceMethodInfo = null;

            if (hasLogMethodCallAttribute)
            {
                var sb = new StringBuilder();
                sb.Append($"Enter {_serviceType.Name}.{serviceMethodInfo.Name}(");

                // TODO Add parameter values to the builder to print them to console.

                sb.Append(")");
                Trace.TraceInformation(sb.ToString());
            }

            // TODO Implement validation logic for method parameters, and verfy strings for NotNullOrEmpty and integers for MaxValue.

            try
            {
                // TODO Invoke the service method and set the returned result.
                int result = (int)0;

                if (hasLogMethodCallAttribute)
                {
                    Trace.TraceInformation($"Leave {_serviceType.Name}.{serviceMethodInfo.Name}() = {result}");
                }

                return result;
            }
            catch (Exception e)
            {
                Trace.TraceError($"Exception {_serviceType.Name}.{serviceMethodInfo.Name}() => {e.Message}");
                throw;
            }
        }

        [DebuggerHidden]
        public int DoSomethingElse(int x, int y)
        {
            // TODO Add new implementation here to handle RedirectMethodCall attribute.
            // If the attribute is applied to a method, redirect to a method with specified name; if the attribute is not applied, don't redirect and call the method with DoSomethingElse name.

            throw new NotImplementedException("DoSomethingElse");
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => $"Proxy for {_serviceType.FullName}";
    }
}
