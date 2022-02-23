using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace AgendaList
{
    internal class Agenda
    {
        public Contacts Head { get; set; }
        public Contacts Tail { get; set; }

        public Agenda()
        {
            Head = null;
            Tail = null;
        }
        public void Push(Contacts newContact)//Criar contato
        {
            newContact.AddNumber();
            Contacts aux = newContact, aux2 = Head, aux3 = Head;
            if (Head == null && Tail == null)
            {
                Tail = Head = aux;
            }
            else
            {
                do
                {
                    if (Tail == Head)
                    {
                        if (aux.Name.CompareTo(Tail.Name) == 1)
                        {
                            Tail.Next = aux;
                            Tail = aux;
                            break;
                        }
                        else
                        {
                            aux.Next = Head;
                            Head = aux;
                            break;
                        }
                    }
                    else
                    {
                        if (aux.Name.CompareTo(aux2.Name) == -1)
                        {
                            aux.Next = Head;
                            Head = aux;
                            break;
                        }
                        else if (aux.Name.CompareTo(aux2.Name) == 1 || aux.Name.CompareTo(aux2.Name) == 0)
                        {
                            aux2 = aux2.Next;
                            if (aux2 == null)
                            {
                                Tail.Next = aux;
                                Tail = aux;
                                break;
                            }
                            else if (aux.Name.CompareTo(aux2.Name) == -1)
                            {
                                aux3.Next = aux;
                                aux.Next = aux2;
                                break;
                            }
                        }

                    }
                    aux = aux.Next;
                } while (aux != null);
            }
        }
        public void Get() //Get - Mostrar todos os contatos
        {
            Contacts aux = Head;
            Console.WriteLine("==================== CONTATOS ====================");
            if (aux != null)
            {
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Next;
                    Thread.Sleep(500); // Sleep
                } while (aux != null);
            }
            else
                Console.WriteLine("Agenda vazia");
        }
        public void SearchContact(string name) //Localizar um contato
        {
            Contacts aux = Head;
            bool flag = false;
            do
            {
                if (aux.Name.ToUpper().CompareTo(name.ToUpper()) == 0)
                {
                    Console.WriteLine(aux.ToString());
                    Thread.Sleep(500);
                    flag = true;
                }
                aux = aux.Next;
            } while (aux != null);
            if (!flag)
            {
                Console.WriteLine("Nada foi encontrado");
            }
        }
        public void Remove(string name) // Remover um contato
        {
            Contacts aux = Head, aux1 = Head;
            bool flag = false;
            do
            {
                if (aux.Name.ToUpper().CompareTo(name.ToUpper()) == 0)
                {
                    if (Tail == Head)
                    {
                        Head = null;
                        Tail = null;
                    }
                    else if (aux == Head)
                    {
                        Head = aux.Next;
                        aux.Next = null;
                    }
                    else if (aux == Tail)
                    {
                        Tail = aux1;
                        Tail.Next = null;
                    }
                    else
                    {
                        aux1.Next = aux.Next;
                        aux.Next = null;
                    }
                    flag = true;
                    Console.WriteLine("O contato foi removido da sua agenda");
                }

                if (aux == aux1)
                {
                    aux = aux.Next;
                }
                else
                {
                    aux1 = aux1.Next;
                    aux = aux.Next;
                }

            } while (aux != null);

            if (!flag)
            {
                Console.WriteLine("Contato nao encontrado");
            }

            Console.ReadKey();
            Console.Clear();
        }
        public void EditContadct()//Editar o Contato
        {
            Console.Clear();
            Contacts aux = Head;
            bool flag = true;
            Console.WriteLine("================== EDITAR ==================");
            if (aux != null)
            {
                int value = 0;
                while (value != 4)
                {
                    Console.WriteLine("O que deseja alterar no contato\n1 - Nome\n2 - Numero\n3 - E-mail\n4 - Voltar ao menu anterior");
                    value = int.Parse(Console.ReadLine());
                    string Name = "";
                    aux = Head;

                    if (value != 4)
                    {
                        Console.Write("\nInsira o nome do contato que deseja fazer alteracoes: ");
                        Name = Console.ReadLine();
                    }
                    switch (value)
                    {
                        case 1:
                            Console.Clear();

                            do
                            {
                                if (aux.Name.ToUpper() == Name.ToUpper())
                                {
                                    Console.Write("Novo nome: ");
                                    string newName = Console.ReadLine();
                                    aux.Name = newName;
                                    flag = false;
                                }
                                aux = aux.Next;


                            } while (aux != null);
                            break;
                        case 2:
                            Console.Clear();
                            do
                            {
                                if (aux.Name.ToUpper() == Name.ToUpper())
                                {
                                    aux.EditNumber();
                                    flag = false;
                                    break;
                                }

                                aux = aux.Next;
                            } while (aux != null);
                            break;
                        case 3:
                            Console.Clear();
                            do
                            {
                                if (aux.Name.ToUpper() == Name.ToUpper())
                                {
                                    Console.WriteLine("Novo e-mail: ");
                                    string newEmail = Console.ReadLine();
                                    aux.Email = newEmail;
                                    flag = false;
                                }
                                aux = aux.Next;
                            } while (aux != null);
                            break;
                        case 4:

                            break;
                        default:
                            Console.WriteLine("Opcao nao encontrada");
                            break;
                    }
                    if (flag)
                        Console.WriteLine("Nenhum contato foi encontrado com este nome");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else
                Console.WriteLine("Nenhum contato foi inserido na agenda");
        }
        public Contacts SearchPosition(Contacts newContact)
        {
            Contacts aux = Head, value = Head;
            if (aux == null)
                return newContact;
            do
            {
                if (Tail == Head)
                    return aux;
                if (aux.Name.CompareTo(newContact.Name) == -1)
                {
                    value = aux.Previous;
                }
                aux = aux.Next;
            } while (aux != null);

            return value;
        }
    }
}