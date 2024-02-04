using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static лаб9.PostCollection;

namespace лаб9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post1 = new Post();
            Post post2 = new Post(200, 10, 20);
            Post post3 = new Post(post2);


            post1.Show();
            post2.Show();
            post3.Show();

            Console.WriteLine($"коэффициент вовлеченности равен: {Post.CalculateEngagementRateStatic(post1, 1000)}");
            Console.WriteLine($"коэффициент вовлеченности равен: {post2.CalculateEngagementRate(1000)}");
            Console.WriteLine($"коэффициент вовлеченности равен: {post3.CalculateEngagementRate(1000)}");

            Console.WriteLine("количесво созданных постов: {0}", Post.GetTotalPostCount());
            
            Console.WriteLine(post1 == post2); 
            Console.WriteLine(post1 != post2);

            bool hasEngagement = (bool)post1;
            Console.WriteLine(hasEngagement); 

            double audienceCoverage = post1;
            Console.WriteLine(audienceCoverage); 

            post1++;
            Console.WriteLine(post1.NumViews); 

            post1 = !post1;
            Console.WriteLine(post1.NumReactions); 

            // Проверка метода Equals
            Console.WriteLine(post1.Equals(post3));

            int size = Input.GetPositiveInteger("Введите количество постов: ");

            Post[] posts = new Post[size];

            for (int i = 0; i < size; i++)
            {
                int views = Input.GetPositiveInteger("Введите количество просмотров для поста #" + (i + 1) + ":");

                int comments = Input.GetPositiveInteger("Введите количество комментариев для поста #" + (i + 1) + ":");

                int reactions = Input.GetPositiveInteger("Введите количество реакций для поста #" + (i + 1) + ":");

                posts[i] = new Post();
                posts[i].NumViews = views;
                posts[i].NumComments = comments;
                posts[i].NumReactions = reactions;
            }

            Console.WriteLine();

            // Создание массива с помощью случайной генерации
            PostCollection.PostCollections collection1 = new PostCollection.PostCollections(5);
            Console.WriteLine("Массив, заполненный случайными значениями:");
            collection1.ViewPosts();

            Console.WriteLine();

            // Создание новой коллекции на основе существующей
            PostCollection.PostCollections collection2 = new PostCollection.PostCollections(posts);
            Console.WriteLine("Новая коллекция, основанная на существующей:");
            collection2.ViewPosts();

            // Проверка глубокого копирования
            posts[0].NumViews = 100;
            Console.WriteLine("Исходная коллекция:");
            collection2.ViewPosts();

            Console.WriteLine();

            // Получение общего коэффициента вовлеченности
            Console.WriteLine("Общий коэффициент вовлеченности: " + collection2.GetOverallEngagement());

            Console.WriteLine();

            // Проверка работы индексатора
            Console.WriteLine("Получение объекта с существующим индексом:");
            Post post4 = collection2[0];
            Console.WriteLine("просмотры: " + post1.NumViews + ", комментарии: " + post1.NumComments + ", реакции: " + post1.NumReactions);

            Console.WriteLine("Получение объекта с несуществующим индексом:");
            try
            {
                Post post5 = collection2[10];
                Console.WriteLine("просмотры: " + post2.NumViews + ", комментарии: " + post2.NumComments + ", реакции: " + post2.NumReactions);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Подсчет количества созданных объектов и коллекций
            Console.WriteLine();
            Console.WriteLine("Количество созданных объектов: " + PostCollection.PostCollections.GetObjectCount());
            Console.WriteLine("Количество созданных коллекций: " + PostCollection.PostCollections.GetCollectionCount());


        Console.ReadLine();

        }

    }
}
