using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Models
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
