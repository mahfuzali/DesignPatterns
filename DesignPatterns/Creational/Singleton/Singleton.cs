using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    public sealed class Singleton
    {
        private static Singleton _instance = null;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public sealed class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton _instance;

        private static readonly object _lock = new object();

        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton GetInstance(string value)
        {

            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                    }
                }
            }
            return _instance;
        }

    }
}
