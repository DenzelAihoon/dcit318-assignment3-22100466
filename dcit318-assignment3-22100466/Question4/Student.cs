namespace Question4;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public decimal Score { get; set; }

    public Student(int id, string fullName, decimal score)
    {
        Id = id;
        FullName = fullName;
        Score = score;
    }

    public string GetGrade()
    {
        if (Score >= 80)
            return "A";
        else if (Score >= 70)
            return "B";
        else if (Score >= 60)
            return "C";
        else if (Score >= 50)
            return "D";
        else
            return "F";
    }
}
