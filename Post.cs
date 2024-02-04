using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб9
{
    public class Post
    {
        // атрибуты(поля)
        private int numViews; // кол-во просмотров
        private int numComments; // комм
        private int numReactions; // реакции
        private static int totalObjects = 0; //счетчик обьектов

        // конструктор с параметрами 
        public Post(int numViews, int numComments, int numReactions) 
        { 
            this.numViews = numViews;
            this.numComments = numComments;
            this.numReactions = numReactions;
            totalObjects++;
        }

        // конструктор without parametrs
        public Post()
        {
            numViews = 0;
            numComments = 0;
            numReactions = 0;
            totalObjects++;
        }


        // конструктор копирования
        public Post(Post post)
        {
            this.numViews = post.numViews;
            this.numComments = post.numComments;
            this.numReactions = post.numReactions;
            totalObjects++;
        }

        public void Show()
        {
            Console.WriteLine($"{numViews}, {numComments}, {numReactions}");
        }

        public int NumViews
        {
            get { return this.numViews; }
            set { this.numViews = value; }
        }

        public int NumComments
        {
            get { return this.numComments; }
            set { this.numComments = value; }
        }

        public int NumReactions
        {
            get { return this.numReactions; }
            set { this.numReactions = value; }
        }

        public static double CalculateEngagementRateStatic(Post post, int totalSubscribers)
        {
            return (post.NumViews + post.NumComments + post.NumReactions) / (double)totalSubscribers * 100;
        }

        public double CalculateEngagementRate(int totalSubscribers)
        {
            return (numViews + numComments + numReactions) / (double)totalSubscribers * 100;
        }

        public static int GetTotalPostCount() //статический метод
        {
            return totalObjects;
        }

        public static bool operator ==(Post p1, Post p2) // перегруженный оператор ==
        {
            return (p1.numViews == p2.numViews &&
                    p1.numComments == p2.numComments &&
                    p1.numReactions == p2.numReactions);
        }

        
        public static bool operator !=(Post p1, Post p2) // перегруженный оператор !=
        {
            return !(p1 == p2);
        }

        // перегруженный оператор приведения типа bool(явная)
        public static explicit operator bool(Post p)
        {
            return (p.numViews != 0 && (p.numComments != 0 || p.numReactions != 0));
        }

        // перегруженный оператор приведения типа double(неявная)
        public static implicit operator double(Post p)
        {
            double audienceCoverage = (double)(p.numViews) / 1000.0;
            return Math.Round(audienceCoverage, 2);
        }

        // перегруженный оператор !
        public static Post operator !(Post p)
        {
            p.numReactions++;
            return p;
        }

        // перегруженный оператор ++
        public static Post operator ++(Post p)
        {
            p.numViews++;
            return p;
        }

        // переопределение метода Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) //проверка является ли объект постом и имеет ли тот же тип
            {
                return false;
            }

            Post other = (Post)obj;
            return (numViews == other.numViews &&
                    numComments == other.numComments &&
                    numReactions == other.numReactions);
        }


    }
}
