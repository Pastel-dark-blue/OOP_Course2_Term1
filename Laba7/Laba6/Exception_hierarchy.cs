using System;

namespace Laba7
{
    class Exceptions
    {
        //проверка даты премьеры
        public class PremiereDate_Exception : Exception
        {
            public PremiereDate_Exception(string message) : base(message) { }
        }

        //если в качестве названия передана строка нулевой длины или null будет выбрасываться исключение
        public class Title_Exception : ArgumentException
        {
            public Title_Exception(string message) : base(message) { }
        }
        
        //проверка продолжительности
        public class DurationMinutes_Exception : ArgumentException
        {
            public DurationMinutes_Exception(string message) : base(message) { }
        }
    }
}
