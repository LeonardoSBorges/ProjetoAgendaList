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
        public void Push(Contacts newContact)
        {
            newContact.AddNumber();
            Contacts aux = newContact, aux2 = Head, aux3 = Head;
            if (Head == null && Tail == null)
            {
                Tail = Head = aux;
            }
            else
            {
                if (aux.Name.CompareTo(Tail.Name) >= 0)
                {
                    aux.Previous = Tail;
                    Tail.Next = aux;
                    Tail = aux;
                }
                else if (Tail == Head)
                {
                    aux.Next = Head;
                    Head.Previous = aux;
                    Head = aux;
                }
                else
                {
                    do
                    {
                        if (aux.Name.CompareTo(aux2.Name) == -1)
                        {
                            aux.Next = Head;
                            Head = aux;
                            break;
                        }
                        else if (aux.Name.CompareTo(aux2.Name) == 1 || aux.Name.CompareTo(aux2.Name) == 0)
                        {
                            aux.Previous = aux2;
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

                        aux = aux.Next;
                    } while (aux != null);
                }
            }
        }
        public void Get()
        {
            Contacts aux = Head;
            Console.WriteLine("=================== CONTATOS ===================");
            if (aux != null)
            {
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Next;
                    Thread.Sleep(500); 
                } while (aux != null);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Agenda vazia");
            }
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
        public Contacts SearchContact(string name) 
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
                    return aux;
                }
                aux = aux.Next;
            } while (aux != null);
            if (!flag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nada foi encontrado");
            }
            return null;
        }
        public void Remove(string name) 
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
                        Head.Previous = aux.Next = null;
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
                    Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Contato nao encontrado");
            }
        }
    }
}