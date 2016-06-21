﻿
using VirtoCommerce.Platform.Core.Common;
namespace VirtoCommerce.Domain.Catalog.Model
{
	public class CategoryLink : ValueObject<CategoryLink>
    {
		public string CatalogId { get; set; }
		public Catalog Catalog { get; set; }
        public string CategoryId { get; set; }
		public Category Category { get; set; }
    }
}
