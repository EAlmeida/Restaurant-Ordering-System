using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace RestaurantOrderingSystem.Common
{
    public class Utility
    {
        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static int IdentityFake()
        {
            var rnd = new Random();
            var identityFace = rnd.Next(1, 10000);

            return identityFace;
        }
    }
}
