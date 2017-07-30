using WhyLinq;

namespace UnitTestWhyLinq
{
    //Example: Use delegates to find elements from the collection in C# 2.0
    public class DotNet20
    {
        private delegate bool FindStudent(Student std);

        private static Student[] Where(Student[] stdArray, FindStudent del)
        {
            int i = 0;
            Student[] result = new Student[10];
            foreach (Student std in stdArray)
                if (del(std))
                {
                    result[i] = std;
                    i++;
                }

            return result;
        }

        public Student[] GetStudents(Student[] studentArray)
        {
            Student[] students = Where(studentArray, delegate (Student std) {
                return std.Age > 12 && std.Age < 20;
            });

            //Student[] students = StudentExtension.where(studentArray, delegate (Student std) {
            //    return std.StudentID == 5;
            //});

            //Also, use another criteria using same delegate
            //Student[] students = StudentExtension.where(studentArray, delegate (Student std) {
            //    return std.StudentName == "Bill";
            //});

            return students;
        }
    }
    
}
