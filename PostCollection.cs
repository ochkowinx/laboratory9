using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace лаб9
{
    public class PostCollection
    {
        public class PostCollections
        {
            public Post[] postArray;

            // Счетчики объектов и коллекций
            private static int objectCount;
            private static int collectionCount;

            // Конструктор без параметров
            public PostCollections()
            {
                postArray = new Post[0];
                objectCount++;
                collectionCount++;
            }

            // Конструктор с параметрами, заполняющий элементы случайными значениями
            public PostCollections(int size)
            {
                postArray = new Post[size];

                Random random = new Random();

                for (int i = 0; i < size; i++)
                {
                    postArray[i] = new Post();
                    postArray[i].NumViews = random.Next(0, 1000);
                    postArray[i].NumComments = random.Next(0, 1000);
                    postArray[i].NumReactions = random.Next(0, 1000);
                }

                objectCount++;
                collectionCount++;
            }

            // Конструктор с параметрами, позволяющий заполнить массив элементами, заданными пользователем с клавиатуры
            public PostCollections(Post[] posts)
            {
                postArray = new Post[posts.Length];

                for (int i = 0; i < posts.Length; i++)
                {
                    postArray[i] = new Post();
                    postArray[i].NumViews = posts[i].NumViews;
                    postArray[i].NumComments = posts[i].NumComments;
                    postArray[i].NumReactions = posts[i].NumReactions;
                }

                objectCount++;
                collectionCount++;
            }

            // Конструктор копирования, позволяющий создать копию коллекции
            public PostCollections (PostCollections collection)
            {
                postArray = new Post[collection.postArray.Length];

                for (int i = 0; i < collection.postArray.Length; i++)
                {
                    postArray[i] = new Post();
                    postArray[i].NumViews = collection.postArray[i].NumViews;
                    postArray[i].NumComments = collection.postArray[i].NumComments;
                    postArray[i].NumReactions = collection.postArray[i].NumReactions;
                }

                objectCount++;
                collectionCount++;
            }

            // Метод для просмотра элементов массива
            public void ViewPosts()
            {
                foreach (Post post in postArray)
                {
                    Console.WriteLine("просмотры: " + post.NumViews + ", комментарии: " + post.NumComments + ", реакции: " + post.NumReactions);
                }
            }

            // Индексатор для доступа к элементам коллекции
            public Post this[int index]
            {
                get
                {
                    if (index < 0 || index >= postArray.Length)
                    {
                        throw new IndexOutOfRangeException("индекс вне границ массива");
                    }

                    return postArray[index];
                }
                set
                {
                    if (index < 0 || index >= postArray.Length)
                    {
                        throw new IndexOutOfRangeException("индекс вне границ массива");
                    }

                    postArray[index] = value;
                }
            }

            // Метод для получения общего коэффициента вовлеченности по постам одного сообщества
            public double GetOverallEngagement()
            {
                int totalViews = 0;
                int totalComments = 0;
                int totalReactions = 0;

                foreach (Post post in postArray)
                {
                    totalViews += post.NumViews;
                    totalComments += post.NumComments;
                    totalReactions += post.NumReactions;
                }

                int subscribers = 1000;

                double engagement = (totalViews + totalComments + totalReactions) / subscribers;

                return engagement;
            }

            // Статический метод для получения количества созданных объектов
            public static int GetObjectCount()
            {
                return objectCount;
            }

            // Статический метод для получения количества созданных коллекций
            public static int GetCollectionCount()
            {
                return collectionCount;
            }
        }
    }
}
