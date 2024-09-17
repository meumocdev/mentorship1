namespace LinqFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Select_ShouldReturnTruePeople()
        {
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 },
                new Person { Id = 2, Name = "Jane", Age = 30 },
                new Person { Id = 3, Name = "Doe", Age = 35 },
                new Person { Id = 4, Name = "Alice", Age = 28 },
                new Person { Id = 5, Name = "Bob", Age = 32 }
            };

            var selectedNames = LinqLikeMethods.Select(people, person => person.Name).ToList();

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            var expectedNames = new List<string> { "John", "Jane", "Doe", "Alice", "Bob" };

            // Sử dụng CollectionAssert để so sánh 2 danh sách
            CollectionAssert.AreEqual(expectedNames, selectedNames);
        }

        [TestMethod] 
        public void Where_ShouldReturnPeopleAbove30()
        {
            // Arrange: Giả lập dữ liệu
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 },
                new Person { Id = 2, Name = "Jane", Age = 30 },
                new Person { Id = 3, Name = "Doe", Age = 35 },
                new Person { Id = 4, Name = "Alice", Age = 28 },
                new Person { Id = 5, Name = "Bob", Age = 32 }
            };

            // Act: Thực hiện phương thức Where để chọn những người có tuổi > 30
            var peopleAbove30 = LinqLikeMethods.Where(people, person => person.Age > 30).ToList();

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            var expectedPeople = new List<Person>
            {
                new Person { Id = 3, Name = "Doe", Age = 35 },
                new Person { Id = 5, Name = "Bob", Age = 32 }
            };

            // So sánh số lượng và nội dung của các phần tử
            Assert.AreEqual(expectedPeople.Count, peopleAbove30.Count);
            for (int i = 0; i < expectedPeople.Count; i++)
            {
                Assert.AreEqual(expectedPeople[i].Name, peopleAbove30[i].Name);
                Assert.AreEqual(expectedPeople[i].Age, peopleAbove30[i].Age);
            }
        }

        [TestMethod]
        public void Count_ShouldReturnCorrectCount()
        {
            // Arrange: Giả lập dữ liệu
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 },
                new Person { Id = 2, Name = "Jane", Age = 30 },
                new Person { Id = 3, Name = "Doe", Age = 35 },
                new Person { Id = 4, Name = "Alice", Age = 28 },
                new Person { Id = 5, Name = "Bob", Age = 32 }
            };

            // Act: Thực hiện phương thức Count
            var count = LinqLikeMethods.Count(people);

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(5, count); // Danh sách có 5 phần tử
        }

        [TestMethod]
        public void Sum_ShouldReturnCorrectSum()
        {
            // Arrange: Giả lập dữ liệu
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act: Thực hiện phương thức Sum
            var sum = LinqLikeMethods.Sum(numbers);

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(15, sum); // Tổng của [1, 2, 3, 4, 5] là 15
        }


        public class LinqLikeMethods
        {
            // Phương thức Select, tương tự như LINQ
            public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
            {
                foreach (var item in source)
                {
                    yield return selector(item);
                }
            }
            public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        yield return item;
                    }
                }
            }


            // Giả lập phương thức Count
            public static int Count<TSource>(IEnumerable<TSource> source)
            {
                int count = 0;
                foreach (var item in source)
                {
                    count++;
                }
                return count;
            }

            // Giả lập phương thức Sum
            public static int Sum(IEnumerable<int> source)
            {
                int sum = 0;
                foreach (var item in source)
                {
                    sum += item;
                }
                return sum;
            }
        }

        public class SelectTest
        {
            public static void RunSelectTest()
            {
                // Giả lập dữ liệu từ lớp DataGenerator
                List<Person> people = DataGenerator.GetPeople();

                // Sử dụng phương thức Select để lấy tên của mọi người
                var selectedNames = LinqLikeMethods.Select(people, person => person.Name);

                // In ra kết quả
                Console.WriteLine("Select_Test - Danh sách tên:");
                foreach (var name in selectedNames)
                {
                    Console.WriteLine(name);
                }
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        // Giả lập dữ liệu
        public static class DataGenerator
        {
            public static List<Person> GetPeople()
            {
                return new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 },
                new Person { Id = 2, Name = "Jane", Age = 30 },
                new Person { Id = 3, Name = "Doe", Age = 35 },
                new Person { Id = 4, Name = "Alice", Age = 28 },
                new Person { Id = 5, Name = "Bob", Age = 32 }
            };
            }
        }
    }
}