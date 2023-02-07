using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_2_Ratings_
{
    /// <summary>
    /// Container class Ratings to store array of objects of class Rating
    /// </summary>
    class Ratings
    {
        private const int Nmax = 100;
        private Rating[] ratings;
        private int n;
        string nameFaculty;
        string correctAnswer;
        public Ratings()
        {
            n = 0;
            ratings = new Rating[Nmax];
        }
        public int get() { return n; }
        public Rating get(int index) { return ratings[index]; }
        public void add(Rating rating) { ratings[n++] = rating; }
        public string getNameFaculty() { return nameFaculty; }
        public string getCorrectAnswer() { return correctAnswer; }
        public void setNameFaculty(string nameFaculty) { this.nameFaculty = nameFaculty; }
        public void setCorrectAnswer(string correctAnswer) { this.correctAnswer = correctAnswer; }
        /// <summary>
        /// computes the evaluation of a single student
        /// </summary>
        /// <param name="index"></param>
        public void computeGrade(int index)
        {
            int buf = 0;
            for (int j = 0; j < correctAnswer.Length; j++)
            {
                if (ratings[index].getAnswer()[j] == correctAnswer[j])
                {
                    buf++;
                }
            }
            ratings[index].setGrade(buf);
        }
        /// <summary>
        /// Defines the best student in the group
        /// </summary>
        /// <returns></returns>
        public int theBestStudent()
        {
            int max = -1;
            for (int i = 0; i < n; i++)
            {
                computeGrade(i);
                int buf = ratings[i].getGrade();
                if (buf > max) max = buf;
            }
            return max;
        }
        /// <summary>
        /// marks each student with "Good","Satisfactory" or "Unsatisfactory" starting from defined best student
        /// </summary>
        public void evaluation()
        {
            int max = theBestStudent();
            for (int i = 0; i < n; i++)
            {
                if ((ratings[i].getGrade() == max) || (ratings[i].getGrade() == max - 1)) { ratings[i].setEvaluation("Good"); }
                else if ((ratings[i].getGrade() == max - 2) || (ratings[i].getGrade() == max - 3)) { ratings[i].setEvaluation("Satisfactory"); }
                else ratings[i].setEvaluation("Unsatisfactory");
            }
        }
        /// <summary>
        /// deletes one specific student from the group
        /// </summary>
        /// <param name="index"></param>
        public void pop(int index)
        {
            for (int i = index; i < n-1; i++)
            {
                ratings[i] = ratings[i + 1];
            }
            n=n-1;
        }
        /// <summary>
        /// deletes all students whose mark isn't "Good"
        /// </summary>
        public void kickBadStudents()
        {
            int m = 0;
            for(int i=0;i<n;i++)
            {
                if (ratings[i].getEvaluation() == "Good")
                {
                    ratings[m++]=ratings[i];
                }
            }
            n = m;
        }
    }
}
