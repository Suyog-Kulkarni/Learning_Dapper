using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public class ContactRepository : IContactRepository
{
    private IDbConnection _db;
    public ContactRepository(string connecString)
    {
        _db = new SqlConnection(connecString);// this is new 
    }

    public Contact Add(Contact contact)
    {
        var sql = "Insert into Contacts (FirstName, LastName, Email, Company, Title) Values (@FirstName, @LastName, @Email, @Company, @Title); " +
            "Select Cast(SCOPE_IDENTITY() as int)";
        var id = _db.Query<int>(sql,contact).Single();
        contact.Id = id;
        return contact;

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Contact Find(int id)
    {
       return _db.Query<Contact>("Select * from Contacts where Id = @id", new {id}).SingleOrDefault();
    }

    public List<Contact> GetAll()
    {
        return _db.Query<Contact>("Select * from Contacts").ToList();
        // this returns  
    }

    public Contact Update(Contact contact)
    {
        throw new NotImplementedException();
    }
}
