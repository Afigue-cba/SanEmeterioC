﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanEmeterio.Clases
{
    public class Switch
    {
        public Switch(Object o)
        {
            Object = o;
        }

        public Object Object { get; private set; }
    }

    //Metodos de extensión
    public static class SwitchExtensions
    {
        public static Switch Case<T>(this Switch s, Action<T> a)
              where T : class
        {
            return Case(s, o => true, a, false);
        }

        public static Switch Case<T>(this Switch s, Action<T> a,
             bool fallThrough) where T : class
        {
            return Case(s, o => true, a, fallThrough);
        }

        public static Switch Case<T>(this Switch s,
            Func<T, bool> c, Action<T> a) where T : class
        {
            return Case(s, c, a, false);
        }

        public static Switch Case<T>(this Switch s,
            Func<T, bool> c, Action<T> a, bool fallThrough) where T : class
        {
            if (s == null)
            {
                return null;
            }

            T t = s.Object as T;
            if (t != null)
            {
                if (c(t))
                {
                    a(t);
                    return fallThrough ? s : null;
                }
            }
            return s;
        }
    }
}
