// See https://aka.ms/new-console-template for more information
using LeetCodeExamples;

CustomLinkedList<int> linkedList = new CustomLinkedList<int>();
linkedList.Push(1);
linkedList.Push(2);
linkedList.Push(3);
linkedList.Push(4);

Console.WriteLine($"Current List: {linkedList.PrintLinkedList()}");
Console.WriteLine();

linkedList.Head = linkedList.IterativeReverseList();
Console.WriteLine($"Iterative Reversal: {linkedList.PrintLinkedList()}");

Console.WriteLine($"Get Value at Index 1: {linkedList.GetIndex(1).Data}");


linkedList.Head = linkedList.RecursiveReverseLinkedList(linkedList.Head);
Console.WriteLine($"Recursive Reversal: {linkedList.PrintLinkedList()}");

Console.WriteLine($"Get Value at Index 1: {linkedList.GetIndex(1).Data}");

linkedList.Head = linkedList.StackReverseLinkedList();
Console.WriteLine($"Recursive Reversal: {linkedList.PrintLinkedList()}");

Console.WriteLine($"Get Value at Index 1: {linkedList.GetIndex(1).Data}");

Console.WriteLine($"(Iterative) Does Value 4 Exist? {linkedList.ExistsInLinkedList(4)}");
Console.WriteLine($"(Iterative) Does Value 9 Exist? {linkedList.ExistsInLinkedList(4)}");

Console.WriteLine($"(Recursive) Does Value 3 Exist? {linkedList.ExistsInLinkedListRecursive(3)}");
Console.WriteLine($"(Recursive) Does Value 10 Exist? {linkedList.ExistsInLinkedListRecursive(10)}");

Console.WriteLine("Complete");