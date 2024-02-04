using Microsoft.VisualStudio.TestPlatform.TestHost;
using лаб9;
using static лаб9.PostCollection;

namespace TestPost
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateEngagementRateStatic()
        {
            // Arrange
            var post = new Post(100, 20, 30);
            int totalSubscribers = 1000;

            // Act
            double engagementRate = Post.CalculateEngagementRateStatic(post, totalSubscribers);

            // Assert
            Assert.AreEqual(15, engagementRate); // ќжидаемый результат: 15%
        }

        [TestMethod]
        public void TestCalculateEngagementRate()
        {
            // Arrange
            var post = new Post(100, 20, 30);
            int totalSubscribers = 1000;

            // Act
            double engagementRate = post.CalculateEngagementRate(totalSubscribers);

            // Assert
            Assert.AreEqual(15, engagementRate); // ќжидаемый результат: 15%
        }

        [TestMethod]
        public void TestGetTotalPostCount()
        {
            // Arrange
            int initialCount = Post.GetTotalPostCount();

            // Act
            var post1 = new Post();
            var post2 = new Post();
            var post3 = new Post();

            int totalCount = Post.GetTotalPostCount();

            // Assert
            Assert.AreEqual(initialCount + 3, totalCount); // ќжидаемое количество объектов: initialCount + 3
        }

        [TestMethod]
        public void TestEqualityOperator()
        {
            // Arrange
            var post1 = new Post(100, 20, 30);
            var post2 = new Post(100, 20, 30);
            var post3 = new Post(200, 40, 60);

            // Act
            bool isEqual1 = post1 == post2;
            bool isEqual2 = post1 == post3;

            // Assert
            Assert.IsTrue(isEqual1); // ќжидаемый результат: true
            Assert.IsFalse(isEqual2); // ќжидаемый результат: false
        }

        [TestMethod]
        public void TestInequalityOperator()
        {
            // Arrange
            var post1 = new Post(100, 20, 30);
            var post2 = new Post(100, 20, 30);
            var post3 = new Post(200, 40, 60);

            // Act
            bool isNotEqual1 = post1 != post2;
            bool isNotEqual2 = post1 != post3;

            // Assert
            Assert.IsFalse(isNotEqual1); // ќжидаемый результат: false
            Assert.IsTrue(isNotEqual2); // ќжидаемый результат: true
        }

        [TestMethod]
        public void TestExplicitConversionToBool()
        {
            // Arrange
            var post1 = new Post(100, 20, 30);
            var post2 = new Post(0, 0, 0);

            // Act
            bool boolValue1 = (bool)post1;
            bool boolValue2 = (bool)post2;

            // Assert
            Assert.IsTrue(boolValue1); // ќжидаемый результат: true
            Assert.IsFalse(boolValue2); // ќжидаемый результат: false
        }

        [TestMethod]
        public void TestImplicitConversionToDouble()
        {
            // Arrange
            var post = new Post(1500, 100, 200);

            // Act
            double audienceCoverage = post;

            // Assert
            Assert.AreEqual(1.5, audienceCoverage); // ќжидаемый результат: 1.5
        }


        [TestMethod]
        public void TestEqualsMethod()
        {
            // Arrange
            var post1 = new Post(100, 20, 30);
            var post2 = new Post(100, 20, 30);
            var post3 = new Post(200, 40, 60);

            // Act
            bool isEqual1 = post1.Equals(post2);
            bool isEqual2 = post1.Equals(post3);

            // Assert
            Assert.IsTrue(isEqual1); // ќжидаемый результат: true
            Assert.IsFalse(isEqual2); // ќжидаемый результат: false
        }

        [TestClass]
        public class PostCollectionsTests
        {
            [TestMethod]
            public void TestDefaultConstructor()
            {
                // Arrange
                var postCollections = new PostCollections();

                // Assert
                Assert.IsNotNull(postCollections);
                Assert.AreEqual(0, postCollections.postArray.Length);
            }

            [TestMethod]
            public void TestParameterizedConstructor()
            {
                // Arrange
                var size = 5;
                var postCollections = new PostCollections(size);

                // Assert
                Assert.IsNotNull(postCollections);
                Assert.AreEqual(size, postCollections.postArray.Length);
            }

            [TestMethod]
            public void TestArrayConstructor()
            {
                // Arrange
                var posts = new Post[]
                {
                   new Post(100, 20, 30),
                   new Post(200, 40, 60),
                   new Post(300, 60, 90)
                };

                var postCollections = new PostCollections(posts);

                // Assert
                Assert.IsNotNull(postCollections);
                Assert.AreEqual(posts.Length, postCollections.postArray.Length);

                for (int i = 0; i < posts.Length; i++)
                {
                    Assert.AreEqual(posts[i].NumViews, postCollections.postArray[i].NumViews);
                    Assert.AreEqual(posts[i].NumComments, postCollections.postArray[i].NumComments);
                    Assert.AreEqual(posts[i].NumReactions, postCollections.postArray[i].NumReactions);
                }
            }

            [TestMethod]
            public void PostCollections_GetObjectCount_ReturnsCorrectCount()
            {
                // Arrange
                int initialCount = PostCollections.GetObjectCount();

                // Act
                PostCollections collection = new PostCollections();

                // Assert
                Assert.AreEqual(initialCount + 1, PostCollections.GetObjectCount());
            }

            [TestMethod]
            public void Equals_TwoEqualPosts_ShouldReturnTrue()
            {
                // Arrange
                var post1 = new Post(100, 5, 10);
                var post2 = new Post(100, 5, 10);

                // Act
                var areEqual = post1.Equals(post2);

                // Assert
                Assert.IsTrue(areEqual);
            }

            [TestMethod]
            public void Equals_TwoDifferentPosts_ShouldReturnFalse()
            {
                // Arrange
                var post1 = new Post(100, 5, 10);
                var post2 = new Post(200, 10, 20);

                // Act
                var areEqual = post1.Equals(post2);

                // Assert
                Assert.IsFalse(areEqual);
            }
            [TestMethod]
            public void GetObjectCount_ShouldReturnCorrectNumberOfCreatedObjects()
            {
                // Arrange

                // Act
                var objectCount = PostCollections.GetObjectCount();

                // Assert
                Assert.Equals(0, objectCount);
            }
            [TestMethod]
            public void GetCollectionCount_ShouldReturnCorrectNumberOfCreatedCollections()
            {
                // Arrange

                // Act
                var collectionCount = PostCollections.GetCollectionCount();

                // Assert
                Assert.Equals(0, collectionCount);
            }
        }
    }
}
    

    