using System;

namespace NumConverter {
    public class Converter {
        public Converter() {
            Ones = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            Teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            Tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        }

        private string[] Ones { get; }
        private string[] Teens { get; }
        private string[] Tens { get; }

        public void Controller( long num ) {
            if( num < 10 ) {
                ones( num );
            } else if( num < 20 ) {
                teens( num );
            } else if( num < 100 ) {
                tens( num );
            } else if( num < 1000 ) {
                LargeValuePrint( num, 100, "Hundred" );
            } else if( num < 1000000 ) {
                LargeValuePrint( num, 1000, "Thousand" );
            } else if( num < 1000000000 ) {
                LargeValuePrint( num, 1000000, "Million" );
            } else if( num <= 2147483648 ) {
                LargeValuePrint( num, 1000000000, "Billion" );
            }
        }

        public void ones( long num ) => Console.Write( $"{Ones[num]} " );

        public void teens( long num ) => Console.Write( $"{Teens[num - 10]} " );

        public void tens( long num ) {

            Console.Write( $"{Tens[( num - 20 ) / 10]} " );

            if((num -= ((num/10) * 10)) > 0 ) {
                Controller( num );
            }
        }

        public void LargeValuePrint( long num, int divider, string name ) {
            var stored = num / divider;

            string n = name;

            num -= ( stored * divider );

            Controller( stored );

            Console.Write( $"{n} " );

            if( num % divider != 0 ) {
                Controller( num );
            }
        }
    }
}