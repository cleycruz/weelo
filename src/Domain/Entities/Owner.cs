using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Owner : AuditableEntity, IHasDomainEvent
    {      
        [Key]
        public int IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public DateTime Birthday { get; set; }
        public int Priority { get; set; }
        public int ListId { get; set; }

        //public virtual ICollection<Property> Properties { get; set; }
    
    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value == true && _done == false)
            {
                DomainEvents.Add(new OwnerCompletedEvent(this));
            }

            _done = value;
        }
    }

    public OwnersList List { get; set; } = null!;
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    
    }

