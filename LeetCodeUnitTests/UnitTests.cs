using LeetCodeExamples;

namespace LeetCodeUnitTests
{
    public class UnitTests
    {
        [Fact]
        public void RunTests()
        {
            RomanToIntTests.RunTests();
            CustomLinkedListTests.RunTests();
        }

        public class CustomLinkedListTests
        {
            [Fact]
            public static void RunTests()
            {
                LinkedList_CreateTest();
                LinkedList_RecursiveReversedTest();
                LinkedList_IterativeReversedTest();
            }

            [Fact]
            private static void LinkedList_CreateTest()
            {
                CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
                customLinkedList.Push(1);
                customLinkedList.Push(2);
                customLinkedList.Push(3);
                CustomLinkedList<int>.Node? node = customLinkedList.Head;
                if (node.Data != 3)
                {
                    Assert.Fail("LinkedList_CreateTest failed: Head should be 3");
                }
                node = node.Next;
                if (node.Data != 2)
                {
                    Assert.Fail("LinkedList_CreateTest failed: Head.Next should be 2");
                }
                node = node.Next;
                if (node.Data != 1)
                {
                    Assert.Fail("LinkedList_CreateTest failed: Head.Next.Next should be 1");
                }

                Assert.True(true, "LinkedList_CreateTest Passed.");
            }

            [Fact]
            private static void LinkedList_RecursiveReversedTest()
            {
                CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
                customLinkedList.Push(1);
                customLinkedList.Push(2);
                customLinkedList.Push(3);
                customLinkedList.Head = customLinkedList.RecursiveReverseLinkedList(customLinkedList.Head);
                CustomLinkedList<int>.Node? node = customLinkedList.Head;

                if (node.Data != 1)
                {
                    Assert.Fail("LinkedList_RecursiveReversedTest failed: Head should be 1");
                    return;
                }

                node = node.Next;
                if (node.Data != 2)
                {
                    Assert.Fail("LinkedList_RecursiveReversedTest failed: Head.Next should be 2");
                    return;
                }

                node = node.Next;
                if (node.Data != 3)
                {
                    Assert.Fail("LinkedList_RecursiveReversedTest failed: Head.Next.Next should be 3");
                    return;
                }

                Assert.True(true, "LinkedList_RecursiveReversedTest Passed.");
            }

            [Fact]
            private static void LinkedList_IterativeReversedTest()
            {
                CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
                customLinkedList.Push(1);
                customLinkedList.Push(2);
                customLinkedList.Push(3);
                customLinkedList.Head = customLinkedList.IterativeReverseList();
                CustomLinkedList<int>.Node? node = customLinkedList.Head;

                if (node.Data != 1)
                {
                    Assert.Fail("LinkedList_IterativeReversedTest failed: Head should be 1");
                    return;
                }

                node = node.Next;
                if (node.Data != 2)
                {
                    Assert.Fail("LinkedList_IterativeReversedTest failed: Head.Next should be 2");
                    return;
                }

                node = node.Next;
                if (node.Data != 3)
                {
                    Assert.Fail("LinkedList_IterativeReversedTest failed: Head.Next.Next should be 3");
                    return;
                }

                Assert.True(true, "LinkedList_IterativeReversedTest Passed.");
            }
        }

        public class RomanToIntTests
        {
            private static List<string> RomanTestValues { get; set; } = new List<string>
            {
                "I",
                "IV",
                "V",
                "IX",
                "X",
                "XL",
                "L",
                "XC",
                "C",
                "CD",
                "D",
                "CM",
                "M"
            };

            private static List<int> IntTestValues { get; set; } = new List<int>
            {
                1,
                4,
                5,
                9,
                10,
                40,
                50,
                90,
                100,
                400,
                500,
                900,
                1000
            };

            [Fact]
            public static void RunTests()
            {
                RomanToIntTest();
            }

            [Fact]
            private static void RomanToIntTest()
            {
                RomanToInt romanToInt = new RomanToInt();
                for (int i = 0; i < RomanTestValues.Count; i++)
                {
                    if (romanToInt.ConvertRomanToInt(RomanTestValues[i]) != IntTestValues[i])
                    {
                        Assert.Fail("RomanToIntTest failed: " + RomanTestValues[i] + " should be " + IntTestValues[i]);
                        return;
                    }
                }

                Assert.True(true, "RomanToIntTest Passed.");
            }

            [Fact]
            private static void IntToRomanTest()
            {
                RomanToInt romanToInt = new RomanToInt();
                for (int i = 0; i < RomanTestValues.Count; i++)
                {
                    if (romanToInt.ConvertIntToRoman(IntTestValues[i]) != RomanTestValues[i])
                    {
                        Assert.Fail("IntToRomanTest failed: " + IntTestValues[i] + " should be " + RomanTestValues[i]);
                        return;
                    }
                }

                Assert.True(true, "IntToRomanTest Passed.");
            }
        }
    }
}