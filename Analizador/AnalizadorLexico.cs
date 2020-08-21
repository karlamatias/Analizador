using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Analizador
{
    class AnalizadorLexico
    {
        private LinkedList<Token> Salida;
        private int estado;
        private String lexema;

        public object MessageBoxButtons { get; private set; }

        public LinkedList<Token> escanear(String entrada)
        {
            entrada = entrada + "#";
            Salida = new LinkedList<Token>();
            estado = 0;
            lexema = "";
            Char variable;

            for (int i = 0; i <= entrada.Length - 1; i++)
            {
                //caracter que voy a leer. 
                variable = entrada.ElementAt(i);

                switch (estado)
                {
                    case 0:
                        if (Char.IsDigit(variable))
                        {
                            estado = 1;
                            lexema += variable;
                        }
                        else if (variable.CompareTo('Q') == 0)
                        {
                            lexema += variable;
                            AgregarToken(Token.Tipo.MONEDA);

                        }
                        break;
                    case 1:
                        if (Char.IsDigit(variable))
                        {
                            estado = 1;
                            lexema += variable;
                        }
                        else if (variable.CompareTo('.') == 0)
                        {
                            estado = 2;
                            lexema += variable;
                        }
                        else
                        {
                            AgregarToken(Token.Tipo.NUMERO_ENTERO);
                            i -= 1;
                        }
                        break;


                    case 2:
                        if (Char.IsDigit(variable))
                        {
                            estado = 2;
                            lexema += variable;
                        }
                        else
                        {
                            AgregarToken(Token.Tipo.NUMERO_DECIMAL);
                            i -= 1;
                        }
                        break;

                    case 3:
                        if (Char.IsLetter(variable))
                        {
                            estado = 3;
                            lexema += variable;
                        }
                        else if (Char.IsLetter(variable))
                        {
                            lexema += variable;
                            AgregarToken(Token.Tipo.IDENTIFICADOR);

                        }
                        break;
                }

            }
            return Salida;
        }

        private void AgregarToken(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(tipo, lexema));
            lexema = "";
            estado = 0;
        }

        public void imprimirListaToken(LinkedList<Token> lista)
        {
            foreach (Token item in lista)
            {
                MessageBox.Show(item.GetTipo() + "<-->" + item.Getvalor());
            }

        }
    }
}

