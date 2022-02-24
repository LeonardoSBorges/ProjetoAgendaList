using System;
using System.Text;
using System.Threading;
namespace AgendaList
{
    internal class Contacts
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Phone TopPhoneNumber { get; set; }
        public Contacts Next { get; set; }
        public Contacts Previous { get; set; }
        public Contacts(string name, string email)
        {
            Name = name;
            Email = email;
            Next = null;
        }
        public void AddNumber()
        {
            Phone aux = TopPhoneNumber, value;
            int Option = 0, i = 0;
            do
            {
                if (i <= 5)
                {
                    i++;
                    Console.Clear();
                    Console.WriteLine("1 - Adicionar numero\n2 - Continuar");
                    Option = int.Parse(Console.ReadLine());
                    if (Option == 1)
                    {
                        Console.Clear();
                        Console.Write("========== NUMERO ==========\nTipo de numero: ");
                        string Type = Console.ReadLine();
                        Console.Write("DDD: ");
                        string ddd = Console.ReadLine();
                        Console.Write("Numero: ");
                        string Number = Console.ReadLine();
                        Number = ddd + Number;

                        if (aux == null)
                        {
                            aux = new Phone(Type, Number);
                            TopPhoneNumber = aux;
                        }
                        else
                        {
                            Phone aux2 = TopPhoneNumber;
                            value = new Phone(Type, Number);
                            aux.Next = value;
                            aux = aux.Next;
                        }
                    }
                    else if (Option != 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Escolha uma opcao valida");
                        Console.ReadKey();
                    }
                    else if (TopPhoneNumber == null)
                    {
                        TopPhoneNumber = new Phone("", "");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Voce atingiu o limite de numeros em um contato");
                    Console.ReadKey();
                    break;
                }
            } while (Option != 2);
        }
        public void EditNumber()
        {
            Phone aux = TopPhoneNumber;
            do
            {
                Console.WriteLine("\n" + Name + "\n" + aux.ToString());
                Console.WriteLine("========== Alterar numero =========");
                Console.WriteLine("1 - Alterar o tipo\n2 - Alterar o numero\n3 - Proximo\n4 - Sair");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.Write("Novo tipo de numero: ");
                        string Type = Console.ReadLine();
                        aux.TypeNumber = Type;
                        break;
                    case 2:

                        Console.Write("DDD: ");
                        string ddd = Console.ReadLine();
                        Console.Write("Novo numero: ");
                        string Number = Console.ReadLine();

                        Number = ddd + Number;
                        aux.PhoneNumber = Number;
                        break;
                    case 3:
                        Console.Clear();
                        aux = aux.Next;
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("As opcao escolhida nao existe");
                        break;
                }
                Thread.Sleep(500);
                if (aux == null)
                    Console.WriteLine("nao existe mais numeros cadastrados nesse contato");
                else if (opc == 4)
                    break;
            } while (aux != null);
        }
        public override string ToString()
        {

            StringBuilder sg = new StringBuilder();
            sg.Append($"\n\nName:\t{Name}\nE-mail:\t{Email}");

            Phone aux;
            aux = TopPhoneNumber;
            do
            {
                sg.Append("\n" + aux.ToString());
                aux = aux.Next;
            } while (aux != null);

            return sg.ToString();
        }
    }
}
