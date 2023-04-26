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
        throw new NotImplementedException();

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Contact Find(int id)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetAll()
    {
        throw new NotImplementedException();
    }

    public Contact Update(Contact contact)
    {
        throw new NotImplementedException();
    }
}
