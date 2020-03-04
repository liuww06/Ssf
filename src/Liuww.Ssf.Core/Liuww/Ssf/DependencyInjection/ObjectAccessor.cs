﻿namespace Liuww.Ssf.DependencyInjection
{
    public class ObjectAccessor<T>:IObjectAccessor<T>
    {
        public T Value { get; set; }

        public ObjectAccessor()
        {
            
        }

        public ObjectAccessor(T obj)
        {
            Value = obj;
        }
    }
}