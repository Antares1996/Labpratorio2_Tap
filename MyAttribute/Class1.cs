using System;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExecuteMe : System.Attribute
    {
        public object[] Value { get; set; }
        public ExecuteMe(params object[] value) => Value = value;

    }
}
