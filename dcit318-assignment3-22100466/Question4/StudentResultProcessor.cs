namespace Question4;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string filePath)
    {
        List<Student> students = new List<Student>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(',');

                if (fields.Length != 3)
                {
                    throw new MissingFieldException(
                        "Student record must contain ID, FullName and Score."
                    );
                }

                if (string.IsNullOrWhiteSpace(fields[0]) ||
                    string.IsNullOrWhiteSpace(fields[1]) ||
                    string.IsNullOrWhiteSpace(fields[2]))
                {
                    throw new MissingFieldException(
                        "A required student field is missing."
                    );
                }

                if (!int.TryParse(fields[0], out int id))
                {
                    throw new InvalidScoreFormatException(
                        "Student ID must be a valid number."
                    );
                }

                if (!decimal.TryParse(fields[2], out decimal score))
                {
                    throw new InvalidScoreFormatException(
                        $"Invalid score format for student: {fields[1]}"
                    );
                }

                students.Add(
                    new Student(id, fields[1], score)
                );
            }
        }

        return students;
    }

    public void WriteReportToFile(
        string filePath,
        List<Student> students)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Student student in students)
            {
                writer.WriteLine(
                    $"{student.FullName} (ID: {student.Id}): " +
                    $"Score = {student.Score}, Grade = {student.GetGrade()}"
                );
            }
        }
    }
}
