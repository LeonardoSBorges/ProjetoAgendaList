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
                        InsertName(agenda);
                        break;
                    case 2:
                        RemoveContact(agenda);

                        break;
                    case 3:

                        agenda.EditContadct();

                        Console.ReadKey();
                        break;
                    case 4:
                        agenda.Get();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        SearchContact(agenda);
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
            Console.Clear();
            Console.WriteLine("============= ADICIONANDO CONTATO ================");
            Console.Write("Nome: ");
            string name = Console.ReadLine().Trim();
            Console.Write("E-mail: ");
            string email = Console.ReadLine().Trim();

            agenda.Push(new Contacts(name, email));
        }

        public static void RemoveContact(Agenda agenda)
        {

            Console.WriteLine("================== REMOVER ==================");
            if (agenda.Head != null)
            {
                Console.Write("Nome:");
                string name = Console.ReadLine().Trim();

                agenda.Remove(name);
            }
            else
                Console.WriteLine("Nao existe contatos que possam ser excluidos");

            Console.ReadKey();
        }

        public static void SearchContact(Agenda agenda)
        {

            Console.WriteLine("================== PESQUISAR CONTATO ==================");
            if (agenda.Head != null)
            {
                Console.Write("Nome:");
                string name = Console.ReadLine().Trim();

                agenda.SearchContact(name);
            }
            else
                Console.WriteLine("Sua agenda nao tem contatos ainda");
            Console.ReadKey();
        }


    }
}
