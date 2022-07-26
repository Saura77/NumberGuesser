using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            getAppVars();

            greetUser();

            while (true) {

                //Getting the random number that user has to guess
                Random myObject = new Random();
                int n = myObject.Next(1, 100);

                //Asking user for the number
                Console.WriteLine("Ingrese un número del 1 al 100");

                //Var with the user's number
                int x;

                //Program´s logic 
                do
                {
                    //Getting the input´s value
                    string s = Console.ReadLine();

                    //Make sure that the input value is a number 
                    if (!int.TryParse(s, out x))
                    {
                        /*Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tipo de dato incorrecto. Seleccione un número entero");*/
                        writeColorMessage(ConsoleColor.Red, "Tipo de dato incorrecto. Seleccione un número entero");
                        continue;
                    }

                    //Parsing the string to int
                    x = int.Parse(s);

                    if (x == 0 || x > 100)
                    {
                        writeColorMessage(ConsoleColor.Red, "Su número se encuentra fuera del rango 1-100. Seleccione otro número.");
                        continue;
                    }

                    if (x < n)
                    {
                        writeColorMessage(ConsoleColor.Magenta, "El número seleccionado es MENOR. Seleccione otro.");
                    }
                    else if (x > n)
                    {
                        writeColorMessage(ConsoleColor.Yellow, "El número seleccionado es MAYOR. Seleccione otro.");
                    }
                } while (x != n);

                writeColorMessage(ConsoleColor.Green, "Felicitaciones. Ha ganado el juego.");

                Console.WriteLine("¿Quieres jugar de nuevo? [Y/ N]");

                string answer;

                do
                {
                    answer = Console.ReadLine().ToUpper();

                    if (answer != "Y" && answer != "N")
                    {
                        writeColorMessage(ConsoleColor.Red, "Caracter inválido. Seleccione Y o N");
                    }
                } while (answer != "Y" && answer != "N");


                if (answer == "Y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    return;
                }
            }

        }

            
        static void getAppVars()
        {
            //App vars
            string appName = "NumberGuesser";
            string appVersion = "1.0.0";
            string appAuthor = "Nicolás Saurina";

            //Set console color

            Console.ForegroundColor = ConsoleColor.Green;

            //App properties
            Console.WriteLine("{0}: {1} by {2}", appName, appVersion, appAuthor);

            //Set console color again
            Console.ResetColor();
        }

        static void greetUser()
        {
            //Ask for user´s name
            Console.WriteLine("Por favor, ingrese su nombre");

            //Getting the input´s value
            string name = Console.ReadLine();

            //Gretting user
            Console.WriteLine("Bienvenido, {0}, vamos a jugar a un juego. ", name);
        }

        static void writeColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
