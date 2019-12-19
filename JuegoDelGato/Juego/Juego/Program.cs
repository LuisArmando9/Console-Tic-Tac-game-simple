using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteGame();
            Console.ReadKey();


        }
        static void ExecuteGame()
        {
            int SelectChar;
           
         
                
                Console.Write("Bienvenido al juego del gato \n" +"" +
                "Las posiciones van del 1-9\n"+
                "Selecciona 0 si deseas  X o 1 si es 0>");
                SelectChar = Int32.Parse(Console.ReadLine());
                Gato NewGame = new Gato(SelectChar);
                Console.WriteLine(String.Format("Seleccionaste>{0}", NewGame.LetterUser));
                Console.WriteLine(String.Format("La pc es>{0}", NewGame.LetterPC));
                Console.Write("Presione una tecla para continuar");
                Console.ReadKey();
                while (true)
                {

                    try
                    {
                             Console.Clear();
                             
                                    NewGame.DrawTable();
                                    Console.Write("Selecciona una opcion del 1-9]>");
                                    NewGame.Position = Int32.Parse(Console.ReadLine());
                                    NewGame.AddElementGame();
                                    if(NewGame.ChecKWinner(NewGame.LetterPC))
                                    {
                                        Console.WriteLine("Gano la pc");
                                        break;

                                    }
                                    else if (NewGame.ChecKWinner(NewGame.LetterUser))
                                    {
                                        Console.WriteLine("Gano el usuario");
                                        break;

                                    }
                                    else if ((NewGame.Attemps == 9) && !NewGame.ChecKWinner(NewGame.LetterPC)
                                                    && !NewGame.ChecKWinner(NewGame.LetterUser))
                                            
                                    {
                                            Console.WriteLine("Nadie gano");
                                            break;
                                    }


                            
                             Console.WriteLine("Presiona una tecla.....");
                             Console.ReadKey();


                    }
                    catch
                    {
                    Console.WriteLine("Opcion incorrecta\n");

                    }



                }

            
         
       
            
            
        }
    }
}
