using System.ComponentModel;

namespace InfoSoftAdmin.Models;

public class Customer
{
    public Guid Id { get; set; }
    
    [DisplayName("Nome")]
    public string Name { get; set; }
    public string Email { get; set; }
    
    [DisplayName("Telefone")]
    public string Phone { get; set; }
}