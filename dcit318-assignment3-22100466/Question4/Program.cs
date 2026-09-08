using Question4;

StudentResultProcessor processor = new StudentResultProcessor();

string inputFile = "students.txt";
string outputFile = "student_report.txt";

try
{
    List<Student> students =
        processor.ReadStudentsFromFile(inputFile);

    processor.WriteReportToFile(outputFile, students);

    Console.WriteLine("Student results processed successfully.");
    Console.WriteLine($"Report saved to: {outputFile}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File not found: {ex.Message}");
}
catch (InvalidScoreFormatException ex)
{
    Console.WriteLine($"Invalid score format: {ex.Message}");
}
catch (Question4.MissingFieldException ex)
{
    Console.WriteLine($"Missing field: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}
