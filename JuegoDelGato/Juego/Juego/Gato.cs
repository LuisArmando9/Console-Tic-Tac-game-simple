using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Juego
{
    class Gato
    {
        //atributos
        private char[,] ContainerPositionLetters;
        private char SelectLetterUser;
        private char SelectLetterPC;
        List<int> TempNumberSerie;
       
        private char[] AvailableLetters = new char[2] {'X', 'O'};
        //propiedades
        int PositionUsed, CheckPosicionBusy;
        public int Position
        {
            get
            { return PositionUsed;}
            set
            {PositionUsed = value;}
        }
      
        public Char LetterPC
        {
            get{return SelectLetterPC;}
        }
        public Char LetterUser
        {
            get { return SelectLetterUser; }
        }
        public int Attemps
        {
            get { return CheckPosicionBusy; }
        }
  
        public Gato(int LetterUsed)
        {
            ContainerPositionLetters = new char[3, 3];
            SelectLetterUser = AvailableLetters[LetterUsed];
            SelectLetterPC = AvailableLetters[LetterUsed == 1 ? 0 : 1];
            CheckPosicionBusy = 0;
            TempNumberSerie = new List<int>() {1,2,3,4,5,6,7,8,9 };
        }

        
        private bool  AddElement(char Letter)
        {
            int Position = 1;

            for (int i = 0; i < 3; i++)
                for (int y = 0; y < 3; y++)
                {
                    if ((Position == this.Position) && (ContainerPositionLetters[i, y] == 0))
                    {
                        ContainerPositionLetters[i, y] = Letter;
                        CheckPosicionBusy++;
                        return true;

                    }

                    Position++;
                }
            return false;
        }
       
        public  bool ChecKWinner(char letter)
        {
            int CountCheckletterH = 0, CountCheckletterV = 0, CountCheckletterD =0, CountCheckletterDi=0;
            for(int i = 0; i<3; i++)
            {
              
              for(int y = 0; y<3; y++)
                {
                    //checara las posiciones  horizontales
                    if (ContainerPositionLetters[i, y] == letter)
                         CountCheckletterH++;
                    //checara las posiciones verticales
                    if (ContainerPositionLetters[y, i] == letter )
                         CountCheckletterV++;


                }
               //checara las posiciones de diagonal 
               if (ContainerPositionLetters[i, i] == letter)
                        CountCheckletterD++;
                //checara las posiciones de la diagonal invertida
                if (ContainerPositionLetters[2 - i, i] == letter)
                    CountCheckletterDi++;
                //verifica si alguna de las opciones tiene 3 elementos iguales 
                if ((CountCheckletterH == 3) || (CountCheckletterV == 3) ||(CountCheckletterD == 3 ) 
                    || (CountCheckletterDi ==3 ))
                {
                    CountCheckletterD = 0;
                    CountCheckletterDi = 0;
                    return true;
                }
                   
             
                 CountCheckletterH = 0;
                 CountCheckletterV = 0;

            }
         

            return false;

        }
        public void DrawTable()
        {
            int CounTempY = 0, NumberF;
            Decimal TempNumber;
            //imprime un cuadrado de multiplos de 3 para poder imprimir las lineas horizontales y verticales
            for (int i = 1; i <= 12; i++)
            {
                for (int y = 0; y < 18; y++)
                {
                    if ((y % 6 == 0) && y != 0)
                        Console.Write("|");
                    if ((i % 4 == 0))
                        Console.Write("_");
                    else
                    {

                        if (i % 2 == 0 && y % 6 == 0)
                        {
                            TempNumber = Decimal.Divide(i, 3);
                            NumberF = ((int)Math.Round(TempNumber)) - 1;
                            Console.Write(ContainerPositionLetters[NumberF, CounTempY]);
                            CounTempY++;
                        }
                        else
                            Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
                CounTempY = 0;
            }

        }
        public void AddElements()
        {
           Random rnd = new Random();
            int Number = 0;
            // se añade el elemento del usuario
            if (AddElement(SelectLetterUser) && TempNumberSerie.Count() != 1)
            {
               
                // se crea un numero aleatorio, para que la pc pueda posicionarse
                TempNumberSerie.Remove(this.Position);
               
                  //genera un numero aleatorio disponible
                 Number = (int)rnd.Next(0, TempNumberSerie.Count());
                 this.Position = TempNumberSerie[Number];
                 AddElement(SelectLetterPC);
                 TempNumberSerie.Remove(this.Position);
            }
         
           
            
           
 
        }
       

    }
}