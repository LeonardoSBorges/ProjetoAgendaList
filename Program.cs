using System;

namespace AgendaList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanciar Agenda
            Agenda agenda = new Agenda();

            //Menu
            int opc = -1;

            while (opc != 6)
            {

                Console.Clear();
                Console.WriteLine("\t========== MENU ==========");
                Console.WriteLine("\t1 - Inserir novo contato\n\t2 - Remover contato\n\t3 - Editar contato\n\t4 - Mostrar contatos\n\t5 - Pesquisar contato\n\t6 - Sair ");
                Console.Write("\t");
                string value = Console.ReadLine();
                bool result = int.TryParse(value, out opc);
                Console.Clear();
                switch (opc)
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
                        Console.WriteLine("Insira uma opcao valida");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //Funcoes

        public static void InsertName(Agenda agenda)
        {
            Console.WriteLine("============= ADICIONANDO CONTATO ================");
            Console.Write("Nome: ");
            string name = Console.ReadLine().Trim();
            Console.Write("E-mail: ");
            string email = Console.ReadLine().Trim();

            agenda.Push(new Contacts(name, email));
        }


        public static Contacts SearchContact(Agenda agenda)
        {

            Console.WriteLine("================== PESQUISAR CONTATO ==================");
            if (agenda.Head != null)
            {
                Console.Write("Nome:");
                string name = Console.ReadLine().Trim();

                Contacts contacts = agenda.SearchContact(name);

                return contacts;
            }
            else
                Console.WriteLine("Sua agenda nao tem contatos ainda");
            return null;

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
                Console.WriteLine("Sua agenda nao tem contatos ainda");

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
