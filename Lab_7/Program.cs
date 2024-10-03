using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Program
    {
        static List<Tablet> tablets;

        static void PrintTablets()
        {
            foreach (Tablet tablet in tablets)
            {
                Console.WriteLine(tablet.Info().Replace('і', 'і'));
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            tablets = new List<Tablet>();
            FileStream fs = new FileStream("бінарн.дані.txt", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            try
            {
                Tablet tablet;
                Console.WriteLine(" Читаємо дані з файлу...\n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    tablet = new Tablet();
                    for (int i = 1; i <= 10; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                tablet.brand = reader.ReadString(); break;
                            case 2:
                                tablet.price = reader.ReadInt32(); break;
                            case 3:
                                tablet.weight = reader.ReadInt32(); break;
                            case 4:
                                tablet.color = reader.ReadString(); break;
                            case 5:
                                tablet.screendiagonal = reader.ReadDouble(); break;
                            case 6:
                                tablet.CPUfrequency = reader.ReadDouble(); break;
                            case 7:
                                tablet.isthereasimcard = reader.ReadBoolean(); break;
                            case 8:
                                tablet.isthereamemorycardslot = reader.ReadBoolean(); break;
                            case 9:
                                tablet.DiscountedPrice = reader.ReadDouble(); break;
                            case 10:
                                tablet.DiscountWithRegularCustomerCard = reader.ReadDouble(); break;
                        }
                    }
                    tablets.Add(tablet);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }
            Console.WriteLine("Несортований перелік планшетів: {0}", tablets.Count);
            PrintTablets();
            tablets.Sort();
            Console.WriteLine("Сортований перлік планшетів: {0}", tablets.Count);
            PrintTablets();
            Console.WriteLine("Додаємо новий запис: Acer");
            Tablet tabletAcer = new Tablet("Acer", 25000, 458, "Grey", 9.8, 2.1, true, false, 12000, 12000);
            tablets.Add(tabletAcer);
            tablets.Sort();
            Console.WriteLine("Перелік планшетів: {0}", tablets.Count());
            PrintTablets();
            Console.WriteLine("Видаляємо останнє значення");
            tablets.RemoveAt (tablets.Count - 1);
            Console.WriteLine("Перелік планшетів: {0}", tablets.Count);
            PrintTablets();
            Console.ReadKey();
        }
    }
}
