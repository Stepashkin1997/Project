using System;

namespace Project.Models
{
    public static class StringExtensions//расширение для класса String
    {
        public static T ParseEnum<T>(this string value)//метод преобразующий строку в Enum определенного типа
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}