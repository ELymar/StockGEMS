using System;
using System.Collections.Generic;
using System.Text;

namespace StockGEMS
{
    public class Container
    {
        private IDictionary<Type, Type> _mappings; 
        private IDictionary<Type, object> _singletons;
        
        public Container()
        {
            _mappings = new Dictionary<Type, Type>();
            _singletons = new Dictionary<Type, object>(); 
        }

        public void RegisterSingleton<IType>(Type concrete)
        {
            _mappings.Add(typeof(IType), concrete); 
        }

        public IType GetObject<IType>()
        {
            // Base Case 1 (already created an instance)
            if (_singletons.ContainsKey(typeof(IType))) 
                return (IType)_singletons[typeof(IType)];

            if (!_mappings.ContainsKey(typeof(IType)))
                throw new ApplicationException($"Type {typeof(IType)} does not have a registered concrete class");

            var concreteType = _mappings[typeof(IType)]; 
            var constructors = concreteType.GetConstructors();
            if (constructors.Length != 1) throw new ApplicationException($"Only one constructor supported. Got {constructors.Length}");
            var constructor = constructors[0];
            var parameters = constructor.GetParameters();

            // Base Case 2 (Constructor has no parameters, trivial construction)
            if (parameters.Length == 0)
            {
                _singletons.Add(typeof(IType), constructor.Invoke(null));
                return (IType)_singletons[typeof(IType)]; 
            }

            // Recursive Case (For each parameter of the constructor GetObject recursively)
            object[] arguments = new object[parameters.Length];
            for (int i = 0; i <parameters.Length; i++)
            {
                var methodInfo = typeof(Container).GetMethod("GetObject").MakeGenericMethod(parameters[i].ParameterType); 
                arguments[i] = methodInfo.Invoke(this, null);  
            }
            _singletons.Add(typeof(IType), constructor.Invoke(arguments));
            return (IType)_singletons[typeof(IType)];
        }
    }
}
