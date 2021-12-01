using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Inheritance_Liskov
{

    //3.1

    class Shape
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }
    class Rectangle :Shape
    {
        public int GetArea()
        {
            return Width * Height;
        }
    }
    class Square : Shape
    {
        public override int Height
        {
            get => base.Height;
            set => base.Height = base.Width = value;
        }
        public override int Width
        {
            get => base.Width;
            set => base.Width = base.Height = value;
        }
        public int GetArea()
        {
            return Width * Width;
        }
    }


    /*wyobraźmy sobie, że mamy metodę dla prostokątów która zwiększa pole / jeden bo o 0.1, i teraz gdy dostaniemy kolekcję tylko prostokątów jest ok, ale gdy dostaniemy kwardrat to zwiększamy jego pole o 0.21 co jest błędem. Ponadto 
    
        Rectangle r1 = new Square();
        r1.Height = 4;
        r1.Width = 5;
 
        Rectangle r2 = new Square();
        r2.Width = 5;
        r2.Height = 4;
 
        bool match = r1.Height == r2.Height && r1.Width == r2.Width;    // match = False
     
    taki przykład także będzie problematyczny gdyż powstaną 2 różne kwadraty z tych samych prostokątów
    łamiemy zasadę liskov zmieniając tak naprawdę funkcjonalność klasy dziedziczącej
    propozycja rozwiązania:
    zrobić nową nadklasę figura i po niej podziedziczyć zarówno prostkątem jak i kwadratem co uniemożliwi takiej operacji: Rectangle r1 = new Square();
    */
}
