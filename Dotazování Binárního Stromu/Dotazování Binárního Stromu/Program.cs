using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryTree;

namespace Dotazování_Binárního_Stromu
{
    class Program
    {
        static void Vstup()
        {
            BTree<Employee> emplTree = new BTree<Employee>(
                new Employee { Id = 1, Name = "Aneta", Surname = " Průšová", Deparement = "IT" });

            emplTree.insert(new Employee
            {
                Id = 2,
                Name = "Mirek",
                Surname = " Travička",
                Deparement = "Marketing"
            });
            emplTree.insert(new Employee
            {
                Id = 4,
                Name = "Katka",
                Surname = " Spěšná",
                Deparement = "IT"
            });
            emplTree.insert(new Employee
            {
                Id = 6,
                Name = "Lucie",
                Surname = " Chvátalová",
                Deparement = "Odbyt"
            });
            emplTree.insert(new Employee
            {
                Id = 3,
                Name = "Erik",
                Surname = " Doležal",
                Deparement = "Odbyt"
            });
            emplTree.insert(new Employee
            {
                Id = 5,
                Name = "David",
                Surname = " Skála",
                Deparement = "Marketing"
            });

            Console.WriteLine("Seznam oddeleni:");
            //var department = emplTree.Select(d => d.Deparement).Distinct();
            var department = (from d in emplTree
                              select d.Deparement).Distinct();
            foreach (var odd in department)
            {
                Console.WriteLine("Oddeleni: {0}", odd);
            }

            Console.WriteLine("\nZamestnanci IT:");
            /*var itEmp = emplTree
                .Where(emp => String.Equals(emp.Deparement, "IT"))
                .Select(emp => emp);
            */
            var itEmp = from emp in emplTree
                        where String.Equals(emp.Deparement, "IT")
                        select emp;
            foreach (var emp in itEmp)
            {
                Console.WriteLine("Zamestnanec: {0}", emp);
            }

            Console.WriteLine("\nOddeleni zamestnanci:");
            /*var depEmp = emplTree
                .GroupBy(z => z.Deparement);
            */
            var depEmp = from item in emplTree
                         group item by item.Deparement;
            foreach (var gr in depEmp)
            {
                Console.WriteLine("Oddeleni: {0}", gr.Key);
                foreach (var emp in gr)
                    Console.WriteLine("\t{0} {1}", emp.Name, emp.Surname);
            }


            Console.WriteLine("\n all staff:");
            var empls = from e in emplTree.ToList<Employee>()
                        select e;
            foreach (var item in empls)
                Console.WriteLine(item);

            emplTree.insert(new Employee { Id = 7, Name = "Kamil", Surname = "Mrkvicka", Deparement = "IT" });
            Console.WriteLine("\n all staff2:");
            foreach (var item in empls)
                Console.WriteLine(item);
        }

        static void Main()
        {
            try
            {
                Vstup();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Výjimka: {0}", ex.Message);
            }
        }
    }
}
