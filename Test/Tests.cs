using System.Linq;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    public class Tests : IStoreable
    {
        public IComparable Id { get; set; }


        [Test]
        public void Testing_Saving_NewItem()
        {
            Repository<Tests> repository = new Repository<Tests>();
            Tests newItemToBeSaved = new Tests { Id = 1 };
            repository.Save(newItemToBeSaved);
            IEnumerable<Tests> expected = repository.All();
            Assert.IsTrue(expected.Contains(newItemToBeSaved));
        }

        [Test]
        public void Testing_A_List_Returns_IEnumberable_CorrectType()
        {
            Repository<Tests> repository = new Repository<Tests>();
            IEnumerable<Tests> expected = repository.All();
            Assert.IsInstanceOf<IEnumerable<Tests>>(expected);
        }

        [Test]
        public void Testing_Deleting_An_Existing_Item()
        {
            Repository<Tests> repository = new Repository<Tests>();
            Tests ExistingItem = new Tests { Id = 1 };
            repository.Save(ExistingItem);
            repository.Delete(1);
            IEnumerable<Tests> expected = repository.All();
            Assert.IsFalse(expected.Contains(ExistingItem));
        }

        [Test]
        public void Testing_Find_By_Id()
        {
            Repository<Tests> repository = new Repository<Tests>();
            Tests Item1 = new Tests { Id = 452 };
            Tests Item2 = new Tests { Id = 555 };
            Tests Item3 = new Tests { Id = 57 };
            Tests Item4 = new Tests { Id = 8883 };
            Tests Item5 = new Tests { Id = 473 };
            Tests Item6 = new Tests { Id = 3623 };
            Tests Item7 = new Tests { Id = 25523 };
            Tests Item8 = new Tests { Id = 4243 };

            repository.Save(Item1);
            repository.Save(Item2);
            repository.Save(Item3);
            repository.Save(Item4);
            repository.Save(Item5);
            repository.Save(Item6);
            repository.Save(Item7);

            Tests expected = repository.FindById(8883);

            Assert.AreEqual(Item4, expected);
        }
    }
}