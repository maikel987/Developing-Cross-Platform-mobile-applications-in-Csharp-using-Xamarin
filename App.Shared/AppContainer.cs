using System;
using System.Collections.Generic;
using System.Text;

namespace App.Shared
{
    public class AppContainer
    {
        private static AppContainer _instance = new AppContainer();

        public static AppContainer Instance
        {
            get { return _instance; }
        }

        private Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public void Register<T>(object instance)
        {
            _instances.Add(typeof(T), instance);
        }

        public T Get<T>()
        {
            return (T)_instances[typeof(T)];
        }
    }
}
