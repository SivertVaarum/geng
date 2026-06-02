using System;
using System.Collections.Generic;
using System.Security;

namespace geng;

public static class Engine
{
    public static void Register<T> (T service)where T : class, IService
    {
        Type type = typeof(T);
        if(_services.ContainsKey(type)) throw new InvalidOperationException("Service already registered"); 
        _services.Add(type, service); 
    }
    public static T Get<T>() where T : class, IService
    {
        Type type = typeof(T);

        if (_services.TryGetValue(type, out var service))
        {
            return (T)service;
        }
        throw new KeyNotFoundException("Service of '{type.name}' is not registered");
    }
    
    private static Dictionary<Type, IService> _services = new(); 
    
}