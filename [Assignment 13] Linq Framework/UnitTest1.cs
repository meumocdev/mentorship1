using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            var expectedNames = new List<string> { "John", "Jane", "Doe", "Alice", "Bob" };

           
            CollectionAssert.AreEqual(expectedNames, selectedNames);
        }

        [TestMethod] 
        public void Where_ShouldReturnPeopleAbove30()
        {
            // Arrange:
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

            // Act: 
            var count = LinqLikeMethods.Count(people);

            // Assert: 
            Assert.AreEqual(5, count); 
        }

        [TestMethod]
        public void DCount_ShouldReturnCorrectCountOfPeopleAbove30()
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

            // Act: Thực hiện phương thức DCount để đếm những người có tuổi > 30
            var countAbove30 = LinqLikeMethods.DCount(people, person => person.Age > 30);

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(2, countAbove30); // Có 2 người có tuổi lớn hơn 30
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

        [TestMethod]
        public void GroupBy_ShouldGroupPeopleByEvenAndOddAge()
        {
            // Arrange: Giả lập dữ liệu
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 }, // Odd
                new Person { Id = 2, Name = "Jane", Age = 30 }, // Even
                new Person { Id = 3, Name = "Doe", Age = 35 },  // Odd
                new Person { Id = 4, Name = "Alice", Age = 28 }, // Even
                new Person { Id = 5, Name = "Bob", Age = 32 }   // Even
            };

            // Act: Thực hiện phương thức GroupBy dựa trên việc phân loại tuổi lẻ và tuổi chẵn
            var groupedPeople = LinqLikeMethods.GroupBy(people, person => person.Age % 2 == 0 ? "Even" : "Odd").ToList();

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(2, groupedPeople.Count); // Có 2 nhóm: "Even" và "Odd"

            // Kiểm tra nhóm "Odd"
            var oddGroup = groupedPeople.First(g => g.Key == "Odd");
            var expectedOddNames = new List<string> { "John", "Doe" };
            CollectionAssert.AreEqual(expectedOddNames, oddGroup.Select(p => p.Name).ToList());

            // Kiểm tra nhóm "Even"
            var evenGroup = groupedPeople.First(g => g.Key == "Even");
            var expectedEvenNames = new List<string> { "Jane", "Alice", "Bob" };
            CollectionAssert.AreEqual(expectedEvenNames, evenGroup.Select(p => p.Name).ToList());
        }

        [TestMethod]
        public void GroupByToKeyValueList_ShouldGroupPeopleByEvenAndOddAge()
        {
            // Arrange: Giả lập dữ liệu
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 }, // Odd
                new Person { Id = 2, Name = "Jane", Age = 30 }, // Even
                new Person { Id = 3, Name = "Doe", Age = 35 },  // Odd
                new Person { Id = 4, Name = "Alice", Age = 28 }, // Even
                new Person { Id = 5, Name = "Bob", Age = 32 }   // Even
            };

            // Act: Thực hiện phương thức GroupByToDictionary dựa trên tuổi chẵn và lẻ
            var groupedPeople = LinqLikeMethods.GroupByToDictionary(people, person => person.Age % 2 == 0 ? "Even" : "Odd");

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(2, groupedPeople.Count); // Có 2 nhóm: "Even" và "Odd"

            // Kiểm tra nhóm "Odd"
            var expectedOddNames = new List<string> { "John", "Doe" };
            var oddGroup = groupedPeople["Odd"];
            CollectionAssert.AreEqual(expectedOddNames, oddGroup.Select(p => p.Name).ToList());

            // Kiểm tra nhóm "Even"
            var expectedEvenNames = new List<string> { "Jane", "Alice", "Bob" };
            var evenGroup = groupedPeople["Even"];
            CollectionAssert.AreEqual(expectedEvenNames, evenGroup.Select(p => p.Name).ToList());
        }

        [TestMethod]
        public void Max_ShouldReturnCorrectMaxAge()
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

            // Act: Thực hiện phương thức Max để tìm tuổi lớn nhất
            var maxAge = LinqLikeMethods.Max(
                people,
                person => person.Age // Selector: Lấy độ tuổi
            );

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(35, maxAge); // Tuổi lớn nhất là 35
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Max_ShouldThrowExceptionWhenSourceIsEmpty()
        {
            // Arrange: Giả lập danh sách rỗng
            var people = new List<Person>();

            // Act & Assert: Thực hiện Max và kiểm tra nếu tập hợp không có phần tử nào
            LinqLikeMethods.Max(
                people,
                person => person.Age // Selector: Lấy độ tuổi
            );
        }

        [TestMethod]
        public void DMax_ShouldReturnCorrectMaxAgeForPeopleAbove30()
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

            // Act: Thực hiện phương thức DMax để tìm tuổi lớn nhất của những người trên 30 tuổi
            var maxAgeAbove30 = LinqLikeMethods.DMax(
                people,
                person => person.Age > 30,  // Predicate: Lọc những người trên 30 tuổi
                person => person.Age         // Selector: Lấy độ tuổi
            );

            // Assert: Kiểm tra kết quả trả về đúng như mong đợi
            Assert.AreEqual(35, maxAgeAbove30); // Tuổi lớn nhất của người trên 30 là 35
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DMax_ShouldThrowExceptionWhenNoMatchingElements()
        {
            // Arrange: Giả lập dữ liệu với những người có tuổi <= 30
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "John", Age = 25 },
                new Person { Id = 2, Name = "Jane", Age = 30 },
                new Person { Id = 3, Name = "Doe", Age = 28 },
                new Person { Id = 4, Name = "Alice", Age = 20 }
            };

            // Act & Assert: Thực hiện DMax và kiểm tra nếu không có phần tử nào thỏa mãn điều kiện
            LinqLikeMethods.DMax(
                people,
                person => person.Age > 30,  // Predicate: Lọc những người trên 30 tuổi
                person => person.Age         // Selector: Lấy độ tuổi
            );
        }
        [TestClass]
        public class LinqLikeMethodsTests
        {
            [TestMethod]
            public void LeftJoin_ShouldReturnCorrectResults()
            {
                // Arrange: Giả lập dữ liệu
                var people = new List<Person>
            {
                new Person { Id = 1, Name = "John" },
                new Person { Id = 2, Name = "Jane" },
                new Person { Id = 3, Name = "Doe" }
            };

                var orders = new List<Order>
            {
                new Order { OrderId = 1, PersonId = 1, Product = "Laptop" },
                new Order { OrderId = 2, PersonId = 1, Product = "Phone" },
                new Order { OrderId = 3, PersonId = 2, Product = "Tablet" }
            };

                // Act: Thực hiện phương thức LeftJoin
                var leftJoinResult = LinqLikeMethods.LeftJoin(
                    people,
                    orders,
                    person => person.Id,
                    order => order.PersonId,
                    (person, order) => new
                    {
                        PersonName = person.Name,
                        Product = order?.Product
                    }
                ).ToList();

                // Assert: Kiểm tra kết quả trả về đúng như mong đợi
                Assert.AreEqual(4, leftJoinResult.Count); // Kết quả có 4 dòng vì có 3 người, John có 2 đơn hàng
                Assert.AreEqual("John", leftJoinResult[0].PersonName);
                Assert.AreEqual("Laptop", leftJoinResult[0].Product);

                Assert.AreEqual("John", leftJoinResult[1].PersonName);
                Assert.AreEqual("Phone", leftJoinResult[1].Product);

                Assert.AreEqual("Jane", leftJoinResult[2].PersonName);
                Assert.AreEqual("Tablet", leftJoinResult[2].Product);

                Assert.AreEqual("Doe", leftJoinResult[3].PersonName);
                Assert.IsNull(leftJoinResult[3].Product); // Doe không có đơn hàng
            }
        }
        public class LinqLikeMethods
        {
            // Select
            public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
            {
                foreach (var item in source)
                {
                    yield return selector(item);
                }
            }

            //Where
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


            // Count
            public static int Count<TSource>(IEnumerable<TSource> source)
            {
                int count = 0;
                foreach (var item in source)
                {
                    count++;
                }
                return count;
            }

            // Phương thức DCount để đếm các phần tử thỏa mãn predicate
            public static int DCount<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                int count = 0;
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        count++;
                    }
                }
                return count;
            }

            // Sum
            public static int Sum(IEnumerable<int> source)
            {
                int sum = 0;
                foreach (var item in source)
                {
                    sum += item;
                }
                return sum;
            }

            public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            {
                var lookup = new Dictionary<TKey, List<TSource>>();

                foreach (var item in source)
                {
                    TKey key = keySelector(item);
                    if (!lookup.ContainsKey(key))
                    {
                        lookup[key] = new List<TSource>();
                    }
                    lookup[key].Add(item);
                }

                foreach (var group in lookup)
                {
                    yield return new Grouping<TKey, TSource>(group.Key, group.Value);
                }
            }

            // Lớp Grouping để giữ nhóm kết quả
            public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
            {
                private readonly TKey _key;
                private readonly IEnumerable<TElement> _group;

                public Grouping(TKey key, IEnumerable<TElement> group)
                {
                    _key = key;
                    _group = group;
                }

                public TKey Key => _key;

                public IEnumerator<TElement> GetEnumerator()
                {
                    return _group.GetEnumerator();
                }

                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return _group.GetEnumerator();
                }
            }

            // Phương thức GroupBy để trả về Dictionary<TKey, List<TSource>>
            public static Dictionary<TKey, List<TSource>> GroupByToDictionary<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            {
                var lookup = new Dictionary<TKey, List<TSource>>();

                foreach (var item in source)
                {
                    TKey key = keySelector(item);
                    if (!lookup.ContainsKey(key))
                    {
                        lookup[key] = new List<TSource>();
                    }
                    lookup[key].Add(item);
                }

                return lookup;
            }

            // Phương thức LeftJoin để thực hiện Left Join
            public static IEnumerable<TResult> LeftJoin<TLeft, TRight, TKey, TResult>(
                IEnumerable<TLeft> left,
                IEnumerable<TRight> right,
                Func<TLeft, TKey> leftKeySelector,
                Func<TRight, TKey> rightKeySelector,
                Func<TLeft, TRight?, TResult> resultSelector)
            {
                var rightLookup = right.ToLookup(rightKeySelector);
                foreach (var leftItem in left)
                {
                    var leftKey = leftKeySelector(leftItem);
                    var rightItems = rightLookup[leftKey];

                    if (rightItems.Any())
                    {
                        foreach (var rightItem in rightItems)
                        {
                            yield return resultSelector(leftItem, rightItem);
                        }
                    }
                    else
                    {
                        yield return resultSelector(leftItem, default);
                    }
                }
            }

            // Max để tìm giá trị lớn nhất từ một tập hợp dựa trên selector
            public static TResult Max<TSource, TResult>(
                IEnumerable<TSource> source,
                Func<TSource, TResult> selector)
                where TResult : IComparable<TResult>
            {
                if (source == null || !source.Any())
                {
                    throw new InvalidOperationException("Sequence contains no elements.");
                }

                TResult maxValue = selector(source.First());

                foreach (var item in source.Skip(1))
                {
                    var selectedValue = selector(item);
                    if (selectedValue.CompareTo(maxValue) > 0)
                    {
                        maxValue = selectedValue;
                    }
                }

                return maxValue;
            }

            // Dmax
            public static TResult DMax<TSource, TResult>(
           IEnumerable<TSource> source,
           Func<TSource, bool> predicate,
           Func<TSource, TResult> selector)
           where TResult : IComparable<TResult>
            {
                var filteredItems = source.Where(predicate).Select(selector);

                if (!filteredItems.Any())
                {
                    throw new InvalidOperationException("Sequence contains no matching elements.");
                }

                return filteredItems.Max();
            }


        }




        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Order
        {
            public int OrderId { get; set; }
            public int PersonId { get; set; }
            public string Product { get; set; }
        }

    }
}
