namespace WhyLinq
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{nameof(StudentID)}: {StudentID}; {nameof(StudentName)}: {StudentName}; {nameof(Age)}: {Age};";
        }
    }
}
