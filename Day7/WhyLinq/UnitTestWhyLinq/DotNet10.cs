namespace WhyLinq
{
    //Example: Use for loop to find elements from the collection in C# 1.0
    public class DotNet10
    {
        public Student[] GetStudents(Student[] studentArray)
        {
            Student[] students = new Student[10];

            int i = 0;

            foreach (Student std in studentArray)
            {
                if (std.Age > 12 && std.Age < 20)
                {
                    students[i] = std;
                    i++;
                }
            }

            return students;
        }
    }
}
