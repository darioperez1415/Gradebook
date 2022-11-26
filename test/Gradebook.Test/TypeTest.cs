using System; 
using Xunit;
using GradeBook;

namespace Gradebook.Test
{
public class TypeTest
    {  
        [Fact]
            public void CSharpCanPassByRef()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1,"New Name");

        Assert.Equal("New Name",book1.Name);
        
        }

    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
      book.Name = name;
    }
        [Fact]
            public void CSharpIsPassByValue()
        {   
        // arrange
        var book1 = GetBook("Book 1");
        GetBookSetName(book1,"New Name");

        Assert.Equal("Book 1",book1.Name);
        
        }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name);
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

    private void SetName(Book book, string name)
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
    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
