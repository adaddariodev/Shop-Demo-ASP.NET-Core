using Core.Domain.Entities.Item;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User
{
    public sealed class Userx : Entity
    {
        public Userx(string name, string surnmame)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surnmame = surnmame ?? throw new ArgumentNullException(nameof(surnmame));
        }

        public string Name { get; private set; }
        public string Surnmame { get; private set; }

        private List<CatalogueItem> _catalogueItems = new List<CatalogueItem>();
        public IReadOnlyCollection<CatalogueItem> CatalogueItems => _catalogueItems.AsReadOnly();


        public Userx CreateUser(string name, string surname)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' non può essere null o vuoto.", nameof(name));

            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException($"'{nameof(surname)}' non può essere null o vuoto.", nameof(surname));

            return new Userx(name, surname);
        }

        public void AddUserCatalogueItem(CatalogueItem item)
        {
            _catalogueItems.Add(item);
        }
    }
}
