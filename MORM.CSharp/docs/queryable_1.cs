Implementing a custom LINQ provider
Jan 28, 2010

I recently read an interesting article that describes how the LINQ to SQL provider was implemented.  The article gave a pretty good description of expression trees and how they relate to IQueryable and LINQ.  I thought it might be interesting to try and implement my own LINQ provider to gain a better understanding of the LINQ technology.

LINQ to File System
I thought a pretty easy and useful example would be to implement a LINQ provider for the file system – the idea being that you specify a root path and the LINQ provider would allow you to query files and folders within this root path.

There is another very useful walkthrough on MSDN that guides the reader through the different steps for creating a LINQ provider – I used concepts from this article extensively in my implementation.

Implementing IQueryable
The first thing we need to do is to write an implementation for the *IQueryable* interface.  (In my provider I actually implemented the *IOrderedQueryable* interface, which inherits from *IQueryable*)  I also created a *FileSystemElement* class which is basically a wrapper for any file element we query.  We will see later on that we can apply filters on any property in this *FileSystemElement* class.

public class FileSystemContext : IOrderedQueryable<FileSystemElement>
{
    public FileSystemContext(string root)
    {
        Provider = new FileSystemProvider(root);
        Expression = Expression.Constant(this);
    }

    internal FileSystemContext(IQueryProvider provider, Expression expression)
    {
        Provider = provider;
        Expression = expression;
    }

    public IEnumerator<FileSystemElement> GetEnumerator()
    {
        return Provider.Execute<IEnumerable<FileSystemElement>>(Expression).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Type ElementType
    {
        get { return typeof(FileSystemElement); }
    }

    public Expression Expression { get; private set; }
    public IQueryProvider Provider { get; private set; }
}

public enum ElementType
{
    File,
    Folder
}

public abstract class FileSystemElement
{
    public string Path { get; private set; }
    public abstract ElementType ElementType { get; }

    protected FileSystemElement(string path)
    {
        Path = path;
    }
}

Implementing IQueryProvider
The next step is to implement the IQueryProvider interface – this class is responsible for creating queries and evaluating them.  At the lowest level this basically means we need to be able to create queries and then execute them. 

public class FileSystemProvider : IQueryProvider
{
    private readonly string root;

    public FileSystemProvider(string root)
    {
        this.root = root;
    }

    public IQueryable CreateQuery(Expression expression)
    {
        return new FileSystemContext(this, expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return (IQueryable<TElement>) new FileSystemContext(this, expression);
    }

    public object Execute(Expression expression)
    {
        return Execute<FileSystemElement>(expression);
    }

    public TResult Execute<TResult>(Expression expression)
    {
        var isEnumerable = (typeof(TResult).Name == "IEnumerable`1");
        return (TResult) FileSystemQueryContext.Execute(expression, isEnumerable, root);
    }
}

So far we haven’t done any real magic – we’re basically using the expression tree created by the compiler and delegating the evaluation of expressions to the FileSystemQueryContext class.

Evaluating expressions
Keep in mind that I don’t really want to manually evaluate expressions – I simply want to retrieve all files and folders from the file system and allow the user to filter on the FileSystemElement class I’m returning.  The only real work I want to do is to retrieve the files and folders and wrap them in an *IQueryable* interface. 

I also need to copy the expression tree that represents the LINQ query and make a single modification – we simply replace the data source with the concrete list of files and folders.

Luckily the walkthrough on MSDN already provides an implementation of an ExpressionVisitor class – this class basically does all the work for us.

public class FileSystemQueryContext
{
    internal static object Execute(Expression expression, bool isEnumerable, string root)
    {
        var queryableElements = GetAllFilesAndFolders(root);

        // Copy the expression tree that was passed in, changing only the first
        // argument of the innermost MethodCallExpression.
        var treeCopier = new ExpressionTreeModifier(queryableElements);
        var newExpressionTree = treeCopier.CopyAndModify(expression);

        // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods.
        if (isEnumerable)
        {
            return queryableElements.Provider.CreateQuery(newExpressionTree);
        }
        else
        {
            return queryableElements.Provider.Execute(newExpressionTree);
        }
    }

    private static IQueryable<FileSystemElement> GetAllFilesAndFolders(string root)
    {
        var list = new List<FileSystemElement>();
        foreach (var directory in Directory.GetDirectories(root))
        {
            list.Add(new FolderElement(directory));
        }
        foreach (var file in Directory.GetFiles(root))
        {
            list.Add(new FileElement(file));
        }
        return list.AsQueryable();
    }
}

Here is the method where I look for a call to the FileSystemContext class – which I replace with the list of files and folders.

protected override Expression VisitConstant(ConstantExpression c)
{
    // Replace the constant FileSystemContext arg with the queryable fileSystemElements.
    if (c.Type == typeof(FileSystemContext))
    {
        return Expression.Constant(fileSystemElements);
    }
    else
    {
        return c;
    }
}

Using the new provider
The following is an example of kind of query we can write with this provider.

var query = from element in new FileSystemContext(@"C:\Downloads")
            where element.ElementType == ElementType.File && element.Path.EndsWith(".zip")
            orderby element.Path ascending
            select element;

Which is actually quite cool.  When I started this exercise I thought that it would actually be a lot more work – granted, I’m delegating most of the work to the underlying technology, but still – it was easier than I thought.

By the way, keep in mind I wrote this provider as an example – you would be absolutely nuts to actually write a LINQ provider for this kind of file access.  The following code does pretty much the same as my implementation, minus any of the hard work.

var files = from file in new DirectoryInfo(@"C:\Downloads").GetFiles()
            where file.Extension == "zip"
            select file;
            
Happy coding.