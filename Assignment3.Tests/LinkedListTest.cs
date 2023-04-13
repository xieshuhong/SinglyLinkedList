using Assignment3.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{

    public class LinkedListTest
    {
        private SinglyLinkedList userList;
        [SetUp]
        public void Setup()
        {
            userList = new SinglyLinkedList();
        }

        [TearDown]
        public void TearDown()
        {
            userList.Clear();
        }

        // the linked list empty testing
        [Test]
        public void TestEmptyList()
        {
            Assert.IsTrue(userList.IsEmpty());
            Assert.AreEqual(0, userList.Count());
        }

        // an item is prepended
        [Test]
        public void TestPrepended()
        {
            User user1 = new User(1, "John", "john@example.com", "password1");
            User user2 = new User(2, "Jane", "jane@example.com", "password2");
            userList.AddFirst(user1);
            userList.AddFirst(user2);
            Assert.AreEqual(user2, userList.Head.data);
            Assert.AreEqual(user1, userList.Head.next.data);
        }

        // An item is appended
        [Test]
        public void TestAppended()
        {
            User user1 = new User(1, "Jane Doe", "Jane@example.com", "password1");
            User user2 = new User(2, "Joe Schmoe", "Joe@example.com", "password2");
            userList.Add(user1, 0);
            userList.Add(user2, 1);
            Assert.AreEqual(2, userList.Count());
            Assert.AreEqual(user1, userList.GetValue(0));
            Assert.AreEqual(user2, userList.GetValue(1));
        }

        // An item is inserted at index.
        [Test]
        public void TestInsertedAtIndex()
        {
            User user1 = new User(1, "Sam Sammerson", "Sam@example.com", "password1");
            User user2 = new User(2, "Dave Daverson", "Sam@example.com", "password2");
            userList.AddFirst(user1);
            userList.Add(user2, 1);
            Assert.AreEqual(user2, userList.GetValue(1));
            Assert.IsFalse(userList.IsEmpty());
        }

        // An item is replaced
        [Test]
        public void TestReplacing()
        {
            User user1 = new User(1, "Jane Doe", "Jane@example.com", "password1");
            User user2 = new User(2, "Dave Daverson", "Sam@example.com", "password2");
            userList.AddFirst(user1);
            userList.Replace(user2, 0);
            Assert.AreEqual(user2, userList.GetValue(0));
        }

        // An item is deleted from beginning of list.
        [Test]
        public void TestDeleteFirst()
        {
            User user1 = new User(1, "Sam Sammerson", "Sam@example.com", "password1");
            userList.AddFirst(user1);
            userList.RemoveFirst();
            Assert.IsTrue(userList.IsEmpty());
        }

        // An item is deleted from end of list
        [Test]
        public void TestDeleteLast()
        {
            User user1 = new User(1, "Jane Doe", "Jane@example.com", "password1");
            User user2 = new User(2, "Dave Daverson", "Sam@example.com", "password2");
            userList.AddFirst(user1);
            userList.AddLast(user2);
            userList.RemoveLast();
            Assert.AreEqual(user1, userList.GetValue(0));
        }

        // An item is deleted from middle of list
        [Test]
        public void TestDeleteFromMiddle()
        {
            User user1 = new User(1, "Sam Sammerson", "Sam@example.com", "password1");
            User user2 = new User(1, "Jane Doe", "Jane@example.com", "password1");
            User user3 = new User(2, "Dave Daverson", "Sam@example.com", "password2");
            userList.Add(user1, 0);
            userList.Add(user2, 1);
            userList.Add(user3, 2);
            userList.Remove(1);
            Assert.That(userList.GetValue(1), Is.EqualTo(user3));
        }

        // An existing item is found and retrieved.
        [Test]
        public void TestFindAndRetrieved()
        {
            User user1 = new User(0, "Sam Sammerson", "Sam@example.com", "password1");
            User user2 = new User(1, "Jane Doe", "Jane@example.com", "password1");
            User user3 = new User(2, "Dave Daverson", "Sam@example.com", "password2");
            userList.Add(user1, 0);
            userList.Add(user2, 1);
            userList.Add(user3, 2);
            Assert.IsTrue(userList.Contains(user1));
            Assert.AreEqual(1, userList.IndexOf(user2));
        }

        // The additional functionality is working
        [Test]
        public void TestAdditionalFunctionality()
        {
            User user1 = new User(0, "Sam Sammerson", "Sam@example.com", "password1");
            User user2 = new User(1, "Dave Daverson", "Sam@example.com", "password2");
            User user3 = new User(2, "Jane Doe", "Jane@example.com", "password1");
            userList.Add(user1, 0);
            userList.Add(user2, 1);
            userList.Add(user3, 2);
            // Reverse
            userList.Reverse();
            Assert.AreEqual(user3, userList.GetValue(0));
            Assert.AreEqual(user2, userList.GetValue(1));
            Assert.AreEqual(user1, userList.GetValue(2));
        }
    }

}
