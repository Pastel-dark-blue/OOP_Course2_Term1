using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;

namespace Laba12
{
    static class Reflector
    {
        // проверка существования указанного типа
        static public void typeExist(string type)
        {
            //второй параметр отвечает за то, что произойдет, если указанного типа не будет найдено
            //false - возврат null
            //true - генерация исключения 
            Type typeInfo = Type.GetType(type, false);

            //если указанного типа не было найдено, завершаем программу
            if (typeInfo == null)
            {
                Console.WriteLine("Указанного вами типа не было найдено");
                System.Environment.Exit(1);
            }
                
        }

        // имя сборки, в которой определен класс
        static public string assemblyName(string type)
        {
            typeExist(type);

            Type t = Type.GetType(type);
            string assemblyName = Assembly.GetAssembly(t).FullName;

            return assemblyName;
        }

        // есть ли публичные конструкторы
        static public bool containsPublConstructors(string type)
        {
            typeExist(type);

            Type t = Type.GetType(type);
            ConstructorInfo[] ctors = t.GetConstructors(BindingFlags.Public);

            if (ctors == null)
                return false;
            else
                return true;
        }

        //извлекает все публичные методы класса
        static public MethodInfo[] getPublMethods(string type)
        {
            typeExist(type);

            Type t = Type.GetType(type);
            MethodInfo[] methods = t.GetMethods();

            return methods;
        }

        static public FieldInfo[] getFields(string type)
        {
            typeExist(type);

            Type t = Type.GetType(type);
            FieldInfo[] fields = t.GetFields();

            return fields;
        }

        static public PropertyInfo[] getProps(string type)
        {
            typeExist(type);

            Type t = Type.GetType(type);
            PropertyInfo[] props = t.GetProperties();

            return props;
        }

        static public Type[] getInterfaces(string type)
        {
            typeExist(type);

            Type t = Type.GetType(type);
            Type[] interfaces = t.GetInterfaces();

            return interfaces;
        }

        //выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра 
        static public IEnumerable<MethodInfo> getMeth(string type, Type paramType)
        {
            typeExist(type);

            Type t = Type.GetType(type);

            MethodInfo[] methods = t.GetMethods();
            var methWithDefineParam = methods // из массива methods 
                // берем каждый последующий элемент (meth) и получаем массив его параметров (meth.GetParameters)
                .Where(meth => meth.GetParameters()
                // у каждого последующего элемента в массиве пареметров (param) узнаем тип (param.ParameterType) 
                //и сравниваем с типом переданным методом getMeth (paramType)
                .Where(param => param.ParameterType == paramType) 
                // если тип с подходящим параметром найден, то он попадает в итоговую выборку
                .Count() != 0);

            return methWithDefineParam;
        }

        // можно передать только методы, содержащие параметры типа string
        // obj - объект типа type, для которого мы вызываем метод meth
        // path - путь к файлу со значениями переметров метода
        static public void Invoke(object obj, string type, string meth, string path)
        {
            typeExist(type);

            Type t = Type.GetType(type);

            MethodInfo method = t.GetMethod(meth);
            int numOfParams = method.GetParameters().Length;

            try
            {
                // значения параметров
                object[] foundParamsValues = new object[numOfParams];

                StreamReader fIn = new StreamReader(path);
                string line; //строка считанная из файла

                int i = -1;
                do
                {
                    i++;
                    line = fIn.ReadLine();
                    if (line != null)
                        foundParamsValues[i] = line;
                } while (line != null && (i + 1) < numOfParams);
                
                // динамический вызов метода
                // первый параметр - объект, чей метод вызывается
                // второй - массив значений параметров данного метода
                method.Invoke(obj, foundParamsValues);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // запись информации о типе в файл
        static public void WriteInfoToFile(string type, Type paramType, string path)
        {
            typeExist(type);

            string info = "Имя типа : " + type + "\n";

            info += "Название сборки, в которой определен тип : " + assemblyName(type) + "\n";

            info += "Содержит ли тип публичные конструкторы : " + containsPublConstructors(type) + "\n";

            info += "Публичные методы :\n";
            MethodInfo[] publMethods = getPublMethods(type);
            foreach(var m in publMethods)
            {
                info += "--> " + m.Name + "\n";
            }

            info += "Поля :\n";
            FieldInfo[] fields = getFields(type);
            foreach (var f in fields)
            {
                info += "--> " + f.Name + "\n";
            }

            info += "Свойства :\n";
            PropertyInfo[] props = getProps(type);
            foreach (var p in props)
            {
                info += "--> " + p.Name + "\n";
            }

            info += "Реализуемые интерфейсы :\n";
            Type[] interfaces = getInterfaces(type);
            foreach (var i in interfaces)
            {
                info += "--> " + i.Name + "\n";
            }

            info += $"Методы с параметром типа {paramType} :\n";
            IEnumerable<MethodInfo> methodsWithDefineParType = getMeth(type, paramType);
            foreach (var m in methodsWithDefineParType)
            {
                info += "--> " + m.Name + "\n";
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(path, false)) 
                {
                    sw.WriteLine(info);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static public object Create(string type, object[] values)
        {
            typeExist(type);

            Type t = Type.GetType(type);

            object result = Activator.CreateInstance(t, values);

            return result;
        }

    }
}
