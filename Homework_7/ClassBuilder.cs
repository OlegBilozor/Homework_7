using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_7
{
    public class ClassBuilder<T>
    {
        public void BuildClass()
        {
            var type = typeof(T);
            string fileName = $"{type.Name}.cs";
          
            if (File.Exists(fileName))
            {
                Console.WriteLine("File with that name already exists. You want to create another one (enter 1) or replace the old one (enter 2)?");
                int.TryParse(Console.ReadLine(), out int choise);
                switch (choise)
                {
                    case 1:
                        int num = 1;
                        
                        while (File.Exists(fileName))
                        {
                            fileName = $"{type.Name}_{num++}.cs";
                        }

                        Console.WriteLine($"Class will be written to file \"{fileName}\"");
                        break;
                    case 2:
                        Console.WriteLine($"File \"{fileName}\" will be replaced with the new one");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        return;
                }
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"class {type.Name}\n{{");
                    var properties = type.GetProperties();
                    foreach (var property in properties)
                    {
                        string newLine = $"{property.PropertyType} {property.Name}\n{{\n";
                        var get = property.GetMethod;
                        if (get.IsPrivate)
                        {
                            newLine += "private ";
                        }
                        else if(get.IsPublic)
                        {
                            newLine += "public ";
                        }
                        else
                        {
                            newLine += "protected ";
                        }
                        newLine += "get;\n";
                        var set = property.SetMethod;
                        if (set.IsPrivate)
                        {
                            newLine += "private ";
                        }
                        else if (set.IsPublic)
                        {
                            newLine += "public ";
                        }
                        else
                        {
                            newLine += "protected ";
                        }

                        newLine += "set;\n}";
                        sw.WriteLine(newLine);
                    }
                    sw.WriteLine("}");
                }
            }
        }
    }
}
