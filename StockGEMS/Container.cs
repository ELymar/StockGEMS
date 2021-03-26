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

        public void RegisterSingleton(Type interf, Type concrete)
        {
            _mappings.Add(interf, concrete); 
        }

        public object GetObject(Type interfaceType)
        {
            // Base Case 1 (already created an instance)
            if (_singletons.ContainsKey(interfaceType)) 
                return _singletons[interfaceType];

            if (!_mappings.ContainsKey(interfaceType))
                throw new ApplicationException($"Type {interfaceType} does not have a registered concrete class");

            var concreteType = _mappings[interfaceType]; 
            var constructors = concreteType.GetConstructors();
            if (constructors.Length != 1) throw new ApplicationException($"Only one constructor supported. Got {constructors.Length}");
            var constructor = constructors[0];
            var parameters = constructor.GetParameters();

            // Base Case 2 (Constructor has no parameters, trivial construction)
            if (parameters.Length == 0)
            {
                _singletons.Add(interfaceType, constructor.Invoke(null));
                return _singletons[interfaceType]; 
            }

            // Recursive Case (For each parameter of the constructor GetObject recursively)
            object[] arguments = new object[parameters.Length];
            for (int i = 0; i <parameters.Length; i++)
            {
                arguments[i] = GetObject(parameters[i].ParameterType); 
            }
            _singletons.Add(interfaceType, constructor.Invoke(arguments));
            return _singletons[interfaceType];
        }
    }
}
