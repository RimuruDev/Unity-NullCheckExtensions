// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace RimuruDev
{
    public static class NullCheckExtensions
    {
        public static T IfNotNull<T>(this T obj, Action<T> action) where T : class
        {
            if (obj != null)
            {
                action?.Invoke(obj);
            }
            else
            {
                var stackTrace = new StackTrace();
                
                var methodCall = stackTrace.GetFrame(1).GetMethod();
                
                Debug.LogWarning($"Null reference at method: {methodCall.Name} in {methodCall.DeclaringType?.Name}, line: {new StackFrame(1, true).GetFileLineNumber()}");
            }

            return obj;
        }
    }

}
