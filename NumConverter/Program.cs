using System;

namespace NumConverter {
    class Program {
        public static object Toint32 { get; private set; }

        static void Main( string[] args ) {

            Console.WriteLine( "Enter a number: " );

            // num stores the user input.
            var num = Console.ReadLine();

            // This determines if what the user inputed is a valid int and if so it will call the class to convert it.
            // Otherwise it will throw an expection stating that the input was invalid.
            if( Int32.TryParse( num, out int number ) ) {

                long NumberForConversion = number;

                if( NumberForConversion < 0 ) {
                    Console.WriteLine( "Negative" );
                    NumberForConversion *= -1;
                }

                Converter convert = new Converter();
                convert.Controller( NumberForConversion );

            } else {
                throw new ArgumentException( $"{num} is not valid input." );
            }

        }
    }
}
