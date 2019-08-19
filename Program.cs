using System;
using System.Text.RegularExpressions;
using System.IO;


namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Expresiones regulares 
            Regex name = new Regex("[A-Z][a-z]{1,20}$");                //Nombre y Apellido
            Regex id = new Regex("^[V|E|J|G|C]-[0-9]+$");               //Cedula o RIF 
            Regex age = new Regex(@"^\d{1,3}$");                        //Edad 
            Regex address = new Regex("[/w|/b|/s/#/-]+");               //Direccion

            Regex[] expresiones = {name,name,id,age,address};

            
            //Chequeamos que se ingrese por consola al menos un string 
            if(args.Length < 1) 
            {
                Console.WriteLine("Debe ingresar al menos un (1) archivo de texto");
                System.Environment.Exit(1);
            }
            else
            {
                foreach(string file in args)
                { 
                    //Leemos archivo de texto linea por linea  
                    int index;
                    int lineNumber = 1;
                    string[] lines = File.ReadAllLines(file); 
                    foreach(string line in lines)
                    {
                        string[] words = line.Split("|");
                        if(words.Length != expresiones.Length)
                        {
                            Console.WriteLine("Existe un error con el numero de campos en el texto de entrada");
                            System.Environment.Exit(1);
                        }
                        else
                        {
                            index = 0;
                            foreach(string word in words)
                            {
                                //index = Array.IndexOf(words,word);
                                Match match = expresiones[index].Match(words[index]);
                                if (match.Success == false)
                                {
                                    //index = index + 1;
                                    Console.Write(" ERROR Linea: ");
                                    Console.Write(lineNumber);
                                    Console.Write(" Columna: ");
                                    Console.WriteLine(index+1);
                                }
                                index = index +1;
                            }
                            
                        }
                        lineNumber = lineNumber +1;
                    }
                
                }
            }
            
        }
    }
}
