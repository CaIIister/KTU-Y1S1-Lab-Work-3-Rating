using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_2_Ratings_
{
    /// <summary>
    /// Class Rating to store single student and his evaluation
    /// </summary>
    class Rating
    {
        private int number;
        private string surname;
        private string name;
        private string answer;
        private string evaluation;
        private int grade;
        public Rating()
        {
            number = 1;
            surname = "Demchyna";
            name = "Taras";
            answer = "NTNNTNNTTT";
        }
        public Rating(int number, string surname, string name, string answer)
        {
            this.number = number;
            this.surname = surname;
            this.name = name;
            this.answer = answer;
        }
        public Rating(int number, string surname, string name, string answer, string evaluation, int grade)
        {
            this.number = number;
            this.surname = surname;
            this.name = name;
            this.answer = answer;
            this.evaluation = evaluation;
            this.grade = grade;
        }

        public int getNumber() { return number; }
        public string getSurname() { return surname; }
        public string getName() { return name; }
        public string getAnswer() { return answer; }
        public string getEvaluation() { return evaluation; }
        public int getGrade() { return grade; }
        public void setNumber(int number) { this.number = number; }
        public void setSurname(string surname) { this.surname = surname; }
        public void setName(string name) { this.name = name; }
        public void setAnswer(string answer) { this.answer = answer; }
        public void setEvaluation(string evaluation) { this.evaluation = evaluation; }
        public void setGrade(int grade) { this.grade = grade; }
        /// <summary>
        /// method Equals of Object class overriding
        /// </summary>
        /// <param name="myObject"></param>
        /// <returns></returns>
        public override bool Equals(object myObject)
        {
            Rating stud = myObject as Rating;
            return stud.grade == grade;
        }
        /// <summary>
        /// operator > overloading
        /// </summary>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        /// <returns></returns>
        public static bool operator >(Rating var1, Rating var2)
        {
            bool res = false;
            if (var1.grade > var2.grade)
            {
                res=true;
            }
            else if(var1.grade<var2.grade)
            {
                res=false;
            }
            else if(var1.grade.Equals(var2.grade))
            {
                if (String.Compare(var1.surname, var2.surname) <= 0)
                {
                    res = true;
                }
                else res = false;
            }
            return res;
        }
        /// <summary>
        /// operator < overloading
        /// </summary>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        /// <returns></returns>
        public static bool operator <(Rating var1, Rating var2)
        {
            bool res = false;
            if (var1.grade > var2.grade)
            {
                res = false;
            }
            else if (var1.grade < var2.grade)
            {
                res = true;
            }
            else if (var1.grade == var2.grade)
            {
                if (String.Compare(var1.surname, var2.surname) <= 0)
                {
                    res = false;
                }
                else res = true;
            }
            return res;
        }
        }
}
