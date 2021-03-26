using System;
using System.Collections.Generic;
using System.Text;

namespace StockGEMS
{
    public class Container
    {
        private IDictionary<Type, Type> _singletonMap; 
        private IDictionary<Type, Type> _transientMap;
        private IDictionary<Type, object> _singletons;
        
        public Container()
        {
            _singletonMap = new Dictionary<Type, Type>();
            _transientMap = new Dictionary<Type, Type>();
            _singletons = new Dictionary<Type, object>(); 
        }

        public void RegisterSingleton<IType, ConcType>()
        {
            _singletonMap.Add(typeof(IType), typeof(ConcType)); 
        }

        public void RegisterTransient<IType, ConcType>()
        {
            _transientMap.Add(typeof(IType), typeof(ConcType));
        }

        public IType GetObject<IType>()
        {
            // Base Case 1 (already created an instance)
            if (_singletons.ContainsKey(typeof(IType))) 
                return (IType)_singletons[typeof(IType)];

            Type concreteType;
            bool isSingleton = _singletonMap.ContainsKey(typeof(IType));
            if (isSingleton)
                concreteType = _singletonMap[typeof(IType)];
            else if (_transientMap.ContainsKey(typeof(IType)))
                concreteType = _transientMap[typeof(IType)];
            else
                throw new ApplicationException($"Type {typeof(IType)} does not have a registered concrete class");

            var constructors = concreteType.GetConstructors();
            if (constructors.Length != 1) throw new ApplicationException($"Only one constructor supported. Got {constructors.Length}");
            var constructor = constructors[0];
            var parameters = constructor.GetParameters();

            object objectToReturn; 
            // Base Case 2 (Constructor has no parameters, trivial construction)
            if (parameters.Length == 0)
            {
                objectToReturn = constructor.Invoke(null);
                if (isSingleton) // Lazy initialize
                    _singletons.Add(typeof(IType), objectToReturn);
                return (IType)objectToReturn; 
            }

            // Recursive Case (For each parameter of the constructor GetObject recursively)
            object[] arguments = new object[parameters.Length];
            for (int i = 0; i <parameters.Length; i++)
            {
                var methodInfo = typeof(Container).GetMethod("GetObject").MakeGenericMethod(parameters[i].ParameterType); 
                arguments[i] = methodInfo.Invoke(this, null);  
            }

            objectToReturn = constructor.Invoke(arguments); 
            if(isSingleton)
                _singletons.Add(typeof(IType), objectToReturn);
            return (IType)objectToReturn;
        }
    }
}
