using Core.Domain.Entities.User;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Item
{
    public sealed class CatalogueItem : Entity
    {
        public CatalogueItem(string name, string description, double price, string imagePath, string user)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price;
            ImagePath = imagePath ?? throw new ArgumentNullException(nameof(imagePath));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public string ImagePath { get; private set; }
        public string User { get; set; }
    }
}
