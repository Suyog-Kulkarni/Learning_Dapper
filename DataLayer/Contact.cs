/*using System.Net;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;*/

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string Title { get; set; }

    public bool IsNew => this.Id == default(int);

    public List<Address> Addresses { get; } = new List<Address>();

}
