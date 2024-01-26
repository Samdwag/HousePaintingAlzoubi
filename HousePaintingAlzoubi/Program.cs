using static System.Console;

/*
 * Sami Alzoubi
 * CPSC 23000
 * January 25th, 2024
 * House Painting
 */


namespace HousePaintingAlzoubi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Print the welcome banner
            WriteLine("*********************************");
            WriteLine("House Painter V1.0");
            WriteLine("*********************************");
            WriteLine();

            // Ask how many rooms
            int roomNumbers = 0;

            do
            {
                Write("How many rooms do you plan to paint? ");

                try
                {
                    // reads their lines
                    roomNumbers = int.Parse(ReadLine());

                    if (roomNumbers <= 0)
                    {
                        WriteLine("Please enter a valid positive number of rooms.");
                        continue;
                    }

                    // this will be storing the pain area and primer area combined
                    double combinedPaintArea = 0;
                    double combinedPrimerArea = 0;

                    // Loop through each room
                    for (int i = 1; i <= roomNumbers; i++)
                    {
                        WriteLine($"\nRoom {i}:");

                        // Ask for room dimensions
                        double length, width, height;
                        try
                        {
                            Write("Enter length of the room: ");
                            length = double.Parse(ReadLine());

                            Write("Enter width of the room: ");
                            width = double.Parse(ReadLine());

                            Write("Enter height of the room: ");
                            height = double.Parse(ReadLine());
                        }
                        catch (FormatException)
                        {
                            WriteLine("Invalid input. Please enter valid numeric values for room dimensions.");
                            i--; // will repeat 
                            continue;
                        }

                        // Ask whether to use primer and paint ceiling
                        Write("Do you want to use primer? (yes/no): ");
                        bool usePrimer = ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase); // will read it whether its YES or yes

                        Write("Do you want to paint the ceiling? (yes/no): ");
                        bool paintCeiling = ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);

                        // Calculate area for paint and primer
                        double roomArea = 2 * (length * height + width * height) + (paintCeiling ? length * width : 0);
                        combinedPaintArea += roomArea;
                        combinedPrimerArea += usePrimer ? roomArea : 0;
                    }

                    // Calculate gallons required
                    double gallonsOfPaint = combinedPaintArea / 400;
                    double gallonsOfPrimer = combinedPrimerArea / 250;

                    // Display results
                    WriteLine($"\nTotal area to be painted: {combinedPaintArea} square feet");
                    WriteLine($"Total gallons of paint required: {gallonsOfPaint:F2}");

                    WriteLine($"Total area to be primed: {combinedPrimerArea} square feet");
                    WriteLine($"Total gallons of primer required: {gallonsOfPrimer:F2}");

                    // Show the goodbye message
                    WriteLine("\nThank you for using the House Painting Calculator!");
                }
                catch (FormatException)
                {
                    WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (roomNumbers <= 0); // makes you repeat till you put a positive number
        }
    }
}
