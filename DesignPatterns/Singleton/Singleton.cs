using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    class ThreadSafeSingle
    {
        private ThreadSafeSingle() { }

        private static ThreadSafeSingle _instance;

        private static readonly object _lock = new object();

        public static ThreadSafeSingle GetInstance(string value)
        {

            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingle();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        public string Value { get; set; }
    }
}
