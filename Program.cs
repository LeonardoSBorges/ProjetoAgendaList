using System;

namespace AgendaList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            int opcaoMenu = 0;

            while (opcaoMenu != 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("\n\t========== MENU ==========");
                Console.WriteLine("\t1 - Inserir novo contato\n\t2 - Remover contato\n\t3 - Editar contato\n\t4 - Mostrar contatos\n\t5 - Pesquisar contato\n\t6 - Sair ");
                Console.Write("\t");
                string value = Console.ReadLine();
                bool result = int.TryParse(value, out opcaoMenu);
                Console.Clear();
                switch (opcaoMenu)
                {
                    case 1:
                        Console.Clear();
                        InsertName(agenda);
                        break;
                    case 2:
                        RemoveContact(agenda);

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:

                        EditContact(agenda);

                        Console.ReadKey();
                        break;
                    case 4:
                        agenda.Get();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        SearchContact(agenda);
                        Console.ReadKey();
                        break;
                    case 6:

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insira uma opcao valida");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void InsertName(Agenda agenda)
        {
            Console.WriteLine("============ Adicione um contato ===============");
            Console.Write("Nome: ");
            string name = Console.ReadLine().Trim();
            Console.Write("E-mail: ");
            string email = Console.ReadLine().Trim();

            agenda.Push(new Contacts(name, email));
        }
        public static void RemoveContact(Agenda agenda)
        {
            if (agenda.Head != null)
            {
                Contacts contacts = SearchContact(agenda);

                if (contacts != null)
                {
                    agenda.Remove(contacts.Name);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sua agenda nao tem contatos ainda");
            }
        }
        public static Contacts SearchContact(Agenda agenda)
        {

            Console.WriteLine("================= Buscar =================");
            if (agenda.Head != null)
            {
                Console.Write("Nome:");
                string name = Console.ReadLine().Trim();

                Contacts contacts = agenda.SearchContact(name);

                return contacts;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sua agenda nao tem contatos ainda");
            }
            return null;
        }
        public static void EditContact(Agenda agenda)
        {
            Contacts contacts = SearchContact(agenda);

            if (contacts != null)
            {
                agenda.Remove(contacts.Name);
                InsertName(agenda);
            }
        }
    }
}
