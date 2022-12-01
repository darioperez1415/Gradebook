using System; 
using Xunit;
using GradeBook;

namespace Gradebook.Test
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTest
    {
        int count = 0; 
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)

        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)

        {
            count++;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            
            Assert.Equal(42,x);
        }

    private void SetInt(ref Int32 z)
    {
      z = 42;
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
            public void CSharpCanPassByRef()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1,"New Name");

        Assert.Equal("New Name",book1.Name);
        
        }

    private void GetBookSetName(ref InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
      book.Name = name;
    }
        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Dario";
            var upper = MakeUpperCase(name);

            Assert.Equal("Dario",name);
            Assert.Equal("DARIO",upper);
        }

    private string MakeUpperCase(string parameter)
    {
      return parameter.ToUpper();
    }

    [Fact]
            public void CSharpIsPassByValue()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        GetBookSetName(book1,"New Name");

        Assert.Equal("Book 1",book1.Name);
        
        }

    private void GetBookSetName(InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
      book.Name = name;
    }
        [Fact]
            public void CanSetNameFromReference()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        SetName(book1,"New Name");

        Assert.Equal("New Name",book1.Name);
        
        }

    private void SetName(InMemoryBook book, string name)
    {
      book.Name = name;
    }

    [Fact]
            public void GetBookReturnsDifferentObject()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1",book1.Name);
        Assert.Equal("Book 2",book2.Name);
        Assert.NotSame(book1,book2);
        
        }
    [Fact]
            public void TowVarsCanRefrenceSameObject()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1,book2);
        Assert.True(Object.ReferenceEquals(book1,book2));
        
        }
    InMemoryBook GetBook(string name)
    {
      return new InMemoryBook(name);
    }
  }
}
